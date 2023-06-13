using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedEventsSystem : MonoBehaviour
{
    [SerializeField]
    private TimedEvents[] eventsList;
    [SerializeField]
    private Clock clock;

    public void CheckForTimedEvents()
    {
        if(eventsList != null)
        {
             foreach(TimedEvents t in eventsList)
            {
                if(clock.GetDay() == t.day)
                {
                    if(clock.GetHours() <= t.hour )
                    {
                        if(t.local == null)
                        {
                            GameObject location = GameObject.Find(t.local);

                            if (location.GetComponent<ILocal>() is ILocal)
                            {
                                location.SetActive(true);
                               // location.GetComponent<ILocal>().LocalAddQuest(t.events);

                            }
                            Debug.Log("Null local");
                        }else if (t.local != null)
                        {

                            Debug.Log("Not null local");
                        }

                    }
                }

            }
        }
    }
}
