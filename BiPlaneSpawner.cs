using UnityEngine;
using System.Collections;

public class BiPlaneSpawner : MonoBehaviour {

    public enum Position { Left, Right }

    public Player owner;
    public Position Orientation;
    Transform _transform;
    Transform spawnedBiPlane;
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
        spawnedBiPlane = (Transform)Instantiate(_biplane, _transform.position, _transform.rotation);

        if (Orientation == Position.Left)
        {
            Vector3 scale = spawnedBiPlane.localScale;
            scale.x *= -1f;
            spawnedBiPlane.localScale = scale;
        }

        BiPlane biplane = spawnedBiPlane.GetComponent<BiPlane>();
        if (biplane != null) biplane.SetOwner(owner);
        spawn = false;
    }
}
