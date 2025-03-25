using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerLogic : MonoBehaviour
{
    // Variaveis de controle
    public Rotation flipSprite; // Variável de girar sprite
    public LimitPlayer headCollision; // Variável de informação de limite
    public LimitPlayer rightCollision;
    public LimitPlayer leftCollision;
    public LimitPlayer footCollision;
    public float speed;
    public float jumpY; // Variável que define a força de pulo
    private bool isJumping; // Variável de estado de pulo
    
    public bool doubleJump;
    private Coroutine coroutineJump; // Variável para limitar o tempo de pulo 

    public Rigidbody2D rigidbody2d; // Variável para acessar propriedades físicas do player;
    
    
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Move
        Move();
        Jump();

    }
    //Movimentação do player
    private void Move()
    {
        // Input 
        float eixoX = Input.GetAxis("Horizontal");

        // Verifica se o player está colidindo com a parede
        if (eixoX > 0 && rightCollision.isLimit == true) { eixoX = 0; }
        else if (eixoX < 0 && leftCollision.isLimit == true) { eixoX = 0; }

        // Flip do Player 
        if (eixoX > 0)
        {
            flipSprite.Right();
        }
        else if (eixoX < 0)
        {
            flipSprite.Left();
        }
        Vector3 direction = new Vector3(eixoX, 0, 0);
        transform.position += direction * speed * Time.deltaTime;

    }

    private void Jump()
    {
        // Input jump
        if (Input.GetButtonDown("Jump"))
        {
            if (footCollision.isLimit == true && isJumping == false)
            {
                isJumping = true;



                ActivateJumpTime();
            }


        }
        // Pular
        Jumping();

    }
    
    // Reset do pulo
    private void ActivateJumpTime()
    {
        if (coroutineJump != null)
        {
            StopCoroutine(coroutineJump);
        }
        coroutineJump = StartCoroutine(JumpTime());
    }
    
    // Contador para tempo de pulo
    private IEnumerator JumpTime()
    {
        yield return new WaitForSeconds(0.3f); // Permitir 0.3s para o player pular
        isJumping = false;// desativa a variável de pulo
    }


    private void Jumping()
    {
        if (isJumping == true)
        {
            if (headCollision.isLimit == false)
            { // Verifica se a há colisão acima do player
                GetComponent<Rigidbody2D>().velocity = Vector3.zero; // |erar forças nos eixos do rigidbody2D                
                GetComponent<Rigidbody2D>().gravityScale = 0; // Altera a propriedade para fazer o player subir
                Vector3 jumpDirection = new Vector3(0, jumpY, 0); // Direcionar o pulo
                transform.position += jumpDirection * speed * Time.deltaTime; // Pulo
            }
            else
            {
                GetComponent<Rigidbody2D>().gravityScale = 4; // Faz o player cair
            }

        }
    }

}
