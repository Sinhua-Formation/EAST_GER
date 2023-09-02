using System;
using UnityEngine;

// Token: 0x0200005A RID: 90
public class TutorialButtonScript : MonoBehaviour
{
	// Token: 0x060001BE RID: 446 RVA: 0x0018C404 File Offset: 0x0018A604
	public void Show(bool a)
	{
		if (a)
		{
			base.GetComponent<SpriteRenderer>().sprite = this.sp;
		}
		else
		{
			base.GetComponent<SpriteRenderer>().sprite = null;
		}
		this.enabled = a;
	}

	// Token: 0x060001BF RID: 447 RVA: 0x0018C42F File Offset: 0x0018A62F
	private void OnMouseEnter()
	{
		if (this.enabled)
		{
			base.GetComponent<SpriteRenderer>().sprite = this.navel;
		}
	}

	// Token: 0x060001C0 RID: 448 RVA: 0x0018C44A File Offset: 0x0018A64A
	private void OnMouseExit()
	{
		if (this.enabled)
		{
			base.GetComponent<SpriteRenderer>().sprite = this.sp;
		}
	}

	// Token: 0x060001C1 RID: 449 RVA: 0x0018C465 File Offset: 0x0018A665
	private void OnMouseDown()
	{
		if (this.enabled)
		{
			this.total.OnDown(this.is_left);
		}
	}

	// Token: 0x04000288 RID: 648
	public new bool enabled;

	// Token: 0x04000289 RID: 649
	public bool is_left;

	// Token: 0x0400028A RID: 650
	public TutorialScript total;

	// Token: 0x0400028B RID: 651
	public Sprite sp;

	// Token: 0x0400028C RID: 652
	public Sprite navel;
}
