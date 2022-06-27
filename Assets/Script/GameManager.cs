using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gM;
    public List<GameObject> sprinklers = new List<GameObject>();

    public GameObject[] pipe;
    [HideInInspector]
    public int getNumber = 0;

    public GameObject tree, flower, plateform, Ground;
    public float delayInDesablingGround = 1;

    public int progressBarFillLimit = 100;
    public int speed = 1;
    public GameObject[] ground_data;
    void Start()
    {
        gM = this;
        tree.SetActive(false);
        flower.SetActive(false);
        plateform.SetActive(true);
        Ground.SetActive(true);
        plateform.GetComponent<plateform>().enabled = false;
        for (int i = 0; i <= ground_data.Length - 1; i++)
        {
            ground_data[i].SetActive(false);
        }
        if (levelManager.levelMan != null)
        {
            //levelManager.levelMan.slider.value = 0;
            for (int i = 0; i <= levelManager.levelMan.star.Length - 1; i++)
            {
                levelManager.levelMan.star[i].SetActive(false);
            }
        }

    }

    void Update()
    {
        starShow();
        if (readyToFountain)
        {
            tree.SetActive(true);
            flower.SetActive(true);
            if (levelManager.levelMan.slider.value <= progressBarFillLimit)
            {
                levelManager.levelMan.slider.value += speed;
                levelManager.levelMan.text.text = levelManager.levelMan.slider.value + "%".ToString();
            }
            for (int i = 0; i <= ground_data.Length - 1; i++)
            {
                ground_data[i].SetActive(true);

            }
            StartCoroutine(desableGround(delayInDesablingGround));

        }
        if (getNumber >= 3)
        {
            plateform.GetComponent<plateform>().enabled = true;
        }
        startFountain();
    }

    void starShow()
    {
        if (levelManager.levelMan.slider.value >= 16)
        {
            levelManager.levelMan.star[0].SetActive(true);
        }
        if (levelManager.levelMan.slider.value >= 50)
        {
            levelManager.levelMan.star[1].SetActive(true);
        }
        if (levelManager.levelMan.slider.value >= 90)
        {
            levelManager.levelMan.star[2].SetActive(true);
        }
    }
    IEnumerator desableGround(float t)
    {
        yield return new WaitForSeconds(t);
        Ground.SetActive(false);
    }

    public bool readyToFountain = false;
    void startFountain()
    {
        if (!pipe[0].GetComponent<pipeData>().disconnected && !pipe[2].GetComponent<pipeData>().disconnected && !pipe[4].GetComponent<pipeData>().disconnected)
        {
            if (pipe[1].GetComponent<dragAndMovePipe>().isConneced && pipe[3].GetComponent<dragAndMovePipe>().isConneced && pipe[5].GetComponent<dragAndMovePipe>().isConneced)
            {
                readyToFountain = true;
            }
        }
    }
}
