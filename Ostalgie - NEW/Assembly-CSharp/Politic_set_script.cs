using System;
using UnityEngine;

// Token: 0x0200003B RID: 59
public class Politic_set_script : MonoBehaviour
{
	// Token: 0x06000116 RID: 278 RVA: 0x0006B410 File Offset: 0x00069610
	private void Awake()
	{
		this.global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
	}

	// Token: 0x06000117 RID: 279 RVA: 0x0006B428 File Offset: 0x00069628
	private void OnMouseDown()
	{
		if (this.global1.data[this.dolshnost] != this.candidat)
		{
			this.global1.data[this.dolshnost] = this.candidat;
			if (this.global1.is_konst_max)
			{
				this.global1.data[1] -= 50;
				this.global1.data[4] += 10;
				this.global1.data[8]--;
			}
			else
			{
				this.global1.data[1] -= 50;
				this.global1.data[4] += 25;
				this.global1.data[8] -= 10;
			}
			for (int i = 0; i < 8; i++)
			{
				GameObject.Find("Text (" + i + ")").GetComponent<Politic_Data_Show_Script>().Update_This();
			}
			GameObject.Find("politiRealise2").transform.Find("Erich1").GetComponent<Min_show_script>().Repaint();
			GameObject.Find("politiRealise2").transform.Find("Erich2").GetComponent<Min_show_script>().Repaint();
			GameObject.Find("politiRealise2").transform.Find("Erich3").GetComponent<Min_show_script>().Repaint();
		}
	}

	// Token: 0x040001B6 RID: 438
	public int dolshnost;

	// Token: 0x040001B7 RID: 439
	public int candidat;

	// Token: 0x040001B8 RID: 440
	private GlobalScript global1;
}
