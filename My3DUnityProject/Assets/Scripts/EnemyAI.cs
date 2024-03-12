using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField]
    private Transform[] waypointTargets;
    [SerializeField]
    private State state;
    [SerializeField]
    int index;
    [SerializeField]
    float delay;

    [SerializeField]
    float walkSpeed = 2f;
    [SerializeField]
    float runSpeed = 3.5f;
    [SerializeField]
    float viewRadius = 6f;

    [SerializeField]
    LayerMask PlayerMask;
    [SerializeField]
    LayerMask ObstacleMask;

    [SerializeField] Transform m_PlayerPosition;
    [SerializeField] HealthBarUI pHealthBarUI;
    [SerializeField] HealthBarUI eHealthBarUI;
    [SerializeField] ShopManager shopManager;



    public enum State
    {
        PATROL,
        ALERT,
    }

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        agent.isStopped = false;
        agent.speed = walkSpeed;
    }

    private void Update()
    {

        switch (state)
        {
            default:

            case State.PATROL:
                patrolState();
                SearchPlayer();

                break;

            case State.ALERT:
                ChasePlayer(m_PlayerPosition);
                SearchPlayer();

                break;
        }

        if (eHealthBarUI.DynamicHealthBarAmount <= 0)
        {
            shopManager.addPlayerCoins(100);
            Destroy(gameObject);
        }

    }

    private void patrolState()
    {
        //find the waypoint and go to it
        Vector3 target;
        agent.speed = walkSpeed;

        index = index % waypointTargets.Length;
        target = waypointTargets[index].position;

        agent.SetDestination(target);

        // Check if enemy reached the destination
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    delay += Time.deltaTime;
                    if (delay > 1.5f)
                    {
                        //iterate waypoints with delay
                        index++;
                        delay = 0f;
                    }
                }
            }
        }
    }

    private void ChasePlayer(Transform player)
    {
        agent.SetDestination(player.position);

        //change speed if within the sphere
        if (Vector3.Distance(transform.position, player.position) <= viewRadius)
        {
            agent.isStopped = false;
            agent.speed = runSpeed;
        }
        //go back patrol
        else
        {
            state = State.PATROL;
        }

        //damage the player if too close
        if (Vector3.Distance(transform.position, player.position) <= viewRadius / 2)
        {
            agent.isStopped = false;
            agent.speed = runSpeed;
            pHealthBarUI.minusHealth(10 * Time.deltaTime);
        }
    }

    private void SearchPlayer()
    {
        Collider[] playerInRange = Physics.OverlapSphere(transform.position, viewRadius, PlayerMask);

        for (int i = 0; i < playerInRange.Length; i++)
        {
            //check if player is within the sphere
            Transform player = playerInRange[i].transform;

            state = State.ALERT;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
        Gizmos.DrawWireSphere(transform.position, viewRadius);
    }
}