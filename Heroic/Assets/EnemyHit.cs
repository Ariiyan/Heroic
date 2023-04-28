using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHit : MonoBehaviour
{
    public float attackRange = 2f;
    public float attackCooldown = 3f;
    public float despawnDelay = 5f;
    public float health = 100f;
    public float damage = 20f;

    public AudioSource EnemyDie;
    private GameObject player;
    private Animator animator;
    private NavMeshAgent navMeshAgent;
    private Rigidbody[] ragdollRigidbodies;
    private Collider[] ragdollColliders;
    private Collider mainCollider;
    private float attackTimer;
    private bool isDead = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        mainCollider = GetComponent<Collider>();

        ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();
        ragdollColliders = GetComponentsInChildren<Collider>(true);

        SetRagdollEnabled(false);
    }

    private void Update()
    {




        if (isDead) return;

        navMeshAgent.SetDestination(player.transform.position);
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= attackRange)
        {
            navMeshAgent.isStopped = true;
            attackTimer += Time.deltaTime;

            if (attackTimer >= attackCooldown)
            {
                animator.SetBool("IsAttacking", true);
                attackTimer = 0;
                // Apply damage to the player, if needed
            }
        }
        else
        {
            navMeshAgent.isStopped = false;
            animator.SetBool("IsAttacking", false);
        }

        //animator.SetFloat("Speed", navMeshAgent.velocity.magnitude);
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if (health <= 0 && !isDead)
        {
            EnemyDie.PlayOneShot(EnemyDie.clip);
            Die();
        }


        /*if (health <= 0 && !isDead)
        {
            EnemyDie.Play();
            Destroy(EnemyDie);
            Die();
        }*/
    }

    /* private void OnTriggerEnter(Collider other)
     {
        if (isDead) return;

         if (other.gameObject.CompareTag("Sword"))
         {

             TakeDamage(damage);
             print("hit");
         }
     }

         */

    private void OnTriggerEnter(Collider other)
    {
        if (isDead) return;

        if (other.gameObject.CompareTag("Sword"))
        {
            FindObjectOfType<UIManager>().EnemyHit();
            TakeDamage(damage);
            print("hit");
        }
    }

    private void Die()
    {
        isDead = true;
        animator.enabled = false;
        navMeshAgent.enabled = false;
        SetRagdollEnabled(true);

        Invoke("Despawn", despawnDelay);
    }

    private void Despawn()
    {
        Destroy(gameObject);
    }

    private void SetRagdollEnabled(bool enabled)
    {
        mainCollider.enabled = !enabled;

        foreach (Rigidbody rb in ragdollRigidbodies)
        {
            rb.isKinematic = !enabled;
        }

        foreach (Collider col in ragdollColliders)
        {
            if (col == mainCollider)
            {
                continue;
            }

            col.enabled = enabled;
        }
    }



}
