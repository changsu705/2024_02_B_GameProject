using MyGame.QuestSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class ItemReward : IQuestReward
{
    private string itemId;
    private int amount;

    public ItemReward(string itemId, int amount)
    {
        this.itemId = itemId;
        this.amount = amount;
    }

    public void Grant(GameObject player)
    {
        Debug.Log($"Granted {amount} {itemId}");
    }

    public string GetDescription() => $"{amount} {itemId}";
}
