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
				//player_info person = init_player_info("lance", 123, "lance@gmail.com");
		        player_transform pt = init_player_transfrom ("lance",1,2,3,4,5,6);
				NetClient.instance.SendMsg (2,serial (pt));
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
			player_info person = Serializer.Deserialize<player_info>(ms);
			pb.AddPlayer(person);
		}
	}

	private byte[] serial<T>(T t)
	{
		using (MemoryStream ms = new MemoryStream())
		{
			Serializer.Serialize<T>(ms, t);
			byte[] data = new byte[ms.Length];
			ms.Position= 0;
			ms.Read(data, 0, data.Length);
			return data;
		}
	}

	private player_info init_player_info(string name_, int id_,string email_)
	{
		player_info person = new player_info ();
		person.name = name_;
		person.id = id_;
		person.email = email_;
		return person;
	}

	private player_transform init_player_transfrom(string name_,int posx_,int posy_,int posz_,int rotx_,int roty_,int rotz_)
	{
		player_transform ts = new player_transform ();
		ts.name = name_;
		ts.pos_x = posx_;
		ts.pos_y = posy_;
		ts.pos_z = posz_;
		ts.rot_x = rotx_;
		ts.rot_y = roty_;
		ts.rot_z = rotz_;
		return ts;
	}
}
