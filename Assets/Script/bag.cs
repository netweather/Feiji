using UnityEngine;
using System.Collections;

public class bag : MonoBehaviour {
	
	public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);
		
		if(transform.position.y < -56.77f)
		{
			transform.position = new Vector3(transform.position.x, 56.77f, transform.position.z);
	}
}
}