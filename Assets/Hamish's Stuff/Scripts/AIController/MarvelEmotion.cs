using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarvelEmotion : AIEmotions
{
    /// <summary>
    /// This is for when the Companion sees the sprawling landscape and stops to look at it
    /// </summary>
    /// <returns>
    /// </returns>
    public override AIEmotions RunCurrentState()
    {
        return this;
    }
}
