using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public void ChangeColor(GameObject gameObject)
    {
        if (gameObject == null)
        {
            return;
        }

        Renderer gameObjectRenderer = gameObject.GetComponent<Renderer>();

        if (gameObjectRenderer != null)
        {
            gameObjectRenderer.material.color = Random.ColorHSV();
        }
    }
}