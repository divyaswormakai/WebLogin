using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Experimental.Networking;
using UnityEngine.Networking;

public class Login : MonoBehaviour
{
    public TMP_InputField username,password;
    public TextMeshProUGUI errorTxt;
    string LoginUrl = "flash-quiz-kuce.bplaced.net/login.php?";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UserLogin()
    {
        StartCoroutine(WebConnect());
    }
    IEnumerator WebConnect()
    {
        string userName = username.text;
        string pw = password.text;
        string postURL = LoginUrl + "username=" + userName + "&pw=" + pw;

        UnityWebRequest userId = UnityWebRequest.Get("http://" + postURL);
        Debug.Log(postURL);
        yield return userId; // Wait until the download is done

        if (userId.error != null)
        {
            print("There was an error loggingin: " + userId.error);
            errorTxt.text="Account was not found";

        }
        else
        {
            errorTxt.text = "Welcome userID = "+userId.responseCode;
        }
    }
}
