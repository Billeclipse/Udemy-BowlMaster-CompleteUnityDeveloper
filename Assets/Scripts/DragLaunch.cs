using UnityEngine;

[RequireComponent(typeof(Ball))]
public class DragLaunch : MonoBehaviour {

	private Vector3 dragStart, dragEnd;
	private float startTime, endTime;
	private Ball ball;

	void Start () {
		ball = GetComponent<Ball>();
	}

	public void MoveStart (float amount)
	{
		if(!ball.in_play)
		{
			float pos_x = Mathf.Clamp(ball.transform.position.x + amount, -50f, 50f);
			float pos_y = ball.transform.position.y;
			float pos_z = ball.transform.position.z;
			ball.transform.position = new Vector3(pos_x, pos_y, pos_z);
		}		
	}
	
	public void DragStart()
	{
		// Capture time & position of drag start
		if (!ball.in_play)
		{
			dragStart = Input.mousePosition;
			startTime = Time.time;
		}
	}

	public void DragEnd()
	{
		// Launch the ball
		if (!ball.in_play)
		{
			dragEnd = Input.mousePosition;
			endTime = Time.time;

			float dragDuration = endTime - startTime;
			float launchSpeedX = (dragEnd.x - dragStart.x) / dragDuration;
			float launchSpeedZ = (dragEnd.y - dragStart.y) / dragDuration;

			Vector3 launchVelocity = new Vector3(launchSpeedX, 0f, launchSpeedZ);

			ball.Launch(launchVelocity);
		}
	}
}
