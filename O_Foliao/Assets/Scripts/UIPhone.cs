using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIPhone : MonoBehaviour
{
    [SerializeField] Animator animator;

    private bool isMouseOver = false;

    void Play()
    {
        animator = GetComponent<Animator>();
        isMouseOver = false;
    }

    void Update()
    {
        IsMouseOverUI();
    }

    private void IsMouseOverUI()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            PointerEventData pointerData = new PointerEventData(EventSystem.current)
            {
                pointerId = -1,
            };
    
            pointerData.position = Input.mousePosition;
    
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerData, results);
    
            if (results.Count > 0)
            {
                for( int i = 0 ; i < results.Count ; ++i )
                {
                    if( results[i].gameObject.CompareTag( "Phone" ) )
                    {
                        isMouseOver = true ;
                        animator.SetBool("IsMouseOver", true);
                        //Debug.Log("ta aqui");
                    }              
                }   
            }
        }
        else
        {
            isMouseOver = false;
            animator.SetBool("IsMouseOver", false);
            //Debug.Log("nao ta aqui");
        }
    }

    /*void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("ta em cima");
        throw new System.NotImplementedException();     
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Nao ta");
        throw new System.NotImplementedException();   
    }*/
}
