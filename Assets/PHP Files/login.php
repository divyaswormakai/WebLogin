<?php

	$db = mysqli_connect('localhost', 'id9699148_flashquiz', 'flashquiz2019','id9699148_flashquizkuce') or die('Could not connect: ' . mysql_error());

	// Strings must be escaped to prevent SQL injection attack.
	$userName = $_GET['username'];
	$pw = $_GET['pw'];
	
	if(is_null($userName) || is_null($pw)){
		echo "NULL";
	}
	else{
		$userName = mysqli_real_escape_string($db,$_GET['username']);
		$pw = mysqli_real_escape_string($db,$_GET['pw']);
		
		$query  = "select * from users where user_name='$userName' and pw='$pw'";
		echo $query;
		$result = mysqli_query($db,$query);
		if($row=mysqli_fetch_assoc($result)){
			echo $row['email'];
		}
		else{
			echo "NO RES";
		}
		
	}
	
?>