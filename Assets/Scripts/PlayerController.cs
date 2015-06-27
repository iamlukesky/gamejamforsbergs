﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private bool facingRight = false;

	private Rigidbody2D rb;
	public float speed;
	public int rightEdge;
	public int leftEdge;
	public int topEdge;
	public int bottomEdge;
	private Animator animator;

	public int energy;
	public int nectar;



	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rb.AddForce(movement * speed);
		
		if (Input.GetKeyDown (KeyCode.RightArrow) && facingRight == false) {

			flip ();

		} else if (Input.GetKeyDown (KeyCode.LeftArrow) && facingRight == true) {
		
			flip ();	
		}

		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			animator.SetTrigger("flap");

		}

		checkEdges ();
		Debug.Log (transform.position.x);
	}

	void checkEdges(){
		if (transform.position.x >= rightEdge) {
			Vector3 vel = rb.velocity;
			vel.x = 0;
			rb.velocity = vel;
			Vector3 pos = transform.position;
			pos.x = rightEdge;
			transform.position = pos;
		} if (transform.position.x <= leftEdge) {
			Vector3 vel = rb.velocity;
			vel.x = 0;
			rb.velocity = vel;
			Vector3 pos = transform.position;
			pos.x = leftEdge;
			transform.position = pos;
		} if (transform.position.y <= topEdge) {
			Vector3 vel = rb.velocity;
			vel.y = 0;
			rb.velocity = vel;
			Vector3 pos = transform.position;
			pos.y = topEdge;
			transform.position = pos;
		} if (transform.position.y >= bottomEdge) {
			Vector3 vel = rb.velocity;
			vel.y = 0;
			rb.velocity = vel;
			Vector3 pos = transform.position;
			pos.y = bottomEdge;
			transform.position = pos;

			//gameOver();
		}
	}

	void OnTriggerEnter2D(Collider2D other){ //Collider2D
		if (other.gameObject.CompareTag("Pick Up")) {
			//other.gameObject.SetActive(false);
			Destroy(other.gameObject);
			Debug.Log("Träff");
		}
	}

	private void flip()
	{
		facingRight = !facingRight;

		Vector3 theScale = transform.localScale;
		//Debug.Log (theScale);
		theScale.x *= -1;
		transform.localScale = theScale;
		//transform.localScale *= new Vector3 (-1, 0, 0);
		//transform.localScale = new Vector3(transform.localScale.x * -1, 0, 0);
	}
}
