using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

// UnityWebRequest.Get example

// Access a website and use UnityWebRequest.Get to download a page.
// Also try to download a non-existing page. Display the error.

public class FlashcardControl : MonoBehaviour
{

    public bool didRead = false;
    public FlashcardList flashy;
    public IEnumerator getFlashcards(int section_num)
    {
        Debug.Log("Getting FLASHCAAAARDS from database. " + section_num);
        // A correct website page.
        yield return StartCoroutine(GetRequest("https://hemo-cardiac.azurewebsites.net//flashcards.php?var1=" , section_num));
    }

    IEnumerator GetRequest(string uri, int section)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri + section))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log("Error with FLAAAASHCAAAARDS web request");
                Debug.Log(webRequest.error);

                didRead = false;

                flashy = FlashcardList.CreateFromDictionary(CSVReader.Read("M" + section + "Flashcards"));
            }
            else
            {
                flashy = FlashcardList.CreateFromJSON(webRequest.downloadHandler.text);
                //FlashcardList flashcards = FlashcardList.CreateFromJSON(webRequest.downloadHandler.text);
                Debug.Log("we got FLASHY FROM DA WEEEEBBB");
                Debug.Log(flashy.Flashcards[0].Prompt);
                didRead = true;
            }
        }
    }
}

