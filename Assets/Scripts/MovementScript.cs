using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float speed;
    public float speedDampen;
    public Animator animator;


    private Rigidbody2D rigidBody;
    private Vector3 change;
    private float xMove;
    private float yMove;

    private float attackTime = .25f;
    private float attackCount = .25f;
    private bool isAttacking= false;
    

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (change != Vector3.zero)
        {
            rigidBody.MovePosition( transform.position + change * speed * Time.deltaTime);
        }

        yMove = Input.GetAxisRaw("Vertical") *speed;
        xMove = Input.GetAxisRaw("Horizontal") *speed;
        animator.SetFloat("VertMove", yMove);

        if(Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1 || Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1){
            animator.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("lastmoveY", Input.GetAxisRaw("Vertical"));
        }

        if(isAttacking)
        {
            rigidBody.velocity = Vector3.zero;
            attackCount -=Time.deltaTime;
            if(attackCount <=0)
            {
                animator.SetBool("isAttacking", false);
                isAttacking = false;
            }    
        }

        if(Input.GetButtonDown("Fire1"))
        {
            attackCount = attackTime;
            isAttacking = true;
            animator.SetBool("isAttacking", true);
        }
    }

    


    public void move(float x, float y)
    {
        change.x = x;
        change.y = y;
    }

}
