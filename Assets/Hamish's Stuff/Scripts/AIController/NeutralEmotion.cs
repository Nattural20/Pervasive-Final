using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

/// <summary>
/// This is for when the Companion is neutral
/// </summary>
/// <returns></returns>
/// 
public class NeutralEmotion : Emotion
{
    public NeutralEmotion(AIController aiController) : base(aiController)
    {

    }

    public override Emotion RunCurrentEmotion()
    {
        aiController.FollowPlayer(5.0f, 0.5f);
        return this;
    }
}
