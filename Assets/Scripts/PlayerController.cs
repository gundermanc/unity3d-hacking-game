using UnityEngine;
using System.Collections;

/**
 * The class that controls the player.
 */
[RequireComponent (typeof(CharacterController))]
public class PlayerController : MonoBehaviour {

	// The player's movement speed.
	public float movementSpeed = 5.0f;

	// The mouse sensitivity.
	public float mouseSensitivity = 5.0f;

	// The speed of the player's jump.
	public float jumpSpeed = 20.0f;

	// Player camera.
	public Camera PlayerCamera;

	// Weapon camera.
	public Camera WeaponCamera;

	// The player's health.
	public float playerHealth = 100.0f;

	// The on-screen pause text.
	public GUIText pauseGameText;
	
	// The position of the player's camera, based on the mouse movement.
	float verticalRotation = 0;
	public float upDownRange = 60.0f;
	
	float verticalVelocity = 0;

	// The controller of the character.
	CharacterController characterController;

	// Is the game paused?
	private bool gamePaused = false;

	/**
	 * When the player is spawned, lock the cursor
	 * to the screen so that it disappears.
	 */
	void Start () {
		Screen.lockCursor = true;
		characterController = GetComponent<CharacterController>();
	}

	/**
	 * Handle game pause and game exit key presses.
	 * Escape key pauses game, F2 key quits game.
	 */
	void Update() {


		if (Input.GetKeyDown(KeyCode.Escape) && !gamePaused){
			
			Time.timeScale = 0.0f;
			gamePaused = true;
			pauseGameText.text = "Game Paused";
			
		} else if (Input.GetKeyDown(KeyCode.Escape) && gamePaused){
			Time.timeScale = 1.0f;
			Screen.lockCursor = true;
			gamePaused = false;
			pauseGameText.text = "";
		}

		// Quits game
		if (Input.GetKeyDown (KeyCode.F2))
			Application.Quit ();
	}

	/**
	 * Every frame, move the camera based on mouse movement
	 * and move the character based on keyboard input.
	 * Also update health information.
	 */
	void FixedUpdate () {
		
		// Rotation
		
		float rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
		transform.Rotate(0, rotLeftRight, 0);
		
		verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
		verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
		PlayerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
		
		// Movement
		
		float forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
		float sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;
		
		verticalVelocity += Physics.gravity.y * Time.deltaTime;
		
		if( characterController.isGrounded && Input.GetButton("Jump") ) {
			verticalVelocity = jumpSpeed;
		}
		
		Vector3 speed = new Vector3( sideSpeed, verticalVelocity, forwardSpeed );
		
		speed = transform.rotation * speed;
		
		characterController.Move( speed * Time.deltaTime );


}
}
