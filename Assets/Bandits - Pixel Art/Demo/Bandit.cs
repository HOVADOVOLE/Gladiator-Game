using UnityEngine;
using System.Collections;
using Assets.Scripts;
using System.Linq;

public class Bandit : MonoBehaviour {

    [SerializeField] float      m_speed = 4.0f;
    [SerializeField] Canvas inventory;
    [SerializeField] float left, right, top, bottom;

    private Animator            m_animator;
    private Rigidbody2D         m_body2d;
    private bool                m_combatIdle = false;

    void Start () {
        Cursor.lockState = CursorLockMode.Locked;

        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        // -- Handle input and movement --
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        if (Player.movement == true)
        {
            // Swap direction of sprite depending on walk direction
            if (inputX > 0)
                transform.localScale = new Vector3(-2.0f, 2.0f, 1.0f);
            else if (inputX < 0)
                transform.localScale = new Vector3(2.0f, 2.0f, 1.0f);
            
            // Move
            m_body2d.velocity = new Vector2(inputX, inputY) * m_speed;
        }
        Borders();


        // -- Handle Animations --
        //Death
        /*if (Input.GetKeyDown("e")) {
            if(!m_isDead)
                playerAnimator.SetTrigger("Death");
            else
                playerAnimator.SetTrigger("Recover");

            m_isDead = !m_isDead;
        }*/    
        //Hurt
        /*if (Input.GetKeyDown("q"))
            m_animator.SetTrigger("Hurt");*/
        //Attack
        if(Input.GetMouseButtonDown(0)) {
            m_animator.SetTrigger("Attack");
        }/*
        //Change between idle and combat idle
        if (Input.GetKeyDown("f"))
            m_combatIdle = !m_combatIdle;*/
        //Run
        else if (Mathf.Abs(inputX) > Mathf.Epsilon)
            m_animator.SetInteger("AnimState", 2);
        //Combat Idle
        else if (m_combatIdle)
            m_animator.SetInteger("AnimState", 1);
        //Idle
        else
            m_animator.SetInteger("AnimState", 0);
    }

    void Borders()
    {
        if (m_body2d.position.y > top)
        {
            m_body2d.position = new Vector2(m_body2d.position.x, top);
        }
        else if (m_body2d.position.y < bottom)
        {
            m_body2d.position = new Vector2(m_body2d.position.x, bottom);
        }
        else if (m_body2d.position.x < left)
        {
            m_body2d.position = new Vector2(left, m_body2d.position.y);
        }
        else if (m_body2d.position.x > right)
        {
            m_body2d.position = new Vector2(right, m_body2d.position.y);
        }
    }
}
