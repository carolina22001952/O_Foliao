using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class BarsLocal : MonoBehaviour, ILocal
{
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
    private Sprite background;

    [SerializeField]
    private string playerChoice1Text;
    [SerializeField]
    private string playerChoice2Text;
    [SerializeField]
    private string playerChoice3Text;

    private List<Events> barsInsideEvents;
    private List<Events> barmenEvents;
    private List<Events> barDanceEvents;
    private List<Events> dayEvents;
    private List<Events> resourceEvents;
    public void localInteraction(Player player, Clock clock)
    {
        shopUi.UpdateBackground(background);
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
                DanceEvents();
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

        barmenEvents = primaryEventList.GetBarmenEvents();
        chosenEvent = eventListTools.ChooseARandomEvent(events);
        primaryEventList.ChangeCurrentEvent(chosenEvent);
        dialogueAction.StartDialogue();
    }

    public void DanceEvents()
    {
        List<Events> events = new List<Events>();
        Events chosenEvent;

        barDanceEvents = primaryEventList.GetBarsInsideZoneEvents();
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




}
