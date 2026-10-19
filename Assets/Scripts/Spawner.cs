using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private ColorChanger _colorChanger;

    public Cube SpawnCube(Vector3 position, Vector3 scale, float splitChance)
    {
        Cube cube = Instantiate(_cubePrefab, position, Random.rotation);

        cube.transform.localScale = scale;
        cube.Initialize(splitChance);

        if (_colorChanger != null)
        {
            _colorChanger.ChangeColor(cube.gameObject);
        }

        return cube;
    }

    public void DestroyCube(GameObject gameObject)
    {
        if (gameObject == null)
        {
            return;
        }

        Destroy(gameObject);
    }
}