using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QuestSystem : MonoBehaviour
{
    public NodeList nodelist;
    public QuestsUI questsUI;
    [SerializeField]
    private List<Quest> questsTimed;
    [SerializeField]
    private List<Quest> currentTimedQuests;
    [SerializeField]
    private Clock clock;

    private void Start()
    {
        questsTimed = new List<Quest>();
        currentTimedQuests = new List<Quest>();
    }
    public void InsertQuest(Quest quest)
    {
        if(quest != null)
        {
            if (quest.startingHours == 0 && quest.startingMinutes == 0)
            {
                GameObject location = GameObject.Find(quest.location);

                if (location.GetComponent<ILocal>() is ILocal)
                {
                    location.SetActive(true);
                    location.GetComponent<ILocal>().LocalAddQuest(quest);

                }
            }else
            {
                questsTimed.Add(quest);
            }

            questsUI.InsertNewButton(quest);
        }
      
    }

    public void UpdateUI()
    {

    }

    public void CompleteQuest(Quest quest)
    {
       questsUI.UpdateCompletedQuest(quest);  
    }

    public void FailedQuest(Quest quest)
    {
        questsUI.UpdateFailedQuest(quest);
    }

    public void CheckForQuestTimers()
    {
        int day = clock.GetDay();
        Debug.Log(day);
        int hour = clock.GetHours();
        Debug.Log(hour);
        int minutes = clock.GetMinutes();
        if (questsTimed.Count > 0)
        {
            for(int i = 0; i< questsTimed.Count; i++)
            { 
                if (questsTimed[i].startingDay <= day)
                {
                    Debug.Log(questsTimed[i].startingDay);
                    Debug.Log(questsTimed[i].startingHours);
                    Debug.Log(questsTimed[i].startingMinutes);
                    if (questsTimed[i].startingDay < day ||questsTimed[i].startingHours < hour || (questsTimed[i].startingHours == hour && questsTimed[i].startingMinutes <= minutes))
                    {
                        Debug.Log("");
                        GameObject location = GameObject.Find(questsTimed[i].location);

                        if (location.GetComponent<ILocal>() is ILocal)
                        {
                            location.SetActive(true);
                            location.GetComponent<ILocal>().LocalAddQuest(questsTimed[i]);
                            currentTimedQuests.Add(questsTimed[i]);
                            questsTimed.Remove(questsTimed[i]);

                        }
                    }
                }
            }
        }
    }

    public void EndFailedTimedQuets()
    {
        int day = clock.GetDay();
        int hour = clock.GetHours();
        int minutes = clock.GetMinutes();
        if (currentTimedQuests.Count > 0)
        {
            for (int i = 0; i < currentTimedQuests.Count; i++)
            {
                if (currentTimedQuests[i].endDay <= day)
                {
                    if (currentTimedQuests[i].endDay < day || currentTimedQuests[i].endHours < hour || (currentTimedQuests[i].endHours == hour && currentTimedQuests[i].endMinutes <= minutes))
                    {
                        GameObject location = GameObject.Find(currentTimedQuests[i].location);

                        if (location.GetComponent<ILocal>() is ILocal)
                        {
                            location.GetComponent<ILocal>().LocalRemoveQuest(currentTimedQuests[i]);
                            FailedQuest(currentTimedQuests[i]);
                            currentTimedQuests.Remove(currentTimedQuests[i]);
                            
                        }
                    }
                }
            }
        }
    }

}


/*  List<GameObject> nodes = nodelist.GetNodeList();
  foreach(GameObject node in nodes)
  {
      if(node == quest.location)
      {

          if (quest.location.gameObject.GetComponent<ILocal>() is ILocal)
          {
              quest.location.gameObject.SetActive(true);
              quest.location.gameObject.GetComponent<ILocal>().LocalAddQuest(quest);

          }

      }
  }
*/