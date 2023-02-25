using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brick_game_manager : MonoBehaviour
{
    enum game_state{game_over,launch,game,pause,restart};
    private game_state actual_game_state;
    public int nb_ball;

    public GameObject ball_go;

    public bool is_pause = true;
    // Start is called before the first frame update
    void Start()
    {
        actual_game_state = game_state.launch;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(actual_game_state + " // " + is_pause);
        switch(actual_game_state){
            case game_state.launch :
                is_pause = true;
                if(Input.GetKeyDown(KeyCode.Space)) {
                    actual_game_state = game_state.game;
                    GetComponentInChildren<ball_movement>().impulse_ball();
                }
                break;

            case game_state.game :
                is_pause = false;
                if(Input.GetKeyDown(KeyCode.Space)){
                    actual_game_state = game_state.pause;
                }
                break;

            case game_state.pause :
                is_pause = true;
                if(Input.GetKeyDown(KeyCode.Space)){
                    actual_game_state = game_state.game;
                    GetComponentInChildren<ball_movement>().impulse_ball();

                }

                break;

            case game_state.game_over :
                is_pause = true;
                break;

            case game_state.restart :
                is_pause = true;
                break;
        }

        
    }

    void launch_game(){

    }

    public void loose_ball(){
        //Debug.Log("loose a ball");
        nb_ball--;
        if (nb_ball ==0){
            GetComponentInChildren<ball_movement>().kill();
            actual_game_state = game_state.game_over;
            return;
        }
        actual_game_state = game_state.restart;
        StartCoroutine(next_ball()); 
    }

    IEnumerator next_ball(){
        // when you lost a ball
        // begin state
        yield return new WaitForSeconds(2f);
        actual_game_state = game_state.game;
        GetComponentInChildren<ball_movement>().impulse_ball();


    }


}
