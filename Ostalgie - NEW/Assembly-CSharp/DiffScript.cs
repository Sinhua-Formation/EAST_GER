using System;
using UnityEngine;

// Token: 0x02000013 RID: 19
public class DiffScript : MonoBehaviour
{
	// Token: 0x06000057 RID: 87 RVA: 0x0000F290 File Offset: 0x0000D490
	private void OnMouseDown()
	{
		if (this.number != 3)
		{
			this.is_checked = !this.is_checked;
			this.game1.diff[this.number] = this.is_checked;
			this.game1.Repaint();
			if (this.is_checked)
			{
				base.GetComponent<SpriteRenderer>().sprite = this.on;
				return;
			}
			base.GetComponent<SpriteRenderer>().sprite = this.off;
			return;
		}
		else
		{
			this.is_checked = !this.is_checked;
			this.game1.sanbox = !this.game1.sanbox;
			this.game1.Repaint();
			if (this.is_checked)
			{
				base.GetComponent<SpriteRenderer>().sprite = this.on;
				return;
			}
			base.GetComponent<SpriteRenderer>().sprite = this.off;
			return;
		}
	}

	// Token: 0x04000074 RID: 116
	public GameStartScript game1;

	// Token: 0x04000075 RID: 117
	private bool is_checked;

	// Token: 0x04000076 RID: 118
	public Sprite off;

	// Token: 0x04000077 RID: 119
	public Sprite on;

	// Token: 0x04000078 RID: 120
	public int number;
}
