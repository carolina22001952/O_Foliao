using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPanels : MonoBehaviour
{
    //Colliders
    [Header("Colliders")]
    [Header("Bars")]
    [SerializeField] private Collider vinilCollider;
    [SerializeField] private Collider celeiroCollider;
    [SerializeField] private Collider skadiCollider;
    [Header("Stages")]
    [SerializeField] private Collider batataCollider;
    [SerializeField] private Collider cebolaCollider;
    [Header("Benches")]
    [SerializeField] private Collider bench1Collider;
    [SerializeField] private Collider bench2Collider;
    [SerializeField] private Collider bench3Collider;

    //Animators
    [Header("Animators")]
    [Header("Bars")]
    [SerializeField] private Animator vinilPanelAnimator;
    [SerializeField] private Animator celeiroPanelAnimator;
    [SerializeField] private Animator skadiPanelAnimator;
    [Header("Stages")]
    [SerializeField] private Animator batataPanelAnimator;
    [SerializeField] private Animator cebolaPanelAnimator;
    [Header("Benches")]
    [SerializeField] private Animator bench1PanelAnimator;
    [SerializeField] private Animator bench2PanelAnimator;
    [SerializeField] private Animator bench3PanelAnimator;


    [SerializeField] private Movement move;

    void Update()
    {
        if(move.IsMoving())
        {
            IsMouseOverPanel(vinilCollider, vinilPanelAnimator);
            IsMouseOverPanel(celeiroCollider, celeiroPanelAnimator);
            IsMouseOverPanel(skadiCollider, skadiPanelAnimator);
            IsMouseOverPanel(batataCollider, batataPanelAnimator);
            IsMouseOverPanel(cebolaCollider, cebolaPanelAnimator);
            IsMouseOverPanel(bench1Collider, bench1PanelAnimator);
            IsMouseOverPanel(bench2Collider, bench2PanelAnimator);
            IsMouseOverPanel(bench3Collider, bench3PanelAnimator);
        }
    }


    void IsMouseOverPanel(Collider panelCollider, Animator panelAnimator)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit) && hit.collider == panelCollider)
        {
            panelAnimator.SetBool("Active", true);
        }   
        else
        {
            panelAnimator.SetBool("Active",false);
        }    
    }
}

    