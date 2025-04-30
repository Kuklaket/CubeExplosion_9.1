using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private SpawnerCube _spawnerCube;

    private void OnEnable()
    {
        _spawnerCube.OnSpawned += Explode;
    }

    private void OnDisable()
    {
        _spawnerCube.OnSpawned -= Explode;
    }

    public void Explode(Collider cubePosition, List<Rigidbody> cubesForExplosion)
    {
        Vector3 explodePosition = cubePosition.transform.position;

        foreach (Rigidbody explodableCube in cubesForExplosion)
            if (explodableCube != null)
                explodableCube.AddExplosionForce(_explosionForce, explodePosition, _explosionRadius);

        cubesForExplosion.Clear();
    }
}
