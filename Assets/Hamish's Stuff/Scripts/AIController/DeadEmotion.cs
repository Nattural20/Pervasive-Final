using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is for when the Companion is dead
/// </summary>
/// <returns>
/// </returns>
public class DeadEmotion : AIEmotions
{
    public DeadEmotion(AIController aicontroller) : base(aicontroller)
    {

    }

    public override AIEmotions RunCurrentState()
    {
        return this;
    }
}
