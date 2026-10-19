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
        if (_inputReader != null)
        {
            _inputReader.InteractionButtonPressed += HandleInteraction;
        }
    }

    private void OnDisable()
    {
        if (_inputReader != null)
        {
            _inputReader.InteractionButtonPressed -= HandleInteraction;
        }
    }

    private void HandleInteraction()
    {
        if (_camera == null)
        {
            return;
        }

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