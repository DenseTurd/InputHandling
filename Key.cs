using System;
using System.Collections.Generic;
using UnityEngine;

public enum When
{
    Pressed,
    Held,
    Released
}

public static class Key // these make things look super sexy but they are probably slow
{
    static Dictionary<When, Func<KeyCode, bool>> checkDict = new Dictionary<When, Func<KeyCode, bool>>
    {
        { When.Pressed, Input.GetKeyDown },
        { When.Held, Input.GetKey },
        { When.Released, Input.GetKeyUp }
    };

    public static bool DoesWhen(KeyCode key, When when)
    {
        return checkDict[when](key);
    }

    public static void DoesWhen(KeyCode key, Action method, When when)
    {
        if (checkDict[when](key)) method();
    }

    public static void DoesWhen(KeyCode key, Action<string> method, string str, When when)
    {
        if (checkDict[when](key)) method(str);
    }

    public static void DoesWhen(KeyCode key, Action<Transform> method, Transform trans, When when)
    {
        if (checkDict[when](key)) method(trans);
    }

    public static void DoesWhen(KeyCode key, Action<float, float> method, float f1, float f2, When when)
    {
        if (checkDict[when](key)) method(f1, f2);
    }


    public static KeyCode StringToKeycode(string key)
    {
        return (KeyCode)Enum.Parse(typeof(KeyCode), key);
    }
}
