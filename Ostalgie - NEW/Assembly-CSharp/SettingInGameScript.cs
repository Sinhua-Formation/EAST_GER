using System;
using UnityEngine;

// Token: 0x02000041 RID: 65
public class SettingInGameScript : MonoBehaviour
{
	// Token: 0x06000139 RID: 313 RVA: 0x0015376D File Offset: 0x0015196D
	private void Awake()
	{
		this.global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
		if (!this.global1.turn_on)
		{
			this.Exit.GetComponent<LoadScript>().new_scene = "Diplomacy";
		}
	}

	// Token: 0x040001EB RID: 491
	private GlobalScript global1;

	// Token: 0x040001EC RID: 492
	public GameObject Exit;
}
