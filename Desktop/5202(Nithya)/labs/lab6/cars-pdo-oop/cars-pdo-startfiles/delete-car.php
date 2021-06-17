<?php
require_once '../models/Database.php';
require_once '../models/Car.php';

if(isset($_POST['id'])){
    $id = $_POST['id'];
    $db = Database::getDb();

    $s = new Car();
    $count = $s->deleteCar($id, $db);
    if($count){
        header("Location: list-cars.php");
    }
    else {
        echo " problem deleting";
    }


}
