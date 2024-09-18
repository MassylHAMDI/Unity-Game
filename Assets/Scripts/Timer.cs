using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;
    public bool countdown;
    public GameObject KeypadOBj;
    private Keypad KeypadScript;
    [Header("Limit Settings")]
    public bool hasLimit;
    public float timerLimit;
    public bool hasFormat;
    public TimerFormats format;
    private Dictionary<TimerFormats,string> timeFormats = new Dictionary<TimerFormats,string>();



    // Start is called before the first frame update
    void Start()
    {
        timeFormats.Add(TimerFormats.Whole,"0");
        timeFormats.Add(TimerFormats.TenthDecimal,"0.0");
        timeFormats.Add(TimerFormats.HundrethDecimal,"0.00");
        KeypadScript = KeypadOBj.GetComponent<Keypad> ();
    }



    // Update is called once per frame
    void Update()
    {
        currentTime = countdown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;

        if(hasLimit && ((countdown && currentTime <= timerLimit) || (!countdown && currentTime >=timerLimit)))
        {
            currentTime = timerLimit;
            SetTimerText();
            timerText.color = Color.red;
            enabled = false;
            KeypadScript.TriggerAlarm();
        }
        SetTimerText();
    }

    private void SetTimerText()
    {
        timerText.text = hasFormat ? currentTime.ToString(timeFormats[format]) : currentTime.ToString();
    }

    public bool IsTimeUp()
    {
        return hasLimit && ((countdown && currentTime <= timerLimit) || (!countdown && currentTime >= timerLimit));
    }
}

public enum TimerFormats
{
    Whole,
    TenthDecimal,
    HundrethDecimal
}