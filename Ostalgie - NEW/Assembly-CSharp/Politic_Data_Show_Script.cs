using System;
using UnityEngine;

// Token: 0x02000038 RID: 56
public class Politic_Data_Show_Script : MonoBehaviour
{
	// Token: 0x0600010F RID: 271 RVA: 0x0006B0DC File Offset: 0x000692DC
	private void Awake()
	{
		this.global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
		this.Update_This();
	}

	// Token: 0x06000110 RID: 272 RVA: 0x0006B0FC File Offset: 0x000692FC
	public void Update_This()
	{
		base.GetComponent<TextMesh>().text = (((this.global1.data[this.num] < 0) ? "-" : "") + Mathf.Abs(this.global1.data[this.num] / 10)).ToString() + "." + Mathf.Abs(this.global1.data[this.num] % 10).ToString();
	}

	// Token: 0x040001B0 RID: 432
	private GlobalScript global1;

	// Token: 0x040001B1 RID: 433
	public int num;
}
