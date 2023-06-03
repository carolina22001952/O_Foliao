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

    [SerializeField] private GameObject _location;
    public GameObject location { get { return _location; } }

    [SerializeField] private Events _events;
    public Events events { get { return _events; } }


    


}
