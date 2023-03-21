using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor.PackageManager;
using UnityEngine;

public class UIEventManager : MonoBehaviour
{
    public UIEvents uiEvents;
    public Player player;
    public bool reading = false;
    private int index = 0;
    [SerializeField]
    private float textSpeed = 0.8f;
    private Events currentEvent;
    public Clock time;
    [SerializeField]
    private Game game;
    [SerializeField]
    private bool restart;

    private void Start()
    {
        uiEvents.UpdateNpcDialogue(string.Empty);

    }

    public void SetupDialogue(Events events)
    {
        uiEvents.OpenCanvas();
        uiEvents.OpenDialogueObject();
        uiEvents.UpdateNpcName(events.dialogue[index].npc.name);
        uiEvents.UpdateNpcSprite(events.dialogue[index].npc.sprite);
        uiEvents.OpenDialogueObject();
        uiEvents.CloseMultipleChoices(3);
    }

    public void StartDialogue(Events events, bool stop = true)
    {
        int index = 0;
        restart = stop;
        currentEvent = events;
        reading = true;
        StartCoroutine(TypeLine());  
    }

    public void StartChoices()
    {
        uiEvents.OpenPlayerChoicesGroup();
        Debug.Log(currentEvent.decisions.Length);
        switch (currentEvent.decisions.Length)
        {
            case 0:
                break;
            case 1:
                uiEvents.UpdatePlayerChoice1Text(currentEvent.decisions[0].choiceDialogue);
                uiEvents.OpenMultipleChoices(currentEvent.decisions.Length);
                break;
            case 2:
                uiEvents.UpdatePlayerChoice1Text(currentEvent.decisions[0].choiceDialogue);
                uiEvents.UpdatePlayerChoice2Text(currentEvent.decisions[1].choiceDialogue);
                uiEvents.OpenMultipleChoices(currentEvent.decisions.Length);
                break;
            case 3:
                uiEvents.UpdatePlayerChoice1Text(currentEvent.decisions[0].choiceDialogue);
                uiEvents.UpdatePlayerChoice2Text(currentEvent.decisions[1].choiceDialogue);
                uiEvents.UpdatePlayerChoice3Text(currentEvent.decisions[2].choiceDialogue);
                uiEvents.OpenMultipleChoices(currentEvent.decisions.Length);
                break;
        }
    }

    public void Choice(int choice)
    {
        if (player.GetAlcohol() >= currentEvent.decisions[choice].minAlcool &&
            player.GetEnergy() >= currentEvent.decisions[choice].minEnergy &&
            player.GetFun() >= currentEvent.decisions[choice].minFun)
        {
            player.ChangeStats(player, currentEvent.decisions[choice].sucessEvent.alcoolPlus,
                currentEvent.decisions[choice].sucessEvent.funPlus,
                currentEvent.decisions[choice].sucessEvent.moneyPlus,
                currentEvent.decisions[choice].sucessEvent.energyPlus);
            time.UpdateTime(currentEvent.decisions[choice].sucessEvent.timePassed);
            //Call achievement
            if (currentEvent.decisions[choice].sucessEvent.nextEvent != null)
            {
                SetupDialogue(currentEvent.decisions[choice].sucessEvent.nextEvent);
                StartDialogue(currentEvent.decisions[choice].sucessEvent.nextEvent);
            }else
            {
                uiEvents.CloseCanvas();
                uiEvents.CloseDialogueObject();
                uiEvents.CloseMultipleChoices(3);
                Restart();
            }
           
        }else
        {
            player.ChangeStats(player, currentEvent.decisions[choice].failedEvent.alcoolPlus,
                currentEvent.decisions[choice].failedEvent.funPlus,
                currentEvent.decisions[choice].failedEvent.moneyPlus,
                currentEvent.decisions[choice].failedEvent.energyPlus);
            time.UpdateTime(currentEvent.decisions[choice].sucessEvent.timePassed);
            //Call achievement
            if (currentEvent.decisions[choice].sucessEvent.nextEvent != null)
            {;
                SetupDialogue(currentEvent.decisions[choice].sucessEvent.nextEvent);
                StartDialogue(currentEvent.decisions[choice].failedEvent.nextEvent);
            }
            else
            {
                uiEvents.CloseCanvas();
                uiEvents.CloseDialogueObject();
                uiEvents.CloseMultipleChoices(3);
                Restart();
            }

        }
          
    }

    IEnumerator TypeLine()
    {
        foreach(char c in currentEvent.dialogue[index].text.ToCharArray())
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
                if (uiEvents.GetDialogueText() == currentEvent.dialogue[index].text )
                {                
                    NextLine();
                }else
                {
                    StopAllCoroutines();
                    uiEvents.UpdateNpcDialogue(currentEvent.dialogue[index].text);
                }
            }
        }
    }

    public void NextLine()
    {
        if(index < currentEvent.dialogue.Length -1)
        {
            index++;
            uiEvents.UpdateNpcDialogue(string.Empty);
            StartCoroutine(TypeLine());
        }else
        {
            reading = false;
            index = 0;
            uiEvents.UpdateNpcDialogue(string.Empty);
            if (currentEvent.decisions.Length > 0)
            {

                StartChoices();
               
            }else
            {
                if (restart == true)
                {
                    Restart();
                }
                uiEvents.CloseCanvas();
            }

            uiEvents.CloseDialogueObject();

        }
    }

    public void Restart()
    {
        game.StartMovement();
    }


}
