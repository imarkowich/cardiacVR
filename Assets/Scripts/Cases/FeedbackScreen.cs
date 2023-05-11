using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackScreen : MonoBehaviour
{
    public void PopulateFeedbackScreen(bool isCorrect, int correctAnswer, int incorrectAnswer)
    {
        //GameObject original = GameObject.Find("Right Room Cases Board");
        GameObject iconA = gameObject.transform.Find("Feedback Screen/Answer Choices/Lists/Item1/Icon A").gameObject;
        GameObject iconACorrect = gameObject.transform.Find("Feedback Screen/Answer Choices/Lists/Item1/Icon Correct").gameObject;
        GameObject iconAIncorrect = gameObject.transform.Find("Feedback Screen/Answer Choices/Lists/Item1/Icon Incorrect").gameObject;
        GameObject iconB = gameObject.transform.Find("Feedback Screen/Answer Choices/Lists/Item2/Icon B").gameObject;
        GameObject iconBCorrect = gameObject.transform.Find("Feedback Screen/Answer Choices/Lists/Item2/Icon Correct").gameObject;
        GameObject iconBIncorrect = gameObject.transform.Find("Feedback Screen/Answer Choices/Lists/Item2/Icon Incorrect").gameObject;
        GameObject iconC = gameObject.transform.Find("Feedback Screen/Answer Choices/Lists/Item3/Icon C").gameObject;
        GameObject iconCCorrect = gameObject.transform.Find("Feedback Screen/Answer Choices/Lists/Item3/Icon Correct").gameObject;
        GameObject iconCIncorrect = gameObject.transform.Find("Feedback Screen/Answer Choices/Lists/Item3/Icon Incorrect").gameObject;

        iconA.SetActive(true);
        iconB.SetActive(true);
        iconC.SetActive(true);

        iconACorrect.SetActive(false);
        iconBCorrect.SetActive(false);
        iconCCorrect.SetActive(false);

        iconAIncorrect.SetActive(false);
        iconBIncorrect.SetActive(false);
        iconCIncorrect.SetActive(false);

        switch (correctAnswer)
        {
            case 0:
                iconA.SetActive(false);
                iconACorrect.SetActive(true);
                break;
            case 1:
                iconB.SetActive(false);
                iconBCorrect.SetActive(true);
                break;
            case 2:
                iconC.SetActive(false);
                iconCCorrect.SetActive(true);
                break;
        }

        if (!isCorrect)
        {
            switch (incorrectAnswer)
            {
                case 0:
                    iconA.SetActive(false);
                    iconAIncorrect.SetActive(true);
                    break;
                case 1:
                    iconB.SetActive(false);
                    iconBIncorrect.SetActive(true);
                    break;
                case 2:
                    iconC.SetActive(false);
                    iconCIncorrect.SetActive(true);
                    break;
            }
        }
    }
}
