using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementBebidasParaCarro : MonoBehaviour, IAchievements
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
        AchievementUnlock();
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