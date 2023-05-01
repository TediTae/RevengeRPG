using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveRoom : MonoBehaviour
{

    public GameObject saveText;
    public GameObject[] effects;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Experince.instance.DataSave();

            for(int i = 0; i < 6; i++)
            {
                effects[i].SetActive(true);
            }
            saveText.SetActive(true);
            StartCoroutine(CloseText());
        }
    }

    IEnumerator CloseText()
    {
        yield return new WaitForSeconds(2);
        //saveText.SetActive(false);
        Destroy(saveText);
    }
}
