using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class harambe_game : MonoBehaviour
{

    public float delta;
    tile[] Tiles;
    private Transform init_pos;
    // Start is called before the first frame update
    void Start()
    {
        Tiles = GetComponentsInChildren<tile>();

        List<int> occupied_id = new List<int>();


        init_position_id();
        init_position_from_id();
        init_pos = transform;

    
    }

    // Update is called once per frame
    void Update()
    {
        foreach (tile t in Tiles)
        {
            // Debug.Log(t.position_id + " // " + t.win_id);
        }
        
        check_win();
    }

    public bool isTheEmptyTile(int position_id) {
        if(position_id ==-1) return false;
        return (Tiles[position_id].GetComponent<tile>().win_id == 2);
    }

    public void switchTiles(int id1, int id2) {
        tile temp_tile = Tiles[id1];
        // switch place in array
        Tiles[id1] = Tiles[id2];
        Tiles[id2] = temp_tile;

        Tiles[id1].position_id = id1;
        Tiles[id2].position_id = id2;

        Tiles[id1].transform.position = init_pos.position + new Vector3(
                                                                (id1%3-1)*delta,
                                                                (-(id1/3)+1)*delta,
                                                                0f
        );

        Tiles[id2].transform.position = init_pos.position + new Vector3(
                                                                (id2%3-1)*delta,
                                                                (-(id2/3)+1)*delta,
                                                                0f
        );

    }

    void init_position_id(){
        for(int i =0; i<9; i++){
            Tiles[i].GetComponent<tile>().position_id = i;
        }
    }

    void init_position_from_id(){
        for(int i =0; i<9; i++){
            int x = i%3-1;
            int y = -i/3+1;
            Tiles[i].GetComponent<tile>().transform.Translate(new Vector3(x*delta,+y*delta,
                                                                        0f));
        }
    }

    void check_win () {
        foreach (tile t in Tiles) {
            if (t.position_id != t.win_id){
                return ;
            }
        }
        Debug.Log("win");
        Destroy(transform.parent.gameObject,0.8f);
    }
}
