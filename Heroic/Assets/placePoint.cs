using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placePoint : MonoBehaviour
{
    public GameObject destinationPoint;
    public string targetTag;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == targetTag)
        {
            print("Collided");
            destinationPoint.SetActive(true);
            Destroy(gameObject);

            
            
        }
    }
    
}
