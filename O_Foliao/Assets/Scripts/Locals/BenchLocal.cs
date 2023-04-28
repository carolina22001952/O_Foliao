using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class BenchLocal : MonoBehaviour, ILocal
{
    [SerializeField]
    private PrimaryEventList primaryEventList;

    [SerializeField]
    private EventListTools eventListTools;

    [SerializeField]
    private UIEventManager uiEventManager;

    [SerializeField]
    private BenchUI benchUI;

    public void localInteraction(Player player, Clock clock)
    {
        benchUI.OpenBenchUI();
    }

    public void ChoiceBench(int choice)
    {
        switch (choice)
        {
            case 0:
                benchUI.OpenBenchUI();
                break;
            case 1:
                benchUI.CloseBenchUI();
                break;
        }
    }

    public void localChoice(bool more)
    {

    }

    public void localDialogue(bool more)
    {

    }
}