using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Experimental.Networking;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public TMP_InputField username,password;
    public TextMeshProUGUI errorTxt;
    string LoginUrl = "flashquizkuce.000webhostapp.com/login.php?";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RegisterScene()
    {
        SceneManager.LoadScene("Register");
    }
    public void UserLogin()
    {
        StartCoroutine(WebConnect());
    }
    IEnumerator WebConnect()
    {
        string userName = username.text;
        string pw = password.text;
        if (userName.Length <= 0 || pw.Length <= 0)
        {
            errorTxt.text = "Please fill all the details";
        }
        else
        {
            string postURL = LoginUrl + "username=" + userName + "&pw=" + pw;

            UnityWebRequest userId = UnityWebRequest.Get("http://" + postURL);
            yield return userId.SendWebRequest(); // Wait until the download is done

            if (userId.isNetworkError)
            {
                errorTxt.text = "No connection found";

            }
            else
            {
                byte[] data = userId.downloadHandler.data;
                print(System.Text.Encoding.UTF8.GetString(data, 0, data.Length));
                string webText = System.Text.Encoding.UTF8.GetString(data, 0, data.Length);
                print(webText);
                if (webText == "Error")
                {
                    errorTxt.text = "The user was not found";
                }
                else
                {
                    errorTxt.text = "Welcome userID = " + webText + "\n to be redirected to game screen";
                }

            }
        }
    }
}
