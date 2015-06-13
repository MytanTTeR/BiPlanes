using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    float screenWidth, screenHeight, backgroundWidth, backgroundHeight, realScreenWidth, realScreenHeight;
    Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        Texture2D backgroundTexture = GetComponent<SpriteRenderer>().sprite.texture;

        backgroundHeight = backgroundTexture.height;
        backgroundWidth = backgroundTexture.width;
    }

    void UpdateParams()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        realScreenHeight = 200f * mainCamera.orthographicSize;
        realScreenWidth = screenWidth * realScreenHeight / screenHeight;
    }

    void Update()
    {
        UpdateParams();
    }
}
