using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "SOStats", menuName = "Scriptable Objects/Stats", order = 1)]
public class SOStats : ScriptableObject
{
    public float SliderMaxVal = 100;
    public UnityEvent happinessChanged = new UnityEvent();
    public UnityEvent SocialRatingChanged = new UnityEvent();
    public UnityEvent HungerChanged = new UnityEvent();
    public float Happines { get; private set; }
    public float SocialRating { get; private set; }
    public float Hunger { get; private set; }

    public void addHappiness(int change)
    {
        Happines += change;
        happinessChanged.Invoke();
    }
    public void addSocialRatings(int change)
    {
        SocialRating += change;
        SocialRatingChanged.Invoke();
    }
    public void addHunger(int change)
    {
        Hunger += change;
        HungerChanged.Invoke();
    }
    public void ClearValues()
    {
        Hunger = 0.5f*SliderMaxVal;
        SocialRating = 0.5f * SliderMaxVal;
        Happines = 0.5f * SliderMaxVal;
        happinessChanged = new UnityEvent();
        SocialRatingChanged = new UnityEvent();
        HungerChanged = new UnityEvent();
    }


}
