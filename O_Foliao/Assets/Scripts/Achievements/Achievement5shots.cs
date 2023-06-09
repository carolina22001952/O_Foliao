using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievement5shots : MonoBehaviour, IAchievements
{
    [SerializeField]
    private string achievementName;

    [SerializeField]
    private bool isUnlocked;

    [SerializeField]
    private Image achievementSprite;
    [SerializeField]
    private Sprite completedAchievementSprite;

    [SerializeField] 
    private AudioManager audioManager;

    [SerializeField]
    private UIPhone uiphone;
    
    private int drinkedShots = 0;

    public void AchievementUnlock()
    {
        if (!isUnlocked)
        {
            isUnlocked = true;
            audioManager.PlayNotificationSound();
            AchievementUI();
            
        }
    }

    public void AchievementLogic()
    {
        drinkedShots++;
        Debug.Log(drinkedShots);
        if (drinkedShots == 5)
        {
            AchievementUnlock();
        }
       
    }

    public void AchievementUI()
    {
        achievementSprite.sprite = completedAchievementSprite;
        uiphone.TurnNotificationAchieve(true);
    }


    public string GetAchievementName()
    {
        return achievementName;
    }
}