using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Camera))]
public class CubeClickHandler : MonoBehaviour
{
    [SerializeField] private float _maxDistance = 100f;
    private Camera _camera;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    private void OnEnable()
    {
        InputManager.InteractionButtonPressed += ClickCube;
    }

    private void OnDisable()
    {
        InputManager.InteractionButtonPressed -= ClickCube;
    }

    private void ClickCube()
    {
        Ray ray = _camera.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));

        if (Physics.Raycast(ray, out RaycastHit hit, _maxDistance))
        {
            CubeController cube = hit.collider.GetComponentInParent<CubeController>();

            if (cube != null)
                cube.OnClick();
        }
    }
}
