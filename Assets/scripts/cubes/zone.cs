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
    public GameObject cube;
    private Vector3 cubePos;
    [SerializeField]
    private Vector3 startPos;
    [SerializeField]
    private Vector3 endPos;
    private float step = 0.01f;
    private float progress;
    private bool onMove = false;
    private string dir;
    Collider collider;

    private void Start()
    {
        onMove = false;
        cubePos = cube.transform.position;
        collider = GetComponent<Collider>();
    }

    public void FixedUpdate()
    {
        if (onMove)
        {
            cube.transform.position = Vector3.Lerp(startPos, endPos, progress);
            progress += step;
        }
    }

    public void OnMouseDown()
    {
        startPos = cube.transform.position;
        dir = DirectionCube(cubePos); // получаем напревление кубика 
        if (dir == "Horizontal") 
        {
            if (cubePos.x < 0) 
            {
                endPos = new Vector3(cube.transform.position.x + 0.3f, cube.transform.position.y, cube.transform.position.z); // двигается  вправо
            }
            else
            {
                endPos = new Vector3(cube.transform.position.x - 0.3f, cube.transform.position.y, cube.transform.position.z); // двигается вправо
            }
        }

        if (dir == "Vertical")
        {
            if (cubePos.z < 0)
            {
                endPos = new Vector3(cube.transform.position.x, cube.transform.position.y, cube.transform.position.z + 0.3f); // двигается вниз
            }
            else
            {
                endPos = new Vector3(cube.transform.position.x, cube.transform.position.y, cube.transform.position.z - 0.3f);// двигается вверх
            }
        }
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

    private void onEndPos(string dir)
    {

    }
}
