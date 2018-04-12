using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	private List<int> rolls;
	private PinSetter pinSetter;
	private Ball ball;
	private ScoreDisplay scoreDisplay;

	void Start () {
		rolls = new List<int>();
		pinSetter = FindObjectOfType<PinSetter>();
		ball = FindObjectOfType<Ball>();
		scoreDisplay = FindObjectOfType<ScoreDisplay>();
	}
	
	public void Bowl(int pin_fall)
	{
		rolls.Add(pin_fall);
		pinSetter.PerformAction(ActionMaster.NextAction(rolls));
		ball.Reset();
		scoreDisplay.FillRolls(rolls);
		scoreDisplay.FillFrames(ScoreMaster.ScoreCumulative(rolls));
	}
}
