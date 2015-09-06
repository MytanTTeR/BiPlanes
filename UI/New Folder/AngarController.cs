using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AngarController : MonoBehaviour
{
    public Image[] Images;

    public int currentBiPlane;

    void Start()
    {
        int index = DataBase.GetInt("PlayerBiPlane");
        currentBiPlane = index != null ? index : 0;
        UpdateImages();
    }

    void UpdateImages()
    {
        Color color;
        for (int i = 0; i < Images.Length; i++)
        {
            color = Images[i].color;
            color.a = (i == currentBiPlane ? 1f : 0.5f);
            Images[i].color = color;
        }
    }

    public void ChangeCurrentBiPlane(int index)
    {
        currentBiPlane = index;
        DataBase.SetInt("PlayerBiPlane", index);
        UpdateImages();
    }
}
