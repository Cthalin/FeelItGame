using System.Collections;
using UnityEngine;
using UnityEngine.UI;
/*
public class textEdit : MonoBehaviour {

	public float speed = 0.1f;
	[SerializeField]
	private Text UsedText = null; //set reference to text from hierachie here

	int characterIndex = 0;
	int stringIndex = 0;

	void Start()
	{
		StartCoroutine (DisplayTimer ());
	}

	//character delay:
	IEnumerator DisplayTimer(){
		while (1 == 1) 
		{
			yield return new WaitForSeconds (speed);
			//check length of text to not increment it endless
			if (characterIndex > UsedText.Length) 
			{
				continue;
			}
			//what is modified:
			UsedText.text = UsedText.Substring(0,characterIndex);
			characterIndex++;
		}
	}

}
*/