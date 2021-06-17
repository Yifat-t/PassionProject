<?php
require_once '../models/Database.php';
require_once '../models/Car.php';

$make = $model = $year = "";

if(isset($_POST['updateCar'])){
    $id= $_POST['id'];
    $db = Database::getDb();

    $s = new Car();
    $car = $s->getCarById($id, $db);

    $make =  $car->make;
    $model = $car->model;
    $year = $car->year;


}
if(isset($_POST['updCar'])){
    $id= $_POST['cid'];
    $make = $_POST['make'];
    $model = $_POST['model'];
    $year = $_POST['year'];

    $db = Database::getDb();
    $s = new Car();
    $count = $s->updateCar($id, $make, $model, $year, $db);

    if($count){
        header('Location:  list-cars.php');
    } else {
        echo "problem";
    }
}


?>

<html lang="en">

<head>
    <title>Add Car - Car Management System</title>
    <meta name="description" content="Car Management System">
    <meta name="keywords" content="Car, College, Admission, Humber">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <link rel="stylesheet" href="CSS/main.css" type="text/css">
</head>

<body>

<div>
    <!--    Form to Update  Car -->
    <form action="" method="post">
        <input type="hidden" name="cid" value="<?= $id; ?>" />
        <div class="form-group">
            <label for="make">Make :</label>
            <input type="text" class="form-control" name="make" id="make" value="<?= $make; ?>"
                   placeholder="Enter Maker">
            <span style="color: red">

            </span>
        </div>
        <div class="form-group">
            <label for="model">Model :</label>
            <input type="text" class="form-control" id="model" name="model"
                   value="<?= $model; ?>" placeholder="Enter model">
            <span style="color: red">

            </span>
        </div>
        <div class="form-group">
            <label for="year">Year :</label>
            <input type="text" class="form-control" id="year" name="year"
                   value="<?= $year; ?>"  placeholder="Enter year">
            <span style="color: red">

            </span>
        </div>
        <a href="./list-cars.php" id="btn_back" class="btn btn-success float-left">Back</a>
        <button type="submit" name="updCar"
                class="btn btn-primary float-right" id="btn-submit">
            Update Car
        </button>
    </form>
</div>


</body>
</html>
