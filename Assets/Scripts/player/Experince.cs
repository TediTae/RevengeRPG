using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Experince : MonoBehaviour
{
    public Image expImage;

    public Text leveltext;
    public int currentLevel;

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
    }

    
    void Update()
    {
        expImage.fillAmount = currentExperince / expToNextLevel;
    }

    public void expMod(float experince)
    {
        currentExperince += experince;
        expImage.fillAmount = currentExperince / expToNextLevel;
        if(currentExperince >= expToNextLevel)
        {
            expToNextLevel *= 2;
            currentExperince = 0;
            currentLevel++;
            leveltext.text = currentLevel.ToString();
            PlayerHealth.instance.maxHealth += 5;
            PlayerHealth.instance.currentHealth += 5;
        }
    }
}
