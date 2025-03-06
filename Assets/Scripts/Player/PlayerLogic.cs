using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerLogic : MonoBehaviour
{
    // Variavel de controle
    public Rotation flipSprite;
    public LimitPlayer headCollision;
    public LimitPlayer rightCollision;
    public LimitPlayer leftCollision;
    public LimitPlayer footCollision;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Move
        move();

    }
    //Movimentação do player
    private void move()
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
}
