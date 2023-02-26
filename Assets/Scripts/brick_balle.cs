using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brick_balle : MonoBehaviour
{

    public float balle_to_add;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {        
    }

    public void hit_brick() {
        GetComponentInParent<brick_game_manager>().add_ball();
        Destroy(gameObject);
    }
}
