﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Diagnostics;
using passionP.Models;
using passionP.Models.ViewModels;
using System.Web.Script.Serialization;

namespace passionP.Controllers
{
    public class ProductController : Controller
    {
        private static readonly HttpClient client;
        private JavaScriptSerializer jss = new JavaScriptSerializer();

        static ProductController()
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                AllowAutoRedirect = false,
                //cookies are manually set in RequestHeader
                UseCookies = false
            };

        
            client = new HttpClient(handler);
            client.BaseAddress = new Uri("https://localhost:44330/api/");
        }

        private void GetApplicationCookie()
        {
            string token = "";
            client.DefaultRequestHeaders.Remove("Cookie");
            if (!User.Identity.IsAuthenticated) return;

            HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies.Get(".AspNet.ApplicationCookie");
            if (cookie != null) token = cookie.Value;

            Debug.WriteLine("Token Submitted is : " + token);
            if (token != "") client.DefaultRequestHeaders.Add("Cookie", ".AspNet.ApplicationCookie=" + token);

            return;

        }



        // GET: Product/List
        public ActionResult List(string SearchKey = null)
        {
            //objective: communicate with our product data api to retrive a list of products 
            //curl https://localhost:44330/api/productdata/listproducts

            string url = "productdata/listproducts";

            if (SearchKey != null)
            {
                url += "?SearchKey=" + SearchKey;
            }
            HttpResponseMessage response = client.GetAsync(url).Result;

            //Debug.WriteLine("The response code is");
            //Debug.WriteLine(response.StatusCode);

            IEnumerable<ProductDto> products = response.Content.ReadAsAsync<IEnumerable<ProductDto>>().Result;
            //Debug.WriteLine("Number of products received: ");
            //Debug.WriteLine(products.Count());

            return View(products);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            DetailsProduct ViewModel = new DetailsProduct();


            //objective: communicate with our product data api to retrive one product.
            //curl https://localhost:44330/api/productdata/findproduct/{id}

            string url = "productdata/findproduct/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;

            //Debug.WriteLine("The response code is");
            //Debug.WriteLine(response.StatusCode);

            ProductDto SelectedProduct = response.Content.ReadAsAsync<ProductDto>().Result;
            //Debug.WriteLine("product received: ");
            //Debug.WriteLine(SelectedProduct.ProductName);

            ViewModel.SelectedProduct = SelectedProduct;


            url = "retailerdata/listretailersforproduct/" + id;
            response = client.GetAsync(url).Result;
            IEnumerable<RetailerProductDto> ResponsibleRetailers = response.Content.ReadAsAsync<IEnumerable<RetailerProductDto>>().Result;

            ViewModel.ResponsibleRetailers = ResponsibleRetailers;

            url = "retailerdata/listretailersnotsellingthisproduct/" + id;
            response = client.GetAsync(url).Result;
            IEnumerable<RetailerDto> AvailableRetailers = response.Content.ReadAsAsync<IEnumerable<RetailerDto>>().Result;

            ViewModel.AvailableRetailers = AvailableRetailers;

            return View(ViewModel);
        }

        //POST: Product/Associate/{productid}
        [HttpPost]
        [Authorize]
        public ActionResult Associate(int id, int RetailerID)
        {
            GetApplicationCookie();
            Debug.WriteLine("Attempting to associate product :" + id + " with retailer " + RetailerID);

            //call our api to associate product with retailer
            string url = "productdata/associateproductwithretailer/" + id + "/" + RetailerID;
            HttpContent content = new StringContent("");
            content.Headers.ContentType.MediaType = "application/json";
            HttpResponseMessage response = client.PostAsync(url, content).Result;

            return RedirectToAction("Details/" + id);
        }


        //Get: Product/UnAssociate/{id}?RetailerID={retailerID}
        [HttpGet]
        [Authorize]
        public ActionResult UnAssociate(int id, int RetailerID)
        {
            GetApplicationCookie();
            Debug.WriteLine("Attempting to unassociate product :" + id + " with retailer: " + RetailerID);

            //call our api to associate product with retailer
            string url = "productdata/unassociateproductwithretailer/" + id + "/" + RetailerID;
            HttpContent content = new StringContent("");
            content.Headers.ContentType.MediaType = "application/json";
            HttpResponseMessage response = client.PostAsync(url, content).Result;

            return RedirectToAction("Details/" + id);
        }

        public ActionResult Error()
        {
            return View();
        }

        // GET: Product/New
        [Authorize]
        public ActionResult New()
        {
            //information about all brands in the system.
            //Get api/barnddata/listbrands

            string url = "branddata/listbrands";
            HttpResponseMessage response = client.GetAsync(url).Result;
            IEnumerable<BrandDto> BrandOptions = response.Content.ReadAsAsync<IEnumerable<BrandDto>>().Result;

            return View(BrandOptions);
        }

        // POST: Product/Create
        [HttpPost]
        [Authorize]
        public ActionResult Create(Product product)
        {
            GetApplicationCookie();
            Debug.WriteLine("the json payload is : ");
            //objective: add a new product into our system using api
            //curl -H "Content-type:application/json -d @product.json https://localhost:44330/api/productdata/addproduct
            string url = "productdata/addproduct";


            string jsonpayload = jss.Serialize(product);

            Debug.WriteLine(jsonpayload);

            HttpContent content = new StringContent(jsonpayload);
            content.Headers.ContentType.MediaType = "application/json";

            HttpResponseMessage response = client.PostAsync(url, content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Error");
            }


        }

        // GET: Product/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            UpdateProduct ViewModel = new UpdateProduct();

            //the existing product information
            string url = "productdata/findproduct/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            ProductDto SelectedProduct = response.Content.ReadAsAsync<ProductDto>().Result;
            ViewModel.SelectedProduct = SelectedProduct;

            // all brands to choose from when updating this product
            //the existing product information
            url = "branddata/listbrands";
            response = client.GetAsync(url).Result;
            IEnumerable<BrandDto> BrandOptions = response.Content.ReadAsAsync<IEnumerable<BrandDto>>().Result;

            ViewModel.BrandOptions = BrandOptions;

            url = "retailerdata/listretailersnotsellingthisproduct/" + id;
            response = client.GetAsync(url).Result;
            IEnumerable<RetailerDto> AvailableRetailers = response.Content.ReadAsAsync<IEnumerable<RetailerDto>>().Result;

            ViewModel.AvailableRetailers = AvailableRetailers;

            return View(ViewModel);
        }

        // POST: Product/Update/5
        [HttpPost]
        [Authorize]
        public ActionResult Update(int id, Product product, HttpPostedFileBase ProductPic)
        {
            GetApplicationCookie();
            string url = "productdata/updateproduct/" + id;
            string jsonpayload = jss.Serialize(product);
            HttpContent content = new StringContent(jsonpayload);
            content.Headers.ContentType.MediaType = "application/json";
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            Debug.WriteLine(content);
            //update request is successful for image data
            if (response.IsSuccessStatusCode && ProductPic != null)
            {
                //Updating the product picture as a separate request
                Debug.WriteLine("Calling Update Image method.");
                //Send over image data for player
                url = "ProductData/UploadProductPic/" + id;
                //Debug.WriteLine("Received Product Picture "+ProductPic.FileName);

                MultipartFormDataContent requestcontent = new MultipartFormDataContent();
                HttpContent imagecontent = new StreamContent(ProductPic.InputStream);
                requestcontent.Add(imagecontent, "ProductPic", ProductPic.FileName);
                response = client.PostAsync(url, requestcontent).Result;

                return RedirectToAction("List");
            }
            else if (response.IsSuccessStatusCode)
            {
                //No image upload, but update still successful
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        // GET: Product/Delete/5
        [Authorize]
        public ActionResult DeleteConfirm(int id)
        {
            string url = "productdata/findproduct/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            ProductDto selectedproduct = response.Content.ReadAsAsync<ProductDto>().Result;
            return View(selectedproduct);
        }

        // POST: Product/Delete/5
        [HttpPost]
        [Authorize]
        public ActionResult Delete(int id)
        {
            GetApplicationCookie();
            string url = "productdata/deleteproduct/" + id;
            HttpContent content = new StringContent("");
            content.Headers.ContentType.MediaType = "application/json";
            HttpResponseMessage response = client.PostAsync(url, content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }
    }
}

