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
        eventsList = new List<TimedEvent>();
    }
    public void CheckForTimedEvents()
    {
        if (eventsList.Count > 0)
        {
            Debug.Log("same");
            foreach (TimedEvent t in eventsList)
            {
                if (clock.GetDay() == t.day)
                {
                    if (clock.GetHours() >= t.hour)
                    {
                        ActivateTimedEvent(t.events);
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

