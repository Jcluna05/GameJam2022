using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.AI;

public class PoliceStatementsTree : MonoBehaviour
{
    public enum EnemyStates { RandomWalk, ChasePlayer, AttackPlayer };
    public EnemyStates currentState = 0;
    public NavMeshAgent agent;
    public Animator animator;
    private float cronometro;
    private Quaternion angulo;
    public int walkrut;
    private float grado;
    public AudioSource audio;

    private Sight _sight;
    //public Transform playerTransform;
    public float playerAttackDistance;

    private void Awake()
    {
        _sight = GetComponent<Sight>();
        agent = GetComponentInParent<NavMeshAgent>();
        animator = GetComponentInParent<Animator>();

    }
    private void Update()
    {
        switch (currentState)
        {
            case EnemyStates.RandomWalk:
                RandomWalk();
                break;
            case EnemyStates.ChasePlayer:
                ChasePlayer();
                break;
            case EnemyStates.AttackPlayer:
                AttackPlayer();
                break;
            default:
                break;
        }
    }
    void RandomWalk()
    {
        animator.SetFloat("Velocity", 0f);
        animator.SetBool("onAttack", false);
        cronometro += 1 * Time.deltaTime;
        if (cronometro >= 4)
        {
            agent.isStopped = false;
            walkrut = Random.Range(0, 2);
            cronometro = 0;
        }
        switch (walkrut)
        {
            case 0:
                agent.isStopped = true;
                if (_sight.detectedTarget != null)
                {
                    currentState = EnemyStates.ChasePlayer;
                    cronometro = 0;
                }
                break;
            case 1:
                
                grado = Random.Range(0, 360);
                angulo = Quaternion.Euler(0, grado, 0);
                walkrut++;
                break;
            case 2:
                animator.SetFloat("Velocity", 0.5f);
                animator.SetBool("onAttack", false);
                agent.isStopped = false;
                if (_sight.detectedTarget != null)
                {

                    currentState = EnemyStates.ChasePlayer;
                    cronometro = 0;
                }
                agent.transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                agent.transform.Translate(Vector3.forward * 2 * Time.deltaTime);
                break;
            default:
                
                if (_sight.detectedTarget != null)
                {
                    currentState = EnemyStates.ChasePlayer;
                }
                // float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
                float distanceToPlayer = Vector3.Distance(transform.position, _sight.detectedTarget.transform.position);

                if (distanceToPlayer < playerAttackDistance)
                {
                    currentState = EnemyStates.AttackPlayer;
                }
                break;

        }
    }
    public void ChasePlayer()
    {

        audio.Play();
        animator.SetBool("onAttack", false);

        animator.SetFloat("Velocity", 1f);
        Debug.Log("Chase player");
        if (_sight.detectedTarget == null)
        {
            RandomWalk();
        }
        else
        {
            agent.isStopped = false;
            agent.SetDestination(_sight.detectedTarget.transform.position);
            float distanceToPlayer = Vector3.Distance(transform.position, _sight.detectedTarget.transform.position);
            if (distanceToPlayer < playerAttackDistance)
            {
                currentState = EnemyStates.AttackPlayer;
            }
        }
        
    }
    void AttackPlayer()
    {
        animator.SetFloat("Velocity", 0f);
        animator.SetBool("onAttack", true);
        agent.isStopped = true;
        Debug.Log("Attack Player");
        if (_sight.detectedTarget == null)
        {
            RandomWalk();
        }
        else
        {
            LookAt(_sight.detectedTarget.transform.position);
            float distanceToPlayer = Vector3.Distance(transform.position, _sight.detectedTarget.transform.position);
            if (distanceToPlayer > playerAttackDistance)
            {
            currentState = EnemyStates.ChasePlayer;
            }
        }
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, playerAttackDistance);
    }

    void LookAt(Vector3 targetpos)
    {
        if (Time.timeScale > 0)
        {
            Vector3 directionToLook = Vector3.Normalize(targetpos - transform.position);
            directionToLook.y = 0;
            transform.parent.forward = directionToLook;
        }
    }
}