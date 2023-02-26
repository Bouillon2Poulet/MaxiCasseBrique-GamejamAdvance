using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brick_game_manager : MonoBehaviour
{
    public enum game_state{game_over,launch,game,pause,restart,win};
    public game_state actual_game_state;
    public int nb_ball;
    public int number_of_brick_remaining;

    private int number_of_brick_initial;

    private bool level2;
    private bool level3;

    public GameObject ball_go;
    public float scale_ball_UI = 2f;

    private List<GameObject> liste_ball_to_draw;

    public bool is_pause = true;

    private float time_pause_remaining;
    public Transform position_ball_UI;
    public float spacing_UI = 0.2f;

    public AudioClip balldead;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        liste_ball_to_draw = new List<GameObject>();
        initiate_ball_UI();
        actual_game_state = game_state.launch;

        level2 = false;

        number_of_brick_initial = GetComponentsInChildren<brick>().Length;
        number_of_brick_remaining = GetComponentsInChildren<brick>().Length;

    }
    IEnumerator wait_to_launch(){
        yield return new WaitForSeconds(3f);
        actual_game_state = game_state.game;
        GetComponentInChildren<ball_movement>().impulse_ball();

    }
    // Update is called once per frame
    void Update()
    {
        number_of_brick_remaining = GetComponentsInChildren<brick>().Length;
        //Debug.Log(number_of_brick_remaining);
        

        if(number_of_brick_remaining ==0) actual_game_state = game_state.win;

        switch(actual_game_state){
            case game_state.launch :
                is_pause = true;
                StartCoroutine(wait_to_launch());
                break;

            case game_state.game :
                is_pause = false;
                if(Input.GetKeyDown(KeyCode.Space)){
                    actual_game_state = game_state.pause;
                }

                if (!level2 && number_of_brick_remaining <= 2*number_of_brick_initial/3){
                    GetComponentInParent<window_manager>().CancelInvoke();
                    GetComponentInParent<window_manager>().InvokeRepeating("generate_random_window", 0f, 2.5f);
                    level2 = true;
                }
                if (level2 && !level3 && number_of_brick_remaining <= number_of_brick_initial/3){
                    GetComponentInParent<window_manager>().CancelInvoke();
                    GetComponentInParent<window_manager>().InvokeRepeating("generate_random_window", 0f, 2f);
                    level3 = true;
                }
                break;

            case game_state.pause :
                time_pause_remaining -= Time.deltaTime;
                if(time_pause_remaining <=0f){
                    time_pause_remaining = 0f;
                    actual_game_state = game_state.game;
                }
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

        // Debug.Log(nb_ball + " // " + liste_ball_to_draw.Count);
    }


    public void loose_ball(){
        nb_ball--;
        audioSource.clip = balldead;
        audioSource.Play();

        GameObject go_to_hide = liste_ball_to_draw[nb_ball];
        go_to_hide.GetComponent<SpriteRenderer>().enabled = false;



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


    void draw_lives(){
        foreach(GameObject go in liste_ball_to_draw){
            Instantiate(go,go.transform,transform);
        }
    }

    void initiate_ball_UI(){
        for(int i = 0; i<nb_ball; i++){
            GameObject go = new GameObject();
            go.AddComponent<SpriteRenderer>();
            SpriteRenderer spr = go.GetComponent<SpriteRenderer>();
            spr.sprite = ball_go.GetComponent<SpriteRenderer>().sprite;
            spr.sortingOrder = 2;
            go.transform.localScale = ball_go.transform.localScale*scale_ball_UI;
            go.transform.position = position_ball_UI.position;
            go.transform.parent = transform;
            go.transform.Translate(Vector3.right*i*spacing_UI);
            
            liste_ball_to_draw.Add(go);
        }
    }

    public void add_ball(){
        if(nb_ball==liste_ball_to_draw.Count){
            GameObject go = new GameObject();
            go.AddComponent<SpriteRenderer>();
            SpriteRenderer spr = go.GetComponent<SpriteRenderer>();
            spr.sprite = ball_go.GetComponent<SpriteRenderer>().sprite;
            spr.sortingOrder = 2;
            go.transform.localScale = ball_go.transform.localScale*scale_ball_UI;
            go.transform.position = position_ball_UI.position;
            go.transform.parent = transform;
            go.transform.Translate(Vector3.right*liste_ball_to_draw.Count*spacing_UI);
            liste_ball_to_draw.Add(go);
        }
        else {
            GameObject go_to_show = liste_ball_to_draw[nb_ball];
            go_to_show.GetComponent<SpriteRenderer>().enabled = true;
        }
        nb_ball++;
    }

    public void start_game(){
        if(actual_game_state != game_state.game) actual_game_state = game_state.game;
    }
    public void start_pause(float t){
        time_pause_remaining = t;
        actual_game_state = game_state.pause;
    }
}
