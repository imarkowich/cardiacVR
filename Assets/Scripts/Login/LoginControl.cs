using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

// UnityWebRequest.Get example

// Access a website and use UnityWebRequest.Get to download a page.
// Also try to download a non-existing page. Display the error.

public class LoginControl : MonoBehaviour
{

    private string _SID;
    private string _Password;
    [HideInInspector] public Login login;
    [HideInInspector] public string error;
    [HideInInspector] public bool isThereInternet;

    public void InitLoginRequest(string SID, string Password)
    {
        _SID = SID;
        _Password = Password;
        error = "";
    }

    public IEnumerator GetLogin()
    {
        // A correct website page.
        yield return StartCoroutine(GetRequest("https://hemo-cardiac.azurewebsites.net//login.php?var1=" + _SID + "&var2=" + _Password));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(webRequest.error);
                error = webRequest.error;
                isThereInternet = false;
            }
            else
            {
                Debug.Log(webRequest.downloadHandler.text);
                isThereInternet = true;
                if (webRequest.downloadHandler.text[0] != '{')
                {
                    error = webRequest.downloadHandler.text;
                    yield break;
                }

                login = Login.CreateFromJSON(webRequest.downloadHandler.text);
            }
        }
    }
}