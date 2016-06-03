using UnityEngine;
using System.Collections;

public class KockaBehaviour : MonoBehaviour {
	
	public AudioClip gotovo = null;
	public int x=0;
	public AudioSource mAudioSource = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter(Collision coll){
		if (coll.gameObject.tag.Equals ("Ball")) {
			if (mAudioSource != null && gotovo != null)// && coll.relativeVelocity.magnitude > 2f) {
				mAudioSource.PlayOneShot(gotovo, coll.relativeVelocity.magnitude);
			}
		}
	
}
