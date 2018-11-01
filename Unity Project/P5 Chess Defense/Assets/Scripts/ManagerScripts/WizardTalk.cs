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
    public int interval03;

    bool w2;
    public List<string> wizardSentences;

	void Start ()
    {
        //CheckIfTetorial();
        tutorialUiHolder.SetActive(true);
        mayNextSentence = true;
        tutorialUIText.text = wizardSentences[0];
        Time.timeScale = 0;
        w2 = true;
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
        TutorialFixedSpawner();
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

        if (wizardSentences[curSentences] == wizardSentences[interval03])
        {
            Debug.Log("he ha ne he");
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

    public void TutorialFixedSpawner()
    {
        if (GameObject.Find("UIManager").GetComponent<UIManager>().waveNumber == 1)
        {
            tutorialSpawnerObject.GetComponent<Spawner>().rEnemy = tutorialSpawnerObject.GetComponent<Spawner>().enemyHolder[1];
        }
        if (GameObject.Find("UIManager").GetComponent<UIManager>().waveNumber == 2)
        {
            Debug.Log("Wave 2");
            tutorialSpawnerObject.GetComponent<Spawner>().rEnemy = tutorialSpawnerObject.GetComponent<Spawner>().enemyHolder[0];

            if (w2== true)
            {
                StartCoroutine(WaitForNextStep());
                w2 = false;
            } 
        }
        if (GameObject.Find("UIManager").GetComponent<UIManager>().waveNumber == 3 || GameObject.Find("UIManager").GetComponent<UIManager>().waveNumber == 4)
        {
            //random fix spawner
        }
        if (GameObject.Find("UIManager").GetComponent<UIManager>().waveNumber == 5)
        {
            Debug.Log("Wave 5");
            tutorialSpawnerObject.GetComponent<Spawner>().rEnemy = tutorialSpawnerObject.GetComponent<Spawner>().enemyHolder[2];
        }

    }
}
