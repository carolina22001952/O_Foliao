using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIPhone : MonoBehaviour
{
    [SerializeField] Animator animator;

    private bool isMouseOver = false;
    void Update()
    {
        IsMouseDown();
    }

    private void IsMouseDown()
    {
        if(Input.GetMouseButtonUp(0))
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
                if (results[i].gameObject.CompareTag("Phone"))
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
        //animator.SetBool("Active", isMouseOver && Input.GetMouseButton(0));
    }
}
