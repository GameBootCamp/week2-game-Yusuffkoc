using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject waitScreen;
    [SerializeField] private Text waitText;
    [SerializeField] private GameObject gameScreen;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject pauseButtonGMO;
    [SerializeField] private GameObject healthBarGMO;
    [SerializeField] private GameObject scoreBarGMO;


    private Button pauseButton;
    private Button resumeButton;

    private bool isWaitingToStart;

    void Start()
    {
        gameScreen.SetActive(false);
        pauseButtonGMO.SetActive(false);
        pauseScreen.SetActive(false);
        waitScreen.SetActive(true);
        isWaitingToStart = true;
        healthBarGMO.SetActive(false);
        scoreBarGMO.SetActive(false);
        StartCoroutine(WaitForStart());

        pauseButton = pauseButtonGMO.GetComponentInChildren<Button>();
        resumeButton = pauseScreen.GetComponentInChildren<Button>();
    }

    
    void Update()
    {
        CheckToPlay();
        pauseButton.onClick.AddListener(Pause);
        resumeButton.onClick.AddListener(Resume);
    }

    private void Resume()
    {
        gameScreen.SetActive(true);
        pauseButtonGMO.SetActive(true);
        pauseScreen.SetActive(false);

    }

    private void CheckToPlay()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            waitScreen.SetActive(false);

            gameScreen.SetActive(true);
            healthBarGMO.SetActive(true);
            scoreBarGMO.SetActive(true);

            pauseButtonGMO.SetActive(true);
        }
    }

    private void Pause()
    {
        gameScreen.SetActive(false);
        pauseButtonGMO.SetActive(false);
        pauseScreen.SetActive(true);
    }

    private IEnumerator WaitForStart()
    {
        float t = 0;

        while (isWaitingToStart)
        {
            var val = Mathf.PingPong(t, 0.5f) + 0.5f;
            waitText.color = new Color(1, 1, 1, val);
            yield return null;
            t += Time.deltaTime;
        }
    }
}
