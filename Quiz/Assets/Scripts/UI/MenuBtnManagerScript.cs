using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuBtnManagerScript : MonoBehaviour 
{
	public void GameMenuBtn(string newGameLevel)
	{
		SceneManager.LoadScene ("HardFeelings_Menu");
	}

	public void realFeelingsLevels (){
	}






	public void ExitGameBtn()
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}
}