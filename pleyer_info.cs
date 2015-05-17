using ProtoBuf;
using System.Collections;
[ProtoContract]
public class player_info {
	[ProtoMember(1)]   
	public string name;
	[ProtoMember(2)]  
	public int id;
	[ProtoMember(3)]  
	public string email;
}
