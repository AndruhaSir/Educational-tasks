using System.Collections.Generic;
using UnityEngine;

public class Handler : MonoBehaviour
{
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;

    [SerializeField, Min(2)] private int _minSplitCount = 2;
    [SerializeField, Range(2, 6)] private int _maxSplitCount = 6;

    private void OnEnable()
    {
        _raycaster.CubeClicked += OnCubeClicked;
    }

    private void OnDisable()
    {
        _raycaster.CubeClicked -= OnCubeClicked;
    }

    private void OnValidate()
    {
        if (_raycaster == null || _spawner == null || _exploder == null)
        {
            Debug.LogError("Не все компоненты назначены", this);
        }
    }

    private void OnCubeClicked(Cube cube)
    {
        if (cube == null)
        {
            return;
        }

        float splitChance = cube.SplitChance;

        if (splitChance <= 0f || (splitChance < 100f && Random.Range(0f, 100f) >= splitChance))
        {
            _spawner.DestroyCube(cube.gameObject);
            return;
        }

        SplitCube(cube);
    }

    private void SplitCube(Cube cube)
    {
        Vector3 origin = cube.transform.position;
        Vector3 childScale = cube.transform.localScale * 0.5f;
        float childChance = cube.SplitChance * 0.5f;

        int minCount = Mathf.Min(_minSplitCount, _maxSplitCount);
        int maxCount = Mathf.Max(_minSplitCount, _maxSplitCount);
        int count = Random.Range(minCount, maxCount + 1);

        List<GameObject> spawnedCubes = new List<GameObject>();

        for (int index = 0; index < count; index++)
        {
            Cube spawnedCube = _spawner.SpawnCube(origin + Random.insideUnitSphere * 0.15f, childScale, childChance);

            spawnedCubes.Add(spawnedCube.gameObject);
        }

        _exploder.Explode(origin, spawnedCubes);
        _spawner.DestroyCube(cube.gameObject);
    }
}