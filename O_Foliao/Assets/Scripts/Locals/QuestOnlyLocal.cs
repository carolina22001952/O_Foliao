using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class QuestOnlyLocal : MonoBehaviour, ILocal
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

    [SerializeField]
    private LocationHighLight locationHighLight;

    private Events chosenEvent;
    public void localInteraction(Player player, Clock clock)
    {
        Events chosenEvent;
        if(quests.Count > 0)
        {
            chosenEvent = quests[0].events;
            questSystem.CompleteQuest(quests[0]);
            quests.RemoveAt(0);

            primaryEventList.ChangeCurrentEvent(chosenEvent);

            uiEvents.OpenCanvas();
            uiEvents.ResetCanvas();
            dialogueAction.StartDialogue();

        }else
        {
            game.StartMovement();
        }

        if(quests.Count == 0)
        {
            
        }


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

}
