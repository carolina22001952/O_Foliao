using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using Unity.VisualScripting;

public class QuestsUI : MonoBehaviour
{
    [SerializeField]
    private Button buttonPrefab;


    [SerializeField]
    private TextMeshProUGUI questTitle;

    [SerializeField]
    private TextMeshProUGUI questDescription;

   // [SerializeField]
   // private List<Button> buttonsList;

    [SerializeField]
    private Dictionary<Button,Quest> buttonsList;

    [SerializeField]
    private GameObject contentGrid;

    [SerializeField]
    private GameObject questInformationParent;

    [SerializeField]
    private GameObject locationText;

    [SerializeField]
    private LocationHighLight locationHighLight;

    [SerializeField] 
    private AudioManager audioManager;

    private void Start()
    {
        buttonsList = new Dictionary<Button, Quest>();
    }
    public void InsertNewButton(Quest quest)
    {
        Button buttonInstance = Instantiate(buttonPrefab, contentGrid.transform);
        buttonsList.Add(buttonInstance,quest);
        ChangeQuestButtonName(buttonInstance, quest.questTitle);

        buttonInstance.onClick.RemoveAllListeners();
        buttonInstance.onClick.AddListener(() => OnClickAction(quest));

        audioManager.PlayNotificationSound();
    }

    public void OnClickAction(Quest quest)
    {
        questTitle.text = quest.questTitle;
        questDescription.text = quest.questDescription;
      //  locationHighLight.UpdateLocation(quest.location);
        questInformationParent.SetActive(true);
        audioManager.PlayButtonSound();
    }

    public void ChangeQuestButtonName(Button button, string text)
    {
        button.GetComponentInChildren<TextMeshProUGUI>().text = text;
    }

    public void UpdateCompletedQuest(Quest quest)
    {
        Button button = buttonsList.FirstOrDefault(x => x.Value == quest).Key;
        ChangeQuestButtonName(button, "(Completed) " + quest.questTitle);
    }

    public void UpdateFailedQuest(Quest quest)
    {
        Button button = buttonsList.FirstOrDefault(x => x.Value == quest).Key;
        ChangeQuestButtonName(button, "(Failed) " + quest.questTitle);
    }


}
