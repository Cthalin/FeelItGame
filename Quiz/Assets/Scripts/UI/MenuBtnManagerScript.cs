using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuBtnManagerScript : MonoBehaviour 
{
	public void GameMenuBtn(string newGameLevel)
	{
		SceneManager.LoadScene ("HardFeelings_Menu");
	}


    public void ExitGameLevelBtn(string exitGame)
    {
        SceneManager.LoadScene("Feelings_UI");
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