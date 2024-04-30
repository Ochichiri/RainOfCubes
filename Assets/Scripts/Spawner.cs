using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _prefab;

    private float _spawnRadius = 4f;
    private float _spawnRate = 1f;
    private WaitForSeconds _waitDelay;

    private int _minCubeLifeTime = 2;
    private int _maxCubeLifeTime = 5;

    private void Start()
    {
        _waitDelay = new WaitForSeconds(_spawnRate);

        StartCoroutine(SpawnCubes());
    }

    private IEnumerator SpawnCubes()
    {
        while (true)
        {
            Vector3 position = GetRandomPosition();
            int lifeTime = Random.Range(_minCubeLifeTime, _maxCubeLifeTime);

            Cube cube = Instantiate(_prefab, position, Quaternion.identity);
            cube.Init(lifeTime);

            yield return _waitDelay;
        }
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 position = new Vector3(
            Random.Range(-_spawnRadius, _spawnRadius), 
            transform.position.y,
            Random.Range(-_spawnRadius, _spawnRadius)
            );

        return position;
    }
}