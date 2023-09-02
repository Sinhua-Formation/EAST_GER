using System;
using UnityEngine;

// Token: 0x02000051 RID: 81
public class VoiceSciptr : MonoBehaviour
{
	// Token: 0x06000184 RID: 388 RVA: 0x00186022 File Offset: 0x00184222
	private void Awake()
	{
		this.text.text = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>().voice.ToString();
	}

	// Token: 0x06000185 RID: 389 RVA: 0x00186048 File Offset: 0x00184248
	private void OnMouseDown()
	{
		if (!this.is_right)
		{
			if (GameObject.Find("Global(Clone)").GetComponent<GlobalScript>().voice == 0)
			{
				GameObject.Find("Global(Clone)").GetComponent<GlobalScript>().voice = 100;
			}
			else if (this.ten)
			{
				if (GameObject.Find("Global(Clone)").GetComponent<GlobalScript>().voice >= 10)
				{
					GameObject.Find("Global(Clone)").GetComponent<GlobalScript>().voice -= 10;
				}
				else
				{
					GameObject.Find("Global(Clone)").GetComponent<GlobalScript>().voice = 0;
				}
			}
			else
			{
				GameObject.Find("Global(Clone)").GetComponent<GlobalScript>().voice--;
			}
		}
		else if (GameObject.Find("Global(Clone)").GetComponent<GlobalScript>().voice == 100)
		{
			GameObject.Find("Global(Clone)").GetComponent<GlobalScript>().voice = 0;
		}
		else if (this.ten)
		{
			if (GameObject.Find("Global(Clone)").GetComponent<GlobalScript>().voice <= 90)
			{
				GameObject.Find("Global(Clone)").GetComponent<GlobalScript>().voice += 10;
			}
			else
			{
				GameObject.Find("Global(Clone)").GetComponent<GlobalScript>().voice = 100;
			}
		}
		else
		{
			GameObject.Find("Global(Clone)").GetComponent<GlobalScript>().voice++;
		}
		this.text.text = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>().voice.ToString();
		PlayerPrefs.SetInt("voice_ost", GameObject.Find("Global(Clone)").GetComponent<GlobalScript>().voice);
	}

	// Token: 0x04000252 RID: 594
	public bool is_right;

	// Token: 0x04000253 RID: 595
	public TextMesh text;

	// Token: 0x04000254 RID: 596
	public bool ten;
}
