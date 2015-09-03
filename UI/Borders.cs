using UnityEngine;
using System.Collections;

public class Borders : MonoBehaviour
{
    Camera _mainCamera;
    int _screenWidth, _screenHeight;
    float _scenePos, _objectWidth;
    Vector2 _objectPos;
    Transform _transform;
    Rect spriteRect;

    void Start()
    {
        _mainCamera = Camera.main;
        _transform = transform;
        spriteRect = _transform.GetComponent<SpriteRenderer>().sprite.textureRect;
    }

    void Update()
    {
        _screenWidth = Screen.width;
        _screenHeight = Screen.height;

        _objectPos = _mainCamera.WorldToScreenPoint(transform.position);
        _objectWidth = _transform.localScale.x * spriteRect.width;

        CriticalPosition();
    }

    void CriticalPosition()
    {
        float z = _transform.position.z;
        if (_objectPos.x - _objectWidth >= _screenWidth) _transform.position = _mainCamera.ScreenToWorldPoint(new Vector3(-_objectWidth, _objectPos.y, _transform.position.z));
        else if (_objectPos.x + _objectWidth <= 0) _transform.position = _mainCamera.ScreenToWorldPoint(new Vector3(_screenWidth + _objectWidth, _objectPos.y, _transform.position.z));
        _transform.position = new Vector3(_transform.position.x, _transform.position.y, z);
    }
}
