using System;
using UnityEngine;

// Token: 0x0200003C RID: 60
public class RegionChangeScript : MonoBehaviour
{
	// Token: 0x06000119 RID: 281 RVA: 0x0006B59B File Offset: 0x0006979B
	public void Repaint()
	{
		if (this.bl1.now_region == this.this_number)
		{
			base.GetComponent<SpriteRenderer>().sprite = this.on;
			return;
		}
		base.GetComponent<SpriteRenderer>().sprite = this.off;
	}

	// Token: 0x0600011A RID: 282 RVA: 0x0006B5D4 File Offset: 0x000697D4
	private void Awake()
	{
		this.global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
		if (this.bl1.now_region == this.this_number)
		{
			this.Regione.text = this.Regiont.text;
		}
		if (this.global1.data[0] == 49 || this.global1.data[0] == 50 || this.global1.data[0] == 51)
		{
			this.yug1 = GameObject.Find("Yugoglobal(Clone)").GetComponent<Yugoglobal>();
		}
	}

	// Token: 0x0600011B RID: 283 RVA: 0x0006B668 File Offset: 0x00069868
	private void OnMouseEnter()
	{
		if (this.global1.data[0] != 12 || this.this_number == 2 || (this.this_number == 0 && this.global1.data[93] == 1) || (this.this_number == 1 && this.global1.data[92] == 1) || (this.this_number == 3 && this.global1.data[90] == 1) || (this.this_number == 4 && this.global1.data[94] == 1))
		{
			base.GetComponent<SpriteRenderer>().sprite = this.on;
			return;
		}
		base.GetComponent<SpriteRenderer>().sprite = this.off;
	}

	// Token: 0x0600011C RID: 284 RVA: 0x0006B71C File Offset: 0x0006991C
	private void OnMouseExit()
	{
		if (this.global1.data[0] != 12)
		{
			this.Repaint();
			return;
		}
		if (this.this_number == 2 || (this.this_number == 0 && this.global1.data[93] == 1) || (this.this_number == 1 && this.global1.data[92] == 1) || (this.this_number == 3 && this.global1.data[90] == 1) || (this.this_number == 4 && this.global1.data[94] == 1))
		{
			this.Repaint();
			return;
		}
		base.GetComponent<SpriteRenderer>().sprite = this.off;
	}

	// Token: 0x0600011D RID: 285 RVA: 0x0006B7CC File Offset: 0x000699CC
	private void OnMouseDown()
	{
		if (this.global1.data[0] == 49 || this.global1.data[0] == 50 || this.global1.data[0] == 51)
		{
			this.bl1.yugreg[0] = -1;
			this.bl1.yugreg[1] = -1;
			this.bl1.yugreg[2] = -1;
			this.bl1.yugown[0] = false;
			this.bl1.yugown[1] = false;
			this.bl1.yugown[2] = false;
			for (int i = 0; i < this.yug1.gameState.yugregions.Length; i++)
			{
				if (this.yug1.gameState.yugregions[i].inreg == this.this_number)
				{
					if (this.bl1.yugreg[0] == -1)
					{
						this.bl1.yugreg[0] = i;
						if (this.yug1.gameState.yugcountries[this.yug1.gameState.yugregions[i].owner].is_player)
						{
							this.bl1.yugown[0] = true;
						}
					}
					else if (this.bl1.yugreg[1] == -1)
					{
						this.bl1.yugreg[1] = i;
						if (this.yug1.gameState.yugcountries[this.yug1.gameState.yugregions[i].owner].is_player)
						{
							this.bl1.yugown[1] = true;
						}
					}
					else if (this.bl1.yugreg[2] == -1)
					{
						this.bl1.yugreg[2] = i;
						if (this.yug1.gameState.yugcountries[this.yug1.gameState.yugregions[i].owner].is_player)
						{
							this.bl1.yugown[2] = true;
						}
					}
				}
			}
		}
		if (this.global1.data[0] != 12 || this.this_number == 2 || (this.this_number == 0 && this.global1.data[93] == 1) || (this.this_number == 1 && this.global1.data[92] == 1) || (this.this_number == 3 && this.global1.data[90] == 1) || (this.this_number == 4 && this.global1.data[94] == 1))
		{
			this.bl1.now_region = this.this_number;
			this.bl1.HideSelects();
			this.bl1.Repaint();
			this.Vyzov.text = "";
			this.Regione.text = this.Regiont.text;
		}
	}

	// Token: 0x040001B9 RID: 441
	public int this_number;

	// Token: 0x040001BA RID: 442
	public BuildingManager bl1;

	// Token: 0x040001BB RID: 443
	public GlobalScript global1;

	// Token: 0x040001BC RID: 444
	public TextMesh Vyzov;

	// Token: 0x040001BD RID: 445
	public TextMesh Regiont;

	// Token: 0x040001BE RID: 446
	public TextMesh Regione;

	// Token: 0x040001BF RID: 447
	public Sprite on;

	// Token: 0x040001C0 RID: 448
	public Sprite off;

	// Token: 0x040001C1 RID: 449
	private Yugoglobal yug1;
}
