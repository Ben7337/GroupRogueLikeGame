using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoamStrategy : MonoBehaviour, EnemyStrategy
{

    Vector2 target = new Vector2(1, 1);
    float angle = 0;


    public void function(Enemy self)
    {        
        if (Physics2D.Raycast(self.transform.position + ((new Vector3(target.x, target.y, 0)).normalized / 6), target, 1f))
        {
            Debug.DrawRay(self.transform.position + ((new Vector3(target.x, target.y, 0)).normalized / 6), target.normalized);
            //Debug.Log(target);
            //Debug.Log(true);
            //angle = angle + 2;
            target = rotateVector(target, 4);
        }
        //Debug.Log(target + "" + angle);
        target = rotateVector(target, -.05f);
        self.moveCharacter(target);
    }

    public Vector2 rotateVector(Vector2 original, float angle)
    {
        float radian = angle * Mathf.Deg2Rad;
        float x = original.x * Mathf.Cos(radian) - original.y * Mathf.Sin(radian);
        float y = original.x * Mathf.Sin(radian) + original.y * Mathf.Cos(radian);
        return new Vector2(x, y);
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
