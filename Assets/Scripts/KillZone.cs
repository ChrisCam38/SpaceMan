using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //DETECCION DEL TRIGGER DEL COLLIDER DE LA KILLZONE

    void OnTriggerEnter2D (Collider2D collision)
    {
        if(collision.tag == "Player")  //Si el elemento que colisiona tiene la etiqueta player
        {
            PlayerController controller = 
                collision.GetComponent<PlayerController>();
            controller.Die();
        }
    }
}
