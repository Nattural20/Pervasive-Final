using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is for when the Companion doesn't want to go a certain path
/// </summary>
/// <returns></returns>
public class UncertainEmotion : AIEmotions
{
    public UncertainEmotion(AIController aicontroller) : base(aicontroller)
    {

    }
    public override AIEmotions RunCurrentState()
    {
        return this;
    }
}
