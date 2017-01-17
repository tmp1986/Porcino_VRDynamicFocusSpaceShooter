#pragma strict

function Start () {

}

function Update () {

if (Input.GetKeyDown ("w")) {
 animation.Play("ABAS DESCE");
 }
  
if (Input.GetKeyUp ("w")) {
animation.Play("ABAS SOBE LIVRE");
}


if (Input.GetKeyDown ("s")) {
 animation.Play("ABAS SOBE");
 }
  
if (Input.GetKeyUp ("s")) {
animation.Play("ABAS DESCE LIVRE");
}
}
