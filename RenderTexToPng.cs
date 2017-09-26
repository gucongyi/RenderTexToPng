using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class RenderTexToPng : MonoBehaviour {
    [MenuItem("AssetDatabase/RenderTexturToPng")]
    static void RenderTexturToPng()
    {
        RenderTexture RT = (RenderTexture)AssetDatabase.LoadAssetAtPath("Assets/DrawCircle/RenderTexture.renderTexture", typeof(RenderTexture));
        Debug.Log(RT);
        if (RT != null)
        {
            Texture2D png = new Texture2D(RT.width, RT.height, TextureFormat.ARGB32, false);
            RenderTexture.active = RT;//要设置这个，否则没法转换。
            png.ReadPixels(new Rect(0, 0, RT.width, RT.height), 0, 0);
            png.Apply();
            byte[] bytes = png.EncodeToPNG();
            string path = "Assets/DrawCircle/miniMap.png";
            FileStream file = File.Open(path, FileMode.Create);
            BinaryWriter writer = new BinaryWriter(file);
            writer.Write(bytes);
            file.Close();
        }
    }
}
