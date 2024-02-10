using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEditor;
using UnityEngine;

public class zone : MonoBehaviour
{
    public List <Transform> cube;
    [SerializeField] private List <Vector3> cubePos;
    [SerializeField]
    private List <Vector3> startPos;
    [SerializeField]
    private List <Vector3> endPos;
    private float step = 0.01f;
    private float progress;
    private bool onMove = false;
    private string dir;
    Collider collider;

    private void Start()
    {
        Transform[] obj = transform.GetComponentsInChildren<Transform>();
        for (int i = 0; i < obj.Length; i++)
        {
            if (obj[i].tag == "cube")
            {
                cube.Add(obj[i]);
            }
        }
        for (int i = 0; i < cube.Count; i++)
        {
            cubePos.Add(cube[i].transform.position);
        }
        onMove = false;
        collider = GetComponent<Collider>();
    }


     public void FixedUpdate()
     {
         if (onMove)
         {
            for (int i = 0; i < cube.Count; i++)
            {
                cube[i].transform.position = Vector3.Lerp(startPos[i], endPos[i], progress);
            }
            progress += step;
        }
    }

     public void OnMouseDown()
     {
        dir = DirectionCube(cube[0].transform.position);
        OnStartPos(cube, startPos);
        onEndPos(dir, endPos, cube);
        onMove = true;
        collider.enabled = false;
     }

     public string DirectionCube(Vector3 direct) // проверяем направление кубика
     {
         if (direct.x < 0)
         {
             direct.x = direct.x * -1;
         }
         if (direct.z < 0)
         {
             direct.z = direct.z * -1;
         }
         if (direct.x > direct.z)
         {
             return "Horizontal";
         }
         else
         {
             return "Vertical";
         }
     }

    private void OnStartPos(List<Transform> obj, List<Vector3> startpos)
    {
        for (int i = 0; i < obj.Count; i++)
        {
            startPos.Add(obj[i].transform.position);
        }
    }


     private void onEndPos(string dir, List<Vector3> endpos, List<Transform> obj)
     {
        for (int i = 0; i < obj.Count; i++)
        {
            if (dir == "Horizontal")
            {
                if (obj[i].transform.position.x < 0)
                {
                    endPos.Add(new Vector3(obj[i].transform.position.x + 0.31f, obj[i].transform.position.y, obj[i].transform.position.z));
                }
                else
                {
                    endPos.Add(new Vector3(obj[i].transform.position.x - 0.31f, obj[i].transform.position.y, obj[i].transform.position.z));
                }
            }
            else
            {
                if (obj[i].transform.position.z < 0)
                {
                    endPos.Add(new Vector3(obj[i].transform.position.x, obj[i].transform.position.y, obj[i].transform.position.z + 0.32f));
                }
                else
                {
                    endPos.Add(new Vector3(obj[i].transform.position.x, obj[i].transform.position.y, obj[i].transform.position.z - 0.32f));
                }
            }
        }
    }
}
