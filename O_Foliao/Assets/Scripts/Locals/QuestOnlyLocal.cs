using System.Collections;
using System.Collections.Generic;
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
    private List<Quest> quests = new List<Quest>();

    [SerializeField]
    private QuestSystem questSystem;

    [SerializeField]
    private LocationHighLight locationHighLight;

    private Events chosenEvent;
    [SerializeField]
    private MeshRenderer parentGameobject;
    [SerializeField]
    private SpriteRenderer childGameobject;
    [SerializeField]
    private Node node;


    [SerializeField]
    private Quest added;
    private int stop = 0;

    public void Update()
    {
        if (quests.Count == 0)
        {
            parentGameobject.enabled = false;

            node.QuestToDeactivate(this.gameObject);
            node.StopAnimation(true);
            stop = 0;
        }else
        {
            parentGameobject.enabled = true;
            childGameobject.enabled = true;
            if (stop == 0)
            {
                node.QuestToNormal(this.gameObject);
                node.StopAnimation(false);
                stop++;
            }
        }

        if (Input.GetKeyUp(KeyCode.Z))
        {
            quests.Add(added);
        }
    }

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
