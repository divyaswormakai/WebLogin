using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Experimental.Networking;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Register : MonoBehaviour
{
    public TMP_InputField username, email, pw, pw2;
    public TextMeshProUGUI errorTxt;
    string RegisterUrl = "flash-quiz-kuce.bplaced.net/register.php?";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RegisterUser()
    {
        StartCoroutine(RegisterConnect());
    }

    IEnumerator RegisterConnect()
    {
        string usernameStr = username.text;
        string emailStr = email.text;
        string pwStr = pw.text;
        string pw2Str = pw2.text;

        if (pwStr == pw2Str)
        {
            string postURL = RegisterUrl + "username=" + usernameStr + "&pw=" + pwStr + "&email="+emailStr;

            UnityWebRequest userId = UnityWebRequest.Get("http://" + postURL);
            Debug.Log(postURL);
            yield return userId; // Wait until the download is done

            if (userId.error != null)
            {
                print("There was an error registering: " + userId.error);
                errorTxt.text = "Error in registering";

            }
            else
            {
                SceneManager.LoadScene("Login");
            }
            
        }
        else
        {
            errorTxt.text = "Password don't match";
        }
    }
}
