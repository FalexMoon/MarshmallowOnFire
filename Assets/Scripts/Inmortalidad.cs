using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inmortalidad : MonoBehaviour
{
    
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        Inmortalidad[] x = FindObjectsOfType<Inmortalidad>();
        if (x.Length > 1)
        {
            Destroy(gameObject);
        }
    }
}
