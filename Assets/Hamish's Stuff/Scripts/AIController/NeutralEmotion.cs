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

    public MarvelEmotion marvelEmotion;
    public UncertainEmotion uncertainEmotion;

    public bool _isUncertain;
    public bool _isMarveling;

    public NeutralEmotion(AIController aicontroller): base(aicontroller)
    {

    }

    public override AIEmotions RunCurrentState()
    {
        if (_isUncertain)
        {
            return uncertainEmotion;
        }
        else if (_isMarveling)
        {
            return marvelEmotion;
        }
        else
        {
            Debug.Log(this);
            return this;
        }
    }

}
