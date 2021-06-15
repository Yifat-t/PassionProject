<?php

class Student {
    private $fname;
    private $lname;
	private $age;
    private $seniority;

    const FRESHMAN = 'fr';
    const SOPHOMORE = 'so';
    const JUNIOR = 'ju';
	const SENIOR = 'se';


    public function __construct($fname, $lname, $age, $seniority){
        $this->fname = $fname;
        $this->lname = $lname;
        $this->age = $age;
		$this->setSeniority($seniority);

    }

    public function displayStudentName(){
        return $this->fname ." ". $this->lname;
    }

    public function setSeniority($value){
       if($value == self::FRESHMAN || $value == self::SOPHOMORE || $value == self::JUNIOR || $value == self::SENIOR) {
          return $this->seniority = $value;
       }
    }
    public function setFirstName($value){
        $this->fname = $value;
    }
    public function getFirstName(){
        return $this->fname;
    }
	public function setLastName($value){
        $this->fname = $value;
    }
    public function getLastName(){
        return $this->fname;
    }

    public function setAge($value){
        if($value >= 14){
            $this->age = $value;
        }

    }
    public function getAge(){
        return $this->age;
    }

}