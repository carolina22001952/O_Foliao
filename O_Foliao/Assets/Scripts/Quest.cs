using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest")]
public class Quest : ScriptableObject
{
    [SerializeField] private string _questTitle;
    public string questTitle { get { return _questTitle; } }

    [SerializeField] private string _questDescription;
    public string questDescription { get { return _questDescription; } }

    [SerializeField] private string _location;
    public string location { get { return _location; } }

    [SerializeField] private Events _events;
    public Events events { get { return _events; } }

    [SerializeField] private int _startingDay;
    public int startingDay { get { return _startingDay; } }

    [SerializeField] private int _startingHours;
    public int startingHours { get { return _startingHours; } }

    [SerializeField] private int _startingMinutes;
    public int startingMinutes { get { return _startingMinutes; } }

    [SerializeField] private int _endDay;
    public int endDay { get { return _endDay; } }

    [SerializeField] private int _endHours;
    public int endHours { get { return _endHours; } }

    [SerializeField] private int _endMinutes;
    public int endMinutes { get { return _endMinutes; } }




}
