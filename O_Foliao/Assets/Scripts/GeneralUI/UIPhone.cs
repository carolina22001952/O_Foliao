using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIPhone : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private bool isMouseOver = false;
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
                Debug.Log("ola");
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
}
