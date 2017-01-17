#pragma strict

function Start () {

}

function Update () {

if (Input.GetKeyDown ("a")) {
 animation.Play("CENTRO_ROT_DIR");
 }
  
if (Input.GetKeyUp ("a")) {
animation.Play("CENTRO_ROT_DIR_VOLTA");
}


if (Input.GetKeyDown ("d")) {
 animation.Play("CENTRO_ROT_ESQ");
 }
  
if (Input.GetKeyUp ("d")) {
animation.Play("CENTRO_ROT_ESQ_VOLTA");
}
}
