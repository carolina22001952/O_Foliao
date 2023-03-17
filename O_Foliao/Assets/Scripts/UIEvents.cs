using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIEvents : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI dialogueText;
    [SerializeField]
    private TextMeshProUGUI npcName;
    [SerializeField]
    private GameObject dialogueGameObject;
    [SerializeField]
    private Sprite npcSprite;


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



    [SerializeField]
    public float textspeed;

    private void Start()
    {

    }

    public void UpdateNpcSprite(Sprite sprite)
    {

        npcSprite = sprite;
    }

    public string GetDialogueText()
    {
        Debug.Log("Updated");
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
        playerChoices1GameObject.SetActive(false);
    }
    public void OpenPlayerChoice3()
    {
        playerChoices1GameObject.SetActive(true);
    }

    public void UpdateNpcName(string name)
    {
        npcName.text = name;
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

    public void UpdateEventUI(Events events)
    {

    }
}
