using UnityEngine;

public class ObjectMovement : MonoBehaviour {

    public float Speed;
    Transform _transform;

    void Start()
    {
        _transform = GetComponent<Transform>();
    }
	
	void FixedUpdate () 
    {
        _transform.Translate((transform.right * Speed).ConvertToVector2());
	}
}
