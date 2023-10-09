using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonKeyControl : MonoBehaviour
{
    public string keyCode;
    public Button button;
    private bool answerShowing;
    public QuizAnswers answerScript;

    void Start()
    {
        answerShowing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyCode))
        {
            button.onClick.Invoke();
            answerShowing = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && answerShowing)
        {
            answerScript.showNextQuestion();
            answerShowing = false;
        }

        // if (Input.GetKeyDown(KeyCode.Space) && answerShown())
        // answerShown means that NPC started talking and green thing appeared
        // need to make two functions: one that initiates npc + green
        // one more that shows next set of questions
    }
}
