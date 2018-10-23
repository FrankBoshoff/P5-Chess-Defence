using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WizardTalk : MonoBehaviour
{
    public GameObject tutorialUiHolder;
    public Text tutorialUIText;
    public int curSentences;

    public int interval01;
    public int interval02;

    public List<string> wizardSentences;

	void Start ()
    {
        //CheckIfTetorial();
        tutorialUiHolder.SetActive(true);
        tutorialUIText.text = wizardSentences[0];
        Time.timeScale = 0;
    }

    //laat zin zien
    //curSentences gelijk aan listindex
    void Update ()
    {
        if (tutorialUiHolder == true)
        {
            if (Input.GetButtonDown("Next"))
            {
                NextSentence();
                tutorialUIText.text = wizardSentences[curSentences];
                NextPhase();
            }
        }
    }

    //volgende zin
    public void NextSentence()
    {
        for (int i = 0; i < wizardSentences.Count; i++)
        {
                curSentences += 1;
                break;
        }
    }
    
    public void NextPhase()
    {
        if (wizardSentences[curSentences] == wizardSentences[interval01])
        {
            Debug.Log("pilsbaas");
            Time.timeScale = 1;
        }
        if (wizardSentences[curSentences] == wizardSentences[interval02])
        {
            Debug.Log("hallo wereld de wereld is van mij");
        }
    }

    //IEnumerator


}
