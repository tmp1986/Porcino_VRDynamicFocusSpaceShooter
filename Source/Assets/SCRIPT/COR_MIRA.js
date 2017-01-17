#pragma strict


var on : Texture;
var off : Texture;


function Start () {
renderer.material.mainTexture = off;
}

function Update () {

}

function OnTriggerEnter (other : Collider) {
   if(other.gameObject.tag == "METEORO"){
   renderer.material.mainTexture = on;
  }
  }
  function OnTriggerExit (other : Collider) {
   if(other.gameObject.tag == "METEORO"){
   renderer.material.mainTexture = off;
  }
  }