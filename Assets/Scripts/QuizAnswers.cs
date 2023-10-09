using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizAnswers : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;

    public void Answer()
    {
        quizManager.showAnswers();
        /*
        if(isCorrect)
        {
            Debug.Log("Correct Answer");
            quizManager.correct();
        }
        else
        {
            Debug.Log("Wrong Answer");
            quizManager.correct(); // change this later - show incorrect - if you can
        }
        */
    }

    public void showNextQuestion()
    {
        quizManager.correct();
    }

}
 