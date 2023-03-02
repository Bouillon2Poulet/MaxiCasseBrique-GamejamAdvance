using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class brickGameThemeAudio : MonoBehaviour
{
    
    public AudioClip[] themes;
    public AudioClip intro_sound;

    public AudioClip bravo;
    int randomPick;
    public bool gameStarted;
    bool isOnMenu = true;
    bool isOnWin = false;
    bool over = false;
    public float speed_win_fade_out = 0.2f;
    AudioSource audioSource;
    // Start is called before the first frame update
    // Update is called once per frame

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = intro_sound;
        audioSource.Play();
        gameStarted=false;
    }
    void Update()
    {   
        if (gameStarted == true && isOnMenu == true)
        {
            audioSource.clip = themes[Random.Range(0, themes.Length)];
            audioSource.Play();
            isOnMenu = false;
        }
        if (audioSource.isPlaying == false && gameStarted==true && !isOnWin){
            audioSource.clip = themes[Random.Range(0, themes.Length)];
            audioSource.Play();
        }

        if(GetComponent<brick_game_manager>().actual_game_state == brick_game_manager.game_state.win && audioSource.isPlaying && !isOnWin){
            Debug.Log("fade");
            if(audioSource.volume <0.02) {
                Debug.Log("stop");
                audioSource.Stop();
                isOnWin = true;
                audioSource.volume = 1f;
            }
            audioSource.volume -= speed_win_fade_out*Time.deltaTime;
        }

        if(GetComponent<brick_game_manager>().actual_game_state == brick_game_manager.game_state.win && !audioSource.isPlaying && isOnWin && !over){
            Debug.Log("joue win");
            audioSource.clip = bravo;
            audioSource.Play();
            over = true;
        }
    }
}
