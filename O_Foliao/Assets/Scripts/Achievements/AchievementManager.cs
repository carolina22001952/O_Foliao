using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    [SerializeField]
    private List<IAchievements> achievementList = new List<IAchievements>();

    private static AchievementManager instance;
    private void Awake()
    {
        // Singleton pattern to ensure only one instance exists
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        Component[] components = gameObject.GetComponents<Component>();
        foreach(Component comp in components)
        {
            if(comp is IAchievements achievementsComponents)
            {
                achievementList.Add(achievementsComponents);
            }
        }
    }
   


    public void UnlockAchievement(string achievementName)
    {
        if (achievementName != null || achievementName != string.Empty)
        {
            foreach (IAchievements achievement in achievementList)
            {
                if (achievement.GetAchievementName() == achievementName)
                {
                    achievement.AchievementLogic();
                }
                else
                {
                    //throw new System.Exception("Achievement name does not exist");
                }
            }
        }
    }


}

