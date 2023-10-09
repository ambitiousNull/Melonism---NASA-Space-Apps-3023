using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitFacility : MonoBehaviour
{
    public string SceneName;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) == true)
        {
            SceneManager.LoadScene(SceneName);
            // playerScript.setSpawnPos(enterScript.getPlayerPos());
        }
    }
}
