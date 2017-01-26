using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizButtonController : MonoBehaviour {

    [SerializeField]
    private Text buttonLabel;

    private bool correct = false;

    public void Setup(string label)
    {
        buttonLabel.text = label;
    }
    public void SetCorrectOne()
    {
        correct = true;
    }
}
