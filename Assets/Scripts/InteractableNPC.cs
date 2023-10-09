using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractableNPC : MonoBehaviour
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
    

    // public TestDialogue dialogueScript;

    public bool playerIsClose;

    void Start()
    {
        // dialogueScript = GameObject.FindGameObjectWithTag("Interactable").GetComponent<TestDialogue>();
    }
   
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.Q) && playerIsClose)
      {
         dialogueName.text = NPCName;
         dialogueImage.sprite = NPCImage;

            if (dialoguePanel.activeInHierarchy && (dialogueText.text == dialogue[index]) )
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
    
    public void zeroText(){
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing(){
        foreach(char letter in dialogue[index].ToCharArray()){
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

     void NextLine(){
        
        if(index < dialogue.Length - 1){
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }else{
            zeroText();
        }
    }
    

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            playerIsClose = true;
     }
    }

      private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroText();
        }
    }
    
}
