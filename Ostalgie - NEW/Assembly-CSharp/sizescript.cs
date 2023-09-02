using System;
using UnityEngine;

// Token: 0x02000043 RID: 67
public class sizescript : MonoBehaviour
{
	// Token: 0x0600013F RID: 319 RVA: 0x00153C58 File Offset: 0x00151E58
	private void Awake()
	{
		this.a43[0] = 640f;
		this.a431[0] = 480f;
		this.a43[1] = 800f;
		this.a431[1] = 600f;
		this.a43[2] = 1024f;
		this.a431[2] = 768f;
		this.a43[3] = 1152f;
		this.a431[3] = 864f;
		this.a43[4] = 1280f;
		this.a431[4] = 960f;
		this.a54[0] = 720f;
		this.a541[0] = 576f;
		this.a54[1] = 1280f;
		this.a541[1] = 1024f;
		this.a1610[0] = 1280f;
		this.a16101[0] = 800f;
		this.a1610[1] = 1600f;
		this.a16101[1] = 1024f;
		this.a1610[2] = 1680f;
		this.a16101[2] = 1050f;
		this.a169[0] = 1024f;
		this.a1691[0] = 576f;
		this.a169[1] = 1380f;
		this.a1691[1] = 720f;
		this.a169[2] = 1360f;
		this.a1691[2] = 768f;
		this.a169[3] = 1366f;
		this.a1691[3] = 768f;
		this.a169[4] = 1600f;
		this.a1691[4] = 900f;
		this.a169[4] = 1920f;
		this.a1691[4] = 1080f;
		this.a169[5] = 2715f;
		this.a1691[5] = 1527f;
		this.newx = (float)Screen.width;
		this.newy = (float)Screen.height;
		for (int i = 0; i < 5; i++)
		{
			if (this.newx == this.a43[i] && this.newy == this.a431[i])
			{
				this.newx = 4f;
				this.newy = 3f;
			}
		}
		for (int j = 0; j < 2; j++)
		{
			if (this.newx == this.a54[j] && this.newy == this.a541[j])
			{
				this.newx = 5f;
				this.newy = 4f;
			}
		}
		for (int k = 0; k < 3; k++)
		{
			if (this.newx == this.a1610[k] && this.newy == this.a16101[k])
			{
				this.newx = 16f;
				this.newy = 10f;
			}
		}
		for (int l = 0; l < 7; l++)
		{
			if (this.newx == this.a169[l] && this.newy == this.a1691[l])
			{
				this.newx = 16f;
				this.newy = 9f;
			}
		}
		this.newx /= this.newy / this.oldy;
		this.newy /= this.newy / this.oldy;
		this.totalx = this.newx / this.oldx;
		base.transform.localScale = new Vector3(base.transform.localScale.x * this.totalx, base.transform.localScale.y, base.transform.localScale.z);
		if (!this.isBackground)
		{
			base.transform.position = new Vector3(this.parent.transform.position.x + (base.transform.position.x - this.parent.transform.position.x) * this.totalx, base.transform.position.y, base.transform.position.z);
		}
		UnityEngine.Object.Destroy(this);
	}

	// Token: 0x040001F3 RID: 499
	public GameObject parent;

	// Token: 0x040001F4 RID: 500
	public bool isBackground;

	// Token: 0x040001F5 RID: 501
	public float totalx;

	// Token: 0x040001F6 RID: 502
	public float oldx = 16f;

	// Token: 0x040001F7 RID: 503
	public float oldy = 9f;

	// Token: 0x040001F8 RID: 504
	public float newx;

	// Token: 0x040001F9 RID: 505
	public float newy;

	// Token: 0x040001FA RID: 506
	public float[] a43 = new float[5];

	// Token: 0x040001FB RID: 507
	public float[] a431 = new float[5];

	// Token: 0x040001FC RID: 508
	public float[] a54 = new float[2];

	// Token: 0x040001FD RID: 509
	public float[] a541 = new float[2];

	// Token: 0x040001FE RID: 510
	public float[] a1610 = new float[3];

	// Token: 0x040001FF RID: 511
	public float[] a16101 = new float[3];

	// Token: 0x04000200 RID: 512
	public float[] a169 = new float[7];

	// Token: 0x04000201 RID: 513
	public float[] a1691 = new float[7];
}
