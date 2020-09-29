using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public float speedDampen;
    public Animator animator;


    private Rigidbody2D rigidBody;
    private Vector3 change;
    private float xMove;
    private float yMove;
    public float vertMove = 0f;
    

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
        change = Vector3.zero;
    }

    public void move(float x, float y)
    {
        change.x = x;
        change.y = y;
    }
}
