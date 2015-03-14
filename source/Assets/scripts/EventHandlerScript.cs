using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EventHandlerScript : MonoBehaviour {
	static bool buzzed;
	static bool timerStarted;
	static bool answered;

	public Text TextPlayer;
	public Text TextTimer;
	public Text TextScorePlayer1;
	public Text TextScorePlayer2;
	public Text TextScorePlayer3;
	public Text TextScorePlayer4;

	public GameObject Timer;
	public GameObject PlayerName;
	public GameObject Continue;
	public GameObject Background;
	public GameObject BackgroundPlayer1;
	public GameObject BackgroundPlayer2;
	public GameObject BackgroundPlayer3;
	public GameObject BackgroundPlayer4;
	public GameObject Scores;
	public GameObject ScorePlayer1;
	public GameObject ScorePlayer2;
	public GameObject ScorePlayer3;
	public GameObject ScorePlayer4;
	public GameObject ScoreButtons;


	public int scorePlayer1;
	public int scorePlayer2;
	public int scorePlayer3;
	public int scorePlayer4;

	public string namePlayer1;
	public string namePlayer2;
	public string namePlayer3;
	public string namePlayer4;

	public float timer;
	public float currentTimer;

	// Use this for initialization
	void Start () {
		Timer.SetActive (false);
		PlayerName.SetActive (false);
		Continue.SetActive (false);
		Scores.SetActive (false);

		Background.SetActive (true);
		BackgroundPlayer1.SetActive (false);
		BackgroundPlayer2.SetActive (false);
		BackgroundPlayer3.SetActive (false);
		BackgroundPlayer4.SetActive (false);
		ScoreButtons.SetActive (false);

		buzzed = false;
		timerStarted = false;
		answered = false;

		scorePlayer1 = 0;
		scorePlayer2 = 0;
		scorePlayer3 = 0;
		scorePlayer4 = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// Frage wird gestellt

		// Timer
		if (buzzed == false){
			if (timerStarted == true){
				// läuft bereits
				currentTimer -= Time.deltaTime;
				if (currentTimer <= 0){
					currentTimer = 0;
				}
				TextTimer.text = currentTimer.ToString("F2");
			} else {
				// wird gestartet
				if (Input.GetAxis("Timerstart") == 1){
					timerStarted = true;
					currentTimer = timer;
					TextTimer.text = "20.00";
					Timer.SetActive(true);
				}
			}
		}

		// Buzzer wird gedrückt
		if (buzzed == false) {
			if (Input.GetAxis ("Buzzer1") == 1){
				Background.SetActive (false);
				BackgroundPlayer1.SetActive (true);
				TextPlayer.text = namePlayer1;
				PlayerName.SetActive(true);
				Timer.SetActive(false);
				buzzed = true;
				Continue.SetActive (true);
			}
			if (Input.GetAxis ("Buzzer2") == 1){
				Background.SetActive (false);
				BackgroundPlayer2.SetActive (true);
				TextPlayer.text = namePlayer2;
				PlayerName.SetActive(true);
				Timer.SetActive(false);
				buzzed = true;
				Continue.SetActive (true);
			}
			if (Input.GetAxis ("Buzzer3") == 1){
				Background.SetActive (false);
				BackgroundPlayer3.SetActive (true);
				TextPlayer.text = namePlayer3;
				PlayerName.SetActive(true);
				Timer.SetActive(false);
				buzzed = true;
				Continue.SetActive (true);
			}
			if (Input.GetAxis ("Buzzer4") == 1){
				Background.SetActive (false);
				BackgroundPlayer4.SetActive (true);
				TextPlayer.text = namePlayer4;
				PlayerName.SetActive(true);
				Timer.SetActive(false);
				buzzed = true;
				Continue.SetActive (true);
			}
		}

		// Scorebildschirm
		//if (buzzed = true && )

		// Punktevergabe

		/*
		if (Input.GetAxis ("Buzzer1") == 1) {
			DisplayPlayer.text = "Player 1";
			Background.SetActive(false);
			BackgroundPlayer1.SetActive(true);
			BackgroundPlayer2.SetActive(false);
			BackgroundPlayer3.SetActive(false);
			BackgroundPlayer4.SetActive(false);
		} else {
			DisplayPlayer.text = "No Player";
			Background.SetActive(true);
			BackgroundPlayer1.SetActive(false);
			BackgroundPlayer2.SetActive(false);
			BackgroundPlayer3.SetActive(false);
			BackgroundPlayer4.SetActive(false);
		}
		*/
	}

	public void OnContinueClick(){
		// Scores wurden verteilt -> wie auf normal
		if (buzzed == true && answered == true) {
			Scores.SetActive (false);
			Background.SetActive (true);
			BackgroundPlayer1.SetActive (false);
			BackgroundPlayer2.SetActive (false);
			BackgroundPlayer3.SetActive (false);
			BackgroundPlayer4.SetActive (false);
			timerStarted = false;
			buzzed = false;
			answered = false;
			ScoreButtons.SetActive(false);
			Continue.SetActive (false);
		}

		// Frage wurde gerade beantwortet -> Scores anzeigen
		if (buzzed == true && answered == false) {
			PlayerName.SetActive (false);
			Scores.SetActive (true);
			ScoreButtons.SetActive(true);
			answered = true;
		} 
	}

	public void AddScorePlayer1(int x){
		scorePlayer1 += x;
		TextScorePlayer1.text = scorePlayer1.ToString();
	}

	public void AddScorePlayer2(int x){
		scorePlayer2 += x;
		TextScorePlayer2.text = scorePlayer2.ToString();
	}

	public void AddScorePlayer3(int x){
		scorePlayer3 += x;
		TextScorePlayer3.text = scorePlayer3.ToString();
	}

	public void AddScorePlayer4(int x){
		scorePlayer4 += x;
		TextScorePlayer4.text = scorePlayer4.ToString();
	}
}
