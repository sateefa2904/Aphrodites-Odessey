using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject PointA;
    public GameObject PointB;
    public float speed;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform CurrentPoint;

    void Start()
    {   
        flip();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        CurrentPoint = PointB.transform;
        anim.SetBool("IsRunning", true);
    }

    void Update()
    {
        // Calculate the direction to the current point
        Vector2 direction = (CurrentPoint.position - transform.position).normalized;

        // Set velocity based on the direction
        rb.velocity = direction * speed;

        // Check if the enemy has reached the current point
        if (Vector2.Distance(transform.position, CurrentPoint.position) < 0.5f)
        {
            // If the current point is PointB, switch to PointA
            if (CurrentPoint == PointB.transform)
            {
                flip();
                CurrentPoint = PointA.transform;
            }
            // If the current point is PointA, switch to PointB
            else if (CurrentPoint == PointA.transform)
            {
                flip();
                CurrentPoint = PointB.transform;
            }
        }
    }

    // Method to flip the enemy's direction
    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}


/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject PointA;
    public GameObject PointB;
    public float speed;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform CurrentPoint;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        CurrentPoint = PointB.transform;
        anim.SetBool("IsRunning", true);
    }

    void Update()
    {
        Vector2 point = CurrentPoint.position - transform.position;
        if(CurrentPoint == PointB.transform){
            rb.velocity = new Vector2(speed, 0);
        }
        else{
            rb.velocity = new Vector2(-speed, 0);
        }

        if(Vector2.Distance(transform.position, CurrentPoint.position) < 0.5f && CurrentPoint == PointB.transform){
            flip();
            CurrentPoint = PointA.transform;
        }
        if(Vector2.Distance(transform.position, CurrentPoint.position) < 0.5f && CurrentPoint == PointA.transform){
            flip();
            CurrentPoint = PointB.transform;
        }

        
    }


    private void flip(){
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

}*/