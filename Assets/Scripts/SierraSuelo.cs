using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SierraSuelo : MonoBehaviour
{
    [SerializeField] float velocidad, velocidadDeGiro;
    [SerializeField] Vector3 direccion, direccionGiro;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        

        if (timer <= 1.25f)
        {

            transform.Translate(direccion * velocidad * Time.deltaTime, Space.Self);

        }
        else
        {

            direccion *= -1;
            timer = 0;

        }

       

        timer = timer + 1 * Time.deltaTime;

    }

}
