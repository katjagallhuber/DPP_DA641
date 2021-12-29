using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SceneCleanUp : MonoBehaviour
{
    [SerializeField] private List<GameObject> scenes;
    [SerializeField] private GameObject wall;

    public static event Action OnTriggeredScene;

    private int puppetLayer = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == puppetLayer)
        {
            foreach (GameObject scene in scenes)
            {
                scene.SetActive(false);
            }

            wall.SetActive(true);

            OnTriggeredScene?.Invoke();
        }  
    }

    private void OnTriggerExit(Collider other)
    {
        if (TryGetComponent(out BoxCollider collider))
        {
            collider.enabled = false;
        }
    }
}
