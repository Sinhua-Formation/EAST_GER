using System;
using UnityEngine;

// Token: 0x0200002C RID: 44
public class MapTypeScript : MonoBehaviour
{
	// Token: 0x060000D4 RID: 212 RVA: 0x000629C0 File Offset: 0x00060BC0
	private void Awake()
	{
		this.map1 = GameObject.Find("MapChanges").GetComponent<MapChangesScript>();
		this.sp = base.GetComponent<SpriteRenderer>();
		this.global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
		this.Repaint();
	}

	// Token: 0x060000D5 RID: 213 RVA: 0x000629FE File Offset: 0x00060BFE
	private void OnMouseDown()
	{
		this.global1.map_type = this.this_type;
		this.map1.UpdateMap();
		this.oth1.Repaint();
		this.oth2.Repaint();
	}

	// Token: 0x060000D6 RID: 214 RVA: 0x00062A34 File Offset: 0x00060C34
	public void Repaint()
	{
		if (this.global1.map_type == this.this_type && this.sp.sprite != this.on)
		{
			this.sp.sprite = this.on;
			return;
		}
		if (this.global1.map_type != this.this_type && this.sp.sprite != this.off)
		{
			this.sp.sprite = this.off;
		}
	}

	// Token: 0x060000D7 RID: 215 RVA: 0x00062ABA File Offset: 0x00060CBA
	private void OnMouseEnter()
	{
		this.sp.sprite = this.on;
	}

	// Token: 0x060000D8 RID: 216 RVA: 0x00062ACD File Offset: 0x00060CCD
	private void OnMouseExit()
	{
		this.Repaint();
	}

	// Token: 0x04000170 RID: 368
	public MapTypeScript oth1;

	// Token: 0x04000171 RID: 369
	public MapTypeScript oth2;

	// Token: 0x04000172 RID: 370
	public Sprite on;

	// Token: 0x04000173 RID: 371
	public Sprite off;

	// Token: 0x04000174 RID: 372
	public int this_type;

	// Token: 0x04000175 RID: 373
	private MapChangesScript map1;

	// Token: 0x04000176 RID: 374
	private SpriteRenderer sp;

	// Token: 0x04000177 RID: 375
	private GlobalScript global1;
}
