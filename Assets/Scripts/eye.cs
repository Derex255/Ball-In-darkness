using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eye : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 toTarget = target.position - transform.position;
        Vector3 totargetXZ = new Vector3(toTarget.x, 0, toTarget.z);
        transform.rotation = Quaternion.LookRotation(totargetXZ);
    }
}
