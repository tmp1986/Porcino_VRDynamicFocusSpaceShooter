#pragma strict

var MovPlayer:float;


function Start () {

}

function Update () {

transform.Translate(Input.GetAxisRaw("Horizontal")*Time.deltaTime*MovPlayer,Input.GetAxisRaw("Vertical")*Time.deltaTime*MovPlayer,0);
transform.position.x = Mathf.Clamp(transform.position.x, -5, 5);
transform.position.y = Mathf.Clamp(transform.position.y, -.7, 1.8);


}