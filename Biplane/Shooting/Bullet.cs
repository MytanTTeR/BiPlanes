using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{
    void Kill()
    {
        Destroy(gameObject);
    }

    void OnBecameInvisible()
    {
        Kill();
    }
}
