using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

[System.Serializable]

public class CaseList
{

    public List<Case> Cases;

    public static CaseList CreateFromJSON(string jsonString)
    {
        Debug.Log(jsonString);
        return JsonUtility.FromJson<CaseList>(jsonString);
    }

    public static CaseList CreateFromDictionary(List<Dictionary<string, object>> dict)
    {
        string jsonString = JsonConvert.SerializeObject(dict);
        
        return CreateFromJSON("{\"Cases\":" + jsonString + "}");
    }

}
