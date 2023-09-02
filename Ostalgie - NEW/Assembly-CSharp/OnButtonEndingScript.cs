using System;
using UnityEngine;

// Token: 0x02000032 RID: 50
public class OnButtonEndingScript : MonoBehaviour
{
	// Token: 0x060000F2 RID: 242 RVA: 0x0006A0D8 File Offset: 0x000682D8
	private void OnMouseDown()
	{
		if (this.is_left)
		{
			if (this.global1.data[0] >= 49 && this.global1.data[0] <= 51 && this.end1.this_okno >= 0 && this.end1.this_okno <= 2)
			{
				if (this.end1.this_vrem > 0)
				{
					this.end1.this_vrem--;
				}
				else
				{
					this.end1.this_okno = -1;
				}
			}
			else if (this.global1.data[0] >= 49 && this.global1.data[0] <= 51 && this.end1.this_okno == 3)
			{
				this.end1.this_vrem = 11;
				this.end1.this_okno = 0;
			}
			else
			{
				this.end1.this_okno--;
				if (this.end1.this_okno == 2 && this.global1.data[0] == 12)
				{
					this.end1.this_okno--;
				}
			}
		}
		else if (this.global1.data[0] >= 49 && this.global1.data[0] <= 51 && this.end1.this_okno == 0)
		{
			if (this.end1.this_vrem < 11)
			{
				this.end1.this_vrem++;
			}
			else
			{
				this.end1.this_okno = 3;
			}
		}
		else
		{
			this.end1.this_okno++;
			if (this.end1.this_okno == 2 && this.global1.data[0] == 12)
			{
				this.end1.this_okno++;
			}
		}
		this.end1.ChangeOkno();
	}

	// Token: 0x060000F3 RID: 243 RVA: 0x0006A2B4 File Offset: 0x000684B4
	private void OnMouseEnter()
	{
		if (this.global1.data[46] == 0)
		{
			base.GetComponent<SpriteRenderer>().sprite = this.navel;
		}
	}

	// Token: 0x060000F4 RID: 244 RVA: 0x0006A2D7 File Offset: 0x000684D7
	private void OnMouseExit()
	{
		if (this.global1.data[46] == 0)
		{
			base.GetComponent<SpriteRenderer>().sprite = this.nenavel;
		}
	}

	// Token: 0x060000F5 RID: 245 RVA: 0x0006A2FA File Offset: 0x000684FA
	private void Awake()
	{
		this.global1 = this.end1.global1;
	}

	// Token: 0x04000196 RID: 406
	public ending_script end1;

	// Token: 0x04000197 RID: 407
	private GlobalScript global1;

	// Token: 0x04000198 RID: 408
	public bool is_left;

	// Token: 0x04000199 RID: 409
	public Sprite navel;

	// Token: 0x0400019A RID: 410
	public Sprite nenavel;
}
