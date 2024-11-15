using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryManager : MonoBehaviour
{
    private Inventory<IItem> PlayerInventory;
    void Start()
    {
        PlayerInventory = new Inventory<IItem>();

        PlayerInventory.AddItem(new Weapon("Sword", 1, 10));
        PlayerInventory.AddItem(new HealthPotion("Small Potion", 2, 20));
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            PlayerInventory.ListItems();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlayerInventory.UseItem(0);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            PlayerInventory.AddItem(new Weapon("Sword", 1, 10));
        }
    }
}
