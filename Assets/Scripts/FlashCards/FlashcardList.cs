using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

[System.Serializable]

public class FlashcardList
{

    public List<Flashcard> Flashcards;

    public static FlashcardList CreateFromJSON(string jsonString)
    {
        Debug.Log(jsonString);
        return JsonUtility.FromJson<FlashcardList>(jsonString);
    }


    public static FlashcardList CreateFromDictionary(List<Dictionary<string, object>> dict)
    {
        string jsonString = JsonConvert.SerializeObject(dict);

        return CreateFromJSON("{\"Flashcards\":" + jsonString + "}");
    }

}
