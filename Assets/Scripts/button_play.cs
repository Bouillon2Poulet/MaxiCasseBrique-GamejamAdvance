using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_play : MonoBehaviour
{
    public Sprite spr_standard;
    public Sprite spr_hower;

    private SpriteRenderer spr_rend;

    private void Start() {
        spr_rend = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update

    void OnMouseOver() {
        // Debug.Log("j suis dessuuuuuuuuuus");

        spr_rend.sprite = Input.GetMouseButtonDown(0) ? spr_hower : spr_standard;
        if(Input.GetMouseButtonUp(0)) Debug.Log("GOGOGOGOGOG");
    }
}
