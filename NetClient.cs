using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class NetClient
{
	public static NetClient instance = new NetClient();
	private TcpClient client;
	private bool isHead;
	private int len;
	
	/// <summary>
	/// 初始化网络连接
	/// </summary>
	public void Init()
	{
		try
		{
		client = new TcpClient();
		client.Connect("127.0.0.1", 8888);
		isHead = true;
		}
		catch(Exception e)
		{
			Debug.Log(e);
		}
	}
	
	/// <summary>
	/// 发送消息
	/// </summary>
	public void SendMsg(int msg_code,byte[] msg)
	{
		try{
		byte[] data = new byte[8 + msg.Length];
		IntToBytes(msg_code).CopyTo(data,0);
		IntToBytes(msg.Length).CopyTo(data, 4);
		msg.CopyTo(data, 8);
		client.GetStream().Write(data, 0, data.Length);
		}
		catch(Exception e)
		{
			Debug.Log(e);		
		}
	}
	
	/// <summary>
	/// 接收消息
	/// </summary>
	public void ReceiveMsg()
	{
	try{
		NetworkStream stream = client.GetStream ();
		if (!stream.CanRead)
		{
			return;
		}
		//读取消息体的长度
		if (isHead)
		{
			if (client.Available < 4)
			{
				return;
			}
			byte[] lenByte = new byte[4];
			stream.Read(lenByte, 0, 4);
			len = BytesToInt(lenByte, 0);
			isHead = false;
		}
		//读取消息体内容
		if (!isHead)
		{
			if (client.Available < len)
			{
				return;
			}
			byte[] msgByte = new byte[len];
			stream.Read(msgByte, 0, len);
			isHead = true;
			len = 0;
			if (onRecMsg != null)
			{
				//处理消息
				onRecMsg(msgByte);
			}
		 }
		}
	 catch(Exception e)
		{
			Debug.Log(e);	
		}
		
	}
	
	/// <summary>
	/// bytes转int
	/// </summary>
	public static int BytesToInt(byte[] data, int offset)
	{
		int num = 0;
		for (int i = offset; i < offset + 4; i++)
		{
			num <<= 8;
			num |= (data[i] & 0xff);
		}
		return num;
	}
	
	/// <summary>
	/// int 转 bytes
	/// </summary>
	/// <param name="num"></param>
	/// <returns></returns>
	public static byte[] IntToBytes(int num)
	{
		byte[] bytes = new byte[4];
		for (int i = 0; i < 4; i++)
		{
			bytes[i] = (byte)(num >> (24 - i * 8));
		}
		return bytes;
	}
	
	public delegate void OnRevMsg(byte[] msg);
	
	public OnRevMsg onRecMsg;
}
