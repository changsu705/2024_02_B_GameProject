using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class SkillTreeUI : MonoBehaviour
{
    public SkillTreeUI skillTree;
    public GameObject skillNodePrefabs;
    public RectTransform skillTreePanel;
    public float NodeSpacing = 100f;
    public Text SkillPointText;
    public int totalSkillPoint = 10;

    private Dictionary<string, Button> SkillButtons = new Dictionary<string, Button>();

    void Start()
    {
        InitalizeSkillTree();
        CreateSkillTreeUI();
        UpdateSkillPointsUI();
    }

    void InitalizeSkillTree()
    {
        skillTree = new SkillTreeUI();

        skillTree.AddNode(new SkillNode("fireball1", "Fireball1",
            new Skill<ISkillTarget, DamageEffect>("Fireball1", new DamageEffect(20)),
            new Vector2(0, 0), "Fireball", 1));

        skillTree.AddNode(new SkillNode("fireball1", "Fireball1",
            new Skill<ISkillTarget, DamageEffect>("Fireball2", new DamageEffect(30)),
            new Vector2(0, 1), "Fireball", 2));

        skillTree.AddNode(new SkillNode("fireball1", "Fireball1",
            new Skill<ISkillTarget, DamageEffect>("Fireball3", new DamageEffect(40)),
            new Vector2(0, 2), "Fireball", 3));

        skillTree.AddNode(new SkillNode("fireball1", "Fireball1",
            new Skill<ISkillTarget, DamageEffect>("Fireball4", new DamageEffect(50)),
            new Vector2(0, 3), "Fireball", 4));

        skillTree.AddNode(new SkillNode("fireBolt1", "fireBolt1",
            new Skill<ISkillTarget, DamageEffect>("fireBolt1", new DamageEffect(90)),
            new Vector2(1, 0), "fireBolt1", 4));

        skillTree.AddNode(new SkillNode("fireBolt2", "fireBolt2",
            new Skill<ISkillTarget, DamageEffect>("fireBolt2", new DamageEffect(90)),
            new Vector2(1, 1), "fireBolt1", 4));

        skillTree.AddNode(new SkillNode("fireBolt3", "fireBolt3",
            new Skill<ISkillTarget, DamageEffect>("fireBolt3", new DamageEffect(90)),
            new Vector2(1, 2), "fireBolt1", 4));
    }
    void CreateSkillTreeUI()
    {
        foreach (var node in skillTree.Nodes)
        {
            CreateSkillNodeUI(node);
        }
    }

    void CreateSkillNodeUI(SkillNode node)
    {
        GameObject nodeObj = Instantiate(skillNodePrefabs, skillTreePanel);
        RectTransform rectTrnasform = nodeObj.GetComponent<RectTransform>();
        RectTransform.anchoredPosition = node.Posistion * NodeSpacing;

        Button button = nodeObj.GetComponent<Button>();
        Text text = nodeObj.GetComponentInChildren<Text>();
        text.text = node.Name;

        SkillButtons[node.Id] = button;
    }

    private void OnSkillNodeClicked(string skillld)
    {
        SkillNode node = skillTree.GetNode(skillld);

        if (node == null) return;

        if(node.isUnlocked)
        {
            if(skillTree.LockSkill(skillld)
            {
                totalSkillPoint++;
                UpdateSkillPointsUI();
                UpdateNodeUi(node);
                UpdateConnecteSkills(skillld);
            }
            else
            {
                Debug.Log("관련 연계 스킬이 아ㅣㅆ어서 해제가 ㅇ ㅏㄴ됩니다.");
            }
        }
        else if(totalSkillPoint >- && CanUnlockSkill(node))
        {
            if (skilllTree.UnlockSkill*(skillld)
                {
                totalSkillPoint--;
                UpdateSkillPointsUI();
                UpdateNodeUI(node);
                UpdateConnerctedSkills(skillld);
            }))
        }
    }
    private void UpdateNodeUI(SkillNode Node)
    {
        if (SkillButtons.TryGetValue(Node.id, out Button button))
        {
            bool canUnlock = !Node.isUnlocked && CanUnlockSkill(Node);
            button.interactable = (canUnlock && totalSkillPoint > 0) || Node.isUnlocked;
            button.GetComponent<image>().color = Node.isUnlocked ? Color.green : (canUnlock ? Color.yellow : Color.red);
        }
    }

    private bool CanUnlockSkill(SkillNode Node)
    {
        foreach (var requiredSkillld in Node.RequiredSkillld)
        {
            if(!skillTree.IsSkillUnlock(requiredSkillld))
            {
                return false;
            }
            
        }
        return false;
    }

    void UpdateSkillPointsUI()
    {
        SkillPointText.text = $"Skill Points: {totalSkillPoint}";
    }

    void UpdateConnerctedSkills(string skillld)
    {
        foreach(var node in skillTree.Nodes)
        {
            if(node.RequiredSkillds.Contains(skillld))
            {
                UpdateNodeUI(node);
            }
        }
    }
}
