using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public GameObject[] animator;
    public GameObject[] Particle;

    bool isActive = false;
    private bool startProgressBar = false, isConnected2 = false;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <= animator.Length-1; i++)
        {
            animator[i].GetComponent<RotationScript>().enabled = false;
        }
        for (int i = 0; i <= Particle.Length-1; i++)
        {
            Particle[i].SetActive(false);
        }
    }

    public void activOn()
    {
        isActive = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            for(int i = 0; i <= animator.Length-1; i++)
            {
                animator[i].GetComponent<RotationScript>().enabled = true;
            }
            for (int i = 0; i <= Particle.Length-1; i++)
            {
                Particle[i].SetActive(true);
            }
            StartCoroutine(progressBar());
        }
        if (startProgressBar)
        {
             
            if (levelManager.levelMan.slider.value <= 70)
            {
                levelManager.levelMan.slider.value += 1;
            }

            if (levelManager.levelMan.slider.value >= 25)
            {
                levelManager.levelMan.star[0].SetActive(true);
            }
            if (levelManager.levelMan.slider.value >= 70)
            {
                levelManager.levelMan.star[1].SetActive(true);
            }
            if (levelManager.levelMan.slider.value >= 90)
            {
                levelManager.levelMan.star[2].SetActive(true);
            }
            levelManager.levelMan.text.text = levelManager.levelMan.slider.value + "%".ToString();
        }
    }
    IEnumerator progressBar()
    {
        yield return new WaitForSeconds(0.5f);
        startProgressBar = true;
    }
}
