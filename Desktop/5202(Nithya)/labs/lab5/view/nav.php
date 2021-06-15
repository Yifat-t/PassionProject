<?php
$navlinks = array("My GitHub", "About", "Home");
echo '<ul>';
//print_r($array);
foreach($navlinks as $key=>$value){
    echo '<li><a href="'.$value.'.php">'.$value.'</a><li>';
}
echo '</ul>';
//$last_normal = array_pop(array_keys($navlinks));
?>

