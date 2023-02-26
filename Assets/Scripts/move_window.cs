using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_window : MonoBehaviour
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
       if(transform.position.x < -17f)  transform.position = new Vector3(-17f,transform.position.y, 0f);
       if(transform.position.x > 17f) transform.position = new Vector3(17f,transform.position.y, 0f);
       if(transform.position.y < -12f) transform.position = new Vector3(transform.position.x, -12f, 0f);
       if(transform.position.y > 12f) transform.position = new Vector3(transform.position.x, 12f, 0f);

       

    }

    void OnMouseOver() {

        if(Input.GetMouseButton(0)){
            diff = Camera.main.ScreenToWorldPoint(Input.mousePosition)-transform.localPosition;
            
        }
    }

    private void OnMouseDrag() {
     transform.localPosition = new Vector3 (
            (Camera.main.ScreenToWorldPoint(Input.mousePosition)-diff).x,
            (Camera.main.ScreenToWorldPoint(Input.mousePosition)-diff).y,
            0f); 
    }
}
