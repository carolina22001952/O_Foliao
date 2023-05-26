using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : ScriptableObject
{
    [SerializeField] private string _questTitle;
    public string questTitle { get { return _questTitle; } }

    [SerializeField] private string _questDescription;
    public string questDescription { get { return _questDescription; } }

    [SerializeField] private Node _location;
    public Node location { get { return _location; } }

    [SerializeField] private Events _events;
    public Events events { get { return _events; } }

    [SerializeField] private bool _completed;

    public bool completed { get { return _completed; } }

    


}
