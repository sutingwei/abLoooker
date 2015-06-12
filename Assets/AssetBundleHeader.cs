using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Collections;

public class AssetBundleHeader
{
    public static string SignatureWeb = "UnityWeb";
    public static string SignatureRaw = "UnityRaw";

    // UnityWeb or UnityRaw
    private string signature;

    // file version
    // 3 in Unity 3.5 and 4
    // 2 in Unity 2.6 to 3.4
    // 1 in Unity 1 to 2.5
    private int streamVersion;

    // player version string
    // 2.x.x for Unity 2
    // 3.x.x for Unity 3/4
    private UnityVersion unityVersion;

    // engine version string
    private UnityVersion unityRevision;

    // minimum number of bytes to read for streamed bundles,
    // equal to completeFileSize for normal bundles
    private long minimumStreamedBytes;

    // offset to the bundle data or size of the bundle header
    private int headerSize;

    // equal to 1 if it's a streamed bundle, number of levelX + mainData assets
    // otherwise
    private int numberOfLevelsToDownload;

    // list of compressed and uncompressed offsets
    private List<KeyValuePair<long, long>> levelByteEnd = new List<KeyValuePair<long, long>>();
 
    // equal to file size, sometimes equal to uncompressed data size without the header
    private long completeFileSize;

    // offset to the first asset file within the data area, equals compressed
    // file size if completeFileSize contains the uncompressed data size
    private long dataHeaderSize;

    public void Read(BinaryReader br)
    {
        signature = br.ReadString();
    }
}
