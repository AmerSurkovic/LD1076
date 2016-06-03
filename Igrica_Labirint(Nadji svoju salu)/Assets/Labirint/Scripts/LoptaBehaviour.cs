using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//<summary>
//Ball movement controlls and simple third-person-style camera
//</summary>
public class LoptaBehaviour : MonoBehaviour {

	public GameObject kamera = null;
	public AudioClip zvukSkoka = null;
    public Text pobjeda;
    public Text over;
    private Rigidbody rigidBody = null;
	private AudioSource izvorZvuka = null;
	private bool dodirnutPod = false;
    private bool aktivan = true;

	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
		izvorZvuka = GetComponent<AudioSource> ();
        if(pobjeda!=null)
             pobjeda.text = "";
		if(over!=null)
			over.text = "";
		
		izvorZvuka=GetComponent<AudioSource>();
		izvorZvuka.clip=zvukSkoka;

    }


	void FixedUpdate () {
		if (rigidBody != null && aktivan) {
			if (Input.GetButton ("Horizontal")) {
				rigidBody.AddTorque(Vector3.back * Input.GetAxis("Horizontal")*10);
			}
			if (Input.GetButton ("Vertical")) {
				rigidBody.AddTorque(Vector3.right * Input.GetAxis("Vertical")*10);
			}
			if (Input.GetButtonDown("Jump") && dodirnutPod) {
				if(izvorZvuka != null && zvukSkoka != null){
					izvorZvuka.Play();
				}
				rigidBody.AddForce(Vector3.up*200);
			}
		}
		if (kamera != null && aktivan) {
			Vector3 smjer = (Vector3.up*2+Vector3.back)*2;
			RaycastHit hit;
			//Debug.DrawLine(transform.position,transform.position+smjer,Color.red);
			if(Physics.Linecast(transform.position,transform.position+smjer,out hit)){
				kamera.transform.position = hit.point;
			}else{
				kamera.transform.position = transform.position+smjer;
			}
			kamera.transform.LookAt(transform.position);
		}
	}

	void OnCollisionEnter(Collision coll){
        if (coll.gameObject.tag.Equals("Cube") && aktivan)
        {
            Destroy(coll.gameObject);

            pobjeda.text = "YOU WIN!";
            aktivan = false;
        }
        else if (coll.gameObject.tag.Equals("Wall") && aktivan)
        {
            Destroy(GameObject.FindGameObjectWithTag("Ball"));
            pobjeda.text = "GAME";
            over.text = "OVER";
            aktivan = false;
        }
		else if(coll.gameObject.tag.Equals("Floor"))
		{
			dodirnutPod=true;
		}
    }

	void OnCollisionExit(Collision coll){
		if (coll.gameObject.tag.Equals ("Floor")) {
			dodirnutPod = false;
		}
	}

}
