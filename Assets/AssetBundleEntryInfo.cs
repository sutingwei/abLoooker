using UnityEngine;
using System.Collections;

public class AssetBundleEntryInfo
{
    public string Name { set; get; }
    public long Offset { set; get; }

    public long Size { set; get; }

    public AssetBundleEntryInfo(string name, long offset, long size)
    {
        Name = name;
        Offset = offset;
        Size = size;
    }
}
