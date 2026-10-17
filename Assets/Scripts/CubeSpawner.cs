using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private CubeController _cubePrefab;

    public CubeController SpawnCube(Vector3 position, Vector3 scale, float splitChance)
    {
        CubeController cube = Instantiate(_cubePrefab, position, Random.rotation);

        cube.transform.localScale = scale;
        cube.Initialize(splitChance);

        cube.SetRandomColor();

        return cube;
    }
}