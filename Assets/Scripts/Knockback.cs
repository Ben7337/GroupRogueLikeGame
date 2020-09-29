using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    [SerializeField] private float thrust = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D hit = collision.GetComponent<Rigidbody2D>();
            if (hit != null)
            {
                StartCoroutine(KnockCoroutine(hit));
            }
        }
    }

    private IEnumerator KnockCoroutine(Rigidbody2D hit)
    {
        Vector2 forceDirection = hit.transform.position - transform.position;
        Vector2 force = forceDirection.normalized * thrust;

        hit.velocity = force;
        //TakeDamage(1);
        yield return new WaitForSeconds(.3f);
        hit.velocity = new Vector2();
    }

}
    
