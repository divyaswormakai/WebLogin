<?php
	$db = mysql_connect('localhost', 'flash-quiz-kuce', 'FlashQuiz12') or die('Could not connect: ' . mysql_error());
	mysql_select_db('flash-quiz-kuce') or die('Could not select database');

	// Strings must be escaped to prevent SQL injection attack.
	$userName = mysql_real_escape_string($_GET['username'], $db);
	$pw = mysql_real_escape_string($_GET['pw'], $db);

	$query  = "select * from users where user_name='$userName' and password='$pw'";
	$result = mysql_query($query) or die('Query failed: ' . mysql_error());
	$num_results = mysql_num_rows($result);


	for($i = 0; $i < $num_results; $i++)
	{
		$row = mysql_fetch_array($result);
		echo $row['id']";";
	}

?>