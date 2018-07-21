//Author: Michael Cox 2016
//------------------------------
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//------------------------------
public class GameController : MonoBehaviour
{
    // Get Player
    public GameObject Player;
    public bool Reset;
    public static bool PlayerKilled;
    public bool CanExit = true;

    //Scores
    public static int Energy;
    public static int KillCount;

    //stats
    public static int PlayerHealth;

	//Prefixes
	public string EnergyPrefix = string.Empty;
    public string KillCountPrefix = string.Empty;
    public string HealthPrefix = string.Empty;

	//Text objects
	public Text EnergyText = null;
    public Text KillCountText = null;
    public Text HealthText = null;

	//Game over text
	public Text GameOverText = null;
   
	public static GameController ThisInstance = null;
	//------------------------------
	void Awake()
	{
		ThisInstance = this;
        ThisInstance.GameOverText.gameObject.SetActive(false);
        PlayerKilled = false;

        //reset scores
        Energy = 0;
        KillCount = 0;
	}
	//------------------------------

	void Update()
	{
        //If Player exists in the game, get their health. If not, do nothing.
        if (Player != null)
            PlayerHealth = (int)GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().HealthPoints;

        //Update score text
        if (EnergyText != null)
			EnergyText.text = EnergyPrefix + Energy.ToString();
        
        //Update KillCount
        if(KillCountText != null)
            KillCountText.text = KillCountPrefix + KillCount.ToString();

        //Update Player Health
        if (HealthText != null)
            HealthText.text = HealthPrefix + PlayerHealth.ToString();
        
        if (PlayerKilled == true)
            Invoke("GameOver", 2);

        //Can Player exit game?
        if(CanExit == true)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
	}
	//------------------------------

	public void GameOver()
	{
        if (ThisInstance.GameOverText != null)
        {
            if (PlayerKilled == true)
                ThisInstance.GameOverText.gameObject.SetActive(true);
        }

        if (Reset == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
	//------------------------------
}