using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIPhone : MonoBehaviour
{
    [Header("Animators")]
    [SerializeField] private Animator animator;
    [SerializeField] private Animator timeDayIcon;

    [Header("Images")]
    [SerializeField] private Image mainBgImage;

    [Header("Sprites")]
    [SerializeField] private Sprite mainBgSprite;
    [SerializeField] private Sprite bankBgSprite;
    [SerializeField] private Sprite questBgSprite;
    [SerializeField] private Sprite achieveBgSprite;
    [SerializeField] private Sprite optionBgSprit;

    [Header("Notifications")]
    [SerializeField] private GameObject notificationAchieve;
    [SerializeField] private GameObject notificationQuest;

    private bool isMouseOver = false;
    private bool mainBG = true;

    void Start()
    {
        mainBgSprite = mainBgImage.sprite;
    }

    void Update()
    {
        IsMouseDown();
    }

    private void IsMouseDown()
    {
        if(Input.GetMouseButtonUp(1))
        {
            if(isMouseOver)
            {
                animator.SetBool("Active", !animator.GetBool("Active"));
            }   
        }
        IsMouseOverUI();
    }
    

    private void IsMouseOverUI()
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            pointerId = -1,
        };

        pointerData.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);

        if(results.Count > 0)
        {
            for(int i = 0; i < results.Count; ++i)
            {
                if(results[i].gameObject.CompareTag("Phone"))
                {
                    isMouseOver = true;
                    break;
                }
            }
        }
        else
        {
            isMouseOver = false;
        }
    }

    private void ChangeBg(Sprite appBg)
    {
        if(mainBG == true)
        {
            mainBgImage.sprite = appBg;
            timeDayIcon.SetBool("Active", true);
            mainBG = false;
        }
        else
        {
            mainBgImage.sprite = mainBgSprite;
            timeDayIcon.SetBool("Active", false);
            mainBG = true;
        }
    }

    public void ChangeBankApp()
    {
       ChangeBg(bankBgSprite);
    }

    public void ChangeQuestApp()
    {
       ChangeBg(questBgSprite);
    }

    public void ChangeAchieveApp()
    {
       ChangeBg(achieveBgSprite);
    }
    public void ChangeOptionApp()
    {
       ChangeBg(optionBgSprit);
    }

    public void TurnNotificationAchieve(bool isOn)
    {
        notificationAchieve.SetActive(isOn);
    }

    public void TurnNotificationQuest(bool isOn)
    {
        notificationQuest.SetActive(isOn);
        Debug.Log("bruv");
    }
}

