using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Character : MonoBehaviour
{
    public bool isPlayer;
    public int hp = 100;
    public int speed;

    TextMeshProUGUI nameText;
    TextMeshProUGUI hpText;
    Vector3 startPos;


    void SetupNameText()
    {
        GameObject textObj = new GameObject("NameText");
        textObj.transform.SetParent(BattleSystem.Instance.uiCanvas.transform);
        nameText = textObj.AddComponent<TextMeshProUGUI>();
        nameText.text = isPlayer ? "P" : "E";
        nameText.fontSize = 36;
        nameText.alignment = TextAlignmentOptions.Center;

        GameObject hpObj = new GameObject("HpText");
        hpObj.transform.SetParent(BattleSystem.Instance.uiCanvas.transform);
        hpText = hpObj.AddComponent<TextMeshProUGUI>();
        hpText.fontSize = 36;
        hpText.alignment = TextAlignmentOptions.Center;
    }

    // Start is called before the first frame update
    void Start()
    {
        SetupNameText();
        startPos = transform.position;
    }

    IEnumerator AttackRoutine(Character target)
    {
        Vector3 attackPos = target.transform.position + (target.transform.position - transform.position).normalized * 1.5f;
        float moveTime = 0.3f;
        float elapsed = 0;

        while (elapsed < moveTime)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / moveTime;
            transform.position = Vector3.Lerp(attackPos, startPos, t);
            yield return null;
        }
        transform.position = startPos;
    }

    public void Attack(Character target)
    {
        if (!target.gameObject.activeSelf) return;
        StartCoroutine(AttackRoutine(target));
    }

    private void Update()
    {
        if (!gameObject.activeSelf)
        {
            if (nameText != null) Destroy(nameText.gameObject);
            if (hpText != null) Destroy(hpText.gameObject);
            return;
        }

        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position + Vector3.up * 2);
        nameText.transform.position = screenPos;
        hpText.transform.position = screenPos + Vector3.down * 30;

        nameText.color = (BattleSystem.Instance.GetCurrentChar() == this) ? Color.green : Color.white;
        hpText.text = hp.ToString();
    }
}
