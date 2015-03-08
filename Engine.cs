using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Engine : MonoBehaviour
{
    Transform engine;

    public float power, maxPower, factor;

    void Start()
    {
        engine = transform;
    }

    void FixedUpdate()
    {
        factor = (maxPower - power) / maxPower;
        SetPosition();
        Gravity(factor);
    }

    void Gravity(float factor)
    {
        engine.rigidbody2D.gravityScale = factor;
    }

    void SetPosition()
    {
        engine.position += power * engine.right * Time.deltaTime;
    }

    public void AddForce()
    {
        power = Mathf.Clamp(power + maxPower * Time.deltaTime, 0, maxPower);
    }

    public void RemoveForce()
    {
        power = Mathf.Clamp(power - maxPower * Time.deltaTime, 0, maxPower);
    }

    public void RotationFactor()
    {
        power = power - Time.deltaTime;
    }
}