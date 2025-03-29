using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
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
    public float jumpForceY; // Variável que define a força de pulo eixo Y
    private float jumpForceX; // Variável que define a força de pulo eixo X
    private bool isJumping; // Variável de estado de pulo
    private bool doubleJump; // Variável de pulo duplo
    private bool wallJump; // Variável de pulo na parede
    private Coroutine coroutineJump; // Variável para limitar o tempo de pulo 
    public Rigidbody2D rigidbody2d; // Variável para acessar propriedades físicas do player;

    // Animação
    public AnimationPlayer animationPlayer;



    // Start is called before the first frame update
    void Start()
    {
        wallJump = true; // Habilitando pulo na parede ao iniciar o jogo
    }

    // Update is called once per frame
    void Update()
    {
        // Move
        Move();
        Jump();
        WallJump();
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

        // Verificar colisão/ground <-> Animações de movimentação
        if (footCollision.isLimit == true)
        {
            if (eixoX != 0)
            {
                animationPlayer.RunningPlayer(); // Ativar animação correndo
            }
            else
            {
                animationPlayer.IdlePlayer(); // Ativa animação parado
            }
        }
        else{
            animationPlayer.FallingPlayer();
        }


        // Movimentar PLayer
        Vector3 direction = new Vector3(eixoX, 0, 0);
        transform.position += direction * speed * Time.deltaTime;

    }

    private void Jump()
    {
        // Input jump
        if (Input.GetButtonDown("Jump"))
        {
            if (footCollision.isLimit == true && isJumping == false)
            { // Verifica se o player estão no chão
                animationPlayer.JumpingPlayer();
                
                isJumping = true;


                doubleJump = true;

                ActivateJumpTime();
            }
            else{

                if(doubleJump == true){
                    isJumping = true;
                    doubleJump = false;

                    ActivateJumpTime(); 
                }
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
        isJumping = false;// Desativa a variável de pulo
        jumpForceX = 0; // Zerar a força no Eixo X, após o reset
    }

    // 
    private void Jumping()
    {
        if (isJumping == true)
        {
            if (headCollision.isLimit == false) // Verifica se a há colisão acima do player
            {
                ResetPhysicalMove(); // zerar forças nos eixos do rigidbody2D                
                rigidbody2d.gravityScale = 0; // Altera a propriedade para fazer o player subir
                Vector3 jumpDirection = new Vector3(jumpForceX, jumpForceY, 0); // Direcionar o pulo
                transform.position += jumpDirection * speed * Time.deltaTime; // Pulo
            }
        }
        else
        {
            rigidbody2d.gravityScale = 4; // Faz o player cair
        }
    }

    private void WallJump(){
        // Verificar se esta no chão para pular na parede novamente
        if(footCollision.isLimit == true){
            wallJump = true;
        }
        // Verifica se está habilitado pular na parede
        if(wallJump == false){
            return;
        }
        // Verifica condições para efetuar pulo na parede
        if(footCollision.isLimit == false && headCollision.isLimit == false &&
        (leftCollision.isLimit == true || rightCollision.isLimit == true)){
            // Obter entrada do usuário para efetuar pulo
            if(Input.GetButtonDown("Jump")){
                //Aplicar força eixoX na direção oposta da parede encostada
                if(rightCollision.isLimit == true){
                    jumpForceX = jumpForceY * -1;
                }
                else if(leftCollision.isLimit == true){   
                    jumpForceX = jumpForceY;
                }
                else{
                    jumpForceX = 0;
                }
                isJumping = true;   // Habilitar pulo
                
                doubleJump = true;  // Habilitar pulo duplo

                wallJump = false;   // Desabilitar pulo na parede

                ActivateJumpTime(); // Novo tempo de pulo
            }

        }
    }
    public void ThrowPlayer(){
        int sortearValor = new System.Random().Next(0, 2);  // Sortear numero entre (0,1), direção de arremesso 

        int directionX = sortearValor == 0? - 1000: 1000;   // Definir direção em X arremesso
        rigidbody2d.AddForce(new Vector2(directionX, 1000));// Aplica força no player

    }
    // Função para zerar as forças nos eixos do rigidbody2D    
    public void ResetPhysicalMove(){
        rigidbody2d.velocity = Vector3.zero;
    }

}
