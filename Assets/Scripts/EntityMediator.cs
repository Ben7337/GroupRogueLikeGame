using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMediator : MonoBehaviour , EntityMediatorInterface
{
    public PlayerController player;
    public ScoreScript scoreScript;

    public void addScore(int addition)
    {
        scoreScript.addScore(addition);
    }

    public void hitEnemy(int damage, Enemy enemy)
    {
        enemy.hit(damage);
    }

    public void hitPlayer(int damage, GameObject source)
    {
        player.hit(damage, source);
    }

    public void registerPlayer(PlayerController player)
    {
        this.player = player;
    }

    public void registerScore(ScoreScript script)
    {
        scoreScript = script;
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
