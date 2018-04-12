using UnityEngine;

public class Shredder : MonoBehaviour {

	private void OnTriggerExit(Collider other)
	{
		GameObject thing_left = other.gameObject;

		if (thing_left.GetComponent<Pin>())
		{
			Destroy(thing_left);
		}
	}

}
