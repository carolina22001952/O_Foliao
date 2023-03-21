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
    private TextMeshProUGUI dialogueText;
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

    public void UpdateShopDialogue(string dialogue)
    {
        dialogueText.text = dialogue;
    }

    public void UpdateBackground(Sprite newbackground)
    {
        background.sprite = newbackground;
    }




}
