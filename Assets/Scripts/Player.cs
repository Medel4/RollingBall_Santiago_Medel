using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float fuerza, fuerzaSalto;
    Rigidbody rb;
        
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        rb.AddForce(new Vector3(h, 0, v) * fuerza, ForceMode.Force);
            
        
        if (Input.GetKeyDown("space"))
        {

            GetComponent<Rigidbody>().AddForce(0, fuerzaSalto, 0, ForceMode.Impulse);

        }
        
    }
}
