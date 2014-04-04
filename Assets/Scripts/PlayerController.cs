using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float jumpStrength;
	public GUIText scoreText;
	public GUIText victoryText;

	private int score;

	void Start (){
		score = 0;
		ClearText (victoryText);
		PrintScore ();
	}

	//put physics here!!!!
	void FixedUpdate (){
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		float insideJump = 0.0f;
		if (Input.GetKeyDown ("space")) {
			insideJump = jumpStrength;
		}

		Vector3 movement = new Vector3(moveHorizontal, insideJump, moveVertical);
		insideJump = 0.0f;
		rigidbody.AddForce(movement * speed * Time.deltaTime);
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "PickUp") {
			other.gameObject.SetActive(false);
			score++;
			PrintScore ();
			if(score >= 12){
				victoryText.text = "Fuck Yes";
			}
		}
	}

	void PrintScore () {
		scoreText.text = "Score: " + score.ToString();
	}

	void ClearText (GUIText guiText){
		guiText.text = "";
	}
}