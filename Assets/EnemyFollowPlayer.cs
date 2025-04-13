using UnityEngine;
using UnityEngine.AI;

public class EnemyFollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float sightRange = 10f;
    [SerializeField] private LayerMask lineOfSightMask;
    [SerializeField] private Transform[] waypoints;

    private NavMeshAgent agent;
    private bool hasLineOfSight = false;
    private int currentWaypointIndex = 0;
    private Vector3 lastSeenPlayerPosition;
    private AIState currentState;

    private enum AIState
    {
        Patrolling,
        Chasing,
        Searching
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.autoBraking = false;
        MoveToNextWaypoint();
        currentState = AIState.Patrolling;
    }

    void Update()
    {
        Vector3 directionToTarget = target.position - transform.position;
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (distanceToTarget <= sightRange)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToTarget.normalized, sightRange, lineOfSightMask);
            if (hit.collider != null && hit.collider.transform == target)
            {
                hasLineOfSight = true;
                lastSeenPlayerPosition = target.position;
                currentState = AIState.Chasing;
                Debug.DrawRay(transform.position, directionToTarget, Color.green);
            }
            else
            {
                //hasLineOfSight = false;
                hasLineOfSight = true;
                lastSeenPlayerPosition = target.position;
                currentState = AIState.Chasing;
                Debug.DrawRay(transform.position, directionToTarget, Color.red);
            }
        }
        else
        {
            hasLineOfSight = false;
        }

        switch (currentState)
        {
            case AIState.Chasing:
                ChasePlayer();
                break;
            case AIState.Searching:
                SearchLastPosition();
                break;
            case AIState.Patrolling:
                Patrol();
                break;
        }
    }

    void ChasePlayer()
    {
        if (hasLineOfSight)
        {
            agent.SetDestination(target.position);
        }
        else
        {
            currentState = AIState.Searching;
            agent.SetDestination(lastSeenPlayerPosition);
        }
    }

    void SearchLastPosition()
    {
        if (!hasLineOfSight && agent.remainingDistance < 0.5f)
        {
            currentState = AIState.Patrolling;
            MoveToNextWaypoint();
        }
    }

    void Patrol()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            MoveToNextWaypoint();
        }
    }

    void MoveToNextWaypoint()
    {
        if (waypoints.Length == 0)
            return;

        agent.destination = waypoints[currentWaypointIndex].position;
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        currentState = AIState.Patrolling;
    }
}
