using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAchievements
{
    void AchievementUnlock();

    void AchievementLogic();

    void AchievementUI();

    string GetAchievementName();
}
