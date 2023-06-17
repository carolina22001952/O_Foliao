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

    [SerializeField]
    private Animator animator;


    private bool lever = true;
    private int counter = 0;

    public void OpenShopUI()
    {
        dialogueGroup.SetActive(true);
        animator.SetBool("Active", true);
        counter = 0;
    }

    public void CloseShopUI()
    {
        animator.SetBool("Active", false);
        counter = 0;
        //dialogueGroup.SetActive(false);
    }

    public void UpdateChoices(Events events)
    {
        choice1Dialogue.text = events.decisions[0].choiceDialogue;
        choice2Dialogue.text = events.decisions[1].choiceDialogue;
        choice3Dialogue.text = events.decisions[2].choiceDialogue;
    }

    public void UpdateBackground(Sprite newbackground)
    {
        background.sprite = newbackground;
    }

    public void ButtonInteraction()
    {
        if(lever == true)
        {
            lever = false; 
        }
        else
        {
            lever = true;
        }
        choice1Button.interactable = lever;
        choice2Button.interactable = lever;
        choice3Button.interactable = lever;
    }

    public void CheckAnimationCompletion()
    {

    }

    public void Update()
    {
        if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            if (counter == 0)
            {
                ButtonInteraction();
                counter++;
            }
        }
    }



}
