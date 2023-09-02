using System;
using UnityEngine;

// Token: 0x02000047 RID: 71
public class Stasi_script : MonoBehaviour
{
	// Token: 0x06000150 RID: 336 RVA: 0x001545F0 File Offset: 0x001527F0
	private void Start()
	{
		this.Cam = GameObject.Find("Main Camera").GetComponent<Camera>();
		this.global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
	}

	// Token: 0x06000151 RID: 337 RVA: 0x0015461C File Offset: 0x0015281C
	private void OnMouseEnter()
	{
		if (this.Cam == null)
		{
			this.Cam = GameObject.Find("Main Camera").GetComponent<Camera>();
		}
		this.pidor = UnityEngine.Object.Instantiate<GameObject>(this.okno, new Vector3(this.Cam.ScreenToWorldPoint(Input.mousePosition).x, this.Cam.ScreenToWorldPoint(Input.mousePosition).y, -9.6f), new Quaternion(0f, 0f, 0f, 0f));
		if (PlayerPrefs.GetInt("language") == 0)
		{
			this.pidor.transform.Find("Text").GetComponent<TextMesh>().text = string.Concat(new string[]
			{
				this.text_en,
				": ",
				(((this.global1.data[9] < 0) ? "-" : "") + Mathf.Abs(this.global1.data[9] / 10)).ToString(),
				".",
				Mathf.Abs(this.global1.data[9] % 10).ToString()
			});
			return;
		}
		this.pidor.transform.Find("Text").GetComponent<TextMesh>().text = string.Concat(new string[]
		{
			this.text,
			": ",
			(((this.global1.data[9] < 0) ? "-" : "") + Mathf.Abs(this.global1.data[9] / 10)).ToString(),
			".",
			Mathf.Abs(this.global1.data[9] % 10).ToString()
		});
	}

	// Token: 0x06000152 RID: 338 RVA: 0x0015480C File Offset: 0x00152A0C
	public void OnMouseExit()
	{
		UnityEngine.Object.Destroy(this.pidor);
	}

	// Token: 0x0400020F RID: 527
	private GameObject pidor;

	// Token: 0x04000210 RID: 528
	private GlobalScript global1;

	// Token: 0x04000211 RID: 529
	public string text;

	// Token: 0x04000212 RID: 530
	public string text_en;

	// Token: 0x04000213 RID: 531
	public GameObject okno;

	// Token: 0x04000214 RID: 532
	public Camera Cam;
}
