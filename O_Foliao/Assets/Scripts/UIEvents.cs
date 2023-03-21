using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIEvents : MonoBehaviour
{
    [SerializeField]
    private GameObject DialogCanvas;

    [Header("Dialog Object")]
    [SerializeField]
    private GameObject dialogueGameObject;
    [SerializeField]
    private TextMeshProUGUI dialogueText;
    [SerializeField]
    private TextMeshProUGUI nameText;


    [Header("Character Objects")]
    [SerializeField]
    private GameObject npcSpriteGameObject;
    private Sprite npcSprite;
    [SerializeField]
    private GameObject characterSpriteGameObject;
    private Sprite charatcerSprite;

    [Header("Player Choices Objects")]
    [SerializeField]
    private GameObject playerChoicesGameObjectGroup;
    [SerializeField]
    private GameObject playerChoices1GameObject;
    [SerializeField]
    private GameObject playerChoices2GameObject;
    [SerializeField]
    private GameObject playerChoices3GameObject;
    [SerializeField]
    private TextMeshProUGUI playerChoice1Text;
    [SerializeField]
    private TextMeshProUGUI playerChoice2Text;
    [SerializeField]
    private TextMeshProUGUI playerChoice3Text;

    [SerializeField]
    private Image Background;




    public void OpenCanvas()
    {
        DialogCanvas.SetActive(true);
    }

    public void CloseCanvas()
    {
        DialogCanvas.SetActive(false);
    }
    public void UpdateNpcSprite(Sprite sprite)
    {

        npcSprite = sprite;
    }

    public void OpenNpcGameObject()
    {
        npcSpriteGameObject.SetActive(true);
    }

    public void CloseNpcGameObject()
    {
        npcSpriteGameObject.SetActive(false);
    }

    public void OpenCharacterGameObject()
    {
        characterSpriteGameObject.SetActive(true);
    }

    public void CloseCharacterGameObject()
    {
        characterSpriteGameObject.SetActive(false);
    }

    public string GetDialogueText()
    {
        return dialogueText.text;
    }

    public void TypeNpcDialogue(char c)
    {
        dialogueText.text += c;
    }

    public void UpdatePlayerChoice1Text(string choice)
    {
        playerChoice1Text.text = choice;
    }

    public void ClosePlayerChoice1()
    {
        playerChoices1GameObject.SetActive(false);
    }
    public void OpenPlayerChoice1()
    {
        playerChoices1GameObject.SetActive(true);
    }
    public void UpdatePlayerChoice2Text(string choice)
    {
        playerChoice2Text.text = choice;
    }
    public void ClosePlayerChoice2()
    {
        playerChoices2GameObject.SetActive(false);
    }
    public void OpenPlayerChoice2()
    {
        playerChoices2GameObject.SetActive(true);
    }
    public void UpdatePlayerChoice3Text(string choice)
    {
        playerChoice3Text.text = choice;
    }
    public void ClosePlayerChoice3()
    {
        playerChoices3GameObject.SetActive(false);
    }
    public void OpenPlayerChoice3()
    {
        playerChoices3GameObject.SetActive(true);
    }

    public void UpdateNpcName(string name)
    {
        nameText.text= name + ":";
    }

    public void UpdateNpcDialogue(string dialogue)
    {
        dialogueText.text = dialogue;
    }

    public void OpenDialogueObject()
    {
        dialogueGameObject.SetActive(true);
    }

    public void CloseDialogueObject()
    {
        dialogueGameObject.SetActive(false);
    }

    public void OpenPlayerChoicesGroup()
    {
        playerChoicesGameObjectGroup.SetActive(true);
    }
    public void ClosePlayerChoicesGroup()
    {
        playerChoicesGameObjectGroup.SetActive(false);
    }

    public void OpenMultipleChoices(int numberOfChoices)
    {
        OpenPlayerChoicesGroup();
        switch(numberOfChoices)
        {
            case 0:
                break;
            case 1:
                OpenPlayerChoice1();
                break;
            case 2:
                OpenPlayerChoice1();
                OpenPlayerChoice2();
                break;
            case 3:
                OpenPlayerChoice1();
                OpenPlayerChoice2();
                OpenPlayerChoice3();
                break;
        }
    }

    public void CloseMultipleChoices(int numberOfChoices)
    {
        ClosePlayerChoicesGroup();
        switch (numberOfChoices)
        {
            case 0:
                break;
            case 1:
                ClosePlayerChoice1();
                break;
            case 2:
                ClosePlayerChoice1();
                ClosePlayerChoice2();
                break;
            case 3:
                ClosePlayerChoice1();
                ClosePlayerChoice2();
                ClosePlayerChoice3();
                break;
        }
    }

}
