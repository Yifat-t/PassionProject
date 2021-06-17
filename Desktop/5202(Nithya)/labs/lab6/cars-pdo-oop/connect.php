<?php

$dbname = "phpdb";  //host name
$user = "root";  //user name
$pass = ""; //password

$dsn ="mysql:host=localhost;dbname=$dbname"; //the type of data base we are connecting too , which is my sql
$dbcon = new PDO ($dsn, $user, $pass);  //describing our connection
$dbcon->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION); //TURNING ON ERROR MODE FOR SQL
$sql = "Select * FROM cars";    //sql statement

$pdostm = $dbcon->prepare($sql);    // calling prepare method and execute the statement using pdo connection object which will return an object.
//$pdostm->setFetchMode(PDO::FETCH_ASSOC); //fetch as associative array and it becomes a key
$pdostm->setFetchMode(PDO::FETCH_OBJ); //fetch as an object and all fields become property
$pdostm->execute();    //this will execute the statement

//var_dump($pdostm->fetchAll());

foreach($pdostm as $car){
    echo "<li>" . $car->model . "</li>";
}
//foreach($pdostm as $car){                            syntax when choosing FETCH_ASSOC, need to receive as a key
//    echo "<li>" . $car['model'] . "</li>";
//}

