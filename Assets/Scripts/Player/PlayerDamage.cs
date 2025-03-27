using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public PlayerLogic playerLogic; // Variável para acessar metodos da lógica do jogador
    
    //Efetuar dano ao jogador
    public void Damage(){
        
        playerLogic.ResetPhysicalMove();    // Resetar forças
        
        playerLogic.ThrowPlayer();  // Arremessar

    }
}
