using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunelLocal : MonoBehaviour, ILocal
{
    [SerializeField]
    private PrimaryEventList primaryEventList;

    [SerializeField]
    private EventListTools eventListTools;

    [SerializeField]
    private TunelUi tunelUi;

    [SerializeField]
    private List<Quest> quests;

    [SerializeField]
    private QuestSystem questSystem;


    public void localInteraction(Player player, Clock clock)
    {
        tunelUi.OpenBusUI();
    }

    public void ChoicesBus(int choice)
    {
        switch(choice)
        {
            case 0:
                tunelUi.OpenTunelUI();
                break;
            case 1:
                tunelUi.CloseBusUI();
                break;
        }
    }

    public void ChoiceTunel(int choice)
    {
        switch(choice)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
        }
    }

    public void localChoice(bool more)
    {

    }

    public void localDialogue(bool more)
    {

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