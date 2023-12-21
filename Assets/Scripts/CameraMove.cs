using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform playerTransform;
    public Rigidbody PlayerRigidbody;
    public List<Vector3> velositiesList = new List<Vector3>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            velositiesList.Add(Vector3.zero);
        }
    }
    private void FixedUpdate()
    {
        velositiesList.Add(PlayerRigidbody.velocity);
        velositiesList.RemoveAt(0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 sum = Vector3.zero;
        for (int i = 0; i < velositiesList.Count; i++)
        {
            sum += velositiesList[i];
        }
        transform.position = playerTransform.position;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(sum),Time.deltaTime * 10);
    }
}
