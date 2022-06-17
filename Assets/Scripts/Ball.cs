using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] GameManager m_gameManager;



    private void OnCollisionEnter(Collision collision)
    {
        var m_collisionObject = collision.collider.gameObject;

        //make sure object belongs to the pins layer
        if((LayerMask.LayerToName(m_collisionObject.layer) == "Pins"))
        {

            //collect the number of points in the prefab hierarchy
            var m_myScore = m_collisionObject.GetComponent<Pin>().m_pinValue;

            //light up the pin with the coroutine
            m_collisionObject.GetComponent<Pin>().ActivateColor();

            //assign the number of points to the gamemanager
            m_gameManager.UpdateScore(m_myScore);
        }




    }


}
