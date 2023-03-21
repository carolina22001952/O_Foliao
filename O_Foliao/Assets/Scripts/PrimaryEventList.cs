using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PrimaryEventList : MonoBehaviour
{
    public EventListTools eventListTools;

    [Header("Zones")]
    [SerializeField] private List<Events> bars;
    [SerializeField] private List<Events> batata;
    [SerializeField] private List<Events> cebola;
    [SerializeField] private List<Events> bench;

    [Header("Market")]
    [SerializeField] private List<Events> market;

    [Header("Hotels")]
    [SerializeField] private List<Events> hotel;

    [Header("Tunel")]
    [SerializeField] private List<Events> tunel;

    [Header("Bars")]
    [SerializeField] private List<Events> celeiro;
    [SerializeField] private List<Events> vinil;
    [SerializeField] private List<Events> skadi;
    [SerializeField] private List<Events> barsInside;

    [Header("TimeOfDay")]
    [SerializeField] private List<Events> morningDeck;
    [SerializeField] private List<Events> afternoonDeck;
    [SerializeField] private List<Events> nightDeck;

    [Header("Day")]
    [SerializeField] private List<Events> day1Deck;
    [SerializeField] private List<Events> day2Deck;
    [SerializeField] private List<Events> day3Deck;

    [Header("Resource Events")]
    [SerializeField] private List<Events> lowAlcohol;
    [SerializeField] private List<Events> highAlcohol;
    [SerializeField] private List<Events> lowEnergy;

    [Header("Bench Event")]
    [SerializeField] private List<Events> Bench;
    [SerializeField] private List<Events> RandomBench;

    [Header("Hotel")]
    [SerializeField] private List<Events> Hotel;

    [SerializeField] private int lowAlcoholThreshold = 20;
    [SerializeField] private int highAlcoholThreshold = 80;
    [SerializeField] private int lowEnergyThreshold = 20;

    public event EventHandler Event;

    public List<Events> GetBarsZoneEvents()
    {
        return this.bars;
    }

    public List<Events> GetBatataZoneEvents()
    {
        return this.batata;
    }
    public List<Events> GetCebolaZoneEvents()
    {
        return this.cebola;
    }
    public List<Events> GetBenchZoneEvents()
    {
        return this.bench;
    }
    public List<Events> GetMarketZoneEvents()
    {
        return this.market;
    }
    public List<Events> GetHotelZoneEvents()
    {
        return this.hotel;
    }
    public List<Events> GetTunelZoneEvents()
    {
        return this.tunel;
    }
    public List<Events> GetCeleiroZoneEvents()
    {
        return this.celeiro;
    }
    public List<Events> GetVinilZoneEvents()
    {
        return this.vinil;
    }

    public List<Events> GetSkadiZoneEvents()
    {
        return this.skadi;
    }
    public List<Events> GetBarsInsideZoneEvents()
    {
        return this.barsInside;
    }
    public List<Events> GetMorningZoneEvents()
    {
        return this.morningDeck;
    }
    public List<Events> GetAfternoonZoneEvents()
    {
        return this.afternoonDeck;
    }

    public List<Events> GetNightZoneEvents()
    {
        return this.nightDeck;
    }

    public List<Events> GetDay1Events()
    {
        return this.day1Deck;
    }
    public List<Events> GetDay2Events()
    {
        return this.day2Deck;
    }
    public List<Events> GetDay3Events()
    {
        return this.day3Deck;
    }
    public List<Events> GetLowAlcoholEvents()
    {
        return this.lowAlcohol;
    }
    public List<Events> GetHighAlcoholEvents()
    {
        return this.highAlcohol;
    }
    public List<Events> GetLowEnergyEvents()
    {
        return this.lowEnergy;
    }

    public List<Events> GetDayDeck(Clock time)
    {
        switch(time.GetDay())
        {
            case 1:
                return GetDay1Events();
            case 2:
                return GetDay2Events();
            case 3:
                return GetDay3Events();
            default:
                throw new NotImplementedException("Day" + time.GetDay() + "unknown");
        }
    }

    public List<Events> GetResourceEvents(Player player)
    {
        List<Events> auxList = null;
        if(player.GetAlcohol() <= lowAlcoholThreshold)
        {
            auxList = eventListTools.UnionEvents(GetLowAlcoholEvents());
        }else if(player.GetAlcohol() >= highAlcoholThreshold)
        {
            auxList = eventListTools.UnionEvents(GetHighAlcoholEvents());
        }
        if(player.GetEnergy() <= lowEnergyThreshold)
        {
            auxList = eventListTools.UnionEvents(GetLowEnergyEvents());
        }

        return auxList;
        
    }

    public EventType CheckForEventType(List<Events> eventList)
    {
        List<Events> auxList = null;
        bool primaryEventExists = false;
        foreach(Events events in eventList)
        {
            if(events.eventType == EventType.Primary)
            {
                return EventType.Primary;
            }
        }

        foreach (Events events in eventList)
        {
            if (events.eventType == EventType.Secondary)
            {
                return EventType.Secondary;
            }
        }

        foreach (Events events in eventList)
        {
            if (events.eventType == EventType.Random)
            {
                return EventType.Secondary;
            }
        }


        throw new NotImplementedException("EventType not Implemented");
    }

    public List<Events> GetAllEventsOfOneType(List<Events> eventList, EventType eventType)
    {
        List<Events> newList = new List<Events>();
        foreach(Events events in eventList)
        {
            if(events.eventType == eventType)
            {
                eventListTools.InsertAnEvent(events, newList);
            }
        }

        return newList;

    }

}


