using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AnimatedTextDialog : MonoBehaviour {
	public Text textArea;
	public string [] strings;
	public float speed = 0.1f;

	int stringIndex = 0;
	int characterIndex = 0;

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
			if (characterIndex > strings [stringIndex].Length) 
				{
				continue;
				}
			//what is modified:
			textArea.text = strings[stringIndex].Substring(0,characterIndex);
			characterIndex++;
		}
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (characterIndex < strings [stringIndex].Length) {
				characterIndex = strings [stringIndex].Length;
			} else if (stringIndex < strings.Length) {
				stringIndex++;
				characterIndex = 0;
			}
		}
	}
}