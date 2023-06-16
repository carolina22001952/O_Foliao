using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Achievement : MonoBehaviour, IAchievements 
{
    [SerializeField]
    private string achievementName;
    [SerializeField]
    private string achievementDescription;
    [SerializeField]
    private bool isUnlocked;

    public void AchievementUnlock()
    {
        if(!isUnlocked)
        {
            isUnlocked = true;
        }
    }

    public void AchievementLogic()
    {
        
    }

    public void AchievementUI()
    {

    }

    public string GetAchievementName()
    {
        return achievementName;
    }

}
