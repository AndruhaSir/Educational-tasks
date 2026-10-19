using System;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Camera _camera;
    [SerializeField, Min(0f)] private float _maxDistance = 100f;

    public event Action<Cube> CubeClicked;

    private void OnEnable()
    {
        _inputReader.InteractionButtonPressed += OnInteractionButtonPressed;
    }

    private void OnDisable()
    {
        _inputReader.InteractionButtonPressed -= OnInteractionButtonPressed;
    }

    private void OnValidate()
    {
        if (_inputReader == null || _camera == null)
        {
            Debug.LogError("Не все компоненты назначены", this);
        }
    }

    private void OnInteractionButtonPressed()
    {
        Ray ray = _camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if (!Physics.Raycast(ray, out RaycastHit hit, _maxDistance))
        {
            return;
        }

        Cube cube = hit.collider.GetComponent<Cube>();

        if (cube == null)
        {
            return;
        }

        CubeClicked?.Invoke(cube);
    }
}