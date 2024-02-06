using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;

public class spawn_ball : MonoBehaviour
{
    public GameObject ball_obj;
    public GameObject point;
    private Vector3 spawn_point;
    // Start is called before the first frame update
    void Start()
    {
        spawn_point = point.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
            Instantiate(ball_obj, new Vector3(spawn_point.x, spawn_point.y, spawn_point.z), transform.rotation);
    }
}
