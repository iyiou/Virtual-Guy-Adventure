using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{

    public SpriteRenderer spriteBody;
    

    public void Right(){
        spriteBody.flipX = false;
    }

    public void Left(){
        spriteBody.flipX = true;
    }
}
