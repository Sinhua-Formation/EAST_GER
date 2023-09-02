using System;
using UnityEngine;

// Token: 0x02000036 RID: 54
public class PlayOnTouch : MonoBehaviour
{
	// Token: 0x06000108 RID: 264 RVA: 0x0006AF60 File Offset: 0x00069160
	private void OnMouseDown()
	{
		if (this.needtouch)
		{
			if (this.total1 == null)
			{
				this.total1 = GameObject.Find("Global(Clone)").transform.Find("AudioSource").GetComponent<Total>();
				if (this.total1 == null)
				{
					return;
				}
			}
			this.total1.Play(this.ontocuh);
		}
	}

	// Token: 0x06000109 RID: 265 RVA: 0x0006AFC8 File Offset: 0x000691C8
	private void OnMouseEnter()
	{
		if (this.needenter)
		{
			if (this.total1 == null)
			{
				this.total1 = GameObject.Find("Global(Clone)").transform.Find("AudioSource").GetComponent<Total>();
				if (this.total1 == null)
				{
					return;
				}
			}
			this.total1.Play(this.onenter);
		}
	}

	// Token: 0x0600010A RID: 266 RVA: 0x0006B030 File Offset: 0x00069230
	private void OnMouseExit()
	{
		if (this.needexit)
		{
			if (this.total1 == null)
			{
				this.total1 = GameObject.Find("Global(Clone)").transform.Find("AudioSource").GetComponent<Total>();
				if (this.total1 == null)
				{
					return;
				}
			}
			this.total1.Play(this.onexit);
		}
	}

	// Token: 0x040001A7 RID: 423
	private Total total1;

	// Token: 0x040001A8 RID: 424
	public int ontocuh;

	// Token: 0x040001A9 RID: 425
	public int onenter;

	// Token: 0x040001AA RID: 426
	public int onexit;

	// Token: 0x040001AB RID: 427
	public bool needtouch;

	// Token: 0x040001AC RID: 428
	public bool needenter;

	// Token: 0x040001AD RID: 429
	public bool needexit;
}
