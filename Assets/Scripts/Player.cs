using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float fuerza, fuerzaSalto, distanciaDeteccionSuelo;
    private float h, v;
    Rigidbody rb;
    int puntuacion, vida = 10;
    [SerializeField] TMP_Text textoPuntuacion, textoVidas;
    [SerializeField] Vector3 salto, respawn;
    [SerializeField] LayerMask queEsSuelo;



        
    // Start is called before the first frame update
    void Start()
    {


        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        saltar();

        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        textoPuntuacion.SetText("Score: " + puntuacion);
        textoVidas.SetText("HP: " + vida);

         
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

}
