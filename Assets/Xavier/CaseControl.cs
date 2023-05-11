/*using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

// UnityWebRequest.Get example

// Access a website and use UnityWebRequest.Get to download a page.
// Also try to download a non-existing page. Display the error.

public class CaseControl : MonoBehaviour
{
    void getCases()
    {
        // A correct website page.
        StartCoroutine(GetRequest("https://hemo-cardiac.azurewebsites.net//cases.php?var1=Section_number"));
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
            }
            else
            {
                CaseList cases = CaseList.CreateFromJSON(webRequest.downloadHandler.text);
            }
        }
    }
}
*/

