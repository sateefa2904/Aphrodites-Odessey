using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skelenton_Controller : MonoBehaviour
{
    public float speed = 0.25f;
    Vector2 direction;

    public GameObject player;

    Rigidbody2D rb;

    public Vector2 vel;

    public Vector3 last_pos;

    public NavMeshAgent agent;
    
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        last_pos = transform.position;

        agent = GetComponent<NavMeshAgent>();        
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.updatePosition = true;
    }
    void Update()
    {
        if (player != null)
        {
            agent.SetDestination(player.transform.position);

            animator.SetFloat("Velocity_x", agent.velocity.x);
        }

        //last_pos = transform.position;
        //vel = rb.velocity;
        //rb.velocity = direction * speed * Time.deltaTime;

        //animator.SetFloat("Velocity_x", rb.velocity.x);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"Skeleton collided with {collision.gameObject.name}");
        if(collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject;
            Debug.Log($"{collision.gameObject.name} has Player tag");
        }
    }
}
