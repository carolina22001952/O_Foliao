using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopsUI : MonoBehaviour
{
    [SerializeField]
    private GameObject dialogueGroup;
    [SerializeField]
    private TextMeshProUGUI choice1Dialogue;
    [SerializeField]
    private TextMeshProUGUI choice2Dialogue;
    [SerializeField]
    private TextMeshProUGUI choice3Dialogue;
    [SerializeField]
    private Button choice1Button;
    [SerializeField]
    private Button choice2Button;
    [SerializeField]
    private Button choice3Button;

    [SerializeField]
    private Image background;

    public void OpenShopUI()
    {
        dialogueGroup.SetActive(true);
    }

    public void CloseShopUI()
    {
        dialogueGroup.SetActive(false);
    }

    public void UpdateChoices(Events events)
    {
        choice1Dialogue.text = events.decisions[0].choiceDialogue;
        choice1Dialogue.text = events.decisions[1].choiceDialogue;
        choice1Dialogue.text = events.decisions[2].choiceDialogue;
    }

    public void UpdateBackground(Sprite newbackground)
    {
        background.sprite = newbackground;
    }

    public void ButtonInteraction(bool lever)
    {
        choice1Button.interactable = lever;
        choice2Button.interactable = lever;
        choice3Button.interactable = lever;
    }



}
