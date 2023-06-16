using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementLendaDoCarnaval : MonoBehaviour, IAchievements
{
    [SerializeField]
    public string achievementName;
    [SerializeField]
    public string achievementDescription;
    [SerializeField]
    public bool isUnlocked;

    [SerializeField]
    private SpriteRenderer achievementSprite;
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