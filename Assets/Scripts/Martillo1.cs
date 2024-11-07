using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Martillo1 : MonoBehaviour
{
    [SerializeField] float amplitud = 45f;
    [SerializeField] float frecuencia = 1f;
    [SerializeField] float anguloInicial = 1f;
    [SerializeField] float direccionOscilacion = 1f;


    private float tiempo;

    void Update()
    {

        tiempo += Time.deltaTime;
        float anguloOscilacion = Mathf.Sin(tiempo * frecuencia) * amplitud;


        transform.localRotation = Quaternion.Euler(0, anguloInicial, direccionOscilacion * anguloOscilacion);
    }
}
