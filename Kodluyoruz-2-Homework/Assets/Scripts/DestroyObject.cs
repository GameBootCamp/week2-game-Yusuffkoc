using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    
    void Start()
    {
        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.z = 90;
        transform.rotation = Quaternion.Euler(rotationVector);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag =="Ground")
        {
            Destroy(this.gameObject);
        }
       
    }
}
