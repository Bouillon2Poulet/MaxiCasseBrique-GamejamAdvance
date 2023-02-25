using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_movement : MonoBehaviour
{
    public float speed;
    private float current_speed;
    private Rigidbody2D rb2d;

    private bool is_pause;

    private float angle = -Mathf.PI/2;
    Vector2 lastVel;
    // Start is called before the first frame update
    void Start()
    {
        is_pause = true;
        rb2d = GetComponent<Rigidbody2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
        is_pause = GetComponentInParent<brick_game_manager>().is_pause;
        current_speed = is_pause ? 0f : speed;
        
        if(!is_pause && rb2d.velocity.magnitude >=0.01f) angle = Mathf.PI*Vector2.SignedAngle(Vector2.right,rb2d.velocity)/180f;
        rb2d.velocity = current_speed ==0f ? Vector2.zero : new Vector2(Mathf.Cos(angle)*speed,Mathf.Sin(angle)*speed);

        // Debug.Log(rb2d.velocity + " // " + angle);
        lastVel = rb2d.velocity;
    }

    private void OnCollisionEnter2D(Collision2D other) {

        if(other.gameObject.layer == 6){// destroyball
            angle = -Mathf.PI/2;
            transform.position = Vector3.zero;
            GetComponentInParent<brick_game_manager>().loose_ball();

        }

        if(other.gameObject.tag == "Brick"){// brick
            other.gameObject.GetComponent<brick>().hit_brick();
        }

        if(other.gameObject.layer == 7){// PlayerBar
        // var dir = Vector2.Reflect(lastVel.normalized,other.contacts[0].normal);0
        var dir = other.contacts[0].point-new Vector2(other.transform.position.x,other.transform.position.y);
        dir.x*=0.5f;
        rb2d.velocity = dir.normalized*current_speed;//*Mathf.Max(speed,0f);
        }
        else{
        var dir = Vector2.Reflect(lastVel.normalized,other.contacts[0].normal);
        // var dir = other.contacts[0].point-new Vector2(transform.position.x,transform.position.y);

        rb2d.velocity = dir.normalized*current_speed;
        }
    }
    public void impulse_ball(){
        //Debug.Log("IMPULSION");
        rb2d.velocity = new Vector2(Mathf.Cos(angle)*speed,Mathf.Sin(angle)*speed);
    }

    public void kill(){
        Destroy(gameObject);
    }
}
