using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QuestSystem : MonoBehaviour
{
    public NodeList nodelist;
    public QuestsUI questsUI;
    public void InsertQuest(Quest quest)
    {
        if(quest != null)
        {
           GameObject location = GameObject.Find(quest.location);

            if (location.GetComponent<ILocal>() is ILocal)
            {
                location.SetActive(true);
                location.GetComponent<ILocal>().LocalAddQuest(quest);

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
        }

        if(quest != null)
        {
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
}
  