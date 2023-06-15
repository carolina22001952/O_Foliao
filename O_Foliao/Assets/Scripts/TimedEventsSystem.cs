using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedEventsSystem : MonoBehaviour
{
    [SerializeField]
    private List<TimedEvent> eventsList;
    [SerializeField]
    private Player player;
    [SerializeField]
    private PrimaryEventList primaryEventList;
    [SerializeField]
    private UIEvents uiEvents;
    [SerializeField]
    private DialogueAction dialogueAction;
    [SerializeField]
    private Clock clock;

    private void Start()
    {
    }
    public void CheckForTimedEvents()
    {
        if (eventsList.Count > 0)
        {
            Debug.Log("same");
            for (int i = 0; i < eventsList.Count; i++)
            {

                if (clock.GetDay() >= eventsList[i].day)
                {
                    if (eventsList[i].day < clock.GetDay() ||clock.GetHours() >= eventsList[i].hour
                        || (eventsList[i].hour == clock.GetHours() && eventsList[i].minutes <=clock.GetMinutes()))
                    {
                        ActivateTimedEvent(eventsList[i].events);

                    }
                }

            }
        }
    }


    public void ActivateTimedEvent(Events events)
    {
        primaryEventList.ChangeCurrentEvent(events);
        uiEvents.OpenCanvas();
        uiEvents.ResetCanvas();
        dialogueAction.StartDialogue();
    }
}

