using UnityEngine;
using System.Collections.Generic;

class DebugGUI : MonoBehaviour
{
    public static List<string> list = new List<string>();

    public static void AddText(string text)
    {
        if (!list.Contains(text))list.Add(text);
    }

    void FixedUpdate()
    {
        list.Clear();
    }

    void OnGUI()
    {
        for (int i = 0; i < list.Count; i++)
            GUI.Box(new Rect(0f, 25f*i, 200f, 25f), list[i]);
    }

}
