using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;


public class Challenge : MonoBehaviour
{
    [SerializeField] SOStats stats;
    public enum QRstringOrder { Type=0, Happiness, Hunger, SocialRating, XP}
    public bool completed = false;
    public UnityEvent OnCompletion = new UnityEvent();
    public const int XPReward = 50;
    string ToStringString = "Base challenge, connect with someone who has a hapiness level of above 10 to get 50XP.";
    public virtual void CheckForCompletion(string comp)
    {
        string[] result = comp.Split(',');
        if (Convert.ToInt32( result[(int)QRstringOrder.Happiness]) > 10 )
        {
            CompleteChallenge();
        }
    }
    private void CompleteChallenge()
    {
        stats.AddXP(XPReward);
        completed = true;
        ToStringString = "COMPLETED!!! YAY";
        OnCompletion.Invoke();

    }
    public override string ToString()
    {
        return ToStringString;
    }
}

