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

    // Start is called before the first frame update
    void Start()
    {
        Stats.happinessChanged.AddListener(UpdateBars);
        Stats.HungerChanged.AddListener(UpdateBars);
        Stats.SocialRatingChanged.AddListener(UpdateBars);

    }
    void UpdateBars()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
