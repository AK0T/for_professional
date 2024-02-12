using System.Collections;
using System.Collections.Generic;
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
    }
}
