using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class appel : MonoBehaviour
{
    public Texture2D[] textures;
    public AudioClip[] sounds;
    public AudioClip callSound;
    Collider2D collider;
    int randomPick;
    AudioSource audioSource;
    // Start is called before the first frame update
    // Update is called once per frame

    void Start()
    {       randomPick = Random.Range(0, textures.Length);
            Texture2D texture = textures[randomPick];
            // Créer un nouveau GameObject enfant avec la texture choisie
            GameObject newObject = new GameObject();
            newObject.transform.parent = transform; // Le nouveau GameObject est un enfant de l'objet sur lequel le script est attaché
            newObject.transform.position = transform.position;
            newObject.transform.position += new Vector3(-0.629999995f, -0.291999996f, 0f)*8.35f;
            newObject.transform.localScale = new Vector3(1f, 1f, 1f);
            newObject.AddComponent<SpriteRenderer>().sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero); // Ajouter un SpriteRenderer au nouveau GameObject avec la texture choisie
            newObject.GetComponent<SpriteRenderer>().sprite.texture.filterMode = FilterMode.Point;
            newObject.GetComponent<SpriteRenderer>().sortingOrder = transform.GetComponent<SpriteRenderer>().sortingOrder + 1;

            audioSource = GetComponent<AudioSource>();
            audioSource.clip = callSound;
            audioSource.loop = true;
            audioSource.Play();

    }
    void Update()
    {
        // Vérifier si le Collider2D est cliqué
        if (Input.GetMouseButtonDown(0) && Collider2DClicked())
        {   
            audioSource.clip = sounds[randomPick];
            audioSource.Play();
            // Récupérer le script Shake attaché au même GameObject que ce script
            shake shakeScript = GetComponent<shake>();

            // Mettre la valeur du float "strength" à zéro dans le script Shake
            shakeScript.strength = 0f;
        }
    }
    // Vérifier si le Collider2D est cliqué
    bool Collider2DClicked()
    {
        Collider2D collider = transform.GetChild(0).GetComponent<Collider2D>();
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return collider.OverlapPoint(mousePosition);
    }
}
