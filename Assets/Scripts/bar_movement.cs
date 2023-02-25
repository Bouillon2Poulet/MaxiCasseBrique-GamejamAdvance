using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bar_movement : MonoBehaviour
{
    public float speed;
    public float max_displacement;

    // private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        // rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float input = Input.GetAxisRaw("Horizontal");
        float move = input*speed*Time.deltaTime;
        if ((move >0 && transform.localPosition.x < max_displacement) || 
            (move <0 && transform.localPosition.x > -max_displacement)){
                transform.Translate(new Vector3(move,0f,0f));
            }
        
    }
}
