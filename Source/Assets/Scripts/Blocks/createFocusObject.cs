#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.Collections;
[ExecuteInEditMode]

public class createFocusObject: MonoBehaviour 
{


		static string path = "Assets/Scripts/Blocks/";

		// Add a new menu item with hotkey CTRL-SHIFT-A

		[MenuItem("Auto Focus DOF/Create Focus GameObject %#a")]
		private static void NewMenuOption()
		{

			if (GameObject.Find ("OBJECTS") == null) 
			{
				print ("0");
				Object prefabobj = AssetDatabase.LoadAssetAtPath (path+"OBJECTS.prefab", typeof(GameObject));
				GameObject cloneobj = Instantiate (prefabobj, Vector3.zero, Quaternion.identity) as GameObject;
				cloneobj.name = "OBJECTS";
				cloneobj.transform.position = new Vector3(0,0,0);

				print ("Created OBJECTS");
				Object prefab1 = AssetDatabase.LoadAssetAtPath (path+"FPoint.prefab", typeof(GameObject));
				GameObject clone1 = Instantiate (prefab1, Vector3.zero, Quaternion.identity) as GameObject;
				clone1.transform.parent = GameObject.Find ("OBJECTS").transform;
				clone1.transform.position = new Vector3 (0, 0, 0);
				clone1.name = clone1.name + clone1.GetInstanceID ().ToString ();
			} 
			else 
			{
				Object prefab = AssetDatabase.LoadAssetAtPath (path+"FPoint.prefab", typeof(GameObject));
				GameObject clone = Instantiate (prefab, Vector3.zero, Quaternion.identity) as GameObject;
				clone.transform.parent = GameObject.Find ("OBJECTS").transform;
				clone.transform.position = new Vector3 (0, 0, 0);
				clone.name = clone.name + clone.GetInstanceID ().ToString ();
			}

		}

		// Add a new menu item with hotkey CTRL-G

		[MenuItem("Auto Focus DOF/Item %g")]
		private static void NewNestedOption()
		{
		}

		// Add a new menu item with hotkey G
		[MenuItem("Auto Focus DOF/Item2 _g")]
		private static void NewOptionWithHotkey()
		{
		}

}
#endif