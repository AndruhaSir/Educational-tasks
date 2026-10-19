using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField, Range(0f, 100f)]
    private float _splitChance = 100f;

    private Renderer _renderer;

    public float SplitChance => _splitChance;
    public Renderer Renderer => _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void Initialize(float splitChance)
    {
        _splitChance = Mathf.Clamp(splitChance, 0f, 100f);
    }
}