using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public GameObject supportingWidthSprite, supportingHeightSprite;

    List<GameObject> supportingsBackground;
    float screenWidth, screenHeight, screenWidthLate, screenHeightLate, backgroundWidht, backgroundHeight, realScreenWidht, realScreenHeight, supportingWidth, supportingHeight;
    Camera _mainCamera;
    Transform _transformMainCamera, _transform;
    float defalutHeight = 200f, defaultWidth;

    void Start()
    {
        _mainCamera = Camera.main;
        _transform = transform;
        _transformMainCamera = _mainCamera.transform;

        Texture2D backgroundTexture = GetComponent<SpriteRenderer>().sprite.texture;

        backgroundHeight = backgroundTexture.height * _transform.localScale.y;
        backgroundWidht = backgroundTexture.width * _transform.localScale.x;

        supportingWidth = supportingWidthSprite.GetComponent<SpriteRenderer>().sprite.texture.width;
        supportingHeight = supportingHeightSprite.GetComponent<SpriteRenderer>().sprite.texture.height;

        supportingsBackground = new List<GameObject>();
        
        UpdateParams();
        ResizeCamera();
        UpdateParams();
        ResizeCamera();

        screenWidthLate = screenWidth;
        screenHeightLate = screenHeight;
    } //+

    void Update()
    {
        UpdateParams();
        if (screenWidthLate != screenWidth && screenHeightLate != screenHeight)
        {
            ResizeCamera();
            UpdateParams();
            ResizeCamera();
        }
        screenWidthLate = screenWidth;
        screenHeightLate = screenHeight;
    } //+

    void UpdateParams()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        realScreenHeight = defalutHeight * _mainCamera.orthographicSize;
        realScreenWidht = screenWidth * realScreenHeight / screenHeight;
        defaultWidth = screenWidth / screenHeight * defalutHeight;
    } //+

    void ResizeCamera()
    {
        if (realScreenWidht / realScreenHeight < backgroundWidht / backgroundHeight) SetAsWidth();
        else SetAsHeight();
    } //+

    void SetAsHeight()
    {
        SetScreenHeight(backgroundHeight);

        UpdateParams();

        float widthOffset = (realScreenWidht - backgroundWidht) / 2f;
        float spawnCount = widthOffset / supportingWidth;
        if ((spawnCount - (int)spawnCount) != 0) spawnCount = (int)spawnCount + 1;

        SetSupportingWidth((int)spawnCount);
    }

    void SetAsWidth()
    {
        SetScreenWidth(backgroundWidht);

        UpdateParams();

        float heightOffset = realScreenHeight - backgroundHeight;
        float spawnCount = heightOffset / supportingHeight;
        if ((spawnCount - (int)spawnCount) != 0) spawnCount = (int)spawnCount + 1;

        SetSupportingHeight((int)spawnCount);
    }

    void SetSupportingHeight(int count)
    {
        ClearSupportingBackground();
        for (int i = 0; i < count; i++)
        {
            Vector3 pos = _transform.position;
            Vector3 offset = new Vector3(0, (backgroundHeight / 2f + supportingHeight / 2f + i * supportingHeight) / 100f, 0);
            supportingsBackground.Add((GameObject)Instantiate(supportingHeightSprite, pos + offset, Quaternion.identity));
        }
    }

    void SetSupportingWidth(int count)
    {
        ClearSupportingBackground();
        for (int i = 0; i < count; i++)
        {
            Vector3 pos = _transform.position;
            Vector3 offset = new Vector3((backgroundWidht / 2f + supportingWidth / 2f + i * supportingWidth) / 100f, 0, 0);
            supportingsBackground.Add((GameObject)Instantiate(supportingWidthSprite, pos + offset, Quaternion.identity));
            supportingsBackground.Add((GameObject)Instantiate(supportingWidthSprite, pos - offset, Quaternion.identity));
        }
    }

    void ClearSupportingBackground()
    {
        foreach (GameObject bg in supportingsBackground)
            Destroy(bg);
        supportingsBackground.Clear();
    } //+

    void SetScreenHeight(float height)
    {
        _mainCamera.orthographicSize = height / defalutHeight;
        _transformMainCamera.position = new Vector3(_transform.position.x, _transform.position.y, _transformMainCamera.position.z);
    } //+

    void SetScreenWidth(float width)
    {
        float size = width / defaultWidth;
        _mainCamera.orthographicSize = size;
        _transformMainCamera.position = new Vector3(_transform.position.x, _transform.position.y + size - (backgroundHeight / realScreenHeight) * size, _transformMainCamera.position.z);
    } //+
}