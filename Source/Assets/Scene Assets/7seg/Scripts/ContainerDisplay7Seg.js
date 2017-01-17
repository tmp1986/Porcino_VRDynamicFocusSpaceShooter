#pragma strict

class ContainerDisplay7Seg extends MonoBehaviour
{
	var text : String = "";
	var onColor : Color = Color.red;
	var offColor : Color = Color.black;
	
	private var displayArray : Array = new Array();

	function Start ()
	{
	
		for(var index:int = 0; index < transform.childCount; ++index)
		{			
			if(transform.GetChild(index).gameObject.name == "Display7Seg") displayArray.push(transform.GetChild(index).gameObject as GameObject);			
		}
	}

	function Update ()
	{
		var pointCounter : int = 0;
		
		for(var index:int = 0; index < text.length; ++index)
		{
			if(index - pointCounter< displayArray.Count)
			{
				var go = displayArray[index-pointCounter] as GameObject;
				go.GetComponent(Display7Seg).onColor = onColor;
				go.GetComponent(Display7Seg).offColor = offColor;
				go.GetComponent(Display7Seg).setChar(text[index]);
				
				
				if(index+1 < text.length)
				{
					if(text[index+1] == '.')
					{
						go.GetComponent(Display7Seg).setPointState(true);
						++pointCounter;
						++index;
					}
					else go.GetComponent(Display7Seg).setPointState(false);
				}
				else go.GetComponent(Display7Seg).setPointState(false);
				
			}
		}
		

	}

}