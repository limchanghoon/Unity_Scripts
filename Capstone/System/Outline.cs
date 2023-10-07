using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outline : MonoBehaviour
{
    public Material outline;

    Renderer renderers;
    List<Material> materialList = new List<Material>();

    private void Start()
    {
        if (outline == null)
            return;

        renderers = GetComponent<Renderer>();
    }
    public void On_Outline()
    {
        if (outline == null)
            return;

        materialList.Clear();
        materialList.AddRange(renderers.sharedMaterials);
        materialList.Add(outline);

        renderers.materials = materialList.ToArray();
    }

    public void Off_Outline()
    {
        if (outline == null)
            return;

        Renderer renderer = GetComponent<Renderer>();

        materialList.Clear();
        materialList.AddRange(renderer.sharedMaterials);
        materialList.Remove(outline);

        renderer.materials = materialList.ToArray();
    }
}
