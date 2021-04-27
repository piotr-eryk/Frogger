using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatCodes : MonoBehaviour
{
    private string[] cheatCode;
    private int index;

    public Action OnStandFinishGame;

    void Start()
    {
        cheatCode = new string[] { "w", "i", "n", "g", "a", "m", "e" };
        index = 0;
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(cheatCode[index]))
            {
                index++;
            }
            else
            {
                index = 0;
            }
        }

        if (index == cheatCode.Length)
        {
            Debug.Log("Cheat code activated");
            OnStandFinishGame?.Invoke();
            index = 0;
        }
    }
}
