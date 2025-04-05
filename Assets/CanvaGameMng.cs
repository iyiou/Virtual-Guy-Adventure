using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class CanvaGameMng : MonoBehaviour
{
    #region Singleton
    public static CanvaGameMng Instance; // Variável para instanciar objetos


    public void Awake()
    {
        // Instância estatica de objetos 
        if(Instance == null){ // Verifica se há uma instância na cena
            Instance = this;
            return;
        }
        Destroy(gameObject); // Destroi o GameObject existente na cena
    }
    #endregion

    public Image imgLife;
    public Sprite[] sprLifes;
    public int playerHP;


    // Start is called before the first frame update
    void Start()
    {
        playerHP = sprLifes.Length -1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Método para verificar a decrementação de HP jogador
    public void DecrementLifePlayer(){
        playerHP--; // Decrementando HP do jogador

        // Verificação de vidas totais
        if(playerHP < 1){
            // Gameover
        }
        else{
            imgLife.sprite = sprLifes[playerHP];
        }
    }
}
