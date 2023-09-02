using System;
using UnityEngine;

// Token: 0x02000037 RID: 55
public class Politic_Data_Show_cel : MonoBehaviour
{
	// Token: 0x0600010C RID: 268 RVA: 0x0006B097 File Offset: 0x00069297
	private void Awake()
	{
		this.global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
		this.Update_This();
	}

	// Token: 0x0600010D RID: 269 RVA: 0x0006B0B4 File Offset: 0x000692B4
	private void Update_This()
	{
		base.GetComponent<TextMesh>().text = this.global1.data[this.num].ToString();
	}

	// Token: 0x040001AE RID: 430
	private GlobalScript global1;

	// Token: 0x040001AF RID: 431
	public int num;
}
