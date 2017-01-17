#pragma strict

var Rotx = 100;

function Start () {

}

function Update () {
transform.Rotate (-Rotx*Time.deltaTime,0,0);

}