using System;
using UnityEngine;

// Token: 0x02000058 RID: 88
public class YugoMapButtons : MonoBehaviour, IButton
{
	// Token: 0x060001AC RID: 428 RVA: 0x001895BF File Offset: 0x001877BF
	void IButton.OnButtonDown()
	{
		this.OnMouseDown();
	}

	// Token: 0x060001AD RID: 429 RVA: 0x001895C7 File Offset: 0x001877C7
	void IButton.OnButtonEnter()
	{
		this.OnMouseEnter();
	}

	// Token: 0x060001AE RID: 430 RVA: 0x001895CF File Offset: 0x001877CF
	void IButton.OnButtonExit()
	{
		this.OnMouseExit();
	}

	// Token: 0x060001AF RID: 431 RVA: 0x001895D7 File Offset: 0x001877D7
	void IButton.OnButtonStay()
	{
		this.OnMouseOver();
	}

	// Token: 0x060001B0 RID: 432 RVA: 0x001895DF File Offset: 0x001877DF
	private void OnMouseDown()
	{
		((IButtonPressReceiver)this.controller).OnButtonDown(this.num);
	}

	// Token: 0x060001B1 RID: 433 RVA: 0x001895F7 File Offset: 0x001877F7
	private void OnMouseEnter()
	{
		((IButtonPressReceiver)this.controller).OnButtonEnter(this.num, base.GetComponent<SpriteRenderer>());
	}

	// Token: 0x060001B2 RID: 434 RVA: 0x00189615 File Offset: 0x00187815
	private void OnMouseExit()
	{
		((IButtonPressReceiver)this.controller).OnButtonExit(this.num, base.GetComponent<SpriteRenderer>());
	}

	// Token: 0x060001B3 RID: 435 RVA: 0x00189633 File Offset: 0x00187833
	private void OnMouseOver()
	{
		((IButtonPressReceiver)this.controller).OnButtonStay(this.num);
	}

	// Token: 0x0400027C RID: 636
	public MonoBehaviour controller;

	// Token: 0x0400027D RID: 637
	public int num;
}
