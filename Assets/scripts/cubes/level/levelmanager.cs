using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelmanager : MonoBehaviour
{
    [SerializeField] private level[] level;
    public GameObject obj;
    private Vector3 DirX;
    private Vector3 DirZ;
    private int levelNum;

    private void Start()
    {
        levelNum = 0;
        CreateGamePlace();
    }

    private void CreateGamePlace()
    {
    }
}
