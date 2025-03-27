using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    // Verificar Colisão

    // Verificar se colidiu com o corpo do player e efetua dano
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            collision.gameObject.GetComponent<PlayerDamage>().Damage();
        }         
    }
}
