#pragma strict

function Start () {

light.range = 0;
}

function Update () {


if(Input.GetKeyDown("space")){
light.range = 2;
}
if(Input.GetKeyUp("space")){
light.range = 0;
}
}