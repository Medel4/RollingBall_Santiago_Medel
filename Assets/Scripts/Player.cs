using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float fuerza, fuerzaSalto;
    private float h, v;
    Rigidbody rb;
        
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

            

         
    }
    private void FixedUpdate()
    {

        rb.AddForce(new Vector3(h, 0, v) * fuerza, ForceMode.Force);

       

    }
    void saltar()
    { 
    
        if (Input.GetKeyDown("space"))
        {

                GetComponent<Rigidbody>().AddForce(0, fuerzaSalto, 0, ForceMode.Impulse);

        }
    
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coleccionable"))
        {
            Destroy(other.gameObject);
        }
    }
}
