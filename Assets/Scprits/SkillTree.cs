using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillNode
{ 

    public string Id { get ; private set; }
    public string Name { get; private set; }
    public object Skill {  get; private set; }
    public List<string> RequiredSkillds { get; private set; }

    public bool isUnlocked { get; set; }

    public Vector2 Position { get; set;}

    public int SkillLevel { get; private set; }

    public bool ISMaxLevel { get; set; }

    public SkillNode(string id, string name, object skill , Vector2 position , string skillSeries, int skillLevel, List<string> requiredSkilllds = null)
    {
        Id = id ; 
        Name = name ;
        Skill = skill;
        Position = position ;
        SkillSeries = skillSeries;
        RequiredSkillds = requiredSkilllds ?? new List<string>();
        isUnlocked = false;

    }

}
