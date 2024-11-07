using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RotacionSensual : MonoBehaviour
{

    [SerializeField] float velocidad, velocidadMovimiento;
    [SerializeField] Vector3 rotacion, movimiento;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(rotacion * velocidad * Time.deltaTime, Space.Self);


        
        
        transform.Translate(movimiento * velocidadMovimiento * Time.deltaTime, Space.World);

        if (timer >= 1)
        {

        velocidadMovimiento *= -1;
        timer = 0;

        }

        timer = timer + 1 * Time.deltaTime;
    }
}
