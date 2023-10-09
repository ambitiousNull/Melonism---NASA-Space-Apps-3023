using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    public string SceneName;
    public PlayerPlacer placer;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            //Load Section 2
            
            SceneManager.LoadScene(SceneName);
            placer = GameObject.FindGameObjectWithTag("Placer").GetComponent<PlayerPlacer>();
            placer.locationChange();
            
        }
    }

}
