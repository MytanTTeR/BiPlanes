using UnityEngine;
using System.Collections;

public class Borders : MonoBehaviour
{
    public Camera MainCamera;
    int _screenWidth, _screenHeight;
    float _scenePos, _objectWidth;
    Vector2 _objectPos;
    Transform _transform;

    void Start()
    {
        _transform = transform;
        Debug.Log(_transform.GetComponent<SpriteRenderer>().sprite.textureRect.width);
    }

    void Update()
    {
        _screenWidth = Screen.width;
        _screenHeight = Screen.height;

        _objectPos = MainCamera.WorldToScreenPoint(transform.position);
        _objectWidth = _transform.localScale.x * 200f;

        CriticalPosition();
    }

    void CriticalPosition()
    {
        if (_objectPos.x - _objectWidth >= _screenWidth)
        {
            _transform.position = MainCamera.ScreenToWorldPoint(new Vector3(-_objectWidth, _objectPos.y, _transform.position.z));
        }
        else if (_objectPos.x + _objectWidth <= 0)
        {
            _transform.position = MainCamera.ScreenToWorldPoint(new Vector3(_screenWidth + _objectWidth, _objectPos.y, _transform.position.z));
        }
    } 
}
