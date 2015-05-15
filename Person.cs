using ProtoBuf;
using System.Collections;
[ProtoContract]
public class Person {
	[ProtoMember(1)]   //message id
	public string name;
	[ProtoMember(2)]  //number of argument in message
	public int id;
	[ProtoMember(3)]  // argument id
	public string email;
}
