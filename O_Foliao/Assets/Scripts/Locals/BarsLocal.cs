using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BarsLocal : MonoBehaviour, ILocal
{
    public enum Bar { Skadi, Vinil, Celeiro }
    [SerializeField]
    private Bar barType;

    [SerializeField]
    private PrimaryEventList primaryEventList;

    [SerializeField]
    private EventListTools eventListTools;

    [SerializeField]
    private DialogueAction dialogueAction;

    [SerializeField]
    private ShopsUI shopUi;



    [SerializeField]
    private Game game;

    [SerializeField]
    private UIEvents uiEvents;

    [Header("Events for Every Bar")]
    [SerializeField]
    private List<Events> GenericBarmenEvents;
    
    [Header("UI Event of Every Bar")]
    [SerializeField]
    private Events SkadiUI;
    [SerializeField]
    private Events VinilUI;
    [SerializeField]
    private Events CeleiroUI;
    [SerializeField]
    private Player player;

    private Events currentBar;
    [SerializeField]
    private Clock clock;

    [SerializeField]
    private List<Quest> quests;

    [SerializeField]
    private QuestSystem questSystem;


    public void localInteraction(Player player, Clock clock)
    {
        switch (barType)
        {
            case Bar.Skadi:
                currentBar = SkadiUI;
                break;
            case Bar.Vinil:
                currentBar = VinilUI;
                break;
            case Bar.Celeiro:
                currentBar = CeleiroUI;
                break;
        }
        OpenBar();
        
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
        }
    }

    public void BarChoices(int choice)
    {
        switch(choice)
        {
            case 0:
                if (player.Position() == this.gameObject)
                {
                    BarmenEvents();
                }
                break;
            case 1:
                if (player.Position() == this.gameObject)
                {
                    BarEvents();
                }
                break;
            case 2:
                QuitBar();
                break;
        }
    }

    public void BarmenEvents()
    {
        List<Events> events = new List<Events>();
        Events chosenEvent;
        switch (barType)
        {
            case Bar.Skadi:
                events = GenericBarmenEvents;
                break;
            case Bar.Vinil:
                events = GenericBarmenEvents;
                break;
            case Bar.Celeiro:
                events = eventListTools.IntersectEventLists(primaryEventList.GetBarmenEvents(), primaryEventList.GetDayDeck(clock), primaryEventList.GetTimeOfDayDeck(clock));
                break;
        }


        chosenEvent = eventListTools.ChooseARandomEvent(events);
        primaryEventList.ChangeCurrentEvent(chosenEvent);
        uiEvents.OpenCanvas();
        uiEvents.ResetCanvas();
        dialogueAction.StartDialogue();
    }

    public void BarEvents()
    {
        List<Events> events = new List<Events>();
        Events chosenEvent;
        if (quests.Count > 0)
        {
            chosenEvent = quests[0].events;
            questSystem.CompleteQuest(quests[0]);
            quests.RemoveAt(0);
        }
        else
        {
            switch (barType)
            {
                case Bar.Skadi:
                    events = eventListTools.IntersectEventLists(primaryEventList.GetSkadiZoneEvents(), primaryEventList.GetDayDeck(clock), primaryEventList.GetTimeOfDayDeck(clock));
                    break;
                case Bar.Vinil:
                    events = eventListTools.IntersectEventLists(primaryEventList.GetVinilZoneEvents(), primaryEventList.GetDayDeck(clock), primaryEventList.GetTimeOfDayDeck(clock));
                    break;
                case Bar.Celeiro:
                    events = eventListTools.IntersectEventLists(primaryEventList.GetCeleiroZoneEvents(), primaryEventList.GetDayDeck(clock), primaryEventList.GetTimeOfDayDeck(clock));
                    break;
            }


            events = primaryEventList.GetAllEventsOfOneType(events, primaryEventList.CheckForEventType(events));
            chosenEvent = eventListTools.ChooseARandomEvent(events);
        }
        primaryEventList.ChangeCurrentEvent(chosenEvent);
        uiEvents.OpenCanvas();
        uiEvents.ResetCanvas();
        dialogueAction.StartDialogue();
    }

    public void QuitBar()
    {
        shopUi.CloseShopUI();
        game.StartMovement();
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
        }
    }

    public void OpenBar()
    {
        shopUi.OpenShopUI();
        shopUi.UpdateBackground(currentBar.dialogue[0].background);
        shopUi.UpdateChoices(currentBar);

    }

    public void LocalAddQuest(Quest quest)
    {
        quests.Add(quest);
    }

    public void LocalRemoveQuest(Quest quest)
    {
        quests.Remove(quest);
    }

    public void buttonInteraction()
    {
 
    }
}
