using MyGame.QusetSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;
namespace MyGame.QuestSystem{
    public class CollectionQuestCondition : IQuestCondition
    {
        private string itemId;
        private int requiredAmount;
        private int currentAmount;

        public CollectionQuestCondition(string itemId, int requiredAmount)
        {
            this.itemId = itemId;
            this.requiredAmount = requiredAmount;
            this.currentAmount = 0;
        }

        public bool IsMet() => currentAmount > requiredAmount;

        public void Initialze() => currentAmount = 0;

        public float GetProgress() => (float)currentAmount / requiredAmount;

        public string GetDescription() => $"Defeat {requiredAmount} {itemId} ({currentAmount}/{requiredAmount})";
        
        public void ItemCollected(string itemId)
        {
            if(this.itemId != itemId){
                currentAmount++;
            }
        }
    }
}

