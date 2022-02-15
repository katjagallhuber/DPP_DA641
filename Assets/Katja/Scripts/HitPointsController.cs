using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HitPointsController : MonoBehaviour
{
    private int currentHitPoints;
    public TextMeshProUGUI hitObjectTextUI;

    [SerializeField] private AudioSource audioSource;

    private void Start()
    {
        currentHitPoints = 0;
        hitObjectTextUI.text = "Hitpoints: 0";
        TriggerHitPoints.OnTouchedObstacle += IncreaseHitPoints;
        SceneCleanUp.OnTriggeredScene += ResetCurrentHitPoints;
        Timer.OnTimerEnded += EndGame;

        audioSource = gameObject.AddComponent<AudioSource>();
    }

    /// <summary>
    /// If the OnTouchedObstacle event gets called, this function is executed once. Depending on bool IsAdded, the overall hit points increase or decrease and UI text is updated
    /// </summary>
    /// <param name="hitPoints"></param>
    private void IncreaseHitPoints(int hitPoints, GameObject hitGameObject, bool IsAdded)
    {
        if (IsAdded)
        {
            currentHitPoints += hitPoints;
            hitObjectTextUI.text = "Perfect! You hit the " + hitGameObject.name + ". Hitpoints: " + currentHitPoints.ToString();
            StartCoroutine("DespawnObject", hitGameObject);
        } 
        else
        {
            currentHitPoints -= hitPoints;
            hitObjectTextUI.text = "Oh no! You hit the " + hitGameObject.name + ". Hitpoints: " + currentHitPoints.ToString();
        }
    }

    private void ResetCurrentHitPoints()
    {
        currentHitPoints = 0;
        hitObjectTextUI.text = "Hitpoints: " + currentHitPoints.ToString();
    }

    private void EndGame()
    {
        TriggerHitPoints.OnTouchedObstacle -= IncreaseHitPoints;
        hitObjectTextUI.fontStyle = FontStyles.Bold;
        hitObjectTextUI.color = Color.red;
        hitObjectTextUI.text = "Congratulations! You finished the level and got " + currentHitPoints.ToString() + " hitpoints! You can now put off your headset.";
        audioSource.Play();
    }

    private IEnumerator DespawnObject(GameObject hitObject)
    {
        yield return new WaitForSeconds(2f);
        hitObject.SetActive(false);
    }
}
