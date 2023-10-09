using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterShow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hide()
    {
        GetComponent<Renderer>().enabled = false;

        return;
    }

    public void show()
    {
        GetComponent<Renderer>().enabled = true;

        return;
    }
}
