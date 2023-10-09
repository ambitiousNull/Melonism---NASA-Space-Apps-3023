using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{

    public GameObject player;
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        player.transform.position = new Vector3(-7.75f, 4.28f, -5.6f);
        player.transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
        // animator.Play("Falling");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
