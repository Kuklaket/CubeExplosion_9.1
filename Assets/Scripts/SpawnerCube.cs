using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerCube : MonoBehaviour
{
    [SerializeField] private RayCollisionCheck _rayCollisionCheck;
    [SerializeField] private Cube _cube;
    [SerializeField] private BoxCollider _spawnZone;

    private List<Rigidbody> _spawnedCubes = new List<Rigidbody>();
    private Cube _newCube;

    public event Action<Collider,List<Rigidbody>> OnSpawned;

    private void Start()
    {
        if (_spawnZone == null)
            _spawnZone = GetComponent<BoxCollider>();
    }

    private void OnEnable()
    {
        _rayCollisionCheck.OnCorrectColliderHit += Spawner;
    }

    private void OnDisable()
    {
        _rayCollisionCheck.OnCorrectColliderHit -= Spawner;
    }

    private void Spawner(Collider collider)
    {
        int minCountCubes = 2;
        int maxCountCubes = 6;
        int minNumberForGeneration = 0;
        int maxNumberForGeneration = 100;
        int countNewCube = UnityEngine.Random.Range(minCountCubes, maxCountCubes);
        int generatedNumber = UnityEngine.Random.Range(minNumberForGeneration, maxNumberForGeneration);

        Rigidbody newCubeRigidbody; 
        Vector3 PositionForNewCude = GetRandomSpawnPoint();
        Cube parentCube = collider.GetComponent<Cube>();

        if (generatedNumber < parentCube.ChanceDuplication)
        {
            for (int i = 0; i < countNewCube; i++)
            {               
                _newCube = Instantiate(_cube, PositionForNewCude, Quaternion.identity);
                _newCube.RandomizeColor();
                _newCube.SetScale(collider.transform.localScale);
                _newCube.SetChanceDuplication(100);              
                _newCube.SetChanceDuplication(collider.gameObject.GetComponent<Cube>().ChanceDuplication);
                _newCube.ReduceChance();

                newCubeRigidbody = _newCube.GetComponent<Rigidbody>();
                _spawnedCubes.Add(newCubeRigidbody);
            }
        }

        OnSpawned?.Invoke(collider,_spawnedCubes);
        Cube.Destroy(collider.gameObject);
    }

    private Vector3 GetRandomSpawnPoint()
    {
        Bounds bounds = _spawnZone.bounds;

        return new Vector3(
            UnityEngine.Random.Range(bounds.min.x, bounds.max.x),
            UnityEngine.Random.Range(bounds.min.y, bounds.max.y),
            UnityEngine.Random.Range(bounds.min.z, bounds.max.z)
        );
    }
}
