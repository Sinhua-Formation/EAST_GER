using System;
using UnityEngine;

// Token: 0x02000033 RID: 51
public class Party_ally_script : MonoBehaviour
{
	// Token: 0x060000F7 RID: 247 RVA: 0x0006A30D File Offset: 0x0006850D
	private void Awake()
	{
		this.global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
		this.Repaint();
	}

	// Token: 0x060000F8 RID: 248 RVA: 0x0006A32A File Offset: 0x0006852A
	public void Repaint()
	{
		if (this.global1.is_party_ally[this.this_number])
		{
			base.GetComponent<SpriteRenderer>().sprite = this.on;
			return;
		}
		base.GetComponent<SpriteRenderer>().sprite = this.off;
	}

	// Token: 0x060000F9 RID: 249 RVA: 0x0006A364 File Offset: 0x00068564
	private void OnMouseDown()
	{
		if (!this.global1.is_party_ally[this.this_number] && this.global1.data[9] >= 30 && this.global1.is_party_enabled[this.this_number] && ((this.global1.party_ideology[this.this_number] == 10 && this.global1.data[18] <= 18) || (this.global1.party_ideology[this.this_number] == 1 && this.global1.data[18] >= 21 && this.global1.data[18] <= 22) || (this.global1.party_ideology[this.this_number] == 2 && this.global1.data[18] >= 22) || (this.global1.party_ideology[this.this_number] == 3 && (this.global1.data[18] <= 18 || this.global1.data[18] >= 23))))
		{
			this.global1.is_party_ally[this.this_number] = true;
			if (this.global1.party_number[this.this_number] > 50)
			{
				this.global1.data[1] -= this.global1.party_number[this.this_number] / 3 * 5;
				this.global1.data[3] -= 50;
				this.global1.data[6] -= 10;
				this.global1.data[8] -= this.global1.party_number[this.this_number] / 5;
				this.global1.data[9] -= this.global1.party_number[this.this_number] / 2;
				this.global1.data[4] -= this.global1.party_number[this.this_number] / 5;
			}
			else
			{
				this.global1.data[1] -= 100;
				this.global1.data[3] -= 50;
				this.global1.data[6] -= 10;
				this.global1.data[8] -= 10;
				this.global1.data[9] -= 30;
				this.global1.data[4] -= 10;
			}
			for (int i = 0; i < 8; i++)
			{
				GameObject.Find("Text (" + i + ")").GetComponent<Politic_Data_Show_Script>().Update_This();
			}
			this.Repaint();
		}
	}

	// Token: 0x060000FA RID: 250 RVA: 0x0006A648 File Offset: 0x00068848
	private void OnMouseEnter()
	{
		if (!this.global1.is_party_ally[this.this_number] && this.global1.data[9] >= 30 && this.global1.is_party_enabled[this.this_number] && ((this.global1.party_ideology[this.this_number] == 10 && this.global1.data[18] <= 18) || (this.global1.party_ideology[this.this_number] == 1 && this.global1.data[18] >= 21 && this.global1.data[18] <= 22) || (this.global1.party_ideology[this.this_number] == 2 && this.global1.data[18] >= 22) || (this.global1.party_ideology[this.this_number] == 3 && (this.global1.data[18] <= 18 || this.global1.data[18] >= 23))))
		{
			base.GetComponent<SpriteRenderer>().sprite = this.on;
		}
	}

	// Token: 0x060000FB RID: 251 RVA: 0x0006A76D File Offset: 0x0006896D
	private void OnMouseExit()
	{
		if (!this.global1.is_party_ally[this.this_number])
		{
			base.GetComponent<SpriteRenderer>().sprite = this.off;
		}
	}

	// Token: 0x0400019B RID: 411
	private GlobalScript global1;

	// Token: 0x0400019C RID: 412
	public int this_number;

	// Token: 0x0400019D RID: 413
	public Sprite on;

	// Token: 0x0400019E RID: 414
	public Sprite off;
}
