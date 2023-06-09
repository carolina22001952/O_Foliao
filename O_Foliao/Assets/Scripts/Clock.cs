using TMPro;
using UnityEngine;

using UnityEngine.UI;

public class Clock : MonoBehaviour
{

    [SerializeField] private int hours = 18;
    [SerializeField] private int minutes = 0;
    [SerializeField] private int day = 1;
    [SerializeField] private int minTimeBetweenEvents = 1;
    [SerializeField] private int minutesPerHour = 60;
    [SerializeField] private Image iconMorning;
    [SerializeField] private Image iconAfternoon;
    [SerializeField] private Image iconNight;
    [SerializeField] private TextMeshProUGUI time;
    [SerializeField] private TextMeshProUGUI dayText;

    public enum TimesOfDay
    {
        Night,
        Afternoon,
        Morning
    }

    public TimesOfDay currentTimeOfDay { get; private set; }
    private TimesOfDay[] timesOfDay;
    private bool daychange = false;
    private int extraHours;
    private int extraMin;

    public int GetHours()
    {
        return this.hours;
    }

    public int GetMinutes()
    {
        return this.minutes; 
    }

    public int GetDay()
    {
        return this.day;
    }

    public TimesOfDay GetCurrentTimeOfDay()
    {
        return this.currentTimeOfDay;
    }

    public string UpdateTime(int timepassed)
    {


        this.minutes += (minTimeBetweenEvents + timepassed);

        extraHours = this.minutes / minutesPerHour;

        this.hours += extraHours;


        extraMin = this.minutes % minutesPerHour;


        if (this.minutes >= minutesPerHour)
        {

            this.minutes = 0 + extraMin;

        }

        if (this.hours >= 24)
        {
            Debug.Log(this.hours + "Bruv");
            this.hours = 0 + extraHours-1;
            daychange = true;

        }

        if(daychange == true)
        {
            this.day += 1;
            Debug.Log(this.day + "LPOL");
            daychange = false;

        }

        TimeOfDay();
        UpdateClockUI();
        return (hours.ToString().PadLeft(2,'0') + ":" + minutes.ToString().PadLeft(2, '0'));
        
    }

    private void TimeOfDay()
    { 
        int hours = GetHours();
        GetCurrentTimeOfDay();
        if (hours >= 6 && hours < 12)
        {
            currentTimeOfDay = TimesOfDay.Morning;

            iconMorning.enabled = true;
            iconAfternoon.enabled = false;
            iconNight.enabled = false;

        }
        else if (hours >= 12 && hours < 20)
        {
            currentTimeOfDay = TimesOfDay.Afternoon;

            iconMorning.enabled = false;
            iconAfternoon.enabled = true;
            iconNight.enabled = false;
        }
        else if (hours >= 20 || hours < 6)
        {
            currentTimeOfDay = TimesOfDay.Night;

            iconMorning.enabled = false;
            iconAfternoon.enabled = false;
            iconNight.enabled = true;
        }

    }

    public void UpdateClockUI()
    {
        time.text = hours.ToString().PadLeft(2,'0') + ":" + minutes.ToString().PadLeft(2, '0');
        dayText.text ="Dia " + this.day.ToString();
    }
}
