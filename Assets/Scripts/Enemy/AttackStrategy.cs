using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStrategy : EnemyStrategy
{
    public void function(Enemy self)
    {
        self.moveCharacter(self.getTargetVector());
        self.attack();
    }
}
