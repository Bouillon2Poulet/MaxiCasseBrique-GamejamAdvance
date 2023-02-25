using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brick : MonoBehaviour
{

    public int HP;
    private int maxHP;
    public int power;

    // Start is called before the first frame update
    void Start()
    {
        maxHP = HP;
    }

    // Update is called once per frame
    void Update()
    {
        if (get_HP()==0) Destroy(gameObject);

        
    }

    public void hit_brick() {
        Color actual_color =  GetComponent<SpriteRenderer>().color;
        GetComponent<SpriteRenderer>().color = actual_color*(1f)/(maxHP+1-get_HP());
        HP--;

    }

    public int get_HP() {
        return HP;
    }
}
