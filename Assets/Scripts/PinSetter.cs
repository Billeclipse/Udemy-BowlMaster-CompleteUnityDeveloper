using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {
	
	public float distance_to_raise = 40f;
	public GameObject pinSet;

	private PinCounter pinCounter;
	private Animator animator;

	void Start()
	{
		animator = GetComponent<Animator>();
		pinCounter = FindObjectOfType<PinCounter>();
	}

	public void RaisePins()
	{
		foreach (Pin pin in FindObjectsOfType<Pin>())
		{
			pin.Raise(distance_to_raise);			
		}
	}

	public void LowerPins()
	{
		foreach (Pin pin in FindObjectsOfType<Pin>())
		{
			pin.Lower(-distance_to_raise);
		}
	}

	public void RenewPins()
	{
		Instantiate(pinSet, new Vector3(0,0,1829), Quaternion.identity);
	}	

	public void PerformAction(ActionMaster.Action action)
	{
		if (action == ActionMaster.Action.Tidy)
		{
			animator.SetTrigger("tidy_trigger");
		}
		else if (action == ActionMaster.Action.EndTurn)
		{
			pinCounter.Reset();
			animator.SetTrigger("reset_trigger");
		}
		else if (action == ActionMaster.Action.Reset)
		{
			pinCounter.Reset();
			animator.SetTrigger("reset_trigger");
		}
		else if (action == ActionMaster.Action.Reset)
		{
			throw new UnityException("Don't know how to handle the endgame");
		}
	}
}
