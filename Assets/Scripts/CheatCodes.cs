using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatCodes : MonoBehaviour
{
    private string[] cheatCode;
    private int index;

    void Start()
    {
        cheatCode = new string[] { "m", "a", "r", "i", "u", "s", "z" };
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
            Debug.Log("Chest code activated");
        }
    }
}
