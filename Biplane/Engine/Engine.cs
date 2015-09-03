using UnityEngine;
using System.Collections;

public class Engine : MonoBehaviour
{
    public float maxPowerEngine;

    float _powerEngine = 0f;

    public float Power
    {
        get { return _powerEngine; }
    }

    public void AddForce()
    {
        _powerEngine = Mathf.Clamp(_powerEngine + maxPowerEngine * Time.deltaTime, 0f, maxPowerEngine);
    }

    public void RemoveForce()
    {
        _powerEngine = Mathf.Clamp(_powerEngine - maxPowerEngine * Time.deltaTime, 0f, maxPowerEngine);
    }
}