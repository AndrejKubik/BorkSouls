using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpsRotation : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0, 80f * Time.deltaTime, 0);
    }
}
