using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Pin : MonoBehaviour {
	
	public float standing_threshold = 3f;

	private Rigidbody rigidBody;

	void Start()
	{
		rigidBody = GetComponent<Rigidbody>();
	}

	public bool IsStanding()
	{
		Vector3 rotation_in_euler = transform.rotation.eulerAngles;
		float tilt_x = Mathf.Abs(270 - rotation_in_euler.x);
		float tilt_z = Mathf.Abs(rotation_in_euler.z);
		if(tilt_x < standing_threshold && tilt_z < standing_threshold)
		{
			return true;
		}
		return false;
	}

	public void Raise(float distance_to_raise)
	{
		if (IsStanding()){
			rigidBody.useGravity = false;
			transform.Translate(new Vector3(0, distance_to_raise, 0), Space.World);
			transform.rotation = Quaternion.Euler(270f, 0, 0);
		}
	}

	public void Lower(float distance_to_lower)
	{
		if (IsStanding())
		{
			transform.Translate(new Vector3(0, distance_to_lower, 0), Space.World);
			rigidBody.useGravity = true;
		}
	}
}
