using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saltador : MonoBehaviour
{
    [SerializeField] float velocidad, duracion;
    [SerializeField] Vector3 direccion;
    float timer = 0;
    [SerializeField] bool subir = false;
    // Start is called before the first frame update
    void Start()
    {
        if (subir == true)
        {
            transform.Translate(direccion * velocidad * Time.deltaTime, Space.World);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        subir = true;
    }
}
