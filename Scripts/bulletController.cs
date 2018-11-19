using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bulletController : MonoBehaviour {


    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            SoundManagerController.PlaySound("hit");
            other.gameObject.SetActive(false);
            FPController.IncrementaEnemyCount();
        }

    }
}
