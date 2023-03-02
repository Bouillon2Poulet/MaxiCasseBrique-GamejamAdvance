using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reparti : MonoBehaviour
{
    public Sprite spr_down;
    public Sprite spr_up;

    public GameObject game_over_menu;
    private void Start() {
    }

    private void OnMouseEnter() {
        GetComponent<SpriteRenderer>().color *= Color.cyan;
    }

    private void OnMouseExit() {
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    void OnMouseOver() {

        if(Input.GetMouseButton(0)){
            GetComponent<SpriteRenderer>().sprite = spr_down;
        }
        else{
            GetComponent<SpriteRenderer>().sprite = spr_up;
        }
        if(Input.GetMouseButtonUp(0)){
            StartCoroutine(restartGame());
            transform.parent.parent.GetComponent<brickGameThemeAudio>().gameStarted = true;
        }
    }

    IEnumerator restartGame(){
        yield return new WaitForSeconds(1f);
        string actual_scene_name = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(actual_scene_name);
        Destroy(GetComponentInParent<brick_game_manager>().gameObject);
    }
}
