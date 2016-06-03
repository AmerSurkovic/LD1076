using UnityEngine;
using System.Collections;

public class PratiKamera : MonoBehaviour {

	public GameObject objekat = null;
	public bool orbitY=false;
	
	private Vector3 ofset_pozicije = Vector3.zero;
	void Start () {
		ofset_pozicije= objekat.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(objekat != null)
		{
			transform.LookAt(objekat.transform);
			
			if(orbitY)
				transform.RotateAround(objekat.transform.position, Vector3.up, Time.deltaTime*15);
			
			transform.position = objekat.transform.position + ofset_pozicije;
		}
	}
}
