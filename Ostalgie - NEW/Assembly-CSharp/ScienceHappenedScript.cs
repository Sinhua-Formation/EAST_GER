using System;
using UnityEngine;

// Token: 0x0200003F RID: 63
public class ScienceHappenedScript : MonoBehaviour
{
	// Token: 0x06000131 RID: 305 RVA: 0x001510B2 File Offset: 0x0014F2B2
	public void IsHappened()
	{
		base.GetComponent<SpriteRenderer>().sprite = this.science[this.this_num];
	}

	// Token: 0x040001D9 RID: 473
	public Sprite[] science = new Sprite[22];

	// Token: 0x040001DA RID: 474
	public int this_num = -1;
}
