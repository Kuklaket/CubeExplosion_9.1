using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _force;
    [SerializeField] private SpawnerCube _spawnerCube;

    private void OnEnable()
    {
        _spawnerCube.SpawnCompleted += Explode;
    }

    private void OnDisable()
    {
        _spawnerCube.SpawnCompleted -= Explode;
    }

    public void Explode(Collider cubePosition, List<Rigidbody> cubesForExplosion)
    {
        Vector3 explodePosition = cubePosition.transform.position;

        foreach (Rigidbody explodableCube in cubesForExplosion)
            if (explodableCube != null)
                explodableCube.AddExplosionForce(_force, explodePosition, _radius);

        cubesForExplosion.Clear();
    }
}
