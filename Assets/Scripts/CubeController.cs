using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CubeController : MonoBehaviour
{
    [SerializeField, Range(0f, 100f)] private float _splitChance = 100f;
    [SerializeField, Min(2)] private int _minSplitCount = 2;
    [SerializeField] private int _maxSplitCount = 6;
    [SerializeField] private CubeSpawner _cubeSpawner;

    [SerializeField, Min(0f)] private float _explosionForce = 5f;
    [SerializeField, Min(0.1f)] private float _explosionRadius = 3f;

    private float _maxChancePrecent = 100f;

    private bool _isProcessed;

    public void OnClick()
    {
        if (_isProcessed)
            return;

        _isProcessed = true;

        if (Random.Range(0f, _maxChancePrecent + 1f) >= _splitChance)
        {
            Destroy(gameObject);
            return;
        }

        Split();
    }

    private void Split()
    {
        int count = Random.Range(_minSplitCount, _maxSplitCount + 1);

        Vector3 origin = transform.position;
        Vector3 childScale = transform.localScale * 0.5f;
        float childChance = _splitChance * 0.5f;

        for (int i = 0; i < count; i++)
        {
            CubeController child = _cubeSpawner.SpawnCube(origin + Random.insideUnitSphere * 0.15f, childScale, childChance);
            ExplosionController.Explode(child.transform.position, _explosionForce, _explosionRadius);
        }

        Destroy(gameObject);
    }

    public void Initialize(float splitChance)
    {
        _splitChance = splitChance;
    }

    public void SetRandomColor()
    {
        Renderer cubeRenderer = gameObject.GetComponent<Renderer>();

        if (cubeRenderer != null)
        {
            cubeRenderer.material.color = Random.ColorHSV();
        }
    }
}
