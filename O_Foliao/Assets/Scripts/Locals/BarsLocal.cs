using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarsLocal : MonoBehaviour, ILocal
{
    [SerializeField]
    private PrimaryEventList primaryEventList;

    [SerializeField]
    private EventListTools eventListTools;

    [SerializeField]
    private BarslUI barsUI;



    private List<Events> barsInsideEvents;
    private List<Events> dayEvents;
    private List<Events> resourceEvents;
    public void localInteraction(Player player, Clock clock)
    {
        barsUI.OpenBarsUI();
    }


   
}
