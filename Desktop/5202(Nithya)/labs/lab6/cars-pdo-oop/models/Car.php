<?php

class Car
{
    public function getYears($db){
        $query = "SELECT DISTINCT year FROM cars";
        $pdostm = $db->prepare($query);
        $pdostm->execute();

        //fetch all result
        $results = $pdostm->fetchAll(PDO::FETCH_OBJ);
        return $results;
    }
    public function getCarsInYear($db, $year){
        $query = "SELECT * FROM cars WHERE year= :year";
        $pdostm = $db->prepare($query);
        $pdostm->bindValue(':year', $year, PDO::PARAM_STR);
        $pdostm->execute();
        $s = $pdostm->fetchAll(PDO::FETCH_OBJ);
        return $s;
    }
    public function getCarById($id, $db){
        $sql = "SELECT * FROM cars where id = :id";
        $pst = $db->prepare($sql);
        $pst->bindParam(':id', $id);
        $pst->execute();
        return $pst->fetch(PDO::FETCH_OBJ);
    }
    public function getAllCars($dbcon){


        $sql = "SELECT * FROM cars";
        $pdostm = $dbcon->prepare($sql);
        $pdostm->execute();

        $cars = $pdostm->fetchAll(PDO::FETCH_OBJ);
        return $cars;
    }

    public function addCar($make, $model, $year, $db)
    {
        $sql = "INSERT INTO cars (make, model, year) 
              VALUES (:make, :model, :year) ";
        $pst = $db->prepare($sql);

        $pst->bindParam(':make', $make);
        $pst->bindParam(':model', $model);
        $pst->bindParam(':year', $year);

        $count = $pst->execute();
        return $count;
    }

    public function deleteCar($id, $db){
        $sql = "DELETE FROM cars WHERE id = :id";

        $pst = $db->prepare($sql);
        $pst->bindParam(':id', $id);
        $count = $pst->execute();
        return $count;

    }

    public function updateCar($id, $make, $model, $year, $db){
        $sql = "Update cars
                set make = :make,
                model = :model,
                year = :year
                WHERE id = :id
        
        ";

        $pst =  $db->prepare($sql);

        $pst->bindParam(':make', $make);
        $pst->bindParam(':model', $model);
        $pst->bindParam(':year', $year);
        $pst->bindParam(':id', $id);

        $count = $pst->execute();

        return $count;
    }
}
