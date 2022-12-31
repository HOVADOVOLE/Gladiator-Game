using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [SerializeField] float attackTime;
    Animator m_animator;
    [SerializeField] Transform player;
    [SerializeField] float attackDistance;
    void Start()
    {
        m_animator = GetComponent<Animator>();
    }
    void Update()
    {
        if(Vector2.Distance(transform.position, player.position) < attackDistance)
        {
            StartCoroutine(AttackCooldown());
        }
    }
    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(attackTime);
        Attack();
    }

    void Attack()
    {
        m_animator.SetTrigger("Attack");
    }
}
