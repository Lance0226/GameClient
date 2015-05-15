using UnityEngine;
using System.Collections;
using System;

public class DisplayDemo : MonoBehaviour {

	
	public PlayerTable pTable;
	void Update () {
		try {
			pTable = GameObject.FindWithTag ("MainCamera").GetComponent<ClientDemo> ().GetPb ();
		} 
		catch (Exception e) 
		{
			Debug.Log("error");
		}
    }
	public string GetName(int index)
	{
	try{
		Person person=pTable.GetPlayer (index);
		return person.name;
		}
	catch(Exception e)
		{
			return null;		
		}
	}
}