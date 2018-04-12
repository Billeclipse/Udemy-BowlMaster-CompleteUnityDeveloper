using UnityEngine;

public class Ball : MonoBehaviour {

	public Vector3 launchVelocity;

	public bool in_play = false;

	private Vector3 ball_start_position;
	private Rigidbody rigidBody;
	private AudioSource audioSource;

	void Start ()
	{
		rigidBody = GetComponent<Rigidbody>();
		rigidBody.useGravity = false;
		ball_start_position = transform.position;
	}

	public void Launch(Vector3 velocity)
	{
		in_play = true;

		rigidBody.useGravity = true;
		rigidBody.velocity = velocity;

		audioSource = GetComponent<AudioSource>();
		audioSource.Play();
	}

	public void Reset()
	{
		in_play = false;
		transform.position = ball_start_position;
		transform.rotation = Quaternion.identity;
		rigidBody.velocity = Vector3.zero;
		rigidBody.angularVelocity = Vector3.zero;
		rigidBody.useGravity = false;
	}
}
