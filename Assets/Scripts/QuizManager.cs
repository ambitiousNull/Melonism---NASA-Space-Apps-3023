using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public List<QuizInfo> QnA;
    public GameObject[] options;
    public int currentCategory;

    public TextMeshProUGUI QuestionTxt;

    public string SceneName;

    void Start()
    {
        generateQuestion();
    }

    public void correct()
    {
        // TODO: get NPC to say "Press Space to Continue"
        QnA.RemoveAt(currentCategory);
        generateQuestion();
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Image>().color = Color.white;            
        }

    }
        

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<QuizAnswers>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentCategory].answers[i];
            // put getcomponent sprite and change that too if you have time

            if (i == System.Convert.ToInt32(QnA[currentCategory].correctAnswer))
            {
                options[i].GetComponent<QuizAnswers>().isCorrect = true;
            }
        }
    }

    public void showAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            if (options[i].GetComponent<QuizAnswers>().isCorrect == false)
            {
                options[i].GetComponent<Image>().color = Color.red;
            }
            else
            {
                options[i].GetComponent<Image>().color = Color.green;
            }
        }
    }

    void generateQuestion()
    {
        if (QnA.Count > 0)
        {
            currentCategory = Random.Range(0, QnA.Count);

            QuestionTxt.text = QnA[currentCategory].category;
            SetAnswers();
        }
        else
        {
            SceneManager.LoadScene(SceneName);
            // change this to make NPC say something - "let's go out in the rover!"
            // when space/enter is pressed, switch to Section 3
        }
        
    }
}

// TODO: 1. make it more obvious which one player chose - make button slightly bigger then smaller again 2. exit out of laboratory when done quiz



// Call Set Questions
// change sprites of buttons
// load buttons with text - in QnA, make sprites attached to text in list
// when button is pressed
// if wrong
// button is highlighted in red - (NPC says stuff)
// if right
// button is highlighted in green
// if correct button has been highlighted   
// if continue (space) button is pressed
// if there are still questions left
// call next set of questions
// else
// hide everything