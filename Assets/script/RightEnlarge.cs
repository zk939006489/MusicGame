using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightEnlarge : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.InvokeRepeating("Enlarge", 0.0f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Enlarge()
    {
        this.transform.localScale *= 1.05f;
    }
}
