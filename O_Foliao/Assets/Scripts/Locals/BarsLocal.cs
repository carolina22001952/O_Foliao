using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    private BarslUI barsUI;

    [SerializeField]
    private Game game;

    [SerializeField]
    private UIEvents uiEvents;

    [SerializeField]
    private GameObject playerChoicesGroup;
    [SerializeField]
    private GameObject playerChoice1;
    [SerializeField]
    private GameObject playerChoice2;
    [SerializeField]
    private GameObject playerChoice3;

    [SerializeField]
    private string playerChoice1Text;
    [SerializeField]
    private string playerChoice2Text;
    [SerializeField]
    private string playerChoice3Text;

    [Header("Events for Every Bar")]
    [SerializeField]
    private List<Events> barDanceEvents;
    [SerializeField]
    private List<Events> GenericBarmenEvents;
    [Header("UI Event of Every Bar")]
    [SerializeField]
    private Events SkadiUI;
    [SerializeField]
    private Events VinilUI;
    [SerializeField]
    private Events CeleiroUI;

    private Events currentBar;

    private Clock clock;
    public void localInteraction(Player player, Clock clock)
    {
        bool inBar = true;
        this.clock = clock;
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
        shopUi.OpenShopUI();
        
    }
    public void localChoice(bool more)
    {
        Debug.Log("LocalChoice");
        if (more)
        {
            dialogueAction.StartDialogue();
        }
        else
        {
            uiEvents.CloseCanvas();
            shopUi.OpenShopUI();
        }
    }

    public void ChoiceUI()
    {
        playerChoice1.GetComponent<TextMeshPro>().text = playerChoice1Text;
        playerChoice2.GetComponent<TextMeshPro>().text = playerChoice2Text;
        playerChoice3.GetComponent<TextMeshPro>().text = playerChoice3Text;
        playerChoice1.SetActive(true);
        playerChoice2.SetActive(true);
        playerChoice3.SetActive(true);
    }

    public void BarChoices(int choice)
    {
        switch(choice)
        {
            case 0:
                BarmenEvents();
                break;
            case 1:
                BarEvents();
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
                events = primaryEventList.GetBarmenEvents();
                break;
        }


        chosenEvent = eventListTools.ChooseARandomEvent(events);
        primaryEventList.ChangeCurrentEvent(chosenEvent);
        dialogueAction.StartDialogue();
    }

    public void BarEvents()
    {
        List<Events> events = new List<Events>();
        Events chosenEvent;

        switch (barType)
        {
            case Bar.Skadi:
                events = eventListTools.IntersectEventLists(primaryEventList.GetSkadiZoneEvents(), primaryEventList.GetDayDeck(clock)) ;
                break;
            case Bar.Vinil:
                events = eventListTools.IntersectEventLists(primaryEventList.GetVinilZoneEvents(), primaryEventList.GetDayDeck(clock));
                break;
            case Bar.Celeiro:
                events = eventListTools.IntersectEventLists(primaryEventList.GetCeleiroZoneEvents(), primaryEventList.GetDayDeck(clock));
                break;
        }
        events = primaryEventList.GetAllEventsOfOneType(events, primaryEventList.CheckForEventType(events));
        chosenEvent = eventListTools.ChooseARandomEvent(events);
        primaryEventList.ChangeCurrentEvent(chosenEvent);
        dialogueAction.StartDialogue();
    }

    public void QuitBar()
    {
        shopUi.CloseShopUI();
        game.StartMovement();
    }

    public void localDialogue(bool more)
    {
        Debug.Log("LocalDialogue");
        if (more)
        {
            dialogueAction.StartChoices();
        }
        else
        {
            shopUi.OpenShopUI();
        }
    }

    public void OpenBar()
    {
        shopUi.OpenShopUI();
        //shopUi.UpdateBackground(currentBar.dialogue[0].background);     
    }



}
