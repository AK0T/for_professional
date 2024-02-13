using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    Ray ray = new Ray();
    public void Start()
    {
        ray.origin = transform.position;
        ray.direction = transform.right;
        Debug.DrawRay(ray.origin, ray.direction);

        if (Physics.Raycast(ray))
        {
            
        }

    }
}
