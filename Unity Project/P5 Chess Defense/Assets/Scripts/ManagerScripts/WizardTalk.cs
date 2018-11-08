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
    public int interval04;

    bool w1;
    bool w2;
    bool w3;
    bool w4;
    bool w5;
    bool mayTure;

    public List<string> wizardSentences;

    public GameObject healthBook;
    public GameObject manaBook;
    public GameObject wave;
    public GameObject help;
    public GameObject panel;
    public GameObject towerEdit;

    void Start ()
    {
        //CheckIfTetorial();

        tutorialUiHolder.SetActive(true);
        mayNextSentence = true;
        tutorialUIText.text = wizardSentences[0];
        Time.timeScale = 0;
        w1 = true;
        w2 = true;
        w3 = true;
        w4 = true;
        w5 = true;

        healthBook.SetActive(false);
        manaBook.SetActive(false);
        wave.SetActive(false);
        help.SetActive(false);
        towerEdit.SetActive(false);
        panel.SetActive(true);
        mayTure = true;
    }

    //laat zin zien
    //curSentences gelijk aan listindex
    void Update ()
    {
        
        if (mayTure == true)
        {
            SetTrueStart();
        }

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

        if (wizardSentences[curSentences] == wizardSentences[interval04])
        {
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

    //fix spawnamount
    public void TutorialFixedSpawner()
    {
        if (GameObject.Find("UIManager").GetComponent<UIManager>().waveNumber == 1)
        {
            tutorialSpawnerObject.GetComponent<Spawner>().rEnemy = tutorialSpawnerObject.GetComponent<Spawner>().enemyHolder[1];

            if (w1 == true)
            {
                waveManagerObject.GetComponent<WaveManager>().toSpawn = 2;
                w1 = false;
            }
        }

        if (GameObject.Find("UIManager").GetComponent<UIManager>().waveNumber == 3)
        {
            tutorialSpawnerObject.GetComponent<Spawner>().rEnemy = tutorialSpawnerObject.GetComponent<Spawner>().enemyHolder[Random.Range(0, 1)];
            print("Random 3 -4");
            if (w3 == true)
            {
                waveManagerObject.GetComponent<WaveManager>().toSpawn = 4;
                w3 = false;
                print("wave 3");
            }

        }

        if (GameObject.Find("UIManager").GetComponent<UIManager>().waveNumber == 4)
        {
            tutorialSpawnerObject.GetComponent<Spawner>().rEnemy = tutorialSpawnerObject.GetComponent<Spawner>().enemyHolder[Random.Range(0, 1)];
            if (w4 == true)
            {
                waveManagerObject.GetComponent<WaveManager>().toSpawn = 5;
                w4 = false;
                print("wave 4");
            }
        }


        if (GameObject.Find("UIManager").GetComponent<UIManager>().waveNumber == 2)
        {
            Debug.Log("Wave 2");
            tutorialSpawnerObject.GetComponent<Spawner>().rEnemy = tutorialSpawnerObject.GetComponent<Spawner>().enemyHolder[0];

            if (w2== true)
            {
                StartCoroutine(WaitForNextStep());
                waveManagerObject.GetComponent<WaveManager>().toSpawn = 3;
                w2 = false;
            } 
        }

        if (GameObject.Find("UIManager").GetComponent<UIManager>().waveNumber == 5)
        {
            Debug.Log("Wave 5");
            tutorialSpawnerObject.GetComponent<Spawner>().rEnemy = tutorialSpawnerObject.GetComponent<Spawner>().enemyHolder[2];
            if (w5 == true)
            {
                StartCoroutine(WaitForNextStep());
                waveManagerObject.GetComponent<WaveManager>().toSpawn = 3;
                w5 = false;
            }
        }

    }


    public void SetTrueStart()
    {
        Time.timeScale = 0;
        if (wizardSentences[curSentences] == wizardSentences[3])
        {
            healthBook.SetActive(true);
        }
        if (wizardSentences[curSentences] == wizardSentences[5])
        {
            towerEdit.SetActive(true);
        }
        if (wizardSentences[curSentences] == wizardSentences[7])
        {
            manaBook.SetActive(true);
        }
        if (wizardSentences[curSentences] == wizardSentences[8])
        {
            wave.SetActive(true);
        }
        if (wizardSentences[curSentences] == wizardSentences[9])
        {
            help.SetActive(true);
        }
        if (wizardSentences[curSentences] == wizardSentences[10])
        {
            panel.SetActive(false);
            towerEdit.SetActive(false);
            Time.timeScale = 1;
            mayTure = false;
        }
    }
}
