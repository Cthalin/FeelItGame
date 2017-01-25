using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class LevelManagerScript: MonoBehaviour 
{

	[System.Serializable]
	public class Level
	{
			public string LevelText;
			public int Unlocked; //0 = locked
			public bool IsInteractable;
	}

	public GameObject LevelButton;
	public Transform Spacer;
	public List<Level> LevelList;

	void Start ()
	{
		//DeleteAll ();
        //place in Panel as a permanet button function
		FillList();
	}

    void FillList()
	{
			foreach(var level in LevelList)
			{
				GameObject newbutton = Instantiate(LevelButton) as GameObject;
				LevelButtonScript button  = newbutton.GetComponent<LevelButtonScript>();
				button.LevelText.text = level.LevelText; //replace buttons text component with the text entered through LevelManagerScript

				if(PlayerPrefs.GetInt("Level" + button.LevelText.text) == 1)
				{
					level.Unlocked = 1;
					level.IsInteractable = true;
				}
				button.unlocked = level.Unlocked;
				button.GetComponent<Button>().interactable = level.IsInteractable;
				button.GetComponent<Button>().onClick.AddListener(() => LoadLevels ("Level" + button.LevelText.text));

			if(PlayerPrefs.GetInt("Level" + button.LevelText.text + "_score") > 0)
			{
				button.Star1.SetActive(true);
			}
			if(PlayerPrefs.GetInt("Level" + button.LevelText.text + "_score") >= 50)
			{
				button.Star2.SetActive(true);
			}
			if(PlayerPrefs.GetInt("Level" + button.LevelText.text + "_score") >= 99)
			{
				button.Star3.SetActive(true);
			}
			
			
			newbutton.transform.SetParent(Spacer, false);
			}
		SaveAll ();
	}
	

	void SaveAll() //remember the status of all buttons stored in LevelManagerScript; only do it once
	{
//		if (PlayerPrefs.HasKey ("Level1")) 
	//		{
	//			return; //if level 1 fails; there is no progress to save
	//		} 
//		else 
			{
				GameObject[] allButtons = GameObject.FindGameObjectsWithTag ("LevelButton");
				foreach (GameObject buttons in allButtons) 
				{
					LevelButtonScript button = buttons.GetComponent<LevelButtonScript>(); //get access to all publics of the LevelButtonScript
					PlayerPrefs.SetInt("Level" + button.LevelText.text, button.unlocked);
				}
			}

	}

	void DeleteAll()
	{
		PlayerPrefs.DeleteAll (); //delete everything to run script properly
	}

	void LoadLevels(string value)
	{
		SceneManager.LoadScene (value);
	}

}
