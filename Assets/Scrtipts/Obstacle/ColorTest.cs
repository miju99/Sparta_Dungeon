using UnityEngine;

public class ColorTest : MonoBehaviour
{
    private Renderer[] childRenderers;

    void Start()
    {
        childRenderers = GetComponentsInChildren<Renderer>();

        foreach(var rend in childRenderers)
        {
            rend.material.color = Color.red;
        }
    }
}
