using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayName : MonoBehaviour {
	private Vector3 m_worldPos;
	private Vector2 m_screenPos;
	private Vector2 m_labelPos;
	private string index;
	private string name;

	void Start () 
	{  
		switch(this.gameObject.name)
		{
		case  "player1"  : index="1";break;
		case  "player2"  : index="2";break;
		case  "player3"  : index="3";break;
		default :break;
		}
	}

	void Update () 
	{       
		       int i = int.Parse (index);
		        name=GameObject.FindWithTag("DB").GetComponent<DisplayDemo>().GetName(i-1);
				m_worldPos = this.transform.position;
				m_screenPos = Camera.main.WorldToScreenPoint (m_worldPos);
				m_labelPos.x = -Screen.width * 0.5f + m_screenPos.x+50.0f;
				m_labelPos.y = -Screen.height * 0.5f + m_screenPos.y+20.0f;
				GameObject.FindWithTag ("UI" + index).GetComponent<RectTransform> ().localPosition=new Vector3(m_labelPos.x,m_labelPos.y,0);
		        GameObject.FindWithTag ("UI" + index).GetComponent<Text> ().text = name;
	}
}