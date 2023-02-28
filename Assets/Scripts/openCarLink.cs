using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openCarLink : MonoBehaviour
{
void Start(){
// cloner le Material du SpriteRenderer pour éviter de modifier le Material du parent
GetComponent<SpriteRenderer>().material = new Material(GetComponent<SpriteRenderer>().material);
GetComponent<SpriteRenderer>().color = Color.red;
}

private void OnMouseEnter() {
// cloner le Material du SpriteRenderer pour éviter de modifier le Material du parent
GetComponent<SpriteRenderer>().material = new Material(GetComponent<SpriteRenderer>().material);
GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f);
}

private void OnMouseExit() {
// réaffecter le Material d'origine pour éviter de modifier le Material du parent
GetComponent<SpriteRenderer>().material = new Material(GetComponent<SpriteRenderer>().material);
GetComponent<SpriteRenderer>().color = Color.red;
}

    void OnMouseOver()
    {
        if(Input.GetMouseButtonUp(0))
        {
            Application.OpenURL("https://www.youtube.com/watch?v=J3z2w5ZsBP8");
        }
    }
}

