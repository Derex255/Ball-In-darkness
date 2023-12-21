using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public Transform CameraCenter;
    public float TorqueValue;
    // Start is called before the first frame update
    public bool isLose = false;
    private LightController[] allLightes;
    public static GameManager instance = null;
    private AudioController audioController;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        allLightes = FindObjectsOfType<LightController>();
        audioController = FindObjectOfType<AudioController>();
    }
    public void Lose()
    {
        isLose = true;
        foreach (LightController light in allLightes)
        {
            light.GetComponent<Light>().enabled = false;
        }
        audioController.PlayLoseSound();
    }
    public void RestartGame()
    {
        isLose = false;
        foreach (LightController light in allLightes)
        {
            light.GetComponent<Light>().enabled = true;
        }
    }
}
