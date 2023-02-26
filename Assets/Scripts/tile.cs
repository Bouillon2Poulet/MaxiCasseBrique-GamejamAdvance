using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tile : MonoBehaviour
{

    public int win_id;
    public int position_id;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int[] voisins() {
        int[] voisins = {-1, -1, -1, -1};

        if(position_id -3 >= 0) voisins[0] = position_id -3; // haut
        if(position_id%3 < 2) voisins[1] = position_id + 1; // droite
        if(position_id + 3 < 9) voisins[2] = position_id + 3; // bas
        if(position_id%3 > 0) voisins[3] = position_id -1; // gauche

        return voisins;
    }

    int WhereCanMove() {
        foreach (int i in voisins()) {
            if (GetComponentInParent<harambe_game>().isTheEmptyTile(i)){
                return i;
            }
        }
        return -1;
    }

    void OnMouseOver() {
        if(Input.GetMouseButton(0)){
            if (WhereCanMove()!=-1) {
                // position_id = WhereCanMove(); 
                GetComponentInParent<harambe_game>().switchTiles(position_id,WhereCanMove());
            }  
        }
    }
}
