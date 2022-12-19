using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBankMaterials : MonoBehaviour
{
    [SerializeField] Material blueMaterial;
    [SerializeField] Material yellowMaterial;

    [SerializeField] MeshRenderer boxRenderer;
    [SerializeField] MeshRenderer[] signsRenderers;

    Material originalBoxMaterial;
    Material originalSignsMaterial;

    bool isOriginal = true;

    // Start is called before the first frame update
    void Start()
    {
        originalBoxMaterial = boxRenderer.material;
        originalSignsMaterial = signsRenderers[0].material;
    }
    
    public void ChangeMaterials()
    {
        if(isOriginal)
        {
            boxRenderer.material = blueMaterial;
            ApplyMaterials(signsRenderers, yellowMaterial);
        }
        else
        {
            boxRenderer.material = originalBoxMaterial;
            ApplyMaterials(signsRenderers, originalSignsMaterial);
        }

        isOriginal = !isOriginal;
    }

    void ApplyMaterials(MeshRenderer[] renderers, Material material)
    {
        foreach(var renderer in renderers)
        {
            renderer.material = material;
        }
    }
}
