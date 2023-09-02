using System;
using UnityEngine;

// Token: 0x02000050 RID: 80
public class VoiceChangeScript : MonoBehaviour
{
	// Token: 0x0600017E RID: 382 RVA: 0x00185F82 File Offset: 0x00184182
	private void Awake()
	{
		this.global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
		this.Repaint();
	}

	// Token: 0x0600017F RID: 383 RVA: 0x00185F9F File Offset: 0x0018419F
	private void Repaint()
	{
		if (this.global1.bitss == this.i)
		{
			base.GetComponent<SpriteRenderer>().sprite = this.on;
		}
	}

	// Token: 0x06000180 RID: 384 RVA: 0x00185FC5 File Offset: 0x001841C5
	private void OnMouseEnter()
	{
		base.GetComponent<SpriteRenderer>().sprite = this.on;
	}

	// Token: 0x06000181 RID: 385 RVA: 0x00185FD8 File Offset: 0x001841D8
	private void OnMouseExit()
	{
		if (this.global1.bitss != this.i)
		{
			base.GetComponent<SpriteRenderer>().sprite = this.off;
		}
	}

	// Token: 0x06000182 RID: 386 RVA: 0x00185FFE File Offset: 0x001841FE
	private void OnMouseDown()
	{
		this.global1.bitss = this.i;
		this.global1.MusicReset();
		this.Repaint();
	}

	// Token: 0x0400024E RID: 590
	public Sprite on;

	// Token: 0x0400024F RID: 591
	public Sprite off;

	// Token: 0x04000250 RID: 592
	private GlobalScript global1;

	// Token: 0x04000251 RID: 593
	public int i;
}
