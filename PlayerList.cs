using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PlayerTable
{
	private List<Person> PlayerList;

	public PlayerTable()
	{
		PlayerList = new List<Person> ();
	}

	public void AddPlayer(Person person)
	{
		PlayerList.Add(person);
	}

	public Person GetPlayer(int index)
	{
		    try{
		    Person person = PlayerList [index];
			return person;
		    }
		    catch(Exception e)
		    {
			return null;
			}
	}
}
