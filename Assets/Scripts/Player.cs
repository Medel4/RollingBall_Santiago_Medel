using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float fuerza, fuerzaSalto, distanciaDeteccionSuelo;
    private float h, v;
    Rigidbody rb;
    int puntuacion;
    [SerializeField] TMP_Text textoPuntuacion;
    [SerializeField] Vector3 salto;
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
    }
    bool DetectarSuelo()
    {

        bool resultado = Physics.Raycast(transform.position, new Vector3(0, -1, 0), distanciaDeteccionSuelo);
        return resultado;
    
    }
}
