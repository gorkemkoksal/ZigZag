using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invokeCube : MonoBehaviour
{
    [SerializeField] GameObject cube;
    [SerializeField] float counter=0f;
    void Start()
    {
        InvokeRepeating("InsCube", 1f, 1f);
    }

    public void InsCube()
    {
        Instantiate(cube, new Vector3(-10 + counter * 3f, 0, 0), Quaternion.identity);
        counter++;
    }
    
}
