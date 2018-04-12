using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class ScoreMaster{

	//Returns a list of cumulative scores, like a normal score card
	public static List<int> ScoreCumulative(List<int> rolls)
	{
		List<int> cumulativeList = new List<int>();
		int running_total = 0;

		foreach(int frameScore in ScoreFrames(rolls))
		{
			running_total += frameScore;
			cumulativeList.Add(running_total);
		}

		return cumulativeList;
	}

	//Returns a list of individual frame scores
	public static List<int> ScoreFrames(List<int> rolls)
	{
		List<int> frames = new List<int>();

		//Index i points to 2nd bowl of frame
		for(int i=1; i<rolls.Count; i += 2)
		{
			if(frames.Count == 10) { break; }  //Prevents 11th frame score

			if (rolls[i-1] + rolls[i] < 10)
			{ // Normal "open" frame
				frames.Add(rolls[i - 1] + rolls[i]);
			}

			if (rolls.Count - i <= 1) { break; } // Insufficient look-ahead

			if(rolls[i-1] == 10)
			{
				i--;             // STRIKE frame has just one bowl
				frames.Add(10 + rolls[i + 1] + rolls[i+2]);
			}
			else if (rolls[i - 1] + rolls[i] == 10) // Calucalate SPARE bonus
			{
				frames.Add(10 + rolls[i+1]);
			}
		}

		return frames;
	}


	//My attempted code...
	//public static List<int> ScoreFrames(List<int> rolls)
	//{
	//	List<int> frameList = new List<int>();
	//	int roll_count = 0;
	//	int frame_count = 0;
	//	int frame_score = 0;
	//	int frame_bonus = 0;
	//	foreach(int roll in rolls)
	//	{
	//		Debug.Log("roll " + roll + " fc " + frame_count);
	//		frame_score += roll;
	//		roll_count++;
	//		if (roll_count % 2 == 0)
	//		{				
	//			if (frame_score < 10)
	//			{
	//				if(frame_count % 2 == 0)
	//				{
	//					Debug.Log("_fs " + frame_score);
	//					frameList.Add(frame_score);
	//					frame_score = 0;
	//				}									
	//			}
	//			else
	//			{
	//				frame_count++;
	//				frame_bonus += frame_score;
	//				frame_score = 0;
	//			}
	//		}
	//		else
	//		{
	//			if (frame_bonus > 0)
	//			{
	//				Debug.Log("_fs " + (frame_score + frame_bonus));
	//				frameList.Add(frame_score + frame_bonus);
	//				frame_bonus = 0;
	//				frame_count++;
	//				if (frame_score > 0 && roll_count==rolls.Capacity && frame_count % 2 ==0)
	//				{
	//					Debug.Log("_fs " + frame_score);
	//					frameList.Add(frame_score);
	//				}					
	//			}
	//			if(frame_score >= 10)
	//			{
	//				frame_bonus += frame_score;
	//				frame_score = 0;
	//				frame_count++;
	//			}
	//		}			
	//		Debug.Log("fs " + frame_score + " rc " + roll_count + " fb " + frame_bonus);
	//	}
	//	return frameList;
	//}
}
