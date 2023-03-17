using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Achievement", menuName = "Achievement")]
public class Achievement : ScriptableObject
{
    public string achievementName;
    public string achievementDescription;
    public bool isUnlocked;

    public void Unlock()
    {
        if(!isUnlocked)
        {
            isUnlocked = true;
        }
    }
}
