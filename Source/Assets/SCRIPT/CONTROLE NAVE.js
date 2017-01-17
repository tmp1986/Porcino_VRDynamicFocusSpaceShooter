#pragma strict

var Controlenave = 50;

function Start () {

}

function Update () {

// CONTROLE MOVIMENTO E LIMITE NAVE NA CAMERA
if(transform.position.x<=15){
	if(Input.GetKey("d")){
		transform.Translate(Controlenave*Time.deltaTime,0,0);
			}
			}
		
if(transform.position.x>=-15){
	if(Input.GetKey("a")){
		transform.Translate(Controlenave*Time.deltaTime*-1,0,0);
			}
			}
		
if(transform.position.y<=10){
	if(Input.GetKey("w")){
		transform.Translate(0,Controlenave*Time.deltaTime,0);
			}
			}
		

if(transform.position.y>=-10){
	if(Input.GetKey("s")){
		transform.Translate(0,Controlenave*Time.deltaTime*-1,0);
			}
			}
		
		
}