using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //Movements variables for player
    public float jumpForce = 30f;
    public float runningSpeed = 8f;
    bool facingRight = true; //Variable para saber si el personaje esta a la derecha
    float inputHorizontal;
    private Rigidbody2D playerRigidbody2D;
    public LayerMask groundMask;
    private Animator animator;


    private const string STATE_ALIVE = "isAlive";
    private const string STATE_ON_THE_GROUND = "isOnTheGround";

    void Awake()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();                  //componente encargado de las animaciones
        
    }
    // Start is called before the first frame update
    void Start() {
        animator.SetBool(STATE_ALIVE, true);
        animator.SetBool(STATE_ON_THE_GROUND, true);
       

    }

    // Update is called once per frame
    void Update() {
        //code for detect if the spacebar or right mouse click bottom is pressed
        if (Input.GetButtonDown("Jump"))
        {
            Jump();

        }
        animator.SetBool(STATE_ON_THE_GROUND, IsTouchingTheGround());
        Debug.DrawRay(this.transform.position, Vector2.down * 1.5f, Color.red);
    }

    
      //METODO PARA HACER CORRER EL PERSONAJE EN UNA DIRECCION A UNA VELOCIDAD CONSTANTE
     
      private void FixedUpdate()
    {
        /*if (playerRigidbody2D.velocity.x < runningSpeed)
        {
            playerRigidbody2D.velocity = new Vector2(runningSpeed,
                                                     playerRigidbody2D.velocity.y);
        }*/

        //MOVIMIENTO DEL PERSONAJE

        inputHorizontal = Input.GetAxis("Horizontal"); //variable que almacena la direccion horizontal

        if (inputHorizontal != 0)
        {
            playerRigidbody2D.AddForce(new Vector2(inputHorizontal * runningSpeed, 0f));
        }

        //VOLTEAR EL PERSONAJE


        if (inputHorizontal > 0 && !facingRight)
        {
            Flip();
        }
        else if (inputHorizontal < 0 && facingRight)
        {
            Flip();
        }
    }
    
     

    //Instruction that make the player jump
    void Jump()
    {
        if(GameManager.sharedInstance.currentGameState == GameState.inGame)
        {
            if (IsTouchingTheGround())
            {
                playerRigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); //se aplica fuerza a vector que indica la direccion a la que se quiere mover el personaje
            }                                                                            //Impulse aplica una fuerza de tipo inmediato y no constante
        }
        
    }

        
        
    

    //Method used for kwow if the player is on the ground
    bool IsTouchingTheGround()
    {
        if (Physics2D.Raycast(this.transform.position, //desde la posicion actual
                             Vector2.down,             //se crea un vector
                             1.5f,                     //se asigna una longitud
                             groundMask))              //se verifica que toque el ground mask
        {
            
            //animator.enabled = true;
            //GameManager.sharedInstance.currentGameState = GameState.inGame;
            return true;
        }
        else
        {
            
            //animator.enabled = false; // codigo para desactivar o pausar una animacion
         
            return false;
        }
    }

    //METODO PARA VOLTEAR EL PERSONAJE
    void Flip()
    {
        Vector3 characterScale = transform.localScale;
        characterScale.x *= -1;
        transform.localScale = characterScale;

        facingRight = !facingRight;
    }


}
