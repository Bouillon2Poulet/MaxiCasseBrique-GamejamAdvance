using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.position.x);
    }

    void OnMouseOver() {

        if(Input.GetMouseButton(0)){
            transform.position += new Vector3(Input.GetAxisRaw("Mouse X"),0f,0f);
        }

    }
}
