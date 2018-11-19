using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerController : MonoBehaviour {

    public static AudioClip shootSound, pingSound, hitSound, winSound;
    static AudioSource audioSrc;

	// Use this for initialization
	void Start () {

        shootSound = Resources.Load<AudioClip>("shoot");
        pingSound = Resources.Load<AudioClip>("ping");
        hitSound = Resources.Load<AudioClip>("hit");
        winSound = Resources.Load<AudioClip>("win");

        audioSrc = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void PlaySound (string clip){
        switch(clip){
            case "shoot":
                audioSrc.PlayOneShot(shootSound);
                break;
            case "ping":
                audioSrc.PlayOneShot(pingSound);
                break;
            case "hit":
                audioSrc.PlayOneShot(hitSound);
                break;
            case "win":
                audioSrc.PlayOneShot(winSound);
                break;
        }
    }
}
