using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerTwo : MonoBehaviour
{
    public static GameManagerTwo instance;

    private void Awake()
    {
        instance = this;
    }
}
