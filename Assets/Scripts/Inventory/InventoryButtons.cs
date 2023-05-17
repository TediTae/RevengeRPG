using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryButtons : MonoBehaviour
{
    GameManagerTwo gameManager;
    Inventory inventtory;

    void Start()
    {
        gameManager = GameManagerTwo.instance;
        inventtory = gameManager.GetComponent<Inventory>();
    }

    // Update is called once per frame
    public void UseItems()
    {
        inventtory.useInventoryItems(gameObject.name);
    }
}
