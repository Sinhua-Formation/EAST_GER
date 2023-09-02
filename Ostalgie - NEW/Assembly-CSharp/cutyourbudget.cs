using System;
using UnityEngine;

// Token: 0x02000012 RID: 18
public class cutyourbudget : MonoBehaviour
{
	// Token: 0x06000052 RID: 82 RVA: 0x0000F0B8 File Offset: 0x0000D2B8
	private void Awake()
	{
		this.global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
		if (this.auto)
		{
			if (this.global1.automat)
			{
				base.GetComponent<SpriteRenderer>().sprite = this.on;
				return;
			}
			base.GetComponent<SpriteRenderer>().sprite = this.off;
		}
	}

	// Token: 0x06000053 RID: 83 RVA: 0x0000F114 File Offset: 0x0000D314
	private void OnMouseDown()
	{
		if (this.auto)
		{
			this.global1.automat = !this.global1.automat;
			return;
		}
		if (this.global1.data[8] < 0)
		{
			this.global1.data[1] += this.global1.data[8] * 10;
			this.global1.data[3] += this.global1.data[8] * 10;
			this.global1.data[5] += this.global1.data[8] * 5;
			this.global1.data[8] = 1;
		}
	}

	// Token: 0x06000054 RID: 84 RVA: 0x0000F1D0 File Offset: 0x0000D3D0
	private void OnMouseExit()
	{
		if (!this.auto)
		{
			base.GetComponent<SpriteRenderer>().sprite = this.off;
			return;
		}
		if (this.global1.automat)
		{
			base.GetComponent<SpriteRenderer>().sprite = this.on;
			return;
		}
		base.GetComponent<SpriteRenderer>().sprite = this.off;
	}

	// Token: 0x06000055 RID: 85 RVA: 0x0000F228 File Offset: 0x0000D428
	private void OnMouseEnter()
	{
		if (!this.auto)
		{
			if (this.global1.data[8] < 0)
			{
				base.GetComponent<SpriteRenderer>().sprite = this.on;
			}
			return;
		}
		if (this.global1.automat)
		{
			base.GetComponent<SpriteRenderer>().sprite = this.off;
			return;
		}
		base.GetComponent<SpriteRenderer>().sprite = this.on;
	}

	// Token: 0x04000070 RID: 112
	public Sprite on;

	// Token: 0x04000071 RID: 113
	public Sprite off;

	// Token: 0x04000072 RID: 114
	private GlobalScript global1;

	// Token: 0x04000073 RID: 115
	public bool auto;
}
