using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "SOStats", menuName = "Scriptable Objects/Stats", order = 1)]
public class SOStats : ScriptableObject
{
    public float MaxStatValue = 100;
    public UnityEvent happinessChanged = new UnityEvent();
    public UnityEvent SocialRatingChanged = new UnityEvent();
    public UnityEvent HungerChanged = new UnityEvent();
    public float Happiness { get; private set; }
    public float SocialRating { get; private set; }
    public float Hunger { get; private set; }

  
    public void addHappiness(int change)
    {
        if ((Happiness+ change <= MaxStatValue) && (Happiness + change >= 0))
        {
            Happiness += change;
            happinessChanged.Invoke();
        }
        else if (Happiness + change <= 0)
        {
            Happiness = 0;
            happinessChanged.Invoke();
        }
        else
        {
            Happiness = MaxStatValue;
            happinessChanged.Invoke();
        }
    }
    public void addSocialRatings(int change)
    {

        if ((SocialRating + change <= MaxStatValue) && (SocialRating + change >= 0))
        {
            SocialRating += change;
            SocialRatingChanged.Invoke();
        }
        else if (SocialRating + change <= 0)
        {
            SocialRating = 0;
            SocialRatingChanged.Invoke();
        }
        else
        {
            SocialRating = MaxStatValue;
            SocialRatingChanged.Invoke();
        }
    }
    public void addHunger(int change)
    {
      
        if ((Hunger + change <= MaxStatValue) && (Hunger + change >= 0))
        {
            Hunger += change;
            HungerChanged.Invoke();
        }
        else if (Hunger + change <= 0)
        {
            Hunger = 0;
            HungerChanged.Invoke();
        }
        else
        {
            Hunger = MaxStatValue;
            HungerChanged.Invoke();
        }
    }
    public void ClearValues()
    {
        Hunger = 0.5f*MaxStatValue;
        SocialRating = 0.5f * MaxStatValue;
        Happiness = 0.5f * MaxStatValue;
        happinessChanged = new UnityEvent();
        SocialRatingChanged = new UnityEvent();
        HungerChanged = new UnityEvent();
    }


}
