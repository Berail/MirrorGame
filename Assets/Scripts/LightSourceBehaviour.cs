﻿using UnityEngine;
using System.Collections;

public class LightSourceBehaviour : MonoBehaviour
{

    public GameObject lightRayPrefab;

    private GameObject lightRayInstantiateRay;
    private Vector3 LightDirectionVector;
    private Ray ray;
    private RaycastHit hit;
    private LightRay lightRay;
    private float raydistance = 100;

    // Use this for initialization
    void Start()
    {
        LightDirectionVector = this.transform.TransformDirection(transform.forward);
        lightRay = new LightRay();
        lightRayInstantiateRay = (GameObject) Instantiate(lightRayPrefab, this.transform.position, lightRayPrefab.transform.rotation);
    }

    //TODO: Delegate creating new ray to mirror object.

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, LightDirectionVector * raydistance, Color.red);

        if (Physics.Raycast(transform.position, LightDirectionVector, out hit, raydistance))
        {

            raydistance = Vector3.Distance(hit.point, this.transform.position) + 0.1f;



            Debug.Log("HIT!" + "\n" + "Normal Vector" + hit.normal);
            Debug.DrawRay(hit.point, hit.normal, Color.green);
            //Vector odbity
            Vector3 mirrored = (-2 * ((Vector3.Dot(LightDirectionVector, hit.normal) * hit.normal)) + LightDirectionVector);
            Debug.DrawRay(hit.point, mirrored, Color.red);
        }
        else
        {
            raydistance = 100;
        }

        lightRayInstantiateRay.transform.localScale = new Vector3(lightRayInstantiateRay.transform.localScale.x, raydistance, lightRayInstantiateRay.transform.localScale.z);

    }
}
