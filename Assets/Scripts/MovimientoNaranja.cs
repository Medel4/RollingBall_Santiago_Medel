using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoNaranja : MonoBehaviour
{
    [SerializeField] float velocidad;
    [SerializeField] Vector3 direccion;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 5)
        {

            transform.Translate(direccion * velocidad * Time.deltaTime);

        }
        else
        { 
        
        direccion *= -1;
        timer = 0;
        
        }

        timer = timer + 1* Time.deltaTime;
        
    }
}
