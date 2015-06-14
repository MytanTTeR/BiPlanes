using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    float screenWidth, screenHeight, backgroundWidth, backgroundHeight, realScreenWidth, realScreenHeight;
    Camera _mainCamera;
    Transform _transformMainCamera, _transform;
    float defalutHeight = 200f, defaultWidth;

    void Start()
    {
        _mainCamera = Camera.main;
        Texture2D backgroundTexture = GetComponent<SpriteRenderer>().sprite.texture;

        backgroundHeight = backgroundTexture.height;
        backgroundWidth = backgroundTexture.width;

        _transform = transform;
        _transformMainCamera = _mainCamera.transform;
    }

    void UpdateParams()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        realScreenHeight = defalutHeight * _mainCamera.orthographicSize;
        realScreenWidth = screenWidth * realScreenHeight / screenHeight;
        defaultWidth = screenWidth / screenHeight * defalutHeight;
    }

    void Update()
    {
        UpdateParams();
        ResizeCamera();
    }

    void ResizeCamera()
    {
        if (realScreenWidth / realScreenHeight < backgroundWidth / backgroundHeight) SetScreenWidth(backgroundWidth);
        else SetScreenHeight(backgroundHeight);
    }

    void SetScreenHeight(float height)
    {
        _mainCamera.orthographicSize = height / defalutHeight;
        _transformMainCamera.position = new Vector3(_transform.position.x, _transform.position.y, _transformMainCamera.position.z);
    }

    void SetScreenWidth(float width)
    {
        _mainCamera.orthographicSize = width / defaultWidth;
        _transformMainCamera.position = new Vector3(_transform.position.x, _transform.position.y + _mainCamera.orthographicSize - (backgroundHeight / realScreenHeight) * _mainCamera.orthographicSize, _transformMainCamera.position.z);
    }
}