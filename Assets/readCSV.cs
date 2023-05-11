using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class readCSV : MonoBehaviour
{

    public string[] flashCardquestions;
    public string[] flashCardanswers;
    public int flashCardCounter;
    public int gradelevel;

    void Start()
    {
        Read();
    }
    void Read()
    {
        StartCoroutine(GetComponent<FlashcardControl>().getFlashcards(gradelevel));
        /*
        List<Dictionary<string, object>> l = CSVReader.Read("flashcards");

        string[] questions = new string[l.Count];
        string[] answers = new string[l.Count];
        for (int i = 0; i < l.Count; i++)
        {
            questions[i] = (string)l[i]["questions"];
            answers[i] = (string)l[i]["answers"];
            Debug.Log(questions[i]);
            Debug.Log(answers[i]);
        }

        flashCardquestions = questions;
        flashCardanswers = answers;
        */
        //TextAsset linesTest = Resources.Load("flashcards") as TextAsset;
        //var lines = Regex.Split(linesTest.text, LINE_SPLIT_RE);

        //if (lines.Length <= 1) return list;
        //var header = Regex.Split(lines[0], SPLIT_RE);
        //string[] Lines = System.IO.File.ReadAllLines("flashcards.csv");
        //string[] Columns= Lines[1].Split(';');

        /*
        string[] questions = new string[Lines.Length];
        string[] answers = new string[Lines.Length];
        flashCardCounter = 0;
        //var dataVal;
        for (int i=0; i<=Lines.Length-1; i++)
        {
            string[] dataVal = Lines[i].Split(',');
            

        }
        
        */
    }
}