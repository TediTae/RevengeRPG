using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Experince : MonoBehaviour
{
    public Image expImage;

    public Text leveltext;
    public int currentLevel;

    public AudioSource levelUpAS;

    [HideInInspector]
    public float currentExperince;
    public float expToNextLevel;

    public static Experince instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        expImage.fillAmount = currentExperince / expToNextLevel;
        currentLevel = 1;
        leveltext.text = currentLevel.ToString();

        currentExperince = PlayerPrefs.GetFloat("Experince", 0);
        expToNextLevel = PlayerPrefs.GetFloat("ExperinceTNL", expToNextLevel);
        currentLevel = PlayerPrefs.GetInt("CurrentLevel",1);
    }

    
    void Update()
    {
        expImage.fillAmount = currentExperince / expToNextLevel;
        leveltext.text = currentLevel.ToString();
    }

    public void expMod(float experince)
    {
        currentExperince += experince;
        
        expToNextLevel = PlayerPrefs.GetFloat("ExperinceTNL", expToNextLevel);

        expImage.fillAmount = currentExperince / expToNextLevel;

        if(currentExperince >= expToNextLevel)
        {
            expToNextLevel *= 2;
            currentExperince = 0;
            currentLevel++;
            leveltext.text = currentLevel.ToString();
            PlayerHealth.instance.maxHealth += 5;
            PlayerHealth.instance.currentHealth += 5;
            

            

            AudioManager.instance.PlayAudio(levelUpAS);


            //currentLevel = PlayerPrefs.GetInt("CurrentLevel",currentLevel);
        }

        
    }

    public void DataSave()
    {
        DataManager.instance.ExperinceData(currentExperince);
        DataManager.instance.ExperinceToNextLevel(expToNextLevel);
        DataManager.instance.LevelData(currentLevel);

        DataManager.instance.CurrentHealth(PlayerHealth.instance.currentHealth);
        PlayerHealth.instance.currentHealth = PlayerPrefs.GetFloat("CurrentHealth");

        DataManager.instance.MaxHealth(PlayerHealth.instance.maxHealth);
        PlayerHealth.instance.maxHealth = PlayerPrefs.GetFloat("MaxHealth");

        currentExperince = PlayerPrefs.GetFloat("Experince");
        expToNextLevel = PlayerPrefs.GetFloat("ExperinceTNL");
        currentLevel = PlayerPrefs.GetInt("CurrentLevel");

        DataManager.instance.CurrentStars(StarBank.instance.bankStar);
        StarBank.instance.bankStar = PlayerPrefs.GetInt("StarAmount");

        DataManager.instance.CurrentCoin(CoinBank.instance.bank);
        CoinBank.instance.bank = PlayerPrefs.GetInt("CoinAmount");
    }
}
