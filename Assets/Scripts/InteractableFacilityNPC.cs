using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractableFacilityNPC : MonoBehaviour
{

    public GameObject dialoguePanel;
    public TMPro.TextMeshProUGUI dialogueText;
    public TMPro.TextMeshProUGUI dialogueName;
    public Image dialogueImage;
    public string[] dialogue;
    public string NPCName;
    public Sprite NPCImage;
    private int index;
    public float wordSpeed;

    void Awake()
    {
        play();
    }

    void Start()
    {
        // dialogueScript = GameObject.FindGameObjectWithTag("Interactable").GetComponent<TestDialogue>();
        dialogueName.text = NPCName;
        dialogueImage.sprite = NPCImage;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
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
        dialoguePanel.SetActive(true);
        StartCoroutine(Typing());
    }

}
