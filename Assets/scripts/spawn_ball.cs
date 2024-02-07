using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;

public class spawn_ball : MonoBehaviour
{
    public GameObject ball_obj;
    public GameObject player_ball;
    private bool ball_here = true;
    private Vector3 spawn_point;
    ball ball;
    [SerializeField]
    private float timebtwspwan;
    // Start is called before the first frame update
    void Start()
    {
        spawn_point = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        ball_obj = GameObject.FindWithTag("ball");
        ball = ball_obj.GetComponent<ball>();
        if (ball.is_fly && timebtwspwan<=-1.1f)
        {
            ball.is_fly = false;
            Instantiate(player_ball, new Vector3(spawn_point.x, spawn_point.y, spawn_point.z), transform.rotation);
            timebtwspwan = 0;
        }
        else
        {
            timebtwspwan -= Time.deltaTime;
        }
    }


}
