#pragma strict

var RotX = 100;
var Roty = 80;
var Rotz = 60;

function Start () {

}

function Update () {
transform.Rotate (RotX*Time.deltaTime,Roty*Time.deltaTime,Rotz*Time.deltaTime);

}