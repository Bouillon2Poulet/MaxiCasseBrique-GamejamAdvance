using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openMiamoLink : MonoBehaviour
{
void Start(){
// cloner le Material du SpriteRenderer pour éviter de modifier le Material du parent
GetComponent<SpriteRenderer>().material = new Material(GetComponent<SpriteRenderer>().material);
GetComponent<SpriteRenderer>().color = Color.green;
}

private void OnMouseEnter() {
Debug.Log("enter");
// cloner le Material du SpriteRenderer pour éviter de modifier le Material du parent
GetComponent<SpriteRenderer>().material = new Material(GetComponent<SpriteRenderer>().material);
GetComponent<SpriteRenderer>().color = Color.blue;
}

private void OnMouseExit() {
// réaffecter le Material d'origine pour éviter de modifier le Material du parent
GetComponent<SpriteRenderer>().material = new Material(GetComponent<SpriteRenderer>().material);
GetComponent<SpriteRenderer>().color = Color.green;
}

    void OnMouseOver()
    {
        if(Input.GetMouseButtonUp(0))
        {
            Debug.Log("click");
            Application.OpenURL("https://miamo.fr/");
        }
    }
}

