using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitPlayer : MonoBehaviour
{
    public bool isLimit;

    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6){
            isLimit = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6){
            isLimit = false;
        }
    }
}
