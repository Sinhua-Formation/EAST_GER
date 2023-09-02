using System;
using UnityEngine;

// Token: 0x0200001E RID: 30
public class galovhka : MonoBehaviour
{
	// Token: 0x06000094 RID: 148 RVA: 0x0005AEB0 File Offset: 0x000590B0
	private void OnMouseDown()
	{
		if (this.this_num != this.Done1.this_otvet)
		{
			this.Done1.this_otvet = this.this_num;
			for (int i = 0; i < this.Done1.kolvo_variant; i++)
			{
				if (this.otveti[i] != null)
				{
					this.otveti[i].sprite = this.nenavel;
				}
			}
			base.GetComponent<SpriteRenderer>().sprite = this.navel;
		}
	}

	// Token: 0x06000095 RID: 149 RVA: 0x0005AF2B File Offset: 0x0005912B
	private void OnMouseEnter()
	{
		if (this.this_num != this.Done1.this_otvet)
		{
			base.GetComponent<SpriteRenderer>().sprite = this.navel;
		}
	}

	// Token: 0x06000096 RID: 150 RVA: 0x0005AF51 File Offset: 0x00059151
	private void OnMouseExit()
	{
		if (this.this_num != this.Done1.this_otvet)
		{
			base.GetComponent<SpriteRenderer>().sprite = this.nenavel;
		}
	}

	// Token: 0x040000D7 RID: 215
	public doneventscript Done1;

	// Token: 0x040000D8 RID: 216
	public Sprite navel;

	// Token: 0x040000D9 RID: 217
	public Sprite nenavel;

	// Token: 0x040000DA RID: 218
	public int this_num;

	// Token: 0x040000DB RID: 219
	public SpriteRenderer[] otveti = new SpriteRenderer[6];
}
