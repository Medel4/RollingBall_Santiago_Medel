using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
    [SerializeField] bool jugando = false;
    [SerializeField] GameObject camaraPrincipal, camaraFinal, camaraMuerte, canvasRestart;
    [SerializeField] AudioClip sonidoColeccionable, sonidoVictoria, sonidoSalto, sonidoDaño, sonidoAgua, sonidoTrampolin;
    [SerializeField] AudioManager manager;



        
    // Start is called before the first frame update
    void Start()
    {


        rb = GetComponent<Rigidbody>();
        tiempo = 0;
        camaraFinal.SetActive(false);
        camaraMuerte.SetActive(false);
        canvasRestart.SetActive(false);
        jugando = false;
        
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
            canvasRestart.SetActive(true);
            
        }
        else
        {

            Time.timeScale = 1;
            Time.fixedDeltaTime = 0.02f;

        }

        if (vida <= 0)
        {

            vida = 0;
            Destroy(gameObject);
            canvasRestart.SetActive(true);
            camaraPrincipal.SetActive(false);
            camaraMuerte.SetActive(true);

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
                manager.ReproducirSonido(sonidoSalto);
            }
        }
    
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coleccionable"))
        {
            Destroy(other.gameObject);
            manager.ReproducirSonido(sonidoColeccionable);

            puntuacion++;
        }

        if (other.gameObject.CompareTag("PinchosRodantes"))
        {

            vida--;
            manager.ReproducirSonido(sonidoDaño);

        }

        if (other.gameObject.CompareTag("Agua"))
        {

            TepearASpawn();
            manager.ReproducirSonido(sonidoAgua);


        }
        if (other.gameObject.CompareTag("RetenedorBolas1"))
        {

            jugando = true;
            Destroy(other.gameObject);

        }
        if (other.gameObject.CompareTag("Final"))
        {

            manager.ReproducirSonido(sonidoVictoria);

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
            manager.ReproducirSonido(sonidoTrampolin);
        }

        if (other.gameObject.CompareTag("Bolas"))
        {
            vida-= 2;
            manager.ReproducirSonido(sonidoDaño);
        }
        if (other.gameObject.CompareTag("Rodillo"))
        {

            vida-= 5;
            manager.ReproducirSonido(sonidoDaño);

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
