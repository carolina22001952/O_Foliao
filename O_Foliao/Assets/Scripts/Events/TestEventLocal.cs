using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEventLocal : MonoBehaviour, ILocal
{
    [SerializeField]
    private PrimaryEventList primaryEventList;

    [SerializeField]
    private EventListTools eventListTools;

    [SerializeField]
    private DialogueAction dialogueAction;

    [SerializeField]
    private UIEvents uiEvents;

    [SerializeField]
    private Game game;

    [SerializeField]
    private List<Quest> quests;

    [SerializeField]
    private QuestSystem questSystem;



    private List<Events> testEvent;
    private List<Events> dayEvents;
    private List<Events> timeOfDayEvents;
    private List<Events> resourceEvents;

    private Events chosenEvent;
    public void localInteraction(Player player, Clock clock)
    {
        List<Events> events = new List<Events>();
        Events chosenEvent;
        //Get the events

        if (quests.Count > 0)
        {
            chosenEvent = quests[0].events;
            questSystem.CompleteQuest(quests[0]);
            quests.RemoveAt(0);
        }
        else
        {
            testEvent = primaryEventList.GetTestEvents();

            //Intersect the events
            //events = eventListTools.IntersectEventLists(cebolaEvents, dayEvents, timeOfDayEvents);
            //events = eventListTools.UnionEvents(events, resourceEvents);
            //Get only 1 type of events and choose a random one

            //events = primaryEventList.GetAllEventsOfOneType(events, primaryEventList.CheckForEventType(events));
            chosenEvent = eventListTools.ChooseARandomEvent(testEvent);
        }
        primaryEventList.ChangeCurrentEvent(chosenEvent);

        uiEvents.OpenCanvas();
        uiEvents.ResetCanvas();
        dialogueAction.StartDialogue();




    }

    public void localChoice(bool more)
    {
        if (more)
        {
            dialogueAction.StartDialogue();
        }
        else
        {
            uiEvents.CloseCanvas();
            game.StartMovement();
        }
    }

    public void localDialogue(bool more)
    {
        if (more)
        {
            dialogueAction.StartChoices();
        }
        else
        {
            uiEvents.CloseCanvas();
            Restart();
        }
    }

    public void Restart()
    {
        game.StartMovement();
    }

    public void LocalAddQuest(Quest quest)
    {
        quests.Add(quest);
    }

    public void LocalRemoveQuest(Quest quest)
    {
        quests.Remove(quest);
    }
}