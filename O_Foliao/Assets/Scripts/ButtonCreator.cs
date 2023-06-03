using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCreator : MonoBehaviour
{
    public Button buttonPrefab;
    public Quest buttonQuest;

    [SerializeField]
    private TextMeshProUGUI questTitle;

    [SerializeField]
    private TextMeshProUGUI questDescription;

    [SerializeField]
    private GameObject questInformationParent;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            Button buttonInstance = Instantiate(buttonPrefab, transform);
            ChangeQuestButtonName(buttonInstance, buttonQuest.questTitle);
            buttonInstance.onClick.RemoveAllListeners();
            buttonInstance.onClick.AddListener(() => OnClickAction(buttonQuest));
        }
    }

    void OnClickAction(Quest quest)
    {
        questTitle.text = quest.questTitle;
        questDescription.text = quest.questDescription;
        questInformationParent.SetActive(true);
    }

    public void ChangeQuestButtonName(Button button, string text)
    {
        button.GetComponentInChildren<TextMeshProUGUI>().text = text;
    }

}

