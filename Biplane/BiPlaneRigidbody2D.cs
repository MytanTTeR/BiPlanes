using UnityEngine;
using System.Collections;

public class BiPlaneRigidbody2D : MonoBehaviour
{

    public float mass = 1f, gravityScale = 1f;
    public Vector2 curVelocity = Vector2.zero, controlVelocity = Vector2.zero;
    Transform _transform;
    Rigidbody2D _rigidbody2d;
    Vector3 curPos, lastPos;

    void Start()
    {
        _transform = transform;
        _rigidbody2d = GetComponent<Rigidbody2D>();
        curPos = _transform.position;
    }

    public void AddForce(Vector2 force)
    {
        controlVelocity += force;
    }

    void FixedUpdate()
    {
        _rigidbody2d.velocity = curVelocity; //+
    }
}