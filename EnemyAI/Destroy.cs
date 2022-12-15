using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
        if(other.gameObject.CompareTag("Building"))
        {
            Destroy(gameObject);
        }
    }
}