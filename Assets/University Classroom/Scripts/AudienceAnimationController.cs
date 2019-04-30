using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceAnimationController : MonoBehaviour {
    private Animation anim;
    // Use this for initialization
    void Start () {
        anim = gameObject.GetComponent<Animation>();
        anim.Play("idle");
        anim["idle"].time = Random.Range(0, 212);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
