using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_move : MonoBehaviour
{
    public float speed;
    public bool MoveRight;

    void Update()
    {
        if(MoveRight){
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2 (-6,6);
        }
        else{
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2 (6,6);
        }
    }

    void OnTriggerEnter2D(Collider2D trig){
        if(MoveRight){
            MoveRight = false;
        }
        else{
            MoveRight = true;
        }
    }
}
