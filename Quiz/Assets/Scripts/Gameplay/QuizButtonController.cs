using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizButtonController : MonoBehaviour {

    [SerializeField]
    private Text buttonLabel;
    
    private GameObject parentPanel;

    private bool correct = false;

    public void Setup(string label, GameObject panel)
    {
        buttonLabel.text = label;
        parentPanel = panel;
    }
    public void SetCorrectOne()
    {
        correct = true;
    }

    public void ClickedButton()
    {
        if (correct)
        {
            gameObject.GetComponent<Image>().color = Color.green;
            parentPanel.GetComponent<QuizPanelController>().IncreaseQuizNumber();
        }
        else
        {
            gameObject.GetComponent<Image>().color = Color.red;
        }
    }
}
