using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BiPlaneController))]
[RequireComponent(typeof(BiPlaneRigidbody))]
[RequireComponent(typeof(Engine))]
public class BiPlane : MonoBehaviour
{
    public float wingWidth, rotationScale;
    Engine _engine;
    BiPlaneRigidbody _rigidbody;
    BiPlaneController _controller;
    Transform _transform;

    void Start()
    {
        _rigidbody = GetComponent<BiPlaneRigidbody>();
        _engine = GetComponent<Engine>();
        _controller = GetComponent<BiPlaneController>();
        _transform = GetComponent<Transform>();
    } //+

    void FixedUpdate()
    {
        UpdateForce();
        UpdateRotation();
        if (_engine.enabled)
        {
            _rigidbody.OtherForce = (_transform.right * _engine.Power).GetVector2();
            _rigidbody.gravityScale = _rigidbody.mass - Mathf.Clamp(GetWing() * _engine.Power / 10f, 0f, _rigidbody.mass);
        }
        else
        {
            _rigidbody.gravityScale = 1;
        }
    } //Debug!!!

    void UpdateForce()
    {
        if (_controller.AddForce) _engine.AddForce();
        if (_controller.RemoveForce) _engine.RemoveForce();
    } //+

    void UpdateRotation()
    {
        Vector3 rot = Vector3.zero;
        if (_controller.RotationUp) rot.z -= Time.deltaTime * rotationScale / wingWidth;
        if (_controller.RotationDown) rot.z += Time.deltaTime * rotationScale / wingWidth;
        _transform.localEulerAngles += rot;
    } //?

    public float GetWing()
    {
        return wingWidth - wingWidth * 90f / rotationAngle();
    } //+

    private float rotationAngle()
    {
        Vector2 direction = _transform.right.GetVector2();
        float rotationLeft = Vector2.Angle(direction, -Vector2.right), rotationRight = Vector2.Angle(direction, Vector2.right);
        if (rotationLeft > rotationRight) return rotationRight;
        else return rotationLeft;
    } //Test!!
}
