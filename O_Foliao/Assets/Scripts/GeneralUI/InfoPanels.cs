using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPanels : MonoBehaviour
{
    //Colliders
    [Header("Icon Colliders")]
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

    [Header("Icon Colliders")]
    [Header("Bars")]
    [SerializeField] private Collider vinilInfoCollider;
    [SerializeField] private Collider celeiroInfoCollider;
    [SerializeField] private Collider skadiInfoCollider;
    [Header("Stages")]
    [SerializeField] private Collider batataInfoCollider;
    [SerializeField] private Collider cebolaInfoCollider;
    [Header("Benches")]
    [SerializeField] private Collider bench1InfoCollider;
    [SerializeField] private Collider bench2InfoCollider;
    [SerializeField] private Collider bench3InfoCollider;
    
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
            IsMouseOverPanel(vinilCollider, vinilInfoCollider, vinilPanelAnimator);
            IsMouseOverPanel(celeiroCollider, celeiroInfoCollider, celeiroPanelAnimator);
            IsMouseOverPanel(skadiCollider, skadiInfoCollider, skadiPanelAnimator);
            IsMouseOverPanel(batataCollider, batataInfoCollider, batataPanelAnimator);
            IsMouseOverPanel(cebolaCollider, cebolaInfoCollider, cebolaPanelAnimator);
            IsMouseOverPanel(bench1Collider, bench1InfoCollider, bench1PanelAnimator);
            IsMouseOverPanel(bench2Collider, bench2InfoCollider, bench2PanelAnimator);
            IsMouseOverPanel(bench3Collider, bench3InfoCollider, bench3PanelAnimator);
        }
    }


    void IsMouseOverPanel(Collider panelCollider, Collider infoPanel, Animator panelAnimator)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit) && (hit.collider == panelCollider || hit.collider == infoPanel))
        {
            panelAnimator.SetBool("Active", true);
        }   
        else
        {
            panelAnimator.SetBool("Active",false);
        }    
    }
}

    