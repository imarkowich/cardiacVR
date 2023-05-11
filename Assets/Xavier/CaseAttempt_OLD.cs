/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class CaseAttempt : MonoBehaviour
{
    /*
    public TMP_InputField firstName;
    public TMP_InputField sid;
    public TMP_InputField classSection;
    */
/*
    public string SID;
    public string CID;
    public string Grade;
    public string TimeSpent;
    public string Answer;

    string url = "https://hemo-cardiac.azurewebsites.net/addCaseAttempt.php"; // can be public but has to be changed in Unity editor as well as in the code


    public void OnSubmit()
    {
        Debug.Log("Sending data");
        StartCoroutine(SendCaseAttempt());
    }

    IEnumerator SendCaseAttempt()
    {
        WWWForm form = new WWWForm();
        
        form.AddField("SID", SID);
        form.AddField("CID", int.Parse(CID));
        form.AddField("Grade", int.Parse(Grade));
        form.AddField("TimeSpent", TimeSpent);
        form.AddField("Answer", Answer);

        using (var send = UnityWebRequest.Post(url, form))
        {
            yield return send.SendWebRequest();

            if(send.result != UnityWebRequest.Result.Success)
            {
                print(send.error);
                Debug.Log("Uh oh, error");
            }
            else
            {
                Debug.Log("Sent request successfully");
                Debug.Log(send.downloadHandler.text);
            }
        }
    }
}
*/