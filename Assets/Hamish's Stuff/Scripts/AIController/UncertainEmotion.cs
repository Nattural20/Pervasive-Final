using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is for when the Companion doesn't want to go a certain path
/// </summary>
/// <returns></returns>
public class UncertainEmotion : Emotion
{
    private bool _tooFar;
    private bool _playerHasLeft;

    private Emotion _neutralEmotion;

    public UncertainEmotion(AIController aiController) : base(aiController)
    {
        _tooFar = false;
        _playerHasLeft = false;
        _neutralEmotion = new NeutralEmotion(aiController);
        EventManager.leftCorruption += PlayerHasLeft;
    }

    public override Emotion RunCurrentEmotion()
    {
        if (_playerHasLeft)
        {
            return _neutralEmotion;
        }

        if(aiController.dist >= 25 && !_tooFar)
        {
            _tooFar = true;
            EventManager.CompanionFriendship(false);
            Debug.Log("I HATE YOU");
        }
        else if(_tooFar)
        {
            aiController.FollowPlayer(2.5f, 0.1f);
        }

        return this;
    }

    private void PlayerHasLeft()
    {
        _playerHasLeft = true;
    }

    private void OnDisable()
    {
        EventManager.leftCorruption -= PlayerHasLeft;
    }
}
