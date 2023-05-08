using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAction : MonoBehaviour
{
    public UIEvents uiEvents;
    public PrimaryEventList primaryEventList;

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

    //1 

    public void OpenCanvas()
    {
        uiEvents.OpenCanvas();
    }

    public bool IsReading()
    {
        return reading; 
    }
    private void Start()
    {
        uiEvents.UpdateNpcDialogue(string.Empty);

    }

    public void SetupDialogue()
    {
        uiEvents.OpenDialogueObject();
        uiEvents.CloseMultipleChoices(3);
    }

    public void StartDialogue()
    {
        SetupDialogue();
        currentEvent = primaryEventList.GetCurrentEvent();
        uiEvents.UpdateNpcName(currentEvent.dialogue[index].npc.name);
        uiEvents.OpenCharacterGameObject();
        uiEvents.OpenNpcGameObject();
        uiEvents.UpdateNpcSprite(currentEvent.dialogue[index].npc.sprite);
        
        index = 0;
        reading = true;
        StartCoroutine(TypeLine());


    }

    public void StartChoices()
    {
        uiEvents.OpenPlayerChoicesGroup();
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
        if (
            player.GetAlcohol() >= currentEvent.decisions[choice].minAlcool &&
            player.GetEnergy() >= currentEvent.decisions[choice].minEnergy &&
            player.GetFun() >= currentEvent.decisions[choice].minFun
            && player.GetMoney() >= currentEvent.decisions[choice].minMoney)
        {
            player.ChangeStats(player, currentEvent.decisions[choice].sucessEvent.alcoolPlus,
                currentEvent.decisions[choice].sucessEvent.funPlus,
                currentEvent.decisions[choice].sucessEvent.moneyPlus,
                currentEvent.decisions[choice].sucessEvent.energyPlus);
            time.UpdateTime(currentEvent.decisions[choice].sucessEvent.timePassed);

            ///
            primaryEventList.EventContinuation(currentEvent.decisions[choice].sucessEvent.eventsToInsert);
            //Call achievemen
            if (currentEvent.decisions[choice].sucessEvent.nextEvent != null)
            {
                Debug.Log("yup");
                primaryEventList.ChangeCurrentEvent(currentEvent.decisions[choice].sucessEvent.nextEvent);
                player.Position().GetComponent<ILocal>().localChoice(true);
            }
            else
            {
                uiEvents.CloseDialogueObject();
                player.Position().GetComponent<ILocal>().localChoice(false);
            }

        }

        else
        {
            player.ChangeStats(player, currentEvent.decisions[choice].failedEvent.alcoolPlus,
                currentEvent.decisions[choice].failedEvent.funPlus,
                currentEvent.decisions[choice].failedEvent.moneyPlus,
                currentEvent.decisions[choice].failedEvent.energyPlus);
            time.UpdateTime(currentEvent.decisions[choice].sucessEvent.timePassed);
            //Call achievement
            primaryEventList.EventContinuation(currentEvent.decisions[choice].failedEvent.eventsToInsert);
            if (currentEvent.decisions[choice].failedEvent.nextEvent != null)
            {
                Debug.Log("yup2");
                primaryEventList.ChangeCurrentEvent(currentEvent.decisions[choice].failedEvent.nextEvent);
                player.Position().GetComponent<ILocal>().localChoice(true);
            }
            else
            {
                uiEvents.CloseDialogueObject();
                player.Position().GetComponent<ILocal>().localChoice(false);
            }

        }




    }

    IEnumerator TypeLine()
    {
        Debug.Log(currentEvent.dialogue[index].text);
        currentEvent.dialogue[index].text.Replace("  ", " ").Trim();
        Debug.Log(currentEvent.dialogue[index].text);
        foreach (char c in currentEvent.dialogue[index].text.ToCharArray())
        {
            uiEvents.TypeNpcDialogue(c);
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void Update()
    {
        if (reading)
        {

            if (Input.GetMouseButtonDown(0))
            {

                if (uiEvents.GetDialogueText() == currentEvent.dialogue[index].text)
                {
                    NextLine();
                }
                else
                {
                    StopAllCoroutines();
                    uiEvents.UpdateNpcDialogue(currentEvent.dialogue[index].text);
                }
            }
        }
    }

    public void NextLine()
    {
        if (index < currentEvent.dialogue.Length - 1)
        {
            currentEvent.dialogue[index].text.Replace("  ", " ").Trim();
            index++;
            uiEvents.UpdateNpcDialogue(string.Empty);
            StartCoroutine(TypeLine());
        }
        else
        {
            reading = false;
            index = 0;
            uiEvents.UpdateNpcDialogue(string.Empty);
            uiEvents.CloseDialogueObject();
            if (currentEvent.decisions.Length > 0)
            {

                player.Position().GetComponent<ILocal>().localDialogue(true);

            }
            else
            {
                uiEvents.CloseCanvas();
                player.Position().GetComponent<ILocal>().localDialogue(false);
            }
            
        }
    }



}
