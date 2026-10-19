using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField, Range(0f, 100f)] private float _splitChance = 100f;
    [SerializeField, Min(0f)] private float _explosionForce = 5f;
    [SerializeField, Min(0.1f)] private float _explosionRadius = 3f;

    private Renderer _renderer;

    public float SplitChance => _splitChance;
    public float ExplotionForce => _explosionForce;
    public float ExplotionRadius => _explosionRadius;

    public Renderer Renderer => _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void Initialize(float splitChance, float explosionForce, float explosionRadius)
    {
        _splitChance = Mathf.Clamp(splitChance, 0f, 100f);
        _explosionForce = explosionForce;
        _explosionRadius = explosionRadius;
    }
}