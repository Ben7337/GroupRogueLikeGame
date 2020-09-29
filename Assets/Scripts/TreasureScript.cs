using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureScript : MonoBehaviour
{

    public EntityMediatorInterface entityMediator;

    private void Start()
    {
        entityMediator = GameObject.Find("Mediator").GetComponent<EntityMediator>();
    }

    void OnTriggerEnter2D(Collider2D collisionObj){
        if(collisionObj.gameObject.CompareTag("Player")){
            entityMediator.addScore(100);
            Destroy(gameObject);
        }
    }
}
