using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slider : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 diff = Vector3.zero;
    private Vector3 start_position;
    public float speed_to_recover;
    void Start()
    {
        start_position = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.localPosition.x < start_position.x)
            transform.localPosition = start_position;

        if(transform.localPosition.x>= 3.2f)Destroy(transform.parent.gameObject);

        if(transform.localPosition.x != start_position.x) transform.localPosition-= Vector3.right*speed_to_recover*Time.deltaTime;
    }

    void OnMouseOver() {

        if(Input.GetMouseButton(0)){
            diff = Camera.main.ScreenToWorldPoint(Input.mousePosition)-transform.localPosition;
            
        }
    }

    private void OnMouseDrag() {
     transform.localPosition = new Vector3 (
            (Camera.main.ScreenToWorldPoint(Input.mousePosition)-diff).x,
            transform.localPosition.y,
            0f); 
    }
}
