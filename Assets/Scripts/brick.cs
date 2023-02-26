using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brick : MonoBehaviour
{

    public int HP;
    public Sprite[] list_sprites;
    public AudioClip destroySound;
    private int maxHP;
    public int power;

    bool isDestroyed = false;
    
    // Start is called before the first frame update
    void Start()
    {
        maxHP = HP;
        GetComponent<SpriteRenderer>().sprite = list_sprites[HP-1];
    }

    // Update is called once per frame
    void Update()
    {
        if (get_HP()==0) {
                Destroy(gameObject);
        }
    }

    public int hit_brick() {
        HP--;
        if (HP == 0) return 0;
        GetComponent<SpriteRenderer>().sprite = list_sprites[HP-1];
        return HP;
    }

    public int get_HP() {
        return HP;
    }
}
