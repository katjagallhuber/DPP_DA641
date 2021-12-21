using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HitPointsController : MonoBehaviour
{
    private int currentHitPoints;
    public TextMeshProUGUI hitPointsUI;
    public TextMeshProUGUI hitObjectTextUI;

    private void Start()
    {
        currentHitPoints = 0;
        TriggerHitPoints.OnTouchedObstacle += IncreaseHitPoints;
    }

    /// <summary>
    /// If the OnTouchedObstacle event gets called, this function is executed once. The overall hit points increase and the UI text is updated
    /// </summary>
    /// <param name="hitPoints"></param>
    private void IncreaseHitPoints(int hitPoints, GameObject hitGameObject)
    {
        Debug.Log("added " + hitPoints + " points!");
        currentHitPoints += hitPoints;

        hitPointsUI.text = currentHitPoints.ToString();
        hitObjectTextUI.text = "Oh no! You hit the object " + hitGameObject.name;
    }

    
}
