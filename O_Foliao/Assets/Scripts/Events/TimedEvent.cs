using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Timed Event", menuName = "Events/New Timed Event")]
public class TimedEvent : ScriptableObject
{
    [SerializeField] private Events _events;
    public Events events { get { return _events; } }

    [SerializeField] private int _day;
    public int day { get { return _day; } }

    [SerializeField] private int _hour;
    public int hour { get { return _hour; } }

    [SerializeField] private int _minutes;
    public int minutes { get { return _minutes; } }

    [SerializeField] private string _local;
    public string local { get { return _local; } }
}
