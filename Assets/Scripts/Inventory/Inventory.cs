using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    public GameObject[] slots;
    //public GameObject[] backpack;
    bool isInstantiated;

    TextMeshProUGUI amountText;


    public Dictionary<string, int> inventoryItems = new Dictionary<string, int>(); 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckSlotsAvailable(GameObject itemToAdd,string itemName,int itemAmount)
    {
        isInstantiated = false;
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].transform.childCount>0)
            {
                slots[i].GetComponent<Slots>().isUsed = true;
            }
            else if(!isInstantiated && !slots[i].GetComponent<Slots>().isUsed)
            {
                if (!inventoryItems.ContainsKey(itemName))
                {
                    GameObject item = Instantiate(itemToAdd, slots[i].transform.position, Quaternion.identity);
                    item.transform.SetParent(slots[i].transform, false);
                    item.transform.localPosition = new Vector3(0, 0, 0);
                    item.name = item.name.Replace("(Clone)", "");
                    isInstantiated = true;
                    inventoryItems.Add(itemName, itemAmount);
                    amountText = slots[i].GetComponentInChildren<TextMeshProUGUI>();
                    amountText.text = itemAmount.ToString();
                    break;
                }
                else
                {
                    for(int j =0; j < slots.Length; j++)
                    {
                        if(slots[j].transform.GetChild(0).gameObject.name == itemName)
                        {
                            inventoryItems[itemName] += itemAmount;
                            amountText = slots[i].GetComponentInChildren<TextMeshProUGUI>();
                            amountText.text = inventoryItems[itemName].ToString();
                            break;
                        }
                    }
                    break;

                }
            }
        }
    }

    public void useInventoryItems(string itemName)
    {
        for ( int i = 0; i < slots.Length; i++)
        {
            if (!slots[i].GetComponent<Slots>().isUsed)
            {
                continue;
            }

            if (slots[i].transform.GetChild(0).gameObject.name == itemName)
            {
                inventoryItems[itemName]--;
                amountText = slots[i].GetComponentInChildren<TextMeshProUGUI>();
                amountText.text = inventoryItems[itemName].ToString();

                if (inventoryItems[itemName] <= 0)
                {
                    Destroy(slots[i].transform.GetChild(0).gameObject);
                    slots[i].GetComponent<Slots>().isUsed = false;
                    inventoryItems.Remove(itemName);
                    ReorganizedInv();
                }
                break;
            }
            break;
        }
    }

    public void ReorganizedInv()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (!slots[i].GetComponent<Slots>().isUsed)
            {
                for (int j = i+1; j < slots.Length; j++)
                {
                    if (slots[j].GetComponent<Slots>().isUsed)
                    {
                        Transform itemMove = slots[j].transform.GetChild(0).transform;
                        itemMove.transform.SetParent(slots[i].transform, false);
                        itemMove.transform.localPosition = new Vector3(0, 0, 0);
                        slots[i].GetComponent<Slots>().isUsed = true;
                        slots[j].GetComponent<Slots>().isUsed = false;
                        break;
                    }
                }
            }
        }
    }
}
