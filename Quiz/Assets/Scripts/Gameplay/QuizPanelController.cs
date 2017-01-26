using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizPanelController : MonoBehaviour {

	[SerializeField]
    private GameObject QuizButton;
    [SerializeField]
    private Text ButtonLabel;
    [SerializeField]
    private GameObject ButtonSpacer;

    private List<GameObject> quizButtonList = new List<GameObject>();

    public void Awake()
    {
        for(int i = 0; i < 4; i++)
        {
            quizButtonList.Add(Instantiate(QuizButton, ButtonSpacer.transform));
        }
    }
}
