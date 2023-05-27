using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is for when the Companion doesn't want to go a certain path
/// </summary>
/// <returns></returns>
public class UncertainEmotion : AIEmotions
{
<<<<<<< Updated upstream
    public bool tooFar;
=======
    public UncertainEmotion(AIController aiController) : base(aiController)
    {

    }
>>>>>>> Stashed changes

    public UncertainEmotion(AIController aicontroller) : base(aicontroller)
    {
        tooFar = false;
    }
    public override AIEmotions RunCurrentState()
    {

        return this;
    }
}
