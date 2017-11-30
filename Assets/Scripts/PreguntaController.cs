using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PreguntaController : MonoBehaviour {

	bool active;
	public Canvas canvas;
	public Button btnLeft;
	public Button btnRight;
	public int numberQuest;
	private string answer;
	private Text txtAnswerLeft;
	private Text txtAnswerRight;
	string[] questions= new string[]{"Answer1","Answer2","Answer3","Answer4","Answer5","Answer6","Answer7","Answer8","Answer9",
		"Answer10","Answer11"};


	// Recupero el valor del canvas para ser mostrado y inicializo el valor actual del canvas en false para que no sea mostrado
	void Start () {


		//reiniciarQuestions ();

		canvas.enabled = false; 
		txtAnswerLeft = btnLeft.GetComponentInChildren<Text> ();
		txtAnswerRight = btnRight.GetComponentInChildren<Text> ();
		btnLeft.onClick.AddListener (OptionLeft);
		btnRight.onClick.AddListener (OptionRight);

		Debug.Log ("Secuencial:"+secuencial()+", Global:" + global());

	}

	void OnTriggerEnter2D(Collider2D other){

	if (other.tag=="Player")
		{
			if (PlayerPrefs.GetString (questions [numberQuest-1], "No contestada aun") == ("No contestada aun")) {
				active = !active;
				canvas.enabled = active;
				Time.timeScale = (active) ? 0 : 1f;
			}
		}
	}
		
	void OptionLeft(){
		answer = txtAnswerLeft.text;
		int secuencialInt = secuencial ();
		PlayerPrefs.SetInt ("Secuencial",secuencialInt+1);
		SaveAnswer (answer,"Secuencial");
		Active ();
	}

	void OptionRight(){
		answer = txtAnswerRight.text;
		int globalInt = global ();
		PlayerPrefs.SetInt ("Global",globalInt+1);
		SaveAnswer (answer,"Global");
		Active ();
	}

	void Active(){

		active = !active;
		canvas.enabled = false;
		Time.timeScale = (active) ? 0 : 1f;
	}
		
	void SaveAnswer(string answer, string type){

		switch(numberQuest){

		case 1: 
			PlayerPrefs.SetString ("Answer1", answer);
			PlayerPrefs.SetString ("Type1",type);
			break;
		case 2:
			PlayerPrefs.SetString ("Answer2",answer);
			PlayerPrefs.SetString ("Type2",type);
			break;
		case 3: 
			PlayerPrefs.SetString ("Answer3",answer);
			PlayerPrefs.SetString ("Type3",type);
			break;
		case 4:
			PlayerPrefs.SetString ("Answer4",answer);
			PlayerPrefs.SetString ("Type4",type);
			break;
		case 5: 
			PlayerPrefs.SetString ("Answer5",answer);
			PlayerPrefs.SetString ("Type5",type);
			break;
		case 6:
			PlayerPrefs.SetString ("Answer6",answer);
			PlayerPrefs.SetString ("Type6",type);
			break;
		case 7: 
			PlayerPrefs.SetString ("Answer7",answer);
			PlayerPrefs.SetString ("Type7",type);
			break;
		case 8:
			PlayerPrefs.SetString ("Answer8",answer);
			PlayerPrefs.SetString ("Type8",type);
			break;
		case 9: 
			PlayerPrefs.SetString ("Answer9",answer);
			PlayerPrefs.SetString ("Type9",type);
			break;
		case 10:
			PlayerPrefs.SetString ("Answer10",answer);
			PlayerPrefs.SetString ("Type10",type);
			break;
		case 11: 
			PlayerPrefs.SetString ("Answer11",answer);
			PlayerPrefs.SetString ("Type11",type);
			break;



		}
	}

	public int secuencial(){
		return PlayerPrefs.GetInt ("Secuencial",0);
	}

	public int global(){
		return PlayerPrefs.GetInt ("Global",0);
	}

	public string answerOne(){
		return PlayerPrefs.GetString ("Answer1","No contestada aun");
	}

	public string answerTwo(){
		return PlayerPrefs.GetString ("Answer2","No contestada aun");
	}

	public string answerThree(){
		return PlayerPrefs.GetString ("Answer3","No contestada aun");
	}

	public string answerFour(){
		return PlayerPrefs.GetString ("Answer4","No contestada aun");
	}

	public string answerFive(){
		return PlayerPrefs.GetString ("Answer5","No contestada aun");
	}

	public string answerSix(){
		return PlayerPrefs.GetString ("Answer6","No contestada aun");
	}

	public string answerSeven(){
		return PlayerPrefs.GetString ("Answer7","No contestada aun");
	}

	public string answerEight(){
		return PlayerPrefs.GetString ("Answer8","No contestada aun");
	}

	public string answerNine(){
		return PlayerPrefs.GetString ("Answer9","No contestada aun");
	}

	public string answerTen(){
		return PlayerPrefs.GetString ("Answer10","No contestada aun");
	}

	public string answerEleven(){
		return PlayerPrefs.GetString ("Answer11","No contestada aun");
	}

	void reiniciarQuestions(){
		/**PdfGenerator pdf = new PdfGenerator ();
		pdf.getQuestions (PlayerPrefs);
		**/
		string codigo = "No contestada aun";
	 
		PlayerPrefs.SetString ("Answer1",codigo);
		PlayerPrefs.SetString ("Answer2",codigo); 
		PlayerPrefs.SetString ("Answer3",codigo);
		PlayerPrefs.SetString ("Answer4",codigo);
		PlayerPrefs.SetString ("Answer5",codigo);
		PlayerPrefs.SetString ("Answer6",codigo);
		PlayerPrefs.SetString ("Answer7",codigo);
		PlayerPrefs.SetString ("Answer8",codigo); 
		PlayerPrefs.SetString ("Answer9",codigo);
		PlayerPrefs.SetString ("Answer10",codigo);
		PlayerPrefs.SetString ("Answer11",codigo);
		PlayerPrefs.SetString ("Type1","");
		PlayerPrefs.SetString ("Type2","");
		PlayerPrefs.SetString ("Type3","");
		PlayerPrefs.SetString ("Type4","");
		PlayerPrefs.SetString ("Type5","");
		PlayerPrefs.SetString ("Type6","");
		PlayerPrefs.SetString ("Type7","");
		PlayerPrefs.SetString ("Type8","");
		PlayerPrefs.SetString ("Type9","");
		PlayerPrefs.SetString ("Type10","");
		PlayerPrefs.SetString ("Type11","");
		PlayerPrefs.SetInt ("Global",0);
		PlayerPrefs.SetInt ("Secuencial",0);
	}
		

}
