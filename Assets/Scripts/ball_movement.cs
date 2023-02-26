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

    
    AudioSource audioSource;
    public AudioClip brickDestroyed;
    public AudioClip brickBounce;
    public AudioClip borderAndBarBounce;
    public AudioClip balldead;
    public AudioClip[] pistes;
    // public AudioClip barBounce;
    int piste;

    Vector2 lastVel;
    // Start is called before the first frame update
    void Start()
    {   
        pistes = new AudioClip[4];
        pistes[0]=brickDestroyed;
        pistes[1]=brickBounce;
        pistes[2]=borderAndBarBounce;
        pistes[3]=balldead;
        is_pause = true;
        rb2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        piste = 666;
        is_pause = GetComponentInParent<brick_game_manager>().is_pause;
        current_speed = is_pause ? 0f : speed;
        
        if(!is_pause && rb2d.velocity.magnitude >=0.01f) angle = Mathf.PI*Vector2.SignedAngle(Vector2.right,rb2d.velocity)/180f;
        rb2d.velocity = current_speed ==0f ? Vector2.zero : new Vector2(Mathf.Cos(angle)*speed,Mathf.Sin(angle)*speed);

        lastVel = rb2d.velocity;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.layer == 6){// destroyball
            angle = -Mathf.PI/2;
            transform.position = Vector3.zero;
            GetComponentInParent<brick_game_manager>().loose_ball();

        }

        if(other.gameObject.tag == "Brick"){// brick
            piste=1;
            if(other.gameObject.GetComponent<brick>().hit_brick()==0){
                piste=0;
                Debug.Log(piste);
            }
        }
        
        if(other.gameObject.tag == "Brick_pause"){// brick
            piste=1;
            other.gameObject.GetComponent<brick_pause>().hit_brick();
        }

        if(other.gameObject.tag == "Brick_balle"){// brick
            piste=1;
            other.gameObject.GetComponent<brick_balle>().hit_brick();
        }        

        if(other.gameObject.layer == 7){// PlayerBar
        // var dir = Vector2.Reflect(lastVel.normalized,other.contacts[0].normal);0
        var dir = other.contacts[0].point-new Vector2(other.transform.position.x,other.transform.position.y);
        dir.x*=0.5f;
        rb2d.velocity = dir.normalized*current_speed;//*Mathf.Max(speed,0f);
        piste=2;
        }
        
        else{
        var dir = Vector2.Reflect(lastVel.normalized,other.contacts[0].normal);
        // var dir = other.contacts[0].point-new Vector2(transform.position.x,transform.position.y);

        rb2d.velocity = dir.normalized*current_speed;
        }
        if(piste==666){
            piste=1;
        }
        audioSource.clip=pistes[piste];
        audioSource.Play();
        Debug.Log(piste);
    }
    public void impulse_ball(){
        rb2d.velocity = new Vector2(Mathf.Cos(angle)*speed,Mathf.Sin(angle)*speed);
    }

    public void kill(){
        Destroy(gameObject);
    }
}
