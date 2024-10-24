using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame.QusetSystem
{


    public interface IQuestCondition
    {
        bool IsMet();

        void Initialze();

        float GetProgress();

        string GetDescription();
       
    }
}
