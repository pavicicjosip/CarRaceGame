using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class camFollow : MonoBehaviour
{
    public Transform Target;

    public Vector3 offset;
    public Vector3 eulerRotation;
    public float damper;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Target == null)
            return;

        transform.position = Vector3.Lerp(transform.position, Target.position + offset, damper * Time.deltaTime);
    }
}
