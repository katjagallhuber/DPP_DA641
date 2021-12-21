using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TriggerHitPoints : MonoBehaviour
{
    private int puppetLayer = 10;
    [SerializeField] private int hitPoints;

    public static event Action<int, GameObject> OnTouchedObstacle;

    private void Start()
    {
        // default value, can be changed in the inspector individually for each obstacle
        hitPoints = 10;
    }

    /// <summary>
    /// Everytime the puppet with layer 10 touches an obstacle, the OnTouchedObstacle Event gets invoked
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == puppetLayer)
        {
            Debug.Log(gameObject.name + "hit by" + other.name);
            OnTouchedObstacle?.Invoke(hitPoints, gameObject);
        }
    }
}
