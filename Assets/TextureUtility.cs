using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TextureUtility : MonoBehaviour
{
	public Texture3D tex;
	public int TexSize = 32;
	public Material Mat;
	// Use this for initialization
	void Start()
	{
		if (TexSize < 8)
		{
			TexSize = 8;
		}
		else if (TexSize > 64)
		{
			TexSize = 64;
		}
		//生成噪点
		Color[] ColorPool = new Color[TexSize * TexSize * TexSize];
		for (int i = 0; i < ColorPool.Length; i++)
		{
			ColorPool[i] = getColor;
		}
		//生成贴图并赋值到材质
		tex = new Texture3D(TexSize, TexSize, TexSize, TextureFormat.ARGB32, true);
		tex.SetPixels(ColorPool);
		tex.Apply();
		Mat.SetTexture("_NoisTex", tex);
	}
	//只获取纯黑和接近纯白的浅灰色
	Color getColor
	{
		get
		{
			float c = Random.Range(-1f, 1f);
			if (c >= 0)
			{
				c = 0;
			}
			else
			{
				c = 0.95f;
			}
			return new Color(c, c, c, c);
		}
	}
}

