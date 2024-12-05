using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class BattleSystem : MonoBehaviour
{

    public static BattleSystem Instance { get; private set; }

    public Character[] players = new Character[3];
    public Character[] enemies = new Character[3];

    public Button attacjBtn;
    public TextMeshProUGUI turnText;
    public GameObject damageTextPrefab;
    public Canvas uiCanvas;

    Queue<Character> turnQueue = new Queue<Character>();
    Character currentChar;
    bool selectingTarget;

    void Awake() => Instance = this;

    //혅재 턴 캐릭터 반환
    public Character GetCurrentChar() => currentChar;
    void OnAttackClick() => selectingTarget = true;
    void Start()
    {
        var orderedChars = players.Concat(enemies).OrderByDescending(c => c.speed);

        foreach (var c in  orderedChars)
        {
            turnQueue.Enqueue(c);
        }
        attacjBtn.onClick.AddListener(OnAttackClick);
        NextTrun();
    }

    void Update()
    {
        if (selectingTarget && Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Character target = hit.collider.GetComponent<Character>();
                if (target != null)
                {
                    currentChar.Attack(target);
                    ShowDamageText(target.transform.position, "20");
                    selectingTarget = false;
                    NextTrun();
                }
                {
                    
                }
            }
        }
    }
    void NextTrun()
    {
        currentChar = turnQueue.Dequeue();
        turnQueue.Enqueue(currentChar);
        turnText.text = turnText.text = $"{currentChar.name}의 턴(Speed:{currentChar.speed})";

        if (currentChar.isPlayer)
        {
            attacjBtn.gameObject.SetActive(true);
        }
        else
        {
            attacjBtn.gameObject.SetActive(false);
            Invoke("EnemeAttack", 1f);
        }
    }

    void ShowDamageText(Vector3 position, string damage)
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(position);
        GameObject damageObj = Instantiate(damageTextPrefab, screenPos, Quaternion.identity, uiCanvas.transform);
        damageObj.GetComponent<TextMeshProUGUI>().text = damage;
        Destroy(damageObj, 1f);
    }

    void EnemyAttack()
    {
        var aliveTargets = players.Where(p => p.gameObject.activeSelf).ToArray();

        if (aliveTargets.Length == 0) return;

        var target = aliveTargets[Random.Range(0,aliveTargets.Length)]; ;
        ShowDamageText(target.transform.position, "20");
        NextTrun();
    }

}