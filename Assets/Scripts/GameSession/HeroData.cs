using System;
using UnityEngine;

[Serializable]
public class HeroData 
{
    public int Health;
    public int Coins;
    public bool IsArmed;

    public HeroData Clone()
    {
        var json = JsonUtility.ToJson(this);
        return JsonUtility.FromJson<HeroData>(json);
    }
}
