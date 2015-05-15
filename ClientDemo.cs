using ProtoBuf;
using UnityEngine;
using System.IO;
using System.Text;

public class ClientDemo : MonoBehaviour {
	private PlayerTable pb;
	// Use this for initialization
	void Start () {
		        pb = new PlayerTable ();
				NetClient.instance.Init ();
				NetClient.instance.onRecMsg = OnRecMsg;
				Person person = InitPerson ("lance", 123, "lance@gmail.com");
				NetClient.instance.SendMsg (1,serial (person));
		}
	
	// Update is called once per frame
	void Update () {

		NetClient.instance.ReceiveMsg ();
	}

	public PlayerTable GetPb()
	{
		return pb;
	}

	void OnRecMsg(byte[] msg)
	{
		using(MemoryStream ms = new MemoryStream()){
			ms.Write(msg,0,msg.Length);
			ms.Position = 0;
			Person person = Serializer.Deserialize<Person>(ms);
			pb.AddPlayer(person);
		}
	}

	private byte[] serial(Person person_)
	{
		Person person = person_;
		person.id = person_.id;
		person.name = person_.name;
		person.email = person_.email;
		
		using (MemoryStream ms = new MemoryStream())
		{
			Serializer.Serialize<Person>(ms, person);
			byte[] data = new byte[ms.Length];
			ms.Position= 0;
			ms.Read(data, 0, data.Length);
			return data;
		}
	}

	private Person InitPerson(string name_, int id_,string email_)
	{
		Person person = new Person ();
		person.name = name_;
		person.id = id_;
		person.email = email_;
		return person;
	}
}
