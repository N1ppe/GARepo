using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public GameObject particleFX;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(particleFX, transform.position, this.gameObject.transform.rotation);
        Debug.Log("Item collected");
        Destroy(this.gameObject);
    }
        
}
