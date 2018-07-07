<?php 
	
	include 'c_config.php';
	$link->set_charset("utf8");
	
	$ipAddress = $_SERVER['REMOTE_ADDR'];

	date_default_timezone_set('Asia/Tbilisi');
	$dateTime = date('Y-m-d H:i:s');
	
	$registrationDate = $dateTime;
	$c_name = $_POST['c_name'];
	$c_email = $_POST['c_email'];
	$c_message = $_POST['c_message'];
	
	$query = "INSERT INTO OrderInfos (IPAddress, RegistrationDate, Name, Email, Message) VALUES ('".$ipAddress."','".$registrationDate."','".$c_name."','".$c_email."','".$c_message."')" or die("Error in the consult.." . mysqli_error($link));
	
	$result = $link->query($query); 
	
?>