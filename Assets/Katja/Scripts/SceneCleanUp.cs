using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SceneCleanUp : MonoBehaviour
{
    [SerializeField] private List<GameObject> scenes;
    [SerializeField] private GameObject wall;
    [SerializeField] private Timer timer;
    [SerializeField] private TextMeshProUGUI playerCountCanvas;
    [SerializeField] private AudioSource source;

    public static event Action OnTriggeredScene;

    private int puppetLayer = 10;

    private void Start()
    {
        playerCountCanvas.enabled = false;

        if (TryGetComponent(out AudioSource audio))
        {
            source = audio;
            source.playOnAwake = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == puppetLayer)
        {
            OnTriggeredScene?.Invoke();
            source.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == puppetLayer)
        {
            if (TryGetComponent(out BoxCollider collider))
            {
                collider.enabled = false;
            }

            StartCoroutine(EnableTimer());
        }
    }

    IEnumerator EnableTimer()
    {
        timer.enabled = true;
        playerCountCanvas.enabled = true;

        yield return new WaitForSeconds(1);

        foreach (GameObject scene in scenes)
        {
            scene.SetActive(false);
        }

        wall.SetActive(true);

    }

}
