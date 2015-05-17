using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PlayerTable
{
	private List<player_info> PlayerList;

	public PlayerTable()
	{
		PlayerList = new List<player_info> ();
	}

	public void AddPlayer(player_info person)
	{
		PlayerList.Add(person);
	}

	public player_info GetPlayer(int index)
	{
		    try{
		    player_info person = PlayerList [index];
			return person;
		    }
		    catch(Exception e)
		    {
			return null;
			}
	}
}
