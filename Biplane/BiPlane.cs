using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Engine))]
public class BiPlane : MonoBehaviour
{
    public enum BiPlaneState { Pause, Work }
    public float rotationScale;

    Player _owner;
    BiPlaneState _state = BiPlaneState.Work;
    Transform _transform;
    BiPlaneController _controller;
    Engine _engine;
    Rigidbody2D _rigidbody2d;

    public void SetOwner(Player owner)
    {
        this._owner = owner;
        CheckParams();
    }

    public void SetController(BiPlaneController controller)
    {
        this._controller = controller;
        CheckParams();
    }

    void CheckParams()
    {
        if (_rigidbody2d != null || _engine != null || _controller != null || _transform != null) _state = BiPlaneState.Work;
    }

    void Start()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _engine = GetComponent<Engine>();
        _controller = GetComponent<BiPlaneController>();
        _transform = GetComponent<Transform>();
        if (_controller == null) _state = BiPlaneState.Pause;
    } //+

    void FixedUpdate()
    {
        if (_state == BiPlaneState.Work)
        {
            UpdateForce();
            UpdateRotation();
            Move();
        }
    } //+

    void UpdateForce()
    {
        if (_controller.AddForce) _engine.AddForce();
        if (_controller.RemoveForce) _engine.RemoveForce();
    } //+

    void UpdateRotation()
    {
        Vector3 rot = Vector3.zero;
        if (_controller.RotationUp) rot.z -= Time.deltaTime * rotationScale;
        if (_controller.RotationDown) rot.z += Time.deltaTime * rotationScale;
        _transform.localEulerAngles += rot;
    } //#

    void Move()
    {
        _rigidbody2d.velocity = _transform.right * _engine.Power;
    }

    float rotationAngle()
    {
        Vector2 direction = _transform.right.ConvertToVector2();
        float rotationLeft = Vector2.Angle(direction, -Vector2.right), rotationRight = Vector2.Angle(direction, Vector2.right);
        if (rotationLeft > rotationRight) return rotationRight;
        else return rotationLeft;
    } //+

    void Dead()
    {
        _owner.Kill();
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "BiPlane" || coll.gameObject.tag == "StaticObject") Dead();
    }
}