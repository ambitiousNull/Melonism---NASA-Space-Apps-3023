using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlacer : MonoBehaviour
{

    public GameObject player;
    private float playerPos;
    private float playerY;
    private float playerDirection;
    public GameObject mainCam;
    private float cameraPos;
    

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Placer");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerDirection = player.transform.localScale.x;
    }

    void Update(){

    }


    public void savePlayerPos()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        mainCam = GameObject.FindGameObjectWithTag("MainCamera");

        playerPos = player.transform.position.x;
        playerY = -2.345701f;
        playerDirection = player.transform.localScale.x;
        cameraPos = mainCam.transform.position.x;
    }

    public float getPlayerPos()
    {
        return playerPos;
    }

    public float getPlayerDirection()
    {
        return playerDirection;
    }

    public float getCameraPos()
    {
        return cameraPos;
    }

    public float getPlayerY()
    {
        return playerY;
    }


    public void locationChange()
    {
        playerY = 0.66f;
        
    }
}