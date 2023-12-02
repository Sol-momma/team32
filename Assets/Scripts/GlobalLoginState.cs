using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalLoginState
{
    public static bool IsLoggedIn { get; private set; }
    public static string PlayerId { get; private set; }

    public static void SetLoginState(bool isLoggedIn, string playerId)
    {
        IsLoggedIn = isLoggedIn;
        PlayerId = playerId;
    }
}
