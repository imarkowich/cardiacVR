using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.IO;
using TMPro;
using System.Text.RegularExpressions;

public class CasesLogic : MonoBehaviour
{
    [Header("Screens")]
    [SerializeField] private Canvas caseScreen;
    [SerializeField] private Canvas resultScreen;
    [SerializeField] private Canvas startScreen;
    [SerializeField] private Canvas loadingScreen;
    [SerializeField] private Canvas feedbackScreen;

    private int currentQuestionIndex = 0;

    // Unity components to display the questions
    [Header("Components")]
    [SerializeField] private TMP_Text questionText;
    [SerializeField] private TMP_Text feedbackquestionText;
    [SerializeField] private TMP_Text feedbackText;

    [SerializeField] private Image choiceA;
    [SerializeField] private Image choiceB;
    [SerializeField] private Image choiceC;
    [SerializeField] private Image choiceAFeedback;
    [SerializeField] private Image choiceBFeedback;
    [SerializeField] private Image choiceCFeedback;

    private int selectedAnswer = -1;

    // true if student answers correctly,
    // false if student answers incorrectly
    private bool[] answerCorrectness;

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text numberCorrectText;

    private CaseControl c;
    private List<Case> cases;
    [Header("Settings")]
    [SerializeField] int sectionNumber;

    private CaseTimer t;
    private FeedbackScreen f;

    [Header("Heart")]
    [SerializeField] private GameObject[] Hearts;
    [SerializeField] private GameObject[] HeartHolders;
    [SerializeField] private GameObject[] HeartOrientationBoards;

    [Header("Answer Choice Buttons")]
    [SerializeField] private Button[] buttons;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        DisableHearts();

        t = GetComponent<CaseTimer>();

        caseScreen.enabled = false;
        startScreen.enabled = false;
        resultScreen.enabled = false;
        feedbackScreen.enabled = false;
        loadingScreen.enabled = true;

        yield return StartCoroutine(GetCases());

        startScreen.enabled = true;
        loadingScreen.enabled = false;

        answerCorrectness = new bool[cases.Capacity];
    }

    IEnumerator GetCases()
    {
        // this uses the CaseControl script to read the cases from the database
        // or as a fallback... read from local csv file
        c = GetComponent<CaseControl>();
        yield return c.getCases(sectionNumber);

        // store the cases locally
        cases = c.cases.Cases;
        Debug.Log("cases logic: " + cases[0].Description);
    }

    public void StartQuiz()
    {
        DisableHearts();
        startScreen.enabled = false;
        resultScreen.enabled = false;
        caseScreen.enabled = true;

        currentQuestionIndex = 0;
        questionText.text = GetQuestionAtIndex(currentQuestionIndex);
        feedbackquestionText.text = questionText.text;
        feedbackText.text = cases[currentQuestionIndex].AnswerDescription;

        t.StartTimer();
    }

    private string GetQuestionAtIndex(int questionIndex)
    {
        DisableHearts();

        if (questionIndex > cases.Capacity - 1)
        {
            FinishQuiz();
            return "";
        }

        selectedAnswer = -1;

        LoadImageFromFile(cases[questionIndex].A, choiceA);
        LoadImageFromFile(cases[questionIndex].B, choiceB);
        LoadImageFromFile(cases[questionIndex].C, choiceC);

        LoadImageFromFile(cases[questionIndex].A, choiceAFeedback);
        LoadImageFromFile(cases[questionIndex].B, choiceBFeedback);
        LoadImageFromFile(cases[questionIndex].C, choiceCFeedback);

        if (cases[questionIndex].Rhythm == "AVNRT")
        {
            EnableHeart(0);
        }
        else if (cases[questionIndex].Rhythm == "AFib")
        {
            EnableHeart(1);
        }
        else if (cases[questionIndex].Rhythm == "AFL" || cases[questionIndex].Rhythm == "Flutter")
        {
            EnableHeart(2);
        }

        return cases[questionIndex].Description;
    }

    public void CheckQuestion()
    {
        if (selectedAnswer == -1)
        {
            Debug.Log("No answer selected");
            return;
        }

        string timeElapsed = t.GetTimeElapsed();
        Debug.Log(timeElapsed);

        // Since the selected answer is an integer, we need to map each integer
        // to the string that's stored in each answer choice
        string selectedAnswerString = "";
        switch (selectedAnswer)
        {
            case 0:
                selectedAnswerString = cases[currentQuestionIndex].A;
                break;
            case 1:
                selectedAnswerString = cases[currentQuestionIndex].B;
                break;
            case 2:
                selectedAnswerString = cases[currentQuestionIndex].C;
                break;
        }

        // check if the selected answer is correct
        answerCorrectness[currentQuestionIndex] = String.Equals(selectedAnswerString, cases[currentQuestionIndex].Rhythm);
        Debug.Log(answerCorrectness[currentQuestionIndex]);

        // find out which answer choice is the correct answer choice
        int correctAnswerIndex = 0;
        if (String.Equals(cases[currentQuestionIndex].A, cases[currentQuestionIndex].Rhythm))
            correctAnswerIndex = 0;
        else if (String.Equals(cases[currentQuestionIndex].B, cases[currentQuestionIndex].Rhythm))
            correctAnswerIndex = 1;
        else
            correctAnswerIndex = 2;

        // show feedback to the student
        f = GetComponent<FeedbackScreen>();
        f.PopulateFeedbackScreen(answerCorrectness[currentQuestionIndex], correctAnswerIndex, selectedAnswer);

        caseScreen.enabled = false;
        feedbackScreen.enabled = true;

        if (LoginInfo.login != null)
        {
            CaseAttempt caseAttempt = GetComponent<CaseAttempt>();
            caseAttempt.Submit(
                LoginInfo.login.SID,
                cases[currentQuestionIndex].CID,
                answerCorrectness[currentQuestionIndex] ? "100" : "0", 
                timeElapsed, 
                "" + (char)('A' + (char)(selectedAnswer % 26)),
                LoginInfo.login.LoggedIn
            );
        }
    }

    public void NextQuestion()
    {
        questionText.text = GetQuestionAtIndex(++currentQuestionIndex);
        feedbackquestionText.text = questionText.text;

        if (currentQuestionIndex < cases.Capacity)
            feedbackText.text = cases[currentQuestionIndex].AnswerDescription;

        if (questionText.text != "")
        {
            t.StartTimer();
            caseScreen.enabled = true;
        }

        feedbackScreen.enabled = false;
    }
    public void SelectAnswer(int index)
    {
        selectedAnswer = index;

        ResetAnswerButtons();

        var color = buttons[index].colors;
        color.normalColor = new Color32(36, 150, 246, 255);
        buttons[index].colors = color;

    }

    public void ResetAnswerButtons()
    {
        foreach (Button button in buttons)
        {
            var colors = button.colors;
            colors.normalColor = new Color32(244, 243, 246, 255);
            button.colors = colors;
        }
    }

    private void FinishQuiz()
    {
        StartCoroutine(GetCases());

        // calculate student score
        double score = 0;
        double numCorrect = 0;
        for (int i = 0; i < cases.Capacity; i++)
        {
            if (answerCorrectness[i]) numCorrect++;
        }

        score = numCorrect / cases.Capacity * 100;
        Debug.Log("Quiz Score: " + score);

        scoreText.text = "Score: " + Math.Round(score, 2) + "%";
        numberCorrectText.text = "Correct Answers: " + numCorrect + "/" + cases.Capacity;

        startScreen.enabled = false;
        caseScreen.enabled = false;
        resultScreen.enabled = true;
    }

    public void ExitQuiz()
    {
        StartCoroutine(GetCases());
        startScreen.enabled = true;
        caseScreen.enabled = false;
        resultScreen.enabled = false;
    }

    void LoadImageFromFile(string fileName, Image targetImageComponent)
    {
        targetImageComponent.sprite = Resources.Load<Sprite>("AnswerChoiceImages/" + fileName);
    }

    IEnumerator LoadImageFromWeb(string url, Image targetImageComponent) {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log(request.error);
        }
        else
        {
            Debug.Log("Image Loaded");
        }

        Texture2D answerChoiceImage = ((DownloadHandlerTexture)request.downloadHandler).texture;
        Sprite newSprite = Sprite.Create(answerChoiceImage, new Rect(0, 0, answerChoiceImage.width, answerChoiceImage.height), new Vector2(0.5f, 0.5f));

        targetImageComponent.preserveAspect = true;
        targetImageComponent.sprite = newSprite;
    }

    private void DisableHearts()
    {
        foreach (GameObject heart in Hearts)
        {
            heart.SetActive(false);
        }

        foreach (GameObject heartHolder in HeartHolders)
        {
            heartHolder.SetActive(false);
        }

        foreach (GameObject board in HeartOrientationBoards)
        {
            board.SetActive(false);
        }
    }

    private void EnableHeart(int index)
    {
        HeartOrientationBoards[index].SetActive(true);
        HeartHolders[index].SetActive(true);
        Hearts[index].SetActive(true);
    }
}
