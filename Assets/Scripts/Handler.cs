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
        if (_raycaster != null)
        {
            _raycaster.CubeClicked += HandleCubeClicked;
        }
    }

    private void OnDisable()
    {
        if (_raycaster != null)
        {
            _raycaster.CubeClicked -= HandleCubeClicked;
        }
    }

    private void HandleCubeClicked(Cube cube)
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

        for (int i = 0; i < count; i++)
        {
            _spawner.SpawnCube(origin + Random.insideUnitSphere * 0.15f, childScale, childChance);
        }

        _exploder.Explode(origin);

        _spawner.DestroyCube(cube.gameObject);
    }
}