using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoreItems : MonoBehaviour
{
    //public string itemName;
    public int itemSellPrice;
    public int itemBuyPrice;

    public GameObject itemToAdd;
    public int amountToAdd;

    GameManagerTwo gameManager;
    Inventory inventory;

    TextMeshProUGUI buyPriceText;

    void Start()
    {
        gameManager = GameManagerTwo.instance;
        inventory = gameManager.GetComponent<Inventory>();

        buyPriceText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        buyPriceText.text = itemBuyPrice.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuyItems()
    {
        if(itemBuyPrice <= CoinBank.instance.bank)
        {
            CoinBank.instance.Money(-itemBuyPrice);
            inventory.CheckSlotsAvailable(itemToAdd, itemToAdd.name, amountToAdd);
        }
    }
}
