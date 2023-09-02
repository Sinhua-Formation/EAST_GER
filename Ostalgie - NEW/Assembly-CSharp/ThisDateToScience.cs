using System;
using UnityEngine;

// Token: 0x02000049 RID: 73
public class ThisDateToScience : MonoBehaviour
{
	// Token: 0x06000156 RID: 342 RVA: 0x00155970 File Offset: 0x00153B70
	private void Awake()
	{
		this.global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
		if (this.global1.data[21] < this.this_year)
		{
			base.GetComponent<OkoshkoScript>().text = "Стоимость возрастёт\nиз-за несоответствия времени:\n" + ((this.this_year - this.global1.data[21]) * 2).ToString() + " из бюджета";
			base.GetComponent<OkoshkoScript>().text_en = "The price will be raised\ndue to the year mismatch:\n" + ((this.this_year - this.global1.data[21]) * 2).ToString() + " from the budget";
			return;
		}
		base.GetComponent<OkoshkoScript>().text = "Стоимость:\n1 из бюджета";
		base.GetComponent<OkoshkoScript>().text_en = "The price:\n1 from the budget";
	}

	// Token: 0x04000217 RID: 535
	private GlobalScript global1;

	// Token: 0x04000218 RID: 536
	public int this_year = 1989;
}
