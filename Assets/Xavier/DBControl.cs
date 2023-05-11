/*
using System.Collections.Generic;

using System;
using System.Collections;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class DBControl : MonoBehaviour
{

    private string secretKey = "mySecretKey";
    public string addStudentURL =
			"https://cardiacapi.azurewebsites.net/cardiac/addStudent.php?";
    public string getStudentsURL =
			 "https://cardiacapi.azurewebsites.net/cardiac/display.php";
    public Text nameTextInput;
    public Text scoreTextInput;
    public Text nameResultText;
    public Text sidResultText;

    public void GetScoreBtn()
    {
        nameResultText.text = "SID: \n \n";
        sidResultText.text = "Student Name: \n \n";
        StartCoroutine(GetScores());
    }

	//Work in Progress
	public void CreateStudentBtn()
	{
		StartCoroutine(PostScores(nameTextInput.text,
		   Convert.ToInt32(scoreTextInput.text)));
		nameTextInput.gameObject.transform.parent.GetComponent<InputField>().text = "";
		scoreTextInput.gameObject.transform.parent.GetComponent<InputField>().text = "";
	}

	IEnumerator GetScores()
	{
		UnityWebRequest hs_get = UnityWebRequest.Get(getStudentsURL);
		yield return hs_get.SendWebRequest();
		if (hs_get.error != null)
			Debug.Log("There was an error getting the high score: "
					+ hs_get.error);
		else
		{
			string dataText = hs_get.downloadHandler.text;
			Debug.Log("Cat");
			Debug.Log(dataText);
			MatchCollection mc = Regex.Matches(dataText, @"_");
			if (mc.Count > 0)
			{
				string[] splitData = Regex.Split(dataText, @"_");
				for (int i = 0; i < mc.Count; i++)
				{
					if (i % 2 == 0)
						nameResultText.text +=
											splitData[i];
					else
						sidResultText.text +=
											splitData[i];
				}
			}
		}
	}

	//Work in Progress
	IEnumerator PostScores(string name, int score)
	{
		string hash = HashInput(name + score + secretKey);
		string post_url = addStudentURL + "name=" +
			   UnityWebRequest.EscapeURL(name) + "&score="
			   + score + "&hash=" + hash;
		UnityWebRequest hs_post = UnityWebRequest.Post(post_url, hash);
		yield return hs_post.SendWebRequest();
		if (hs_post.error != null)
			Debug.Log("There was an error posting the high score: "
					+ hs_post.error);
	}

	//Work in Progress
	public string HashInput(string input)
	{
		SHA256Managed hm = new SHA256Managed();
		byte[] hashValue =
				hm.ComputeHash(System.Text.Encoding.ASCII.GetBytes(input));
		string hash_convert =
				 BitConverter.ToString(hashValue).Replace("-", "").ToLower();
		return hash_convert;
	}
}
*/