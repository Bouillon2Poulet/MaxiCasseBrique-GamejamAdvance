using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyParentCross : MonoBehaviour
{
    void OnMouseOver()
    {
        {
            if(Input.GetMouseButtonUp(0))
            {
                Destroy(gameObject.transform.parent.gameObject);
            }
        }
    }
}

