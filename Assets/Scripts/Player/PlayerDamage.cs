using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerDamage : MonoBehaviour
{
    public PlayerLogic playerLogic; // Variável para acessar metodos da lógica do jogador
    
    public AnimationPlayer animationPlayer;
    
    //Efetuar dano ao jogador
    public void Damage(){
        
        animationPlayer.Damage(); // Ativar animação de dano
        playerLogic.ResetPhysicalMove();    // Resetar forças
        
        playerLogic.ThrowPlayer();  // Arremessar

    }
}
