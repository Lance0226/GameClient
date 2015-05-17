using ProtoBuf;
using System.Collections;
[ProtoContract]
public class player_transform {
	[ProtoMember(1)]  
	public string name;
	[ProtoMember(2)]  
	public int pos_x;
	[ProtoMember(3)]  
	public int pos_y;
	[ProtoMember(4)]  
	public int pos_z;
	[ProtoMember(5)]  
	public int rot_x;
	[ProtoMember(6)]  
	public int rot_y;
	[ProtoMember(7)]  
	public int rot_z;
}
