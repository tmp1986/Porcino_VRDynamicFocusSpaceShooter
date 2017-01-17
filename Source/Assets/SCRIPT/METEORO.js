#pragma strict
var velMeteoroz : float;
var EXPLOSAO_FINAL : AudioClip;

var ZPosition: int;
var RangeX: int;
var RangeY: int;

var RangeVelMin: float;
var RangeVelMax: float;
function Start () {
//transform.position.z = -5;
}

function Update () {

var vel = Random.Range(RangeVelMin,RangeVelMax);
transform.Translate(0,0,-vel*Time.deltaTime);

if(transform.position.z <= -50){
transform.position.z = ZPosition;
transform.position.x=Random.Range(-RangeX, RangeX);
transform.position.y=Random.Range(-RangeY, RangeY);
}
}
function OnTriggerEnter (other : Collider) {
   
   //print (other.gameObject.tag);
   if(other.gameObject.tag == "tiro")
   {
   audio.PlayOneShot(EXPLOSAO_FINAL, 1);
   
   
   
    var hingeJoints: Component[];

		hingeJoints = GetComponentsInChildren.<ParticleSystem>();
		this.gameObject.GetComponent.<MeshRenderer>().enabled = false;
		this.gameObject.transform.GetChild(0).active = true;
		this.gameObject.transform.GetChild(1).active = true;
		for (var joint: ParticleSystem in hingeJoints)
		{
			//joint.enableEmission = true;
			joint.Play();
			
		}	
	//gameObject.GetComponent.<MeshRenderer>().active = false;
	yield WaitForSeconds (1);
	
	
    Destroy (gameObject);   
   	}
   	
   	
}