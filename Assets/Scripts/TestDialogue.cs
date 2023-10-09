using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TestDialogue : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TMPro.TextMeshProUGUI dialogueText;
    public string[] dialogue;
    private int index;

    public float wordSpeed;

    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    void NextLine()
    {

        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
        }
    }

    public void play()
    {
        if (dialoguePanel.activeInHierarchy && (dialogueText.text == dialogue[index]))
        {
            NextLine();
        }
        else if (!(dialoguePanel.activeInHierarchy))
        {
            dialoguePanel.SetActive(true);
            StartCoroutine(Typing());
        }
    }
}
