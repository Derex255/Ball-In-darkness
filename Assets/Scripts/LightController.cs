using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform player;
    public Transform ground;
    private Light myLight;
    public Color goodColor;
    public Color badLight;
    void Start()
    {
        player = FindObjectOfType<Player>().transform;
        myLight = GetComponent<Light>();
        

    }
    void ChangeLightColor()
    {
        float distanceToBoundary = GetMinDistanseToBound();
        float t = Mathf.InverseLerp(0, ground.localScale.x / 2, distanceToBoundary);
        myLight.color = Color.Lerp(badLight, goodColor, t);
    }

    // Update is called once per frame
    void Update()
    {
       
        ChangeLightColor();
    }
    float GetMinDistanseToBound()
    {
        float zBound = ground.position.z + ground.localScale.z / 2;
        float xBound = ground.position.x + ground.localScale.x/ 2;
        float minDistance = Mathf.Min(player.position.x + xBound, xBound - player.position.x, player.position.z + zBound, zBound - player.position.z);
        return minDistance;
    }
}
