using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Data;
using System.Data.OleDb;
using System.Data.OracleClient;

public class GameControl : MonoBehaviour {
    public static GameControl instance;
	public GameObject GameOverText;
	public bool gameOver = false;
	public float ScrollSpeed = -1.5f;
	public int score = 0;
    public int flagtest = 0;
	public Text ScoreText;

    public Text ScoreText1;
//	string cs1="http://localhost/Counts.php";
    
  

    public void Awake() {

		if (instance == null) 
		{
			instance = this;
		} else if (instance != this) 
		{
			Destroy (gameObject);
		}

       
    }

  

    public void createScore(string str1)
	{
		
		//WWWForm form = new WWWForm ();
		//form.AddField ("scorepost",str1);
		//WWW www = new WWW (cs1,form);	
	
	}
	// Update is called once per frame
	void Update () 
	{
		if (gameOver == true && Input.GetMouseButtonDown (0)) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}	
		if (gameOver == true) {
			string s1 = score.ToString();
			createScore (s1);
			return;
		}
	}
	public void BirdScored()
	{
		if (gameOver) {
			
			return;
		}
		score++;
		ScoreText.text = "Score:" + score.ToString ();

	}

	public void BirdDied()
	{
		
		GameOverText.SetActive(true);
		gameOver = true;
        NewBehaviour2 n2 = new NewBehaviour2();
        n2.qqq = n2.qq;
       
        if (flagtest == 0)
        {
           
            n2.counter();
            Debug.Log("gysghd" + n2.qq);
            ScoreText1.text = " high scores: "+ n2.qq;
         

        }
	}
	 
}
