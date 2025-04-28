using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerController : MonoBehaviour
{
    private PlayerLogic playerLogic;
    private AnimationPlayer animationPlayer;
    private PlayerDamage playerDamage;


    // Propriedades de acesso
    public PlayerLogic PlayerLogic => playerLogic;
    public AnimationPlayer AnimationPlayer => animationPlayer;
    public PlayerDamage PlayerDamage => playerDamage;
   

    void Awake()
    {
        //Obeter referência
        playerLogic = GetComponent<PlayerLogic>(); // Jogador 
        animationPlayer = GetComponentInChildren<AnimationPlayer>(); // Animações
        playerDamage = GetComponent<PlayerDamage>(); // Dano ao Jogador
    }

}
