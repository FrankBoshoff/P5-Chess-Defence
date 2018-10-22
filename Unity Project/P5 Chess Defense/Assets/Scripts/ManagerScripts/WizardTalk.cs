using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WizardTalk : MonoBehaviour
{
    public GameObject tutorialUiTekst;
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
        NextSentence();
        if (tutorialUiTekst == true)
        {
            //tutorialUiTekst.GetComponentInChildren<Tekst>();
        }
    }

    //volgende zin
    public void NextSentence()
    {
        if (Input.GetButtonDown("Next"))
        {
            for (int i = 0; i < wizardSentences.Count; i++)
            {
                curSentences += 1;
                break;
            }
        }

    }

    //kijken welke scene
    public void CheckIfTetorial()
    {
        Scene curScene = SceneManager.GetActiveScene();
        string curSceneName = curScene.name;

        if (curSceneName == ("Tutorial"))
        {
            tutorialUiTekst.SetActive(true);
            Debug.Log("Wel Tut");
        }
        else
        {
            tutorialUiTekst.SetActive(false);
            Debug.Log("No Tut");
        }
    }
}
