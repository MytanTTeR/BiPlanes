using UnityEngine;
using System.Collections;


public delegate void Empty();

public class Player : MonoBehaviour
{
    public GameObject BiPlanePrefab;

    public event Empty Dead;

    public void Kill()
    {
        Dead.Invoke();
    }
}
