using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public FloatValue maxHealth;
    public float health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;
    public float aggroRadius;
    public Transform target;
    
    private EnemyMovement movementScript;
    public EnemyStrategy strategy;
    public EntityMediatorInterface entityMediator;

    public abstract void attack();

    private void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            entityMediator.addScore(10);
            Destroy(gameObject);
        }
    }

    //public void Knock(Rigidbody2D myRigidbody, float knock)
    public void moveCharacter(Vector2 vector)
    {
        vector = vector.normalized;
        movementScript.move(vector.x, vector.y);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        entityMediator = entityMediator = GameObject.Find("Mediator").GetComponent<EntityMediator>();
        strategy = new IdleStrategy();
        movementScript = gameObject.GetComponent<EnemyMovement>();
        movementScript.speed = moveSpeed;
    }

    public void hit(int damage)
    {
        TakeDamage(damage);
    }

    public Vector2 getTargetVector()
    {
        return (target.position - this.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        strategy.function(this);
    }
}
