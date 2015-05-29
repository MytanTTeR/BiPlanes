using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BiPlaneRigidbody : MonoBehaviour
{
    public float gravityScale = 1f, mass = 1f;
    public Vector2 otherForce = Vector2.zero;
    Rigidbody2D _rigidbody;

    public Vector2 OtherForce
    {
        set { otherForce = value; }
    }

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float gravity = 9.8f * Time.deltaTime * Time.deltaTime * gravityScale / 2f - (_rigidbody.velocity.y < 0f ? _rigidbody.velocity.y : 0f);
        _rigidbody.velocity = otherForce - gravity * Vector2.up;
    }
}
