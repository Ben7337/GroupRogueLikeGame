using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface EntityMediatorInterface
{
    void registerPlayer(PlayerController player);
    void registerScore(ScoreScript script);
    void addScore(int addition);
    void hitPlayer(int damage, GameObject source);
    void hitEnemy(int damage, Enemy enemy);

}
