using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementLendaDoCarnaval : MonoBehaviour, IAchievements
{
    [SerializeField]
    private string achievementName;

    [SerializeField]
    private bool isUnlocked;

    [SerializeField]
    private Image achievementSprite;
    [SerializeField]
    private Sprite completedAchievementSprite;

    public void AchievementUnlock()
    {
        if (!isUnlocked)
        {
            isUnlocked = true;
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
    }

    public string GetAchievementName()
    {
        return achievementName;
    }
}