using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public static InteractionManager Instance { get; private set; }

    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI promptText;
    [SerializeField] private float checkRadius = 3f;
    [SerializeField] private LayerMask interactableLayers;

    private IInteractable currentInteractable;
    private GameObject player;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void UpdatePrompt()
    {
        if (currentInteractable != null)
        {
            promptText.text = $"[E] {currentInteractable.GetInteractPrompt()}";
            promptText.gameObject.SetActive(true);
        }
        else
        {
            promptText.gameObject.SetActive(false);
        }
    }

    private void CheckInteractables()
    { 
        Collider[] colliders = Physics.OverlapSphere(player.transform.position, checkRadius, interactableLayers);
        IInteractable closest = null;
        float closetDistance = float.MaxValue;

        foreach (var col in colliders)
        {
            if(col.TryGetComponent<IInteractable>(out var interactable))
            {
                float distance = Vector3.Distance(player.transform.position, col.transform.position);

                if (distance <= interactable.GetInteractionDistane() && distance < closetDistance && interactable.CanInteract(player));
                {
                    closest = interactable;
                    closetDistance = distance;
                }
            }
        }
        currentInteractable = closest;
        UpdatePrompt();
    }
}
