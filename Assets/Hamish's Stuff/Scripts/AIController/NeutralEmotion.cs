using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutralEmotion : AIEmotions
{
    /// <summary>
    /// This is for when the Companion is neutral
    /// </summary>
    /// <returns></returns>
    /// 
    MarvelEmotion MarvelEmotion;
    public override AIEmotions RunCurrentState()
    {
        return this;
    }

}
