<?php

	$db = mysqli_connect('localhost', 'id9699148_flashquiz', 'flashquiz2019','id9699148_flashquizkuce') or die('Could not connect: ' . mysql_error($db));

	// Strings must be escaped to prevent SQL injection attack.
	$userName = mysqli_real_escape_string($db,$_GET['username']);
	$email = mysqli_real_escape_string($db,$_GET['email']);
	$pw = mysqli_real_escape_string($db,$_GET['pw']);
	if(is_null($userName) || is_null($email) || is_null($pw)){
		echo "Null";
	}
	else{
		$query  = "insert into users(user_name,email,pw) values('$userName','$email','$pw')";
		$result = mysqli_query($db,$query) or die('Query failed: ' . mysqli_error($db));
	}
?>