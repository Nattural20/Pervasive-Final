using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is for when the Companion is dead
/// </summary>
/// <returns>
/// </returns>
public class DeadEmotion : Emotion
{
    public DeadEmotion(AIController aiController) : base(aiController)
    {

    }

    public override Emotion RunCurrentEmotion()
    {
        throw new System.NotImplementedException();
    }
}
