using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brick_pause : MonoBehaviour
{

    public float time_pause = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {        
    }

    public void hit_brick() {
        GetComponentInParent<brick_game_manager>().start_pause(time_pause);
        Destroy(gameObject);
    }
}
