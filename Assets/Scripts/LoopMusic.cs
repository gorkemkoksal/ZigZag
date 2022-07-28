using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopMusic : MonoBehaviour
{
    public static LoopMusic instance;
    private void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

    }
    
}
