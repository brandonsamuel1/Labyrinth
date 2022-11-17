using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToGoal : MonoBehaviour
{
    public Transform goal;
    public Transform goal2;
    private Animator animator;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("Starting...")
        animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("collectible"))
        {
            Destroy(other.gameObject);
            agent.destination = goal2.position;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (agent.hasPath)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }
}
