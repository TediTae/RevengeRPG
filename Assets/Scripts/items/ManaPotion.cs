using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPotion : MonoBehaviour
{
    public float manaToGive;

    GameManagerTwo gameManager;
    Inventory inventtory;

    public GameObject itemToAdd;
    public int itemAmount;

    void Start()
    {
        gameManager = GameManagerTwo.instance;
        inventtory = gameManager.GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inventtory.CheckSlotsAvailable(itemToAdd, itemToAdd.name, itemAmount);
            //collision.GetComponent<PlayerHealth>().currentHealth += healthToGive;
            Destroy(gameObject);
        }
    }
}
