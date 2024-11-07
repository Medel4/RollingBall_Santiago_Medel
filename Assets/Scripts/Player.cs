using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float fuerza, fuerzaSalto, distanciaDeteccionSuelo;
    private float h, v, tiempo;
    Rigidbody rb;
    int puntuacion, vida = 10;
    [SerializeField] TMP_Text textoPuntuacion, textoVidas, textoTiempo;
    [SerializeField] Vector3 salto, respawn, trampolin;
    [SerializeField] LayerMask queEsSuelo;
    [SerializeField] bool jugando = true;



        
    // Start is called before the first frame update
    void Start()
    {


        rb = GetComponent<Rigidbody>();
        tiempo = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        saltar();

        if (jugando)
        {

            TiempoPartida();

        }

        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        textoPuntuacion.SetText("Score: " + puntuacion);
        textoVidas.SetText("HP: " + vida);
        textoTiempo.SetText("Tiempo: " + tiempo);

         
    }
    private void FixedUpdate()
    {

        rb.AddForce(new Vector3(h, 0, v) * fuerza, ForceMode.Force);

        
       

    }
    void saltar()
    { 
    
        if (Input.GetKeyDown("space"))
        {
            if (DetectarSuelo() == true)
            {

                rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            }
        }
    
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coleccionable"))
        {
            Destroy(other.gameObject);

            puntuacion++;
        }

        if (other.gameObject.CompareTag("PinchosRodantes"))
        {

            vida--;

        }

        if (other.gameObject.CompareTag("Agua"))
        {

            TepearASpawn();


        }
        if (other.gameObject.CompareTag("RetenedorBolas1"))
        {

            Destroy(other.gameObject);

        }
    }
    void OnCollisionEnter(Collision other)
    {


        if (other.gameObject.CompareTag("Trampolin"))
        {
            rb.AddForce(0, 10, 0, ForceMode.Impulse);
        }

        if (other.gameObject.CompareTag("Bolas"))
        {
            vida--;
        }


    }
    bool DetectarSuelo()
    {

        bool resultado = Physics.Raycast(transform.position, new Vector3(0, -1, 0), distanciaDeteccionSuelo);
        return resultado;
    
    }
    private void TepearASpawn()
    {

        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        transform.position = respawn;

        rb.isKinematic = false;
        vida--;vida--;
        
    }
    void TiempoPartida()
    {

        tiempo = tiempo + 1 * Time.deltaTime;
    
    }

}
