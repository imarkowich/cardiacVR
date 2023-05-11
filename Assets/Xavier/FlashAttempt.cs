using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class FlashAttempt : MonoBehaviour
{
    /*
    public TMP_InputField firstName;
    public TMP_InputField sid;
    public TMP_InputField classSection;
    */

    private string FID;
    private string SID;
    private string Grade;
    private string TimeSpent;
    private string Confidence;
    private string Login;

    string url = "https://hemo-cardiac.azurewebsites.net/addFlashcardAttempt.php"; // can be public but has to be changed in Unity editor as well as in the code


    public void OnSubmit(string FID, string SID, string Grade, string TimeSpent, string Confidence, string Login)
    {
        Debug.Log("Sending data");
        StartCoroutine(SendFlashAttempt(FID, SID, Grade, TimeSpent, Confidence, Login));
    }

    IEnumerator SendFlashAttempt(string FID, string SID, string Grade, string TimeSpent, string Confidence, string Login)
    {
        WWWForm form = new WWWForm();
        
        form.AddField("FID", int.Parse(FID));
        form.AddField("SID", SID);
        form.AddField("Grade", int.Parse(Grade));
        form.AddField("TimeSpent", TimeSpent);
        form.AddField("Confidence", Confidence);
        form.AddField("Login", int.Parse(Login));

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