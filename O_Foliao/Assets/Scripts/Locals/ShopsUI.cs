using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEditor;
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

    [SerializeField]
    private Animator animation;


    private bool lever = true;

    public void OpenShopUI()
    {
        dialogueGroup.SetActive(true);
        animator.SetBool("Active", true);
    }

    public void CloseShopUI()
    {
        animator.SetBool("Active", false);
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

    public void ButtonInteraction(bool lever)
    {

        choice1Button.interactable = lever;
        choice2Button.interactable = lever;
        choice3Button.interactable = lever;
    }

    public void CheckAnimationCompletion()
    {

    }

    public void Update()
    {
        if(animation.GetCurrentAnimatorStateInfo(0).IsName("Open_EventsUICanvas"))
        {
            Debug.Log("FALSE");
            ButtonInteraction(false);
        }
        else if(animation.GetCurrentAnimatorStateInfo(0).IsName("New State"))
        {
            Debug.Log("True");
            ButtonInteraction(true);
        }
        else
        {
            ButtonInteraction(false);
        }
    }





}
