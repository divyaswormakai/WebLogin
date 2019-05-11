/*using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HSController : MonoBehaviour
{
	private static HSController instance6;
	
	public static HSController Instance
	{
		get { return instance6; }
	}
	void Awake() {
		
		DontDestroyOnLoad (gameObject);
		// If no Player ever existed, we are it.
		if (instance6 == null)
			instance6 = this;
		// If one already exist, it's because it came from another level.
		else if (instance6 != this) {
			Destroy (gameObject);
			return;
		}


	}
	void Start(){
		//startGetScores ();
		//startPostScores ();

		//
		//HSController.Instance.startGetScores ();
	}

	private string secretKey = "123456789"; // Edit this value and make sure it's the same as the one stored on the server
	string addScoreURL = "tutorial.bplaced.net/addscore.php?"; //be sure to add a ? to your url
	string highscoreURL = "tutorial.bplaced.net/display.php";

	//for testing
	public string uniqueID;
	public string name3;
	int score;


	public string[] onlineHighscore;

	public void startGetScores()
	{
		StartCoroutine(GetScores());
	}

	public void startPostScores()
	{	
		StartCoroutine(PostScores());
	}

	//set actual values before posting score
	
	
	// remember to use StartCoroutine when calling this function!
	IEnumerator PostScores()
	{
		updateOnlineHighscoreData ();
		//This connects to a server side php script that will add the name and score to a MySQL DB.
		// Supply it with a string representing the players name and the players score.
		string hash = Md5Sum(name3 + score + secretKey);
		//string post_url = addScoreURL + "name=" + WWW.EscapeURL(name) + "&score=" + score + "&hash=" + hash;
		string post_url = addScoreURL + "uniqueID=" + uniqueID+ "&name=" + WWW.EscapeURL (name3) + "&score=" + score+ "&hash=" + hash;
		//Debug.Log ("post url " + post_url);
		// Post the URL to the site and create a download object to get the result.
		WWW hs_post = new WWW("http://"+post_url);
		yield return hs_post; // Wait until the download is done
		
		if (hs_post.error != null)
		{
			print("There was an error posting the high score: " + hs_post.error);
		}
	}
	
	// Get the scores from the MySQL DB to display in a GUIText.
	// remember to use StartCoroutine when calling this function!
	IEnumerator GetScores()
	{


		Scrolllist.Instance.loading = true;

		WWW hs_get = new WWW("http://"+highscoreURL);

		yield return hs_get;
		
		if (hs_get.error != null)
		{
			//Debug.Log("There was an error getting the high score: " + hs_get.error);

		}
		else
		{

			//Change .text into string to use Substring and Split
			string help = hs_get.text;

			//help= help.Substring(5, hs_get.text.Length-5);
			//200 is maximum length of highscore - 100 Positions (name+score)

			onlineHighscore  = help.Split(";"[0]);

		}
		Scrolllist.Instance.loading = false;
		Scrolllist.Instance.getScrollEntrys ();
	}
	
}*/