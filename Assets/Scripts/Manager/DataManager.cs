using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != null){
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SetMusicData(float value)
    {
        PlayerPrefs.SetFloat("MusicVolume", value);
    }

    public void ExperinceData(float value)
    {
        PlayerPrefs.SetFloat("Experince", value);
    }
    public void LevelData(int value)
    {
        PlayerPrefs.SetInt("CurrentLevel", value);
    }
    public void ExperinceToNextLevel(float value)
    {
        PlayerPrefs.SetFloat("ExperinceTNL", value);
    }

    public void CurrentStars(int value)
    {
        PlayerPrefs.SetInt("StarAmount", value);
    }

    public void CurrentCoin(int value)
    {
        PlayerPrefs.SetInt("CoinAmount", value);
    }

    public void MaxHealth(float value)
    {
        PlayerPrefs.SetFloat("MaxHealth", value);
    }

    public void CurrentHealth(float value)
    {
        PlayerPrefs.SetFloat("CurrentHealth", value);
    }
}
