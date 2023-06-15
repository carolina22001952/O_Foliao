using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenchLocal : MonoBehaviour, ILocal
{
    [SerializeField]
    private PrimaryEventList primaryEventList;

    [SerializeField]
    private EventListTools eventListTools;

    [SerializeField]
    private UIEvents uiEvents;

    [SerializeField]
    private DialogueAction dialogueAction;

    [SerializeField]
    private List<Quest> quests;

    [SerializeField]
    private QuestSystem questSystem;


    private List<Events> benchEvents;
    [SerializeField]
    private List<Events> alcoholEvents;
    [SerializeField]
    private Game game;
    

    public void localInteraction(Player player, Clock clock)
    {
        List<Events> events = new List<Events>();
        Events chosenEvent;
        //Get the events
        benchEvents = primaryEventList.GetBenchEvents();
        //Intersect the events
        events = benchEvents;

        //Get only 1 type of events and choose a random one
        if (quests.Count > 0)
        {
            chosenEvent = quests[0].events;
            questSystem.CompleteQuest(quests[0]);
            quests.RemoveAt(0);
        }
        else
        {

            // events = primaryEventList.GetAllEventsOfOneType(events, primaryEventList.CheckForEventType(events));
            chosenEvent = eventListTools.ChooseARandomEvent(events);

            if (player.GetAlcohol() > 80)
            {
                chosenEvent = eventListTools.ChooseARandomEvent(alcoholEvents);
            }
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
            Restart();
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