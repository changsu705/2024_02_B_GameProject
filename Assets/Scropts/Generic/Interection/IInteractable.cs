using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    string GetInteractPrompt();
    void ONInteract(GameObject player);
    float GetInteractionDistane();
    bool CanInteract(GameObject player);
}