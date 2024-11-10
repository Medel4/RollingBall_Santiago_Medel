using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking.PlayerConnection;
using UnityEngine.Rendering.Universal;

public class Player : MonoBehaviour
{
    [SerializeField] float fuerza, fuerzaSalto, distanciaDeteccionSuelo;
    private float h, v, tiempo, timerCamaraLenta = 3;
    Rigidbody rb;
    int puntuacion, vida = 10;
    [SerializeField] TMP_Text textoPuntuacion, textoVidas, textoTiempo;
    [SerializeField] Vector3 salto, respawn, trampolin;
    [SerializeField] LayerMask queEsSuelo;
    [SerializeField] bool jugando = true;
    [SerializeField] GameObject camaraPrincipal, camaraFinal;        



        
    // Start is called before the first frame update
    void Start()
    {


        rb = GetComponent<Rigidbody>();
        tiempo = 0;
        camaraFinal.SetActive(false);
        
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

        if (timerCamaraLenta <= 2)
        {
            Time.timeScale = 0.5f;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
            timerCamaraLenta+= 1 * Time.deltaTime;
            
        }
        else
        {

            Time.timeScale = 1;
            Time.fixedDeltaTime = 0.02f;

        }
        

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

        if (other.gameObject.CompareTag("Rodillo"))
        {

            vida -= 5;

        }

        if (other.gameObject.CompareTag("Agua"))
        {

            TepearASpawn();


        }
        if (other.gameObject.CompareTag("RetenedorBolas1"))
        {

            Destroy(other.gameObject);

        }
        if (other.gameObject.CompareTag("Final"))
        {

            timerCamaraLenta = 0;
            jugando = false;
            transform.localScale = new Vector3(2, 2, 2);

            camaraPrincipal.SetActive(false);
            camaraFinal.SetActive(true);
            

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
