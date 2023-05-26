using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QuestSystem : MonoBehaviour
{
    NodeList nodelist;

    public void InsertQuest(Quest quest)
    {
        if(quest != null)
        {
            List<Node> nodes = nodelist.GetNodeList();
            foreach(Node node in nodes)
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
        }

        //Add ui
    }

    public void CompleteQuest(Quest quest)
    {
        
        //UpdateUI
    }
}
  