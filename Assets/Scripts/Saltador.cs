using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saltador : MonoBehaviour
{
    int timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {

        transform.Translate(0, 6, 0);

    }
}
