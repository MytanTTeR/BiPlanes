using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Engine : MonoBehaviour
{
    public float maxPower;

    Transform engineGO;

    Rigidbody2D engine;

    public float force;

    void Start()
    {
        engine = GetComponent<Rigidbody2D>();
        engineGO = transform;
    }

    void FixedUpdate()
    {
        engine.velocity = GetForce();
    }

    public void AddForce()
    {
        force = Mathf.Clamp(force + maxPower * Time.deltaTime, 0, maxPower);
    }

    public void RemoveForce()
    {
        force = Mathf.Clamp(force - maxPower * Time.deltaTime, 0, maxPower);
    }

    private Vector2 GetForce()
    {
        Vector2 velocity = GetEngineForce();
        return GetEngineForce() * Time.deltaTime;
    }

    private Vector2 GetEngineForce()
    {
        return force * engineGO.right;
    }

    private float GetRorationWind()
    {
        float angle1 = Vector2.Angle(engineGO.right, Vector2.up);
        float angle2 = Vector2.Angle(engineGO.right, -Vector2.up);
        return angle1 > angle2 ? angle2 : angle1;
    } //тож можно переделать

    private float GetEnginePower()
    {
        return force / engine.mass;
    } // переделать

    void OnGUI()
    {
        GUI.Box(new Rect(0, 0, 100, 20), engine.velocity.Length().ToString());
    }
}
