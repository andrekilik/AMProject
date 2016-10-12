using UnityEngine;
using System.Collections;

public class Floor : MonoBehaviour {

	public float speed;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < -18) {
			transform.position = new Vector3 (0, transform.position.y, 0);
		}
		Move ();
	}

	void Move(){
		transform.Translate (speed, 0, 0);
	}
}
