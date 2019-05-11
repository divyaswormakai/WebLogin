<?php
	$db = mysql_connect('localhost', 'flash-quiz-kuce', 'FlashQuiz12') or die('Could not connect: ' . mysql_error());
	mysql_select_db('flash-quiz-kuce') or die('Could not select database');

	// Strings must be escaped to prevent SQL injection attack.
	$userName = mysql_real_escape_string($_GET['username'], $db);
	$email = mysqli_real_escape_string($_GET['email'],$db);
	$pw = mysql_real_escape_string($_GET['pw'], $db);

	$query  = "insert into users(user_name,email,password) values('$userName','$email','$pw'";
	$result = mysql_query($query) or die('Query failed: ' . mysql_error());
?>