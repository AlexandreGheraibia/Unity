using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RotatePropeller : MonoBehaviour
{
    public string objectName;
     GameObject propeller=null;
    // Start is called before the first frame update
    void Start()
    {
        Transform propellerTransform = transform.GetComponentsInChildren<Transform>()
                           .Where(child => objectName.Equals(child.gameObject.name))
                           .DefaultIfEmpty(null).First();
        if(propellerTransform!=null)
            propeller=propellerTransform.gameObject;
    }

    // Update is called once per frame
    void Update()
    {   //excepetion if propeller is null
        propeller.transform.Rotate(30 * Vector3.forward, Space.Self);
    }
}
