using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fish_shake : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector3 shaking = new Vector3(0f,Random.Range(-0.01f,0.01f), 0f );
        transform.Translate(shaking);
    }
}
