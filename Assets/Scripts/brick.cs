using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brick : MonoBehaviour
{

    public int HP;
    public Sprite[] list_sprites;

    private int maxHP;
    public int power;

    // Start is called before the first frame update
    void Start()
    {
        maxHP = HP;
        GetComponent<SpriteRenderer>().sprite = list_sprites[HP-1];
    }

    // Update is called once per frame
    void Update()
    {
        if (get_HP()==0) Destroy(gameObject);

        
    }

    public void hit_brick() {
        HP--;
        GetComponent<SpriteRenderer>().sprite = list_sprites[HP-1];


    }

    public int get_HP() {
        return HP;
    }
}
