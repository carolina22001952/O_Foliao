using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestsUI : MonoBehaviour
{
    [SerializeField]
    private Button buttonPrefab;


    [SerializeField]
    private TextMeshProUGUI questTitle;

    [SerializeField]
    private TextMeshProUGUI questDescription;

    [SerializeField]
    private List<Button> buttonsList;

    [SerializeField]
    private GameObject questInformationParent;

    public void InsertNewButton(Quest quest)
    {
        Button buttonInstance = Instantiate(buttonPrefab, transform);
        buttonsList.Add(buttonInstance);
        ChangeQuestButtonName(buttonInstance, quest.questTitle);

        buttonInstance.onClick.RemoveAllListeners();
        buttonInstance.onClick.AddListener(() => OnClickAction(quest));

    }

    public void OnClickAction(Quest quest)
    {
        questTitle.text = quest.questTitle;
        questDescription.text = quest.questDescription;
        questInformationParent.SetActive(true);
    }

    public void ChangeQuestButtonName(Button button, string text)
    {
        button.GetComponentInChildren<TextMeshProUGUI>().text = text;
    }

    public void UpdateCompletedQuest(Quest quest)
    {
        
    }
}
