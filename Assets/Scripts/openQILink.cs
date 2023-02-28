using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openQILink : MonoBehaviour
{
void Start(){
// cloner le Material du SpriteRenderer pour éviter de modifier le Material du parent
GetComponent<SpriteRenderer>().material = new Material(GetComponent<SpriteRenderer>().material);
GetComponent<SpriteRenderer>().color = Color.blue;
}

private void OnMouseEnter() {
// cloner le Material du SpriteRenderer pour éviter de modifier le Material du parent
GetComponent<SpriteRenderer>().material = new Material(GetComponent<SpriteRenderer>().material);
GetComponent<SpriteRenderer>().color = new Color(1f,0f,1f);
}

private void OnMouseExit() {
// réaffecter le Material d'origine pour éviter de modifier le Material du parent
GetComponent<SpriteRenderer>().material = new Material(GetComponent<SpriteRenderer>().material);
GetComponent<SpriteRenderer>().color = Color.blue;
}

    void OnMouseOver()
    {
        if(Input.GetMouseButtonUp(0))
        {
            Application.OpenURL("https://fr.wikihow.com/augmenter-son-quotient-intellectuel");
        }
    }
}

