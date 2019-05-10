using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class UIStatHandler : MonoBehaviour
{
    public SOStats Stats;
    [SerializeField] private Slider HappinessMeter;
    [SerializeField] private Slider HungerMeter;
    [SerializeField] private Slider SocializationMeter;
    [SerializeField] private Text XPAmount;

    // Start is called before the first frame update
    void Start()
    {
        Stats.ClearValues();
        Stats.happinessChanged.AddListener(UpdateBars);
        Stats.HungerChanged.AddListener(UpdateBars);
        Stats.SocialRatingChanged.AddListener(UpdateBars);
        Stats.XPChanged.AddListener(UpdateBars);
       
        UpdateBars();
        

    }
    void UpdateBars()
    {
        //this will map the value between 0 and 1.
        HappinessMeter.value = Stats.Happiness/Stats.MaxStatValue;
        HungerMeter.value = Stats.Hunger / Stats.MaxStatValue;
        SocializationMeter.value = Stats.SocialRating / Stats.MaxStatValue;
        XPAmount.text = Stats.XP.ToString();
    }

}
