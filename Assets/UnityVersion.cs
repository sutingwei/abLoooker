using System;
using UnityEngine;
using System.Collections;

public class UnityVersion
{
    public byte Major { get; set; }
    public byte Minor { get; set; }
    public byte Patch { get; set; }
    public string Build { get; set; }
    public string Raw { get; set; }

    public UnityVersion(string version)
    {
        try
        {
            // version example: 4.6.2f1
            Major = ParseFromString(version.Substring(0, 1));
            Minor = ParseFromString(version.Substring(2, 1));
            Patch = ParseFromString(version.Substring(4, 1));
            Build = version.Substring(5);
        }
        catch (Exception ex)
        {
            // invalid format, save raw string
            Raw = version;
        }
    }

    public byte ParseFromString(string part)
    {
        return part.Equals("x") ? Convert.ToByte(-1) : Convert.ToByte(part);
    }

    public string ParseToString(byte part)
    {
        return part == -1 ? "x" : Convert.ToString(part);
    }

    public bool IsValid()
    {
        return string.IsNullOrEmpty(Raw);
    }

    public override string ToString()
    {
        if (!string.IsNullOrEmpty(Raw))
        {
            return Raw;
        }
        else
        {
            return string.Format("{0}.{1}.{2}{3}", ParseToString(Major), ParseToString(Minor), 
                ParseToString(Patch), Build);
        }
    }
}
