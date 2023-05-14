using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Reward
{
    public int Num;
    public Sprite Sprite;

    public static bool operator ==(Reward r1, Reward r2)
    {
        return r1.Num == r2.Num && r1.Sprite == r2.Sprite;
    }
    public static bool operator !=(Reward r1, Reward r2)
    {
        return !(r1 == r2);
    }
}
