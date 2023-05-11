using System;
using System.Collections.Generic;
using UnityEngine;
using static EventBaseData;
using DayOfWeek = EventBaseData.DayOfWeek;
using Random = System.Random;

public class PrimaryEventList : MonoBehaviour
{
    public EventListTools eventListTools;

    public Events currentEvent;

    [Header("Zones")]

    [SerializeField] private List<Events> batata;
    [SerializeField] private List<Events> cebola;

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

    [Header("Barmen")]
    [SerializeField] private List<Events> barmen;
    [Header("BarDance")]
    [SerializeField] private List<Events> barDance;

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
    [SerializeField] private List<Events> bench;

    [Header("Hotel")]
    [SerializeField] private List<Events> Hotel;

    [Header("ResourceEvents lvls")]
    [SerializeField] private int lowAlcoholThreshold = 20;
    [SerializeField] private int highAlcoholThreshold = 80;
    [SerializeField] private int lowEnergyThreshold = 20;

    [Header("Probabilities")]
    [SerializeField] private int primary = 80;
    [SerializeField] private int random = 20;
    [SerializeField] private int secondary = 0;

    public void ChangeCurrentEvent(Events events)
    {
        Debug.Log(events.eventType);
        if (events.eventType != EventType.Random)
        {
            Debug.Log("Ya");
            eventListTools.RemoveEvent(events, morningDeck, afternoonDeck, nightDeck);
        }
        currentEvent = events;
    }

    public Events GetCurrentEvent()
    {
        return currentEvent;
    }
    public List<Events> GetBarmenEvents()
    {
        return this.barmen;
    }
    public List<Events> GetBarDanceEvents()
    {
        return this.barDance;
    }
    public List<Events> GetBatataZoneEvents()
    {
        return this.batata;
    }
    public List<Events> GetCebolaZoneEvents()
    {
        return this.cebola;
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

    public List<Events> GetBenchEvents()
    {
        return this.bench;
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

    public List<Events> GetTimeOfDayDeck(Clock time)
    {
        switch (time.GetCurrentTimeOfDay())
        {
            case Clock.TimesOfDay.Morning:
                return GetMorningZoneEvents();
            case Clock.TimesOfDay.Afternoon:
                return GetAfternoonZoneEvents();
            case Clock.TimesOfDay.Night:
                return GetNightZoneEvents();
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
        do
        {
            int number = RandomNumber();
            if (number < primary)
            {
                foreach (Events events in eventList)
                {
                    if (events.eventType == EventType.Primary)
                    {
                        return EventType.Primary;
                    }
                }
            }
            else if (number > primary && number < primary + secondary)
            {
                foreach (Events events in eventList)
                {
                    if (events.eventType == EventType.Secondary)
                    {
                        return EventType.Secondary;
                    }
                }
            }
            else
            {

                foreach (Events events in eventList)
                {
                    if (events.eventType == EventType.Random)
                    {
                        return EventType.Random;
                    }
                }
            }
        } while (true);


    }

    public int RandomNumber()
    {
        Random rnd = new Random();
        return rnd.Next(1,101);
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

    public void EventContinuation(Events[] eventslist)
    {
        foreach(Events events in eventslist )
        {
            if( events.eventBaseData.locals.Length > 0)
            {
                foreach(Locals local in events.eventBaseData.locals)
                {
                    switch (local)
                    {
                        case Locals.Cebola:
                            eventListTools.InsertAnEvent(events, cebola);
                            break;
                        case Locals.Batata:
                            eventListTools.InsertAnEvent(events, batata);
                            break;
                        case Locals.Barmen:
                            eventListTools.InsertAnEvent(events, barmen);
                            break;
                        case Locals.Celeiro:
                            eventListTools.InsertAnEvent(events, celeiro);
                            break;
                        case Locals.Skadi:
                            eventListTools.InsertAnEvent(events, skadi);
                            break;
                        case Locals.Vinil:
                            eventListTools.InsertAnEvent(events, vinil);
                            break;
                        case Locals.Tunel:
                            eventListTools.InsertAnEvent(events, tunel);
                            break;
                        case Locals.Hotel:
                            eventListTools.InsertAnEvent(events, hotel);
                            break;
                        case Locals.Market:
                            eventListTools.InsertAnEvent(events, market);
                            break;
                    }
                }

                foreach(TimeOfDay timeOfDay in events.eventBaseData.timeOfDay)
                {
                    switch(timeOfDay)
                    {
                        case TimeOfDay.Morning:
                            eventListTools.InsertAnEvent(events, morningDeck);
                            break;
                        case TimeOfDay.Afternoon:
                            eventListTools.InsertAnEvent(events, afternoonDeck);
                            break;
                        case TimeOfDay.Night:
                            eventListTools.InsertAnEvent(events, nightDeck);
                            break;
                    }

                }

                foreach (DayOfWeek timeOfDay in events.eventBaseData.dayOfWeek)
                {
                    switch (timeOfDay)
                    {
                        case DayOfWeek.Day1:
                            eventListTools.InsertAnEvent(events, morningDeck);
                            break;
                        case DayOfWeek.Day2:
                            eventListTools.InsertAnEvent(events, afternoonDeck);
                            break;
                        case DayOfWeek.Day3:
                            eventListTools.InsertAnEvent(events, nightDeck);
                            break;
                    }

                }

                foreach (Alcohol alcoholLvl in events.eventBaseData.alcohol)
                {
                    switch (alcoholLvl)
                    {
                        case Alcohol.Low30:
                            eventListTools.InsertAnEvent(events, lowAlcohol);
                            break;
                        case Alcohol.Normal:
                            break;
                        case Alcohol.High80:
                            eventListTools.InsertAnEvent(events, highAlcohol);
                            break;
                    }

                }
            }
        }
    }

}


