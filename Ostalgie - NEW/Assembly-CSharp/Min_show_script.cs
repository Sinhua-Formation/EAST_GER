using System;
using UnityEngine;

// Token: 0x0200002D RID: 45
public class Min_show_script : MonoBehaviour
{
	// Token: 0x060000DA RID: 218 RVA: 0x00062AD8 File Offset: 0x00060CD8
	private void OnMouseEnter()
	{
		if (this.Cam == null)
		{
			this.Cam = GameObject.Find("Main Camera").GetComponent<Camera>();
		}
		this.pidor = UnityEngine.Object.Instantiate<GameObject>(this.okno, new Vector3(this.Cam.ScreenToWorldPoint(Input.mousePosition).x, this.Cam.ScreenToWorldPoint(Input.mousePosition).y, -6f), new Quaternion(0f, 0f, 0f, 0f));
		this.pidor.transform.Find("Text").GetComponent<TextMesh>().text = this.global1.politics_charact[this.global1.data[this.dolshnost]];
	}

	// Token: 0x060000DB RID: 219 RVA: 0x00062BA3 File Offset: 0x00060DA3
	private void OnMouseExit()
	{
		UnityEngine.Object.Destroy(this.pidor);
	}

	// Token: 0x060000DC RID: 220 RVA: 0x00062BB0 File Offset: 0x00060DB0
	private void Awake()
	{
		this.Cam = GameObject.Find("Main Camera").GetComponent<Camera>();
		this.elect1 = GameObject.Find("KrasnayaNEnazhataya 6").GetComponent<ElectScript>();
		this.global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
		this.Repaint();
	}

	// Token: 0x060000DD RID: 221 RVA: 0x00062C04 File Offset: 0x00060E04
	public void Repaint()
	{
		if (this.global1.data[0] < 49 || this.global1.data[0] > 51)
		{
			base.GetComponent<SpriteRenderer>().sprite = this.elect1.politics[(this.global1.data[0] - 1) * 10 + this.global1.data[this.dolshnost]];
		}
		else if (this.global1.data[0] >= 49 && this.global1.data[0] <= 51 && this.global1.data[114] == 100)
		{
			base.GetComponent<SpriteRenderer>().sprite = this.elect1.politics[this.global1.data[0] * 10 + this.global1.data[this.dolshnost]];
		}
		else if (this.global1.data[0] >= 49 && this.global1.data[0] <= 51 && this.global1.data[114] != 100)
		{
			base.GetComponent<SpriteRenderer>().sprite = this.elect1.politics[150 + this.global1.data[this.dolshnost]];
		}
		this.text.text = this.global1.politics_name[this.global1.data[this.dolshnost]];
	}

	// Token: 0x04000178 RID: 376
	private GlobalScript global1;

	// Token: 0x04000179 RID: 377
	public int dolshnost;

	// Token: 0x0400017A RID: 378
	public TextMesh text;

	// Token: 0x0400017B RID: 379
	private ElectScript elect1;

	// Token: 0x0400017C RID: 380
	private GameObject pidor;

	// Token: 0x0400017D RID: 381
	public GameObject okno;

	// Token: 0x0400017E RID: 382
	public Camera Cam;
}
