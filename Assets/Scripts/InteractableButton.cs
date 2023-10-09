using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractableButton : MonoBehaviour
{

    public GameObject player;
    private bool touchingTrigger;

    public PlayerPlacer placer;


    public string SceneName;

    // Start is called before the first frame update
    void Start()
    {
        hide();
        touchingTrigger = false;

        player = GameObject.FindGameObjectWithTag("Player");

        placer = GameObject.FindGameObjectWithTag("Placer").GetComponent<PlayerPlacer>();

    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.E) == true) && touchingTrigger )
        {
            placer.savePlayerPos();
            SceneManager.LoadScene(SceneName);
        }
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            show();
            touchingTrigger = true;
        }
        
    }

    void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            hide();
            touchingTrigger = false;
        }

    }

    void hide()
    {
        GetComponent<Renderer>().enabled = false;

        return;
    }

    void show()
    {
        GetComponent<Renderer>().enabled = true;

        return;
    }

}
