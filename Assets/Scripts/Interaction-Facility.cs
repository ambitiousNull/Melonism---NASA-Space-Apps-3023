using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{

    public InteractableButton interactable;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GameObject.FindGameObjectWithTag("Interactable").GetComponent<InteractableButton>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

// start
    // hide thing

// when player touches trigger
    // show thing
// else
    // hide thing
