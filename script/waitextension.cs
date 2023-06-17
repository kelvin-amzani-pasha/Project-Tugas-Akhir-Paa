using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class wairextension
{
    public static void wait (this MonoBehaviour mono, float delay, UnityAction action)
    {
        mono.StartCoroutine(ExecutedAction(delay, action));
    }

    private static IEnumerator ExecutedAction (float delay, UnityAction action)
    {
        yield return new WaitForSecondsRealtime(delay);
        action.Invoke();
        yield break;
    }
}
