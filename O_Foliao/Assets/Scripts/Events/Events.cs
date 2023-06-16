using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public enum EventType { Primary, Secondary, Random }

[Serializable()]
public struct Decisions
{
    [SerializeField] private string _choiceDialogue;
    public string choiceDialogue { get { return _choiceDialogue; } }

    [SerializeField] private int _minAlcool;
    public int minAlcool { get { return _minAlcool; } }

    [SerializeField] private int _minFun;
    public int minFun { get { return _minFun; } }

    [SerializeField] private int _minEnergy;
    public int minEnergy { get { return _minEnergy; } }

    [SerializeField] private int _minMoney;
    public int minMoney { get { return _minMoney; } }

    [SerializeField] EventOutcome _sucessEvent;
    public EventOutcome sucessEvent { get { return _sucessEvent; } }

    [SerializeField] EventOutcome _failedEvent;
    public EventOutcome failedEvent { get { return _failedEvent; } }

}

[CreateAssetMenu(fileName = "New Event", menuName = "Events/new Event")]
public class Events : ScriptableObject
{
    [SerializeField] private EventType _eventType;
    public EventType eventType { get { return _eventType; } }

    [SerializeField] private Dialogue[] _dialogue;
    public Dialogue[] dialogue { get { return _dialogue; } }

    [SerializeField] Decisions[] _decisions = null;
    public Decisions[] decisions { get { return _decisions; } }

    [SerializeField] EventBaseData _eventBaseData;
    public EventBaseData eventBaseData { get { return _eventBaseData; } }


}
[Serializable()]
public struct Dialogue
{
    [SerializeField] private string _text;
    public string text { get { return _text; } }

    [SerializeField] private NPCData _npc;
    public NPCData npc { get { return _npc; } }

    [SerializeField] private Sprite _background;
    public Sprite background { get { return _background; } }


}
[Serializable()]
public struct EventOutcome
{
    [SerializeField] private int _timePassed;
    public int timePassed { get { return _timePassed; } }

    [SerializeField] private int _alcoolPlus;
    public int alcoolPlus { get { return _alcoolPlus; } }

    [SerializeField] private int _funPlus;
    public int funPlus { get { return _funPlus; } }

    [SerializeField] private int _moneyPlus;
    public int moneyPlus { get { return _moneyPlus; } }

    [SerializeField] private int _energyPlus;
    public int energyPlus { get { return _energyPlus; } }

    [SerializeField] Quest _questToInsert;
    public Quest questToInsert { get { return _questToInsert; } }

    [SerializeField] Events _nextEvent;
    public Events nextEvent { get { return _nextEvent; } }

    [SerializeField] Events[] _eventsToInsert;
    public Events[] eventsToInsert { get { return _eventsToInsert; } }

    [SerializeField] string _achievementName;
    public string achievementName { get { return _achievementName; } }


}
[Serializable]
public struct NPCChanges
{
    [SerializeField] private NPCData[] _npc;
    public NPCData[] npc { get { return _npc; } }

    [SerializeField] private int _friendshipPointsPlus;
    public int friendshipPointsPlus { get { return _friendshipPointsPlus; } }


}
[Serializable]
public struct EventBaseData
{
    public enum TimeOfDay { Morning, Afternoon, Night };

    [SerializeField] private TimeOfDay[] _timeOfDay;
    public TimeOfDay[] timeOfDay { get { return _timeOfDay; } }


    public enum DayOfWeek { Day1, Day2, Day3, Day4, Day5 };

    [SerializeField] private DayOfWeek[] _dayOfWeek;
    public DayOfWeek[] dayOfWeek { get { return _dayOfWeek; } }

    public enum Locals { Cebola, Batata, Bars, Celeiro, Vinil, Skadi, Tunel, Bench, Barmen, Hotel, Market };

    [SerializeField] private Locals[] _locals;
    public Locals[] locals { get { return _locals; } }

    public enum Alcohol { Low30, Normal, High80 };

    [SerializeField] private Alcohol[] _alcohol;
    public Alcohol[] alcohol { get { return _alcohol; } }


}