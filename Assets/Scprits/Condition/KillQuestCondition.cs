using MyGame.QusetSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillQuestCondition : IQuestCondition
{

    private string enemyType;
    private int requiredKills;
    private int currentkills;

    public KillQuestCondition(string enemyType, int requiredKills)
    {
        this.enemyType = enemyType;
        this.requiredKills = requiredKills;
        this.currentkills = 0;
    }

    public bool IsMet() => currentkills >= requiredKills;

    public void Initialze() => currentkills = 0;

    public float GetProgress() => (float)currentkills / requiredKills;

    public string GetDescription() => $"Defeat {requiredKills} {enemyType} ({currentkills}/{requiredKills}";

    public void EnemyKilled(string enemyType)
    {
        if(this.enemyType == enemyType)
        {
            currentkills++;
        }
    }

}
