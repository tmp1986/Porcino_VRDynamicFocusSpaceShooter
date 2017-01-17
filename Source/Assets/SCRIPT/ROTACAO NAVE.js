#pragma strict

function Start () {

}

function Update () {

if (Input.GetKeyDown ("a")) {
 animation.Play("ROT_DIR_IDA");
 }
  
if (Input.GetKeyUp ("a")) {
animation.Play("ROT_DIR_VOLTA");
}


if (Input.GetKeyDown ("d")) {
 animation.Play("ROT_ESQ_IDA");
 }
  
if (Input.GetKeyUp ("d")) {
animation.Play("ROT_ESQ_VOLTA");
}
}
