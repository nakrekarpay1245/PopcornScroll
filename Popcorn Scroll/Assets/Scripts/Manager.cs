using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    [Header("Level")]
    [SerializeField]
    private TextMeshProUGUI levelText;
    public int levelNumber = 1;

    [Header("Progress")]
    [SerializeField]
    private Bar progressBar;
    public int necessaryExplodedCornCount = 5;
    public int explodedCornCount = 0;
    [SerializeField]
    private TextMeshProUGUI explodedCornText;

    [Header("Start-End Game")]
    [SerializeField]
    private GameObject tutorial;
    [SerializeField]
    private GameObject levelEndUI;
    [SerializeField]
    private GameObject levelFailedText;
    [SerializeField]
    private GameObject restartButton;
    [SerializeField]
    private GameObject levelCompletedText;
    [SerializeField]
    private GameObject nextButton;
    [SerializeField]
    private GameObject levelUI;

    private bool isFirstTouch;

    private bool firstMove;

    public bool isLevelCompleted;
    public bool isLevelFailed;
    public bool isLevelFinished;

    [SerializeField]
    private GameObject finishLine;

    public static Manager manager;
    private void Awake()
    {
        if (manager == null)
        {
            manager = this;
        }
        levelText.text = "LEVEL - " + levelNumber.ToString();
    }

    private void Start()
    {
        progressBar.SetMaxValue(finishLine.transform.position.z -
            PlayerMovement.playerMovement.transform.position.z);

        explodedCornText.text = explodedCornCount + " / " + necessaryExplodedCornCount;
    }

    private void Update()
    {
        if (!isFirstTouch && firstMove)
        {
            if (!isLevelFinished)
            {
                isFirstTouch = true;
                tutorial.SetActive(false);
            }
        }
        if (!isLevelFinished)
        {
            progressBar.SetCurrentValue(PlayerMovement.playerMovement.transform.position.z);
        }
    }

    public void FinishLevel()
    {
        StartCoroutine(FinishLevelCoroutine());
    }

    public IEnumerator FinishLevelCoroutine()
    {
        Debug.Log("LEVEL FINISHED !");
        PlayerMovement.playerMovement.FinishLevel();
        PlayerRotate.playerRotate.FinishLevel();
        CameraKeeper.cameraKeeper.FinishLevel();

        if (!isLevelFinished)
        {
            isLevelFinished = true;
            levelUI.SetActive(false);
            levelEndUI.SetActive(true);
        }

        yield return new WaitForSeconds(1);

        if (explodedCornCount >= necessaryExplodedCornCount)
        {
            LevelCompleted();
        }
        else
        {
            LevelFailed();
        }
        StopAllCoroutines();
    }


    public void LevelCompleted()
    {
        levelCompletedText.SetActive(true);
        nextButton.SetActive(true);
        Debug.Log("Level Completed !");
    }

    public void LevelFailed()
    {
        levelFailedText.SetActive(true);
        restartButton.SetActive(true);
        Debug.Log("Level Failed !");
    }

    public void StartGame()
    {
        StartCoroutine(StartGameRoutine());
    }

    public IEnumerator StartGameRoutine()
    {
        PlayerMovement.playerMovement.StartGame();
        PlayerRotate.playerRotate.StartGame();
        yield return new WaitForSeconds(0.25f);
        firstMove = true;
        levelUI.SetActive(true);
    }

    public void IncreaseExplodedCornCount()
    {
        Debug.Log("Increase Exploded Corn Count");
        explodedCornCount++;
        explodedCornText.text = explodedCornCount + " / " + necessaryExplodedCornCount;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(levelNumber - 1);
    }

    public void NextLevel()
    {
        if (SceneManager.sceneCountInBuildSettings > levelNumber)
            SceneManager.LoadScene(levelNumber);
        else
            SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
