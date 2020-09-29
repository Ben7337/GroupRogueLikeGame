using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstEnemy : Enemy
{
    public float attackRadius = .05f;


    public override void attack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(gameObject.transform.position, attackRadius);

        foreach (Collider2D collider in colliders)
        {
            //Debug.Log(collider.gameObject.tag);
            if (collider.gameObject.CompareTag("Player"))
            {
                Debug.Log(collider.gameObject.tag);
                entityMediator.hitPlayer(baseAttack, this.gameObject);
            }
        }
    }

    void Update()
    {
        strategy.function(this);
        target = GameObject.FindGameObjectWithTag("Player").transform;
        CheckDistance();
    }

    void CheckDistance()
    {
        if(Vector3.Distance(target.position, transform.position) <= aggroRadius)
        {
            if (!(strategy is AttackStrategy))
                strategy = new AttackStrategy();
        }
        else
            if(!(strategy is RoamStrategy))
                strategy = new RoamStrategy();
    }

    
}
