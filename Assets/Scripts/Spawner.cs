using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private ColorChanger _colorChanger;

    public Cube SpawnCube(Vector3 position, Vector3 scale, float splitChance, float explotionForce, float explotionRadius)
    {
        Cube cube = Instantiate(_cubePrefab, position, Random.rotation);

        cube.transform.localScale = scale;
        cube.Initialize(splitChance, explotionForce, explotionRadius);
        _colorChanger.ChangeColor(cube.Renderer);

        return cube;
    }

    public void DestroyCube(GameObject gameObject)
    {
        Destroy(gameObject);
    }

    private void OnValidate()
    {
        if (_cubePrefab == null || _colorChanger == null)
        {
            Debug.LogError("Не все компоненты назначены", this);
        }
    }
}