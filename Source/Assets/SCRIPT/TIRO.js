#pragma strict

var veltiro :float;


function Start () {

}

function Update () {

transform.Translate(-veltiro*Time.deltaTime,0,0);

	if(transform.position.z >=500){
	Destroy (gameObject);
	}
}

function OnTriggerEnter (other : Collider) {
   if(other.gameObject.tag == "METEORO"){
      DISPARADOR.PontosJogador += 10;
          
     
     //other.gameObject.transform.position.z=-5;
     //other.gameObject.transform.position.x = Random.Range(-5,5);
    // other.gameObject.transform.position.y = Random.Range(-.7,2);
     //Destroy(gameObject);
      }
}