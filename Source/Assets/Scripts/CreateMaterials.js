/*
@script ExecuteInEditMode()
function Start()
{
	var i: int = 0;
	for (i = 1; i<73; i++) 
	{
		 var material = new Material (Shader.Find("Mobile/Depth of Field/Normal (Surface)"));
		 AssetDatabase.CreateAsset(material, "Assets/Cubes_Materials/" + i.ToString() + ".mat");
		 
		 var gradiente: float  = 255/73;
		 
		 var cor = Color32(Random.Range(25,255),Random.Range(50,255), Random.Range(50,255),1);
		 
		 
		 material.SetColor("_Color",cor);
		 
		 GameObject.Find(i.ToString()).renderer.material = material;
		
	}
}
*/