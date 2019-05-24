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
    string RegisterUrl = "flashquizkuce.000webhostapp.com/register.php?";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Login");
        } 
    }

    public IEnumerator StartCountDown()
    {
        float currValue = 5;
        while (currValue > 0)
        {
            errorTxt.text = "Registered Sucessfully.\nRedirecting to login page in " + currValue + "second";
            yield return new WaitForSeconds(1.0f);
            currValue--;
            if (currValue <= 0)
            {
                SceneManager.LoadScene("Login");
            }
        }
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
        if (usernameStr.Length <= 0 || emailStr.Length <= 0 || pwStr.Length <= 0 || pw2Str.Length <= 0)
        {
            errorTxt.text = "Please fill all the details";
        }
        else
        {
            if (pwStr == pw2Str)
            {
                string postURL = RegisterUrl + "username=" + usernameStr + "&pw=" + pwStr + "&email=" + emailStr;

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
                        StartCoroutine(StartCountDown());
                    }

                }

            }
            else
            {
                errorTxt.text = "Password don't match";
            }
        }
    }
}
