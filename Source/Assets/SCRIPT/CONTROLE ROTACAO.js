#pragma strict


var RotPlayer:float;
var smooth = -1;
var tiltAngle = 500.0;

function Start () {

}

function Update () {

var tiltAroundZ = Input.GetAxis("Horizontal") * -tiltAngle;
var tiltAroundX = Input.GetAxis("Vertical") * -tiltAngle;
var target = Quaternion.Euler (tiltAroundX, 0, tiltAroundZ);

// Dampen towards the target rotation
transform.rotation = Quaternion.Slerp(transform.rotation, target,
	                 Time.deltaTime * smooth);
}