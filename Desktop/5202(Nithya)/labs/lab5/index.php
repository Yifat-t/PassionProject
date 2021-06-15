<!DOCTYPE html>
<html lang="en">
<head>
    <title>lab5</title>
    <link rel="stylesheet" type="text/css" href="styles/style.css">
</head>
<body>
<?php
include 'view/header.php';
?>

<main>
 <?php
require_once 'library/student.php';
require_once 'library/studentDetails.php';


$u = new Student('Yifat', 'Tshuva', 14, 'ju');

$u->setFirstName('Alex');
$u->setSeniority(Student::JUNIOR);

$d = new studentDetails('Yifat', 'Tshuva', 14, 'ju', 80, ['english', 'math', 'science']);
echo  $d->displayDeveloperCourses();
 ?>
</main>
<footer>
    <?php
    include 'view/footer.php';
    ?>
</footer>
</body>

</html>