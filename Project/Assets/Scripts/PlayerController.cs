using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public EntityMediatorInterface entityMediator;
    private MovementScript movementScript;
    public GameObject bomb;
    public HealthBar healthbar;

    public static PlayerController instance;
    public float maxHealth = 100;
    public float currentHealth = 100;
    public float invincibilityFrames = 7;
    public float lastHit = 0;
    

    void Awake(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(this);
        }
        else {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        entityMediator = entityMediator = GameObject.Find("Mediator").GetComponent<EntityMediator>();
        entityMediator.registerPlayer(this);
        currentHealth = maxHealth;
        healthbar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
        healthbar.SetMaxHealth(maxHealth);
        movementScript = gameObject.GetComponent<MovementScript>();
        bomb.GetComponent<BombScript>().map = GameObject.Find("MapController").GetComponent<MapGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveCharacter();
        if (Input.GetButtonDown("Fire3"))
        {
            Instantiate(bomb, new Vector3(0,0,0) + this.transform.position, Quaternion.identity);
        }
        lastHit++;
    }

    void moveCharacter()
    {
        try{
            movementScript.move(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
        catch
        {
            movementScript = gameObject.GetComponent<MovementScript>();
        }
    }

    void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
        if(currentHealth <= 0)
        {
            die();
        }
    }

    public void hit(float damage, GameObject source)
    {
        if (lastHit > invincibilityFrames)
        {
            TakeDamage(damage);
            lastHit = 0;
        }
    }

    private void die()
    {
        SceneManager.LoadScene("Menu");
    }
}
