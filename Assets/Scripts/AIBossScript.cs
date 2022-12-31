using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBossScript : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float minimumDistance;
    [SerializeField] Transform player;
    [SerializeField] PolygonCollider2D playerCollider;
    Animator m_animator;
    [SerializeField] float scaleX;
    [SerializeField] float scaleY;
    private void Start()
    {
        m_animator = GetComponent<Animator>();
        m_animator.SetTrigger("Run");
    }

    void Update()
    {
        //Enemy Rotation
        if (player.transform.position.x < gameObject.transform.position.x)
            transform.localScale = new Vector3(scaleX, scaleY, 1.0f);
        else
            transform.localScale = new Vector3(-scaleX, scaleY, 1.0f);

        //--------------
        if (Vector2.Distance(transform.position, player.position) > minimumDistance && playerCollider.enabled == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }

        //Run animation
        else if (Mathf.Abs(speed + 1) > Mathf.Epsilon)
            m_animator.SetTrigger("Run");
    }
}
