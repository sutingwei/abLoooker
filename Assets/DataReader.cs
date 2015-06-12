using System;
using UnityEngine;
using System.Collections;

public class DataReader 
{
    public DataReader(byte[] data)
    {
        Data = data;
        Position = 0;
        Length = data != null ? data.Length : 0;
    }

    public int Length { get; private set; }

    public int Position { get; private set; }

    public byte[] Data { get; private set; }

    public int ReadInt()
    {
        int oldPos = Position;
        Position += 4;
        return BitConverter.ToInt32(Data, oldPos);
    }

    public uint ReadUnsignedInt()
    {
        int oldPos = Position;
        Position += 4;
        return BitConverter.ToUInt32(Data, oldPos);
    }

    public string ReadStringNull()
    {
        int startPos = Position;
        while (Data[Position] != 0)
        {
            Position += 1;
        }
        return System.Text.Encoding.UTF8.GetString(Data, startPos, Position - startPos);
    }
}
