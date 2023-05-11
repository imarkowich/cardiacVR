using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

// UnityWebRequest.Get example

// Access a website and use UnityWebRequest.Get to download a page.
// Also try to download a non-existing page. Display the error.

public class CaseControl : MonoBehaviour
{
    public CaseList cases;
    public bool readSuccessful;

    public IEnumerator getCases(int section_num)
    {
        Debug.Log("Getting cases from database. " + section_num);
        // A correct website page.
        yield return StartCoroutine(GetRequest("https://hemo-cardiac.azurewebsites.net//cases.php?var1=", section_num));

        //return "success";
        //Debug.Log("this should work? " + cases.Cases[0].Description);
    }

    IEnumerator GetRequest(string uri, int section)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri + section))
        {
            Debug.Log("Waiting on cases web request");
            
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();
            
            Debug.Log("got return from cases web request");

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log("Error with cases web request");
                Debug.Log(webRequest.error);
                readSuccessful = false;

                cases = CaseList.CreateFromDictionary(CSVReader.Read("M" + section + "Cases"));
            }
            else
            {
                cases = CaseList.CreateFromJSON(webRequest.downloadHandler.text);
                Debug.Log(cases.Cases[0].Description);
            
                readSuccessful = true;
            }
        }
    }
}

