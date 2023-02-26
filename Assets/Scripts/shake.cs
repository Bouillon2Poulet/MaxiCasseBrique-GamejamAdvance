using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shake : MonoBehaviour
{

    public float strength;
    private float impulse_factor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        impulse_factor = Mathf.Round(Mathf.Sin(2*Time.time));
        Vector3 shaking = new Vector3(Random.Range(-strength,strength),Random.Range(-strength,strength), 0f );
        shaking*= impulse_factor;
        transform.Translate(shaking);
        
    }
}
