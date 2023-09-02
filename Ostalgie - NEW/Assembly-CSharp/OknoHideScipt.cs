using System;
using UnityEngine;

// Token: 0x02000030 RID: 48
public class OknoHideScipt : MonoBehaviour
{
	// Token: 0x060000EA RID: 234 RVA: 0x00069F40 File Offset: 0x00068140
	private void OnMouseEnter()
	{
		base.GetComponent<SpriteRenderer>().sprite = this.on;
	}

	// Token: 0x060000EB RID: 235 RVA: 0x00069F53 File Offset: 0x00068153
	private void OnMouseExit()
	{
		base.GetComponent<SpriteRenderer>().sprite = this.off;
	}

	// Token: 0x060000EC RID: 236 RVA: 0x00069F66 File Offset: 0x00068166
	private void OnMouseDown()
	{
		this.map1.ShowHideOcno(false);
		base.GetComponent<SpriteRenderer>().sprite = this.off;
	}

	// Token: 0x0400018D RID: 397
	public Sprite on;

	// Token: 0x0400018E RID: 398
	public Sprite off;

	// Token: 0x0400018F RID: 399
	public MapChangesScript map1;
}
