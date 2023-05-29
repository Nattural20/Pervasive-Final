using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static event Action enteredCorruption;
    public static event Action leftCorruption;

    public static event Action enteredScenic;
    public static event Action leftScenic;

    public static event Action dislikePlayer;
    public static event Action likePlayer;

    public static event Action momentHasEnded;

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

    public static void ExitArea(string tag)
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

    public static void MomentHasEnded()
    {
        momentHasEnded?.Invoke();
    }

}
