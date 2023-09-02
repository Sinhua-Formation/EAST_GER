using System;
using UnityEngine;

// Token: 0x0200001A RID: 26
public class EnterScript : MonoBehaviour
{
	// Token: 0x0600007F RID: 127 RVA: 0x00058783 File Offset: 0x00056983
	private void OnMouseEnter()
	{
		base.GetComponent<SpriteRenderer>().sprite = this.on;
	}

	// Token: 0x06000080 RID: 128 RVA: 0x00058796 File Offset: 0x00056996
	private void OnMouseExit()
	{
		base.GetComponent<SpriteRenderer>().sprite = this.off;
	}

	// Token: 0x040000C4 RID: 196
	public Sprite on;

	// Token: 0x040000C5 RID: 197
	public Sprite off;
}
