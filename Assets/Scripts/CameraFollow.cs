using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour

{
    public PlayerPlacer placer;

    public float FollowSpeed = 2f;
    public Transform target;
    public float min, max;

    void Start()
    {
        placer = GameObject.FindGameObjectWithTag("Placer").GetComponent<PlayerPlacer>();
        transform.position = new Vector3(placer.getCameraPos(), transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 newPos = new Vector3(target.position.x, 0, -10f);

        if (newPos.x > max)
        {
            newPos.x = max;
        }
            
        else if (newPos.x < min)
        {
            newPos.x = min;
        }

        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }
}
