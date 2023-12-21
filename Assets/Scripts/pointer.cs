using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointer : MonoBehaviour
{
    public CoinManager coinManager;
    public Transform playerTransform;
    public float rotationSpeed = 3;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = FindAnyObjectByType<Player>().transform;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerTransform.position;

        Coin closestCoin = coinManager.GetClosest(transform.position);
        Vector3 toTarget = closestCoin.transform.position;
        Vector3 totargetXZ = new Vector3(toTarget.x, 0, toTarget.z);
        Vector3 direction = totargetXZ - transform.position;
        
        transform.rotation = Quaternion.Lerp(transform.rotation,transform.rotation = Quaternion.LookRotation(direction), Time.deltaTime * rotationSpeed);
       

    }
}
