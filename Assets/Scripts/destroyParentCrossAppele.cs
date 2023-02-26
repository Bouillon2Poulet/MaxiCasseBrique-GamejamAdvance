using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyParentCrossAppele: MonoBehaviour
{
    void OnMouseOver()
    {
        {
            if(Input.GetMouseButtonUp(0))
            {
                Destroy(gameObject.transform.parent.gameObject);
                // Trouver le GameObject qui contient le script "Appel"
                
                GameObject appelGameObject = GetComponent<appel>().gameObject;

                // Récupérer l'AudioSource attaché au même GameObject que le script "Appel"
                AudioSource audioSource = appelGameObject.GetComponent<AudioSource>();

                // Arrêter la musique
                audioSource.Stop();
            }
        }
    }
}

