using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UncertainEmotion : AIEmotions
{
    /// <summary>
    /// This is for when the Companion doesn't want to go a certain path
    /// </summary>
    /// <returns></returns>
    public override AIEmotions RunCurrentState()
    {
        return this;
    }
}
