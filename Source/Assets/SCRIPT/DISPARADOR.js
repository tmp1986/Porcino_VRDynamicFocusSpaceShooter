#pragma strict

var tiro:Transform;
public static var PontosJogador=0;
var PTiro : GameObject;

function Start () {

}

function Update () {
if (Input.GetKeyDown ("space")) {
	Instantiate(tiro, transform.position, transform.rotation);
	Instantiate(PTiro, transform.position, transform.rotation);
	    }

}

function OnGUI(){

GameObject.FindGameObjectWithTag("SCOREUI").GetComponent.<TextMesh>().text = PontosJogador.ToString();
//GUI.Label(Rect(100,100,200,50), "Pontos:" + PontosJogador);
PlayerPrefs.SetInt("PlayerScore",System.Convert.ToInt16(PontosJogador));

}

