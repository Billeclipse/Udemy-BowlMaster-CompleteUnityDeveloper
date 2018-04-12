using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {

	public Text standing_display;
	public bool is_ball_out_of_play = false;

	private GameManager gameManager;
	private int last_standing_count = -1;
	private float last_change_time;
	private int last_settled_count = 10;

	void Start()
	{
		gameManager = FindObjectOfType<GameManager>();
	}

	void Update()
	{
		standing_display.text = CountStanding().ToString();

		if (is_ball_out_of_play)
		{
			CheckStanding();
			standing_display.color = Color.red;
		}
		else
		{
			standing_display.color = Color.white;
		}
	}

	public void Reset()
	{
		last_settled_count = 10;
	}

	public int CountStanding()
	{
		int standing_pins = 0;
		foreach (Pin pin in FindObjectsOfType<Pin>())
		{
			if (pin.IsStanding())
			{
				standing_pins++;
			}
		}
		return standing_pins;
	}

	void CheckStanding()
	{
		int current_standing = CountStanding();

		if (current_standing != last_standing_count)
		{
			last_change_time = Time.time;
			last_standing_count = current_standing;
			return;
		}

		float settle_time = 3f; // How long to wait to consider pins settled
		if ((Time.time - last_change_time) > settle_time)
		{
			PinHaveSettled();
		}
	}

	void PinHaveSettled()
	{
		int standing = CountStanding();
		int pin_fall = last_settled_count - standing;
		last_settled_count = standing;
		gameManager.Bowl(pin_fall);
		last_standing_count = -1; // Indicates pins have settled, and ball not back in box
		is_ball_out_of_play = false;
		standing_display.color = Color.green;
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.name.Equals("Ball"))
		{
			is_ball_out_of_play = true;
		}
	}
}
