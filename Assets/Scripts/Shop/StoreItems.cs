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

    public ShopNPC shopNPC;

    void Start()
    {
        gameManager = GameManagerTwo.instance;
        inventory = gameManager.GetComponent<Inventory>();

        buyPriceText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        buyPriceText.text = itemBuyPrice.ToString();

        shopNPC = transform.root.GetComponent<ShopNPC>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();
    }

    public void BuyItems()
    {
        if (!shopNPC.sellItems)
        {
            if (itemBuyPrice <= CoinBank.instance.bank)
            {
                CoinBank.instance.Money(-itemBuyPrice);
                inventory.CheckSlotsAvailable(itemToAdd, itemToAdd.name, amountToAdd);
                buyPriceText.text = itemBuyPrice.ToString();
            }
        }
        else 
        {
            inventory.useInventoryItems(itemToAdd.name);
            CoinBank.instance.Money(itemSellPrice);
            buyPriceText.text = itemSellPrice.ToString();
        }
    }

    public void UpdateText()
    {
        if (!shopNPC.sellItems)
        {
            buyPriceText.text = itemBuyPrice.ToString();
        }
        else
        {
            buyPriceText.text = itemSellPrice.ToString();
        }
    }
}
