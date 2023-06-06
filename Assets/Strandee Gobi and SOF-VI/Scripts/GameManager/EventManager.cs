using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static event Action togglePlayer;

    public static event Action enteredCorruption;
    public static event Action leftCorruption;

    public static event Action enteredScenic;
    public static event Action leftScenic;

    public static event Action dislikePlayer;
    public static event Action likePlayer;

    public static event Action momentHasEnded;

    public static event Action sofviHasDied;

    public static void EnteredArea(string tag)
    {
        switch (tag)
        {
            case "Aversion":
                enteredCorruption?.Invoke();
                break;
            case "Marvel":
                enteredScenic?.Invoke();
                break;
        }
    }

    public static void ExitArea(string tag) //TODO: Does listening for when the player leaves save memory? Is it worth to just keep triggering the event while the player is in the collision zone
    {
        switch (tag)
        {
            case "Aversion":
                leftCorruption?.Invoke();
                break;
            case "Marvel":
                leftScenic?.Invoke();
                break;
        }
    }

    public static void CompanionFriendship(bool action)
    {
        if (action)
        {
            likePlayer?.Invoke();
        }
        else
        {
            dislikePlayer?.Invoke();
        }
    }

    public static void TogglePlayer()
    {
        togglePlayer?.Invoke();
    }

    public static void MomentHasEnded()
    {
        momentHasEnded?.Invoke();
    }

    public static void SofviHasDied(){
        sofviHasDied?.Invoke();
    }

}
