using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WizardTalk : MonoBehaviour
{
    public GameObject tutorialUiHolder;
    //public Tekst tutorialUiTekst;  //engine.ui werkt niet
    public int curSentences;

    public List<string> wizardSentences;

	void Start ()
    {
        CheckIfTetorial();
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
                //tutorialUiTekst.tekst
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

    //kijken welke scene
    public void CheckIfTetorial()
    {
        Scene curScene = SceneManager.GetActiveScene();
        string curSceneName = curScene.name;

        if (curSceneName == ("Tutorial"))
        {
            tutorialUiHolder.SetActive(true);
            Debug.Log("Wel Tut");
        }
        else
        {
            tutorialUiHolder.SetActive(false);
            Debug.Log("No Tut");
        }
    }
}
