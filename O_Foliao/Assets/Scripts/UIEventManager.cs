using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventManager : MonoBehaviour
{
    public UIEvents uiEvents;
    public Player player;
    public bool reading = false;
    private int index = 0;
    private int textSpeed = 20;
    private Events currentEvent;
    public void TriggerEvent(Events events)
    {
        StartDialogue(events);
    }

    public void StartDialogue(Events events)
    {
        Debug.Log("Cmon");
        int index = 0;
        currentEvent = events;
        uiEvents.UpdateNpcDialogue(string.Empty);
        Debug.Log(events.dialogue.Length.ToString() + " " + events.dialogue[0].text);
        Debug.Log(events.dialogue[index].npc.name);
        if (index < events.dialogue.Length - 1)
        {
            Debug.Log("Uya");
            reading = true;
            uiEvents.OpenDialogueObject();
            uiEvents.UpdateNpcName(events.dialogue[index].npc.name);
            uiEvents.UpdateNpcSprite(events.dialogue[index].npc.sprite);
            StartCoroutine(TypeLine(events.dialogue[index].text));
        }else
        {
            reading = false;

        }
    }

    public void StartChoices()
    {
        Debug.Log("Yup");
        switch (currentEvent.decisions.Length)
        {
            case 0:
                break;
            case 1:
                uiEvents.UpdatePlayerChoice1Text(currentEvent.decisions[0].choiceDialogue);
                uiEvents.OpenPlayerChoice1();
                break;
            case 2:
                uiEvents.UpdatePlayerChoice1Text(currentEvent.decisions[0].choiceDialogue);
                uiEvents.UpdatePlayerChoice2Text(currentEvent.decisions[1].choiceDialogue);
                uiEvents.OpenPlayerChoice1();
                uiEvents.OpenPlayerChoice2();
                break;
            case 3:
                uiEvents.UpdatePlayerChoice1Text(currentEvent.decisions[0].choiceDialogue);
                uiEvents.UpdatePlayerChoice2Text(currentEvent.decisions[1].choiceDialogue);
                uiEvents.UpdatePlayerChoice3Text(currentEvent.decisions[2].choiceDialogue);
                uiEvents.OpenPlayerChoice1();
                uiEvents.OpenPlayerChoice2();
                uiEvents.OpenPlayerChoice3();
                break;
        }
    }

    public void Choice(int choice)
    {
        if (player.GetAlcohol() > currentEvent.decisions[choice].minAlcool &&
            player.GetEnergy() > currentEvent.decisions[choice].minEnergy &&
            player.GetFun() > currentEvent.decisions[choice].minFun)
        {
            player.ChangeStats(player, currentEvent.decisions[choice].sucessEvent.alcoolPlus,
                currentEvent.decisions[choice].sucessEvent.funPlus,
                currentEvent.decisions[choice].sucessEvent.moneyPlus,
                currentEvent.decisions[choice].sucessEvent.energyPlus);
            //Call achivement
            if (currentEvent.decisions[choice].sucessEvent.nextEvent != null)
            {
                uiEvents.ClosePlayerChoice1();
                uiEvents.ClosePlayerChoice2();
                uiEvents.ClosePlayerChoice3();
                StartDialogue(currentEvent.decisions[choice].sucessEvent.nextEvent);
            }else
            {
                uiEvents.CloseDialogueObject();
                uiEvents.ClosePlayerChoice1();
                uiEvents.ClosePlayerChoice2();
                uiEvents.ClosePlayerChoice3();
                //call event to restart
            }
        }else
        {
            player.ChangeStats(player, currentEvent.decisions[choice].failedEvent.alcoolPlus,
                currentEvent.decisions[choice].failedEvent.funPlus,
                currentEvent.decisions[choice].failedEvent.moneyPlus,
                currentEvent.decisions[choice].failedEvent.energyPlus);
            //Call achivement
            if (currentEvent.decisions[choice].failedEvent.nextEvent != null)
            {
                uiEvents.ClosePlayerChoice1();
                uiEvents.ClosePlayerChoice2();
                uiEvents.ClosePlayerChoice3();
                StartDialogue(currentEvent.decisions[choice].failedEvent.nextEvent);
            }
            else
            {
                uiEvents.CloseDialogueObject();
                uiEvents.ClosePlayerChoice1();
                uiEvents.ClosePlayerChoice2();
                uiEvents.ClosePlayerChoice3();
                //call event to restart
            }
        }
    }

    IEnumerator TypeLine(string dialogue)
    {
        foreach(char c in dialogue.ToCharArray())
        {
            uiEvents.TypeNpcDialogue(c);
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void Update()
    {
        if(reading)
        {
            if(Input.GetMouseButtonDown(0))
            {
                if(uiEvents.GetDialogueText() == currentEvent.dialogue[index].text )
                {
                    index++;
                    StartDialogue(currentEvent);
                }else
                {
                    StopAllCoroutines();
                    uiEvents.UpdateNpcDialogue(currentEvent.dialogue[index].text);
                }
            }
        }
    }
}
