﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Controller : MonoBehaviour {

    public GameObject Bullet_Emitter;
 
    public GameObject Bullet;
 
    public float Bullet_Forward_Force;
 
        void Start ()
    {
       
        }
       
        void Update ()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SoundManagerController.PlaySound("shoot");
            GameObject Temporary_Bullet_Handler;
            Temporary_Bullet_Handler = Instantiate(Bullet,Bullet_Emitter.transform.position,Bullet_Emitter.transform.rotation) as GameObject;
 
            Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 90);
 
            Rigidbody Temporary_RigidBody;
            Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();
 
            Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force);
 
            Destroy(Temporary_Bullet_Handler, 10.0f);
        }
    }
}
