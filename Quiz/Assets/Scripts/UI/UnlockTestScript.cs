using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UnlockTestScript : MonoBehaviour 
{

	public int score = 100;
	private int LevelAmount = 20; //make that flexible by getting the size of level list of the level manager script 
	private int CurrentLevel;

	void Start () 
	{	
		CheckCurrentLevel ();
		//PlayerPrefs.SetInt("Level2", 1);
		//PlayerPrefs.SetInt ("Level1_score", score);
		StartCoroutine (Time ());
	}


	IEnumerator Time()
	{
		yield return new WaitForSeconds (2f);
		SceneManager.LoadScene (0); //load menu level via ID
	}

	void CheckCurrentLevel()
	{
		for (int i = 1; i<LevelAmount; i++) 
		{
			if (SceneManager.GetActiveScene().name == "Level" + i)
			{
				CurrentLevel = i;
				SaveMyGame();
			}
		}
	}

	void SaveMyGame()
	{
		int NextLevel = CurrentLevel + 1;
		if (NextLevel < LevelAmount) 
		{
			PlayerPrefs.SetInt ("Level" + NextLevel.ToString (), 1); //unlock next level
			PlayerPrefs.SetInt ("Level" + CurrentLevel.ToString () + "_score", score); //save left level
		} 
		else 
		{
			PlayerPrefs.SetInt("Level" + CurrentLevel.ToString()+ "_score", score);
		}
	}
}