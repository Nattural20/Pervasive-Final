using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is for when the Companion sees the sprawling landscape and stops to look at it
/// </summary>
/// <returns>
/// </returns>
public class MarvelEmotion : AIEmotions
{
    public MarvelEmotion(AIController aicontroller) : base(aicontroller)
    {

    }

    public override AIEmotions RunCurrentState()
    {
        return this;
    }
}
