<?php

class studentDetails extends student {
    private $aveGrades;
    private $courses;

    public function __construct($fname, $lname, $age, $seniority, $aveGrades, array $courses)
    {
        parent::__construct($fname, $lname, $age, $seniority);
        $this->aveGrades = $aveGrades;
        $this->courses = $courses;
    }

    public function displayDeveloperCourses(){

        return $this->displayStudentName()  . ' is taking the following courses ' . implode(', ' , $this->courses);
    }
}






