using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EnemyStats : MonoBehaviour
{
    public float maxHealth;
    private float currentHealth;
    public GameObject deathEffect;

    public float timer;

    HitEffect effect;
    Rigidbody2D rb;

    public AudioSource hitAS, flameAS;

    public float damage;

    public float knockBackForceX, knockBackForceY;
    public Transform player;

    void Start()
    {
        currentHealth = maxHealth;
        effect = GetComponent<HitEffect>();
        rb = GetComponent<Rigidbody2D>();
    }

    public float expToGive;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg;
        AudioManager.instance.PlayAudio(hitAS);

               if (player.position.x < transform.position.x)
        {
            rb.AddForce(new Vector2(knockBackForceX, knockBackForceY), ForceMode2D.Force);
        }
        else
        {
            rb.AddForce(new Vector2(-knockBackForceX, knockBackForceY), ForceMode2D.Force);
        }

        GetComponent<SpriteRenderer>().material = effect.white;
        StartCoroutine(BackToNormal());

        if(currentHealth <= 0)
        {
            currentHealth = 0;
            Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            Experince.instance.expMod(expToGive);
            AudioManager.instance.PlayAudio(flameAS);
        }
    }
    
    IEnumerator BackToNormal()
    {
        yield return new WaitForSeconds(timer);
        GetComponent<SpriteRenderer>().material = effect.original;
    }
}
