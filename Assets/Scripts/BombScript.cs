using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BombScript : MonoBehaviour
{
    public float waitTime = 2;
    public MapGenerator map;
    public float radius = 1;
    public AudioSource explosionSound;

    public EntityMediatorInterface entityMediator;

    // Start is called before the first frame update
    void Start()
    {
        entityMediator = entityMediator = GameObject.Find("Mediator").GetComponent<EntityMediator>();
        explosionSound = GetComponent<AudioSource>();
        Invoke("explode", waitTime);

    }

    void explode() 
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(gameObject.transform.position, radius);
        explosionSound.Play();

        for (float i = -radius; i <= radius; i += (float)0.25)
        {
            for (float j = -radius; j <= radius; j += (float)0.25)
            {
                try
                {
                    map.destroyTileFromWorldSpace(new Vector3(this.transform.position.x + i, this.transform.position.y + j, 0));
                }
                catch
                {
                    map = GameObject.Find("MapController").GetComponent<MapGenerator>();
                    map.destroyTileFromWorldSpace(new Vector3(this.transform.position.x + i, this.transform.position.y + j, 0));
                }
            }
        }

        foreach (Collider2D collider in colliders)
        {

            if (collider.gameObject.CompareTag("Player"))
            {
                entityMediator.hitPlayer(50, this.gameObject);
            }
            else if (collider.gameObject.CompareTag("Enemy"))
            {
                entityMediator.hitEnemy(50, collider.gameObject.GetComponent<Enemy>());
            }


            Debug.Log(collider.GetType());
            //collider.gameObject.GetComponent<Tile>;
            //Destroy(collider.gameObject);
            try
            {
                collider.GetComponent<Rigidbody2D>().AddRelativeForce((collider.transform.position - this.transform.position).normalized * 700);
            }
            catch { }
            if (collider.GetType() is BoxCollider2D)
            {
                Debug.Log("test");
                
            }
        }
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Knob");
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().addTrauma(50);
        //Destroy(GetComponent<SpriteRenderer>(), 3f);
        Destroy(this.gameObject, 2f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
