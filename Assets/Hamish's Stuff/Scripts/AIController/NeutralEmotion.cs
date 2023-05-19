using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is for when the Companion is neutral
/// </summary>
/// <returns></returns>
/// 
public class NeutralEmotion : AIEmotions
{

    MarvelEmotion MarvelEmotion;
    UncertainEmotion UncertainEmotion;

    public bool _isUncertain;
    public bool _isMarveling;

    public NeutralEmotion(AIController aicontroller): base(aicontroller)
    {

    }

    public override AIEmotions RunCurrentState()
    {
        if (_isUncertain)
        {
            return UncertainEmotion;
        }
        else if (_isMarveling)
        {
            return MarvelEmotion;
        }
        else
        {
            return this;
        }
    }

}
