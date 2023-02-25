using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timer : MonoBehaviour
{

    private float chrono; 

    private int milliseconds =0 ;
    private int minutes =0;
    private int seconds =0;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TMPro.TextMeshProUGUI>().text ="00:00:00";
        chrono = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponentInParent<brick_game_manager>().is_pause) {
                
            milliseconds = (int) (chrono % 100) ;
            seconds = (int) (chrono/100) % 60 ;
            minutes = (int) (chrono/6000) ;

            chrono += Time.deltaTime*100;


        }

        GetComponent<TMPro.TextMeshProUGUI>().text = minutes.ToString("D2") + ":" + seconds.ToString("D2") +":"+milliseconds.ToString("D2");
        
    }
}

