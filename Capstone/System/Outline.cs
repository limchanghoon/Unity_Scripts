using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outline : MonoBehaviour
{
    public Material outline;

    Renderer myRenderer;
    List<Material> materialList = new List<Material>();

    private void Start()
    {
        if (outline == null)
            return;

        myRenderer = GetComponent<Renderer>();
        materialList.AddRange(myRenderer.sharedMaterials);
    }

    public void On_Outline()
    {
        if (outline == null)
            return;

        materialList.Add(outline);

        myRenderer.materials = materialList.ToArray();
    }

    public void Off_Outline()
    {
        if (outline == null)
            return;

        materialList.Remove(outline);

        myRenderer.materials = materialList.ToArray();
    }
}
