using System;
using UnityEngine;

// Token: 0x02000028 RID: 40
public class liberalismscript : MonoBehaviour
{
	// Token: 0x060000BB RID: 187 RVA: 0x0005FEA0 File Offset: 0x0005E0A0
	private void Awake()
	{
		this.global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
		this.text.text = this.global1.data[this.this_num].ToString() + "/10";
		if (this.this_num == 38 && this.global1.data[0] >= 49 && this.global1.data[0] <= 51 && !this.global1.event_done[271] && !this.global1.event_done[322] && !this.global1.event_done[344])
		{
			this.Repaint2();
			return;
		}
		if (this.this_num == 39 && this.global1.data[0] >= 49 && this.global1.data[0] <= 51 && !this.global1.event_done[287])
		{
			this.Repaint2();
			return;
		}
		if ((this.this_num != 39 && this.this_num != 38) || (this.this_num == 38 && !this.right) || (this.this_num == 38 && (this.global1.data[0] != 12 || this.global1.event_done[228])))
		{
			this.Repaint();
			return;
		}
		if (this.this_num == 39)
		{
			this.Repaint1();
			return;
		}
		if (this.this_num == 38 && this.right)
		{
			this.Repaint2();
		}
	}

	// Token: 0x060000BC RID: 188 RVA: 0x00060028 File Offset: 0x0005E228
	private void OnMouseDown()
	{
		if (this.right && !this.global1.is_liber)
		{
			this.global1.data[this.this_num]++;
			if (this.global1.is_konst_max)
			{
				this.global1.data[8] -= 5;
				this.global1.data[1] += 10;
				this.global1.data[2] += 25;
				this.global1.data[22] -= 2;
				this.global1.data[10]--;
				this.global1.data[6] -= 8;
				this.global1.data[33] -= 2;
				this.global1.data[3] += 15;
				this.global1.data[4] += 5;
				if (this.global1.data[0] == 10)
				{
					this.global1.data[22] -= 2;
					this.global1.data[33] -= 2;
					this.global1.data[4] += 5;
				}
			}
			else
			{
				this.global1.data[8] -= 10;
				this.global1.data[1] += 10;
				this.global1.data[2] += 25;
				this.global1.data[22] -= 2;
				this.global1.data[10]--;
				this.global1.data[6] -= 8;
				this.global1.data[33] -= 2;
				this.global1.data[3] += 15;
				this.global1.data[4] += 20;
				if (this.global1.data[0] == 10)
				{
					this.global1.data[22] -= 2;
					this.global1.data[33] -= 2;
					this.global1.data[4] += 5;
				}
			}
			this.global1.is_liber = true;
			for (int i = 0; i < 8; i++)
			{
				GameObject.Find("Text (" + i + ")").GetComponent<Politic_Data_Show_Script>().Update_This();
			}
			this.text.text = this.global1.data[this.this_num].ToString() + "/10";
			this.Repaint();
			return;
		}
		if (!this.right && !this.global1.is_liber)
		{
			if (this.global1.is_konst_max)
			{
				this.global1.data[1] += 10;
				this.global1.data[2] -= 10;
				this.global1.data[8] -= 5;
				this.global1.data[1] += 15;
				this.global1.data[2] -= 10;
				this.global1.data[22] += 2;
				this.global1.data[6] += 4;
				this.global1.data[33] += 2;
				this.global1.data[3] -= 15;
				this.global1.data[4] += 5;
			}
			else
			{
				this.global1.data[1] += 10;
				this.global1.data[2] -= 10;
				this.global1.data[8] -= 10;
				this.global1.data[1] += 15;
				this.global1.data[2] -= 10;
				this.global1.data[22] += 2;
				this.global1.data[6] += 4;
				this.global1.data[33] += 2;
				this.global1.data[3] -= 30;
				this.global1.data[4] += 5;
			}
			this.global1.data[this.this_num]--;
			this.global1.is_liber = true;
			for (int j = 0; j < 8; j++)
			{
				GameObject.Find("Text (" + j + ")").GetComponent<Politic_Data_Show_Script>().Update_This();
			}
			this.text.text = this.global1.data[this.this_num].ToString() + "/10";
			this.Repaint();
		}
	}

	// Token: 0x060000BD RID: 189 RVA: 0x000605BE File Offset: 0x0005E7BE
	private void OnMouseEnter()
	{
		base.GetComponent<SpriteRenderer>().sprite = this.on;
	}

	// Token: 0x060000BE RID: 190 RVA: 0x000605D4 File Offset: 0x0005E7D4
	private void OnMouseExit()
	{
		if (!this.global1.is_liber && (this.global1.data[0] != 12 || this.this_num != 38 || this.global1.event_done[228]))
		{
			base.GetComponent<SpriteRenderer>().sprite = this.off;
		}
	}

	// Token: 0x060000BF RID: 191 RVA: 0x0006062D File Offset: 0x0005E82D
	private void Repaint()
	{
		if (this.global1.is_liber)
		{
			base.GetComponent<SpriteRenderer>().sprite = this.on;
			return;
		}
		base.GetComponent<SpriteRenderer>().sprite = this.off;
	}

	// Token: 0x060000C0 RID: 192 RVA: 0x00060660 File Offset: 0x0005E860
	private void Repaint1()
	{
		if ((this.global1.data[0] != 2 && this.global1.data[0] != 4) || (this.global1.data[113] == 0 && this.global1.data[0] == 2) || (this.global1.event_done[149] && this.global1.data[0] == 4))
		{
			this.Repaint();
			return;
		}
		UnityEngine.Object.Destroy(base.gameObject);
	}

	// Token: 0x060000C1 RID: 193 RVA: 0x000606E2 File Offset: 0x0005E8E2
	private void Repaint2()
	{
		UnityEngine.Object.Destroy(base.gameObject);
	}

	// Token: 0x04000152 RID: 338
	private GlobalScript global1;

	// Token: 0x04000153 RID: 339
	public Sprite on;

	// Token: 0x04000154 RID: 340
	public Sprite off;

	// Token: 0x04000155 RID: 341
	public TextMesh text;

	// Token: 0x04000156 RID: 342
	public int this_num;

	// Token: 0x04000157 RID: 343
	public bool right;
}
