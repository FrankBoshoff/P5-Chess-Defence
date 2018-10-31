using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WizardTalk : MonoBehaviour
{
    public GameObject tutorialUiHolder;
    public GameObject tutorialSpawnerObject;
    public GameObject waveManagerObject;
    public Text tutorialUIText;
    public int curSentences;
    public float waitTime;
    public bool mayNextSentence;

    public int interval01;
    public int interval02;

    public List<string> wizardSentences;

	void Start ()
    {
        //CheckIfTetorial();
        tutorialUiHolder.SetActive(true);
        mayNextSentence = true;
        tutorialUIText.text = wizardSentences[0];
        Time.timeScale = 0;

    }

    //laat zin zien
    //curSentences gelijk aan listindex
    void Update ()
    {
        if (tutorialUiHolder == true)
        {
            if (mayNextSentence == true)
            {
                if (Input.GetButtonDown("Next"))
                {
                    NextSentence();
                    tutorialUIText.text = wizardSentences[curSentences];
                    NextPhase();
                }
            }

            UiOnOrOf();
        }
        TutorialSpawner();
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
            StartCoroutine(WaitForNextStep());
            mayNextSentence = false;

        }

        if (wizardSentences[curSentences] == wizardSentences[interval02])
        {
            Debug.Log("hallo wereld de wereld is van mij");
            mayNextSentence = false;
            Time.timeScale = 1;
        }
    }

    IEnumerator WaitForNextStep()
    {
        yield return new WaitForSeconds(waitTime);
        mayNextSentence = true;
        Time.timeScale = 0;
    }

    public void UiOnOrOf()
    {
        if (mayNextSentence == true)
        {
            tutorialUiHolder.SetActive(true);
        }
        if (mayNextSentence == false)
        {
            tutorialUiHolder.SetActive(false);
        }
    }

    public void TutorialSpawner()
    {
        if (GameObject.Find("UIManager").GetComponent<UIManager>().waveNumber == 1)
        {
            tutorialSpawnerObject.GetComponent<Spawner>().rEnemy = tutorialSpawnerObject.GetComponent<Spawner>().enemyHolder[0];
            //waveManagerObject.GetComponent<WaveManager>().
        }
        if (GameObject.Find("UIManager").GetComponent<UIManager>().waveNumber == 2)
        {
            Debug.Log("Wave 2");
            tutorialSpawnerObject.GetComponent<Spawner>().rEnemy = tutorialSpawnerObject.GetComponent<Spawner>().enemyHolder[1];
        }
    }
}
