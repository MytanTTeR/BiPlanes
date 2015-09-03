using UnityEngine;
using System.Collections;

public class BiPlaneSpawner : MonoBehaviour {

    public Player owner;
    Transform _transform;
    Transform BiPlane;
    bool spawn = true;

    void Start()
    {
        _transform = GetComponent<Transform>();
        owner.Dead += ReadyForSpawn;
    } //+

    void Update()
    {
        if (spawn) Spawn();
    } //+

    void ReadyForSpawn()
    {
        spawn = true;
    }

    void Spawn()
    {
        Transform _biplane = owner.BiPlanePrefab.GetComponent<Transform>();
        Vector3 pos = new Vector3(_transform.position.x, _transform.position.y, _biplane.position.z);
        BiPlane = (Transform)Instantiate(_biplane, _transform.position, _transform.rotation);
        BiPlane biplane = BiPlane.GetComponent<BiPlane>();
        if (biplane != null) biplane.SetOwner(owner);
        spawn = false;
    }
}
