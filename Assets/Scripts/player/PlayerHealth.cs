using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    public Image HealthBar;

    bool isImnume;
    public float immunityTime;

    Animator anim;

    public static PlayerHealth instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        maxHealth = PlayerPrefs.GetFloat("MaxHealth",maxHealth);
        currentHealth = PlayerPrefs.GetFloat("CurrentHealth", currentHealth);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }

        HealthBar.fillAmount = currentHealth / maxHealth;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !isImnume)
        {
            currentHealth -= collision.GetComponent<EnemyStats>().damage;

            StartCoroutine(Immunity());
            anim.SetTrigger("Hit");

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                Destroy(gameObject);
            }
        }
    }
    IEnumerator Immunity()
    {
        isImnume = true;
        yield return new WaitForSeconds(immunityTime);
        isImnume = false;
    }
}
