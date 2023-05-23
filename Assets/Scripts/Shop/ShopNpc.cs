using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopNPC : MonoBehaviour
{
    public GameObject[] itemsInStore;

    public GameObject shopPanel;

    public bool sellItems;

    Inventory inventory;

    void Start()
    {
        inventory = GetComponent<Inventory>();
        SetUpShop();
    }

    void Update()
    {
        
    }

    public void SetUpShop()
    {
        for (int i = 0; i < itemsInStore.Length; i++)
        {
            GameObject itemToSell = Instantiate(itemsInStore[i], inventory.slots[i].transform.position, Quaternion.identity);
            itemToSell.transform.SetParent(inventory.slots[i].transform, false);
            itemToSell.transform.localPosition = new Vector3(0, 0, 0);
            itemToSell.name = itemToSell.name.Replace("(Clone)", "");
        }
    }

    public void IsSellingItems()
    {
        sellItems = !sellItems;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){

            shopPanel.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            shopPanel.SetActive(false);
        }
    }
}
