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

    private string SID;
    private string CID;
    private string Grade;
    private string TimeSpent;
    private string Answer;

    string url = "https://hemo-cardiac.azurewebsites.net/addCaseAttempt.php"; // can be public but has to be changed in Unity editor as well as in the code

    public void Submit(string SID, string CID, string Grade, string TimeSpent, string Answer, string Login)
    {
        Debug.Log("Sending data");
        StartCoroutine(SendCaseAttempt(SID, CID, Grade, TimeSpent, Answer, Login));
    }

    IEnumerator SendCaseAttempt(string SID, string CID, string Grade, string TimeSpent, string Answer, string Login)
    {
        WWWForm form = new WWWForm();
        
        form.AddField("SID", SID);
        form.AddField("CID", int.Parse(CID));
        form.AddField("Grade", int.Parse(Grade));
        form.AddField("TimeSpent", TimeSpent);
        form.AddField("Answer", Answer);
        form.AddField("Login", Login);

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