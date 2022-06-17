using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    [SerializeField] public int m_pinValue;
    [SerializeField] Material m_pinLightUpMaterial;
    private Material m_pinBaseMaterial;
    private float m_lightingTimer = .5f;
    private float myTime = 0;


    public void Start()
    {
        //save pin original color for later use
        m_pinBaseMaterial = GetComponent<MeshRenderer>().material;
    }

    public void ActivateColor()
    {
        StartCoroutine(LightItUp());
    }


    private IEnumerator LightItUp()
    {
       // change pin material to the lightup one
        GetComponent<MeshRenderer>().material = m_pinLightUpMaterial;

       // timer for the pin to remain lighted up
        while (myTime < m_lightingTimer)
        {
            myTime += Time.deltaTime; ;
            yield return new WaitForEndOfFrame();
        }

        //return pin to its original color
        GetComponent<MeshRenderer>().material = m_pinBaseMaterial;
        myTime = m_lightingTimer;
    }

}