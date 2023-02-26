using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timer : MonoBehaviour
{

    public float chrono; 

    public int milliseconds =0 ;
    public int minutes =0;
    public int seconds =0;

    public string text;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TMPro.TextMeshProUGUI>().text ="00:00:00";
        chrono = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        brick_game_manager bgm = GetComponentInParent<brick_game_manager>();
        if (bgm.actual_game_state == brick_game_manager.game_state.game) {
                
            milliseconds = (int) (chrono % 100) ;
            seconds = (int) (chrono/100) % 60 ;
            minutes = (int) (chrono/6000) ;

            chrono += Time.deltaTime*100;


        }

        GetComponent<TMPro.TextMeshProUGUI>().text = minutes.ToString("D2") + ":" + seconds.ToString("D2") +":"+milliseconds.ToString("D2");
        text =  minutes.ToString("D2") + ":" + seconds.ToString("D2") +":"+milliseconds.ToString("D2");
    }
}

