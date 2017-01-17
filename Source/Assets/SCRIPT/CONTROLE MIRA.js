#pragma strict

var Controlemira = 1;

function Start () {

}

function Update () {

// CONTROLE MOVIMENTO E LIMITE NAVE NA CAMERA
if(transform.position.x<=2){
	if(Input.GetKey("d")){
	transform.Translate(Controlemira*Time.deltaTime,0,0);
		}
		}
		
if(transform.position.x>=-2){
	if(Input.GetKey("a")){
	transform.Translate(Controlemira*Time.deltaTime*-1,0,0);
		}
		}
		
if(transform.position.y<=2){
	if(Input.GetKey("w")){
	transform.Translate(0,0,Controlemira*Time.deltaTime);
		}
		}
		
if(transform.position.y>=0){
	if(Input.GetKey("s")){
	transform.Translate(0,0,-Controlemira*Time.deltaTime);
		}
		}
		
		
}