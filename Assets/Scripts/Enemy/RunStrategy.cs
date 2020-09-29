using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : EnemyStrategy
{
    public void function(Enemy self)
    {
        self.moveCharacter(-self.getTargetVector());
    }

}
