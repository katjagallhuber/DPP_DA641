using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TriggerHitPoints : MonoBehaviour
{
    [SerializeField] private int hitPoints;
    [SerializeField] private bool IsAdded;

    private int puppetLayer = 10;
    private List<Material> materials;

    public static event Action<int, GameObject, bool> OnTouchedObstacle;

    private void Start()
    {
        // default value, can be changed in the inspector individually for each obstacle
        hitPoints = 10;

        AddMaterialsToList();

        Debug.Log(materials.Count);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == puppetLayer)
        {
            ControlEmissionOnHover();
        }
        
    }

    /// <summary>
    /// Everytime the puppet with layer 10 touches an obstacle, the OnTouchedObstacle Event gets invoked
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == puppetLayer)
        {
            OnTouchedObstacle?.Invoke(hitPoints, gameObject, IsAdded);
        }
    }

    // Control the emission of the object 
    private void ControlEmissionOnHover()
    {
        foreach (Material m in materials)
        {
           // m.EnableKeyword("Emission");

            if (IsAdded)
            {
                m.SetColor("_EMISSION_COLOR", new Color(0.0f, 0.8f, 0.0f));
            } else
            {
                m.SetColor("_EMISSION_COLOR", new Color(0.8f, 0.0f, 0.0f));
            }
        }

        StartCoroutine("ResetMaterials");
    }


    private IEnumerator ResetMaterials()
    {
        yield return new WaitForSeconds(2f);

        foreach (Material m in materials)
        {
            //m.DisableKeyword("Emission");
            //m.SetColor("_EmissionColor", new Color(0.15f, 0.15f, 0.15f));
            m.SetColor("_EMISSION_COLOR", new Color(0.0f, 0.0f, 0.0f));
        }
    }

    // Get all materials on the object to control their emission later on
    // Sometimes there are more than one material on an object
    private void AddMaterialsToList()
    {
        materials = new List<Material>();

        if (TryGetComponent(out MeshRenderer renderer))
        {
            for (int i = 0; i < renderer.materials.Length; i++)
            {
                materials.Add(renderer.materials[i]);
            }

        }

        Renderer[] rendererChildren = this.gameObject.GetComponentsInChildren<Renderer>();

        for (int i = 0; i < rendererChildren.Length; i++)
        {
            foreach (Material mChild in rendererChildren[i].materials)
            {
                materials.Add(mChild);
            }
        }
    }
}
