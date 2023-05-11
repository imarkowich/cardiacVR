using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]

public class Login
{

    public string SID;
    public string Section;
    public string LoggedIn;

    public static Login CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<Login>(jsonString);
    }

}