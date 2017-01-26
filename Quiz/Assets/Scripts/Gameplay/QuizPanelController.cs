using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class QuizPanelController : MonoBehaviour {

	[SerializeField]
    private GameObject QuizButton;
    [SerializeField]
    private Text ButtonLabel;
    [SerializeField]
    private GameObject ButtonSpacer;
    [SerializeField]
    private Text HeaderLabel;
    [SerializeField]
    private int maxQuizNo;

    private List<GameObject> quizButtonList = new List<GameObject>();
    private List<string> trueFeelingsList = new List<string>();
    private List<string> falseFeelingsList = new List<string>();
    string[] rand = new string[4];
    private int quizNo;

    public void Awake()
    {
        quizNo = 0;
        string[] lines = System.IO.File.ReadAllLines(@"Assets/Resources/TrueFeelings.txt");
        for(int i = 0; i < lines.Length; i++)
        {
            trueFeelingsList.Add(lines[i]);
        }
        lines = System.IO.File.ReadAllLines(@"Assets/Resources/FalseFeelings.txt");
        for (int i = 0; i < lines.Length; i++)
        {
            falseFeelingsList.Add(lines[i]);
        }

        System.Random r = new System.Random();
        rand[0] = trueFeelingsList[r.Next(trueFeelingsList.Count)];
        rand[1] = trueFeelingsList[r.Next(falseFeelingsList.Count)];
        rand[2] = trueFeelingsList[r.Next(falseFeelingsList.Count)];
        rand[3] = trueFeelingsList[r.Next(falseFeelingsList.Count)];

        for (int i = 0; i < 4; i++)
        {
            quizButtonList.Add(Instantiate(QuizButton));
            quizButtonList[i].GetComponent<QuizButtonController>().Setup(rand[i]+" "+i,gameObject); //TODO: Remove string addition! Just for debug
        }

        quizButtonList[0].GetComponent<QuizButtonController>().SetCorrectOne();
        GameObject[] quizButtonArray = quizButtonList.ToArray();
        shuffle(quizButtonArray);
        for(int i = 0; i < quizButtonArray.Length; i++)
        {
            quizButtonArray[i].transform.SetParent(ButtonSpacer.transform);
        }
    }

    GameObject[] shuffle(GameObject[] buttons)
    {
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int t = 0; t < buttons.Length; t++)
        {
            GameObject tmp = buttons[t];
            int r = UnityEngine.Random.Range(t, buttons.Length);
            buttons[t] = buttons[r];
            buttons[r] = tmp;
        }

        return buttons;
    }

    public void IncreaseQuizNumber()
    {
        quizNo++;
        HeaderLabel.text = quizNo + "/" + maxQuizNo;
    }
}