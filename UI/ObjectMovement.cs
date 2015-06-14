using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class ObjectMovement : MonoBehaviour {

    public float Speed;
    Rigidbody2D _rigidbody;

	void Start () 
    {
        _rigidbody = GetComponent<Rigidbody2D>();
	}
	
	void Update () 
    {
        _rigidbody.velocity = (transform.right * Speed).GetVector2();
	}
}
