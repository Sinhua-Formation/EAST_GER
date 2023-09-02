using System;
using UnityEngine;

// Token: 0x02000045 RID: 69
public class SpeedScript : MonoBehaviour
{
	// Token: 0x06000147 RID: 327 RVA: 0x001541B0 File Offset: 0x001523B0
	private void Awake()
	{
		this.global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
		this.goto_economy = GameObject.Find("Button (2)").GetComponent<EvetnnashScript>();
		this.map1 = GameObject.Find("MapChanges").GetComponent<MapChangesScript>();
		this.Repaint();
	}

	// Token: 0x06000148 RID: 328 RVA: 0x00154204 File Offset: 0x00152404
	public void Probel()
	{
		if (this.this_number == 0)
		{
			if (this.global1.speed != 0)
			{
				this.save_speed = this.global1.speed;
				this.global1.speed = 0;
			}
			else if (this.save_speed != 0 && (this.global1.data[8] >= 0 || this.global1.automat))
			{
				this.global1.speed = this.save_speed;
			}
			else if (this.global1.data[8] >= 0 || this.global1.automat)
			{
				this.global1.speed = 4;
			}
			this.Repaint();
			this.other[0].Repaint();
			this.other[1].Repaint();
			this.other[2].Repaint();
		}
	}

	// Token: 0x06000149 RID: 329 RVA: 0x001542D8 File Offset: 0x001524D8
	public void Repaint()
	{
		if (this.this_number == 0)
		{
			if (this.global1.speed != 0)
			{
				base.GetComponent<SpriteRenderer>().sprite = this.off;
				return;
			}
			base.GetComponent<SpriteRenderer>().sprite = this.on;
			return;
		}
		else
		{
			if (this.this_number <= this.global1.speed)
			{
				base.GetComponent<SpriteRenderer>().sprite = this.on;
				return;
			}
			base.GetComponent<SpriteRenderer>().sprite = this.off;
			return;
		}
	}

	// Token: 0x0600014A RID: 330 RVA: 0x00154354 File Offset: 0x00152554
	public void OnMouseDown()
	{
		if (!this.map1.okno.active && !this.minus && !this.plus)
		{
			if (this.this_number != 0 && (this.global1.data[8] >= 0 || this.global1.automat))
			{
				this.global1.speed = this.this_number;
				this.Repaint();
				this.other[0].Repaint();
				this.other[1].Repaint();
				this.other[2].Repaint();
				return;
			}
			if (this.this_number == 0 && this.global1.speed != 0)
			{
				this.save_speed = this.global1.speed;
				this.global1.speed = this.this_number;
				this.Repaint();
				this.other[0].Repaint();
				this.other[1].Repaint();
				this.other[2].Repaint();
				return;
			}
			if (this.this_number == 0 && this.global1.speed == 0 && (this.global1.data[8] >= 0 || this.global1.automat))
			{
				if (this.save_speed != 0)
				{
					this.global1.speed = this.save_speed;
				}
				else
				{
					this.global1.speed = 4;
				}
				this.Repaint();
				this.other[0].Repaint();
				this.other[1].Repaint();
				this.other[2].Repaint();
				return;
			}
			this.global1.speed = 0;
			this.goto_economy.OnMouseDown();
			return;
		}
		else
		{
			if (!this.map1.okno.active && this.minus)
			{
				this.global1.speed -= 10;
				return;
			}
			if (!this.map1.okno.active && this.plus && (this.global1.data[8] >= 0 || this.global1.automat))
			{
				this.global1.speed += 10;
			}
			return;
		}
	}

	// Token: 0x0600014B RID: 331 RVA: 0x00154570 File Offset: 0x00152770
	private void OnMouseEnter()
	{
		if (!this.map1.okno.active)
		{
			if (base.GetComponent<SpriteRenderer>().sprite == this.on)
			{
				base.GetComponent<SpriteRenderer>().sprite = this.off;
				return;
			}
			base.GetComponent<SpriteRenderer>().sprite = this.on;
		}
	}

	// Token: 0x0600014C RID: 332 RVA: 0x001545CA File Offset: 0x001527CA
	private void OnMouseExit()
	{
		if (!this.map1.okno.active)
		{
			this.Repaint();
		}
	}

	// Token: 0x04000205 RID: 517
	public Sprite on;

	// Token: 0x04000206 RID: 518
	public Sprite off;

	// Token: 0x04000207 RID: 519
	public int this_number;

	// Token: 0x04000208 RID: 520
	private GlobalScript global1;

	// Token: 0x04000209 RID: 521
	public SpeedScript[] other;

	// Token: 0x0400020A RID: 522
	private EvetnnashScript goto_economy;

	// Token: 0x0400020B RID: 523
	private int save_speed;

	// Token: 0x0400020C RID: 524
	public bool minus;

	// Token: 0x0400020D RID: 525
	public bool plus;

	// Token: 0x0400020E RID: 526
	private MapChangesScript map1;
}
