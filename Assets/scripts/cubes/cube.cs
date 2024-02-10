using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour
{
    private int speed = 2;
    public Vector3 fromPos;
    public Vector3 toPos;
    public float step;
    private float progress;

    private void Start()
    {
        fromPos = transform.position;
        toPos = new Vector3(transform.position.x + 0.2f, transform.position.y, transform.position.z);
    }

    public void FixedUpdate()
    {
        transform.position = Vector3.Lerp(fromPos, toPos, progress);
        progress += step;
    }


}
