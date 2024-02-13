using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class levelmanager : MonoBehaviour
{
    public int PosX;
    public int PosZ;
    public Vector3 DirPosX;
    public Vector3 DirPosZ;
    public Vector3 TimeDirPosX;
    public Vector3 TimeDirPosZ;
    public GameObject cell;
    public GameObject cube;
    [SerializeField] private GameObject[] spawnedCube;
    private void Start()
    {
        var _PosX = PosX * 3;
        var _PosZ = PosZ * 3;
            DirPosX.x = DirPosX.x - PosX;
            DirPosZ.z = DirPosZ.z - PosZ / 2;
            TimeDirPosX.x = DirPosX.x;
            TimeDirPosZ.z = DirPosZ.z;

            for (int i = 0; i < PosX; i++)
            {
                for (int j =0; j < PosZ; j++)
                {
                    Instantiate(cell, new Vector3(TimeDirPosX.x, 4, TimeDirPosZ.z), Quaternion.identity);
                    TimeDirPosZ.z = TimeDirPosZ.z + 2.6f;
                }
                TimeDirPosZ.z = DirPosZ.z;
                TimeDirPosX.x += 2.6f;
            }

            TimeDirPosX.x = DirPosX.x;

            for (int i = 0; i < PosX; i++)
            {
                TimeDirPosX.x -= 2.6f;
                for (int j = 0; j < PosZ; j++)
                {
                    Instantiate(cell, new Vector3(TimeDirPosX.x, 4, TimeDirPosZ.z), Quaternion.identity);
                    TimeDirPosZ.z = TimeDirPosZ.z + 2.6f;
                }
                TimeDirPosZ.z = DirPosZ.z;
            }

            TimeDirPosX.x = DirPosX.x;

            for (int i = 0; i < PosX; i++)
            {
                for (int j = 0; j < PosZ; j++)
                {
                    Instantiate(cell, new Vector3(TimeDirPosX.x + 2.6f*PosX, 4, TimeDirPosZ.z), Quaternion.identity);
                    TimeDirPosZ.z = TimeDirPosZ.z + 2.6f;
                }
                TimeDirPosZ.z = DirPosZ.z;
                TimeDirPosX.x += 2.6f;
            }

            TimeDirPosX.x = DirPosX.x;

            for (int i = 0; i < PosX; i++)
            {
                for (int j = 0; j < PosZ; j++)
                {
                    Instantiate(cell, new Vector3(TimeDirPosX.x, 4, TimeDirPosZ.z + 2.6f * PosX), Quaternion.identity);
                    TimeDirPosX.x += 2.6f;
                }
                TimeDirPosX.x = DirPosX.x;
                TimeDirPosZ.z += 2.6f;
            }

            TimeDirPosZ.z = DirPosZ.z;

            for (int i = 0; i < PosX; i++)
            {
                TimeDirPosZ.z -= 2.6f;
                for (int j = 0; j < PosZ; j++)
                {
                    Instantiate(cell, new Vector3(TimeDirPosX.x, 4, TimeDirPosZ.z), Quaternion.identity);
                    TimeDirPosX.x += 2.6f;
                }
                TimeDirPosX.x = DirPosX.x;
            }

        TimeDirPosX.x = DirPosX.x;
        TimeDirPosZ.z = DirPosZ.z;

        for (int i = 0; i < PosX; i++)
        {
            for (int j = 0; j < PosZ; j++)
            {
                Instantiate(cube, new Vector3(TimeDirPosX.x, 5.2f, TimeDirPosZ.z), Quaternion.identity);
                TimeDirPosZ.z = TimeDirPosZ.z + 2.6f;
            }
            TimeDirPosZ.z = DirPosZ.z;
            TimeDirPosX.x += 2.6f;
        }

        spawnedCube = GameObject.FindGameObjectsWithTag("cube");

        int maxPlane = 5;
        int minPlane = 1;
        for (int i = 0; i < PosZ*PosX; i++)
        {
            int plane = Random.Range(minPlane, maxPlane);
            /*
             * 1 - права€ €чейка
             * 2 - лева€ €чейка
             * 3 - верхн€€ €чейка 
             * 4 - нижн€€ €чейка
             */
            Ray ray = new Ray();
            ray.origin = spawnedCube[i].transform.position;
            if (plane == 1)
            {
                ray.direction = spawnedCube[i].transform.right;
                if (Physics.Raycast(ray.origin, ray.direction))
                {
                    i = i - 1;
                    //spawnedCube[i].transform.position
                }
                else
                {
                    spawnedCube[i].transform.position = new Vector3(spawnedCube[i].transform.position.x + 2.6f * PosX, spawnedCube[i].transform.position.y, spawnedCube[i].transform.position.z);
                }
            }else if (plane == 2)
            {
                spawnedCube[i].transform.position = new Vector3(spawnedCube[i].transform.position.x - 2.6f * PosX, spawnedCube[i].transform.position.y, spawnedCube[i].transform.position.z);
            }
            else if (plane == 3)
            {
                ray.direction = spawnedCube[i].transform.forward;
                if (Physics.Raycast(ray.origin, ray.direction))
                {
                    i = i - 1;
                    //spawnedCube[i].transform.position
                }
                else
                {
                    spawnedCube[i].transform.position = new Vector3(spawnedCube[i].transform.position.x, spawnedCube[i].transform.position.y, spawnedCube[i].transform.position.z + 2.6f * PosZ);
                }
            }
            else
            {
                spawnedCube[i].transform.position = new Vector3(spawnedCube[i].transform.position.x, spawnedCube[i].transform.position.y, spawnedCube[i].transform.position.z - 2.6f * PosZ );
            }
        }
    }
}
