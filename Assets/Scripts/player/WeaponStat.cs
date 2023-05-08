using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponStat : MonoBehaviour
{
    float attackPower;
    float totalAttack;
    public float weaponAttack;

    public GameObject damageText;


    PlayerKontroller player;
    void Start()
    {
        player = GetComponent<PlayerKontroller>();
        attackPower = player.damage;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float DamageInput()
    {
        totalAttack = attackPower + weaponAttack;
        float finalAttack = Mathf.Round(Random.Range(totalAttack - 7, totalAttack + 5));
        GameObject textDam = Instantiate(damageText, new Vector2(transform.position.x+1, transform.position.y), Quaternion.identity);
        textDam.GetComponent<TextMeshPro>().SetText(finalAttack.ToString());

        if(finalAttack > totalAttack + 3)
        {
            textDam.GetComponent<TextMeshPro>().SetText("CRITICAL!\n" + finalAttack.ToString());
            finalAttack *= 2;

        }
        return finalAttack;
    }
}
