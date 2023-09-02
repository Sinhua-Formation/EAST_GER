using System;
using UnityEngine;

// Token: 0x02000031 RID: 49
public class OkoshkoScript : MonoBehaviour
{
	// Token: 0x060000EE RID: 238 RVA: 0x00069F85 File Offset: 0x00068185
	private void Start()
	{
		this.Cam = GameObject.Find("Main Camera").GetComponent<Camera>();
	}

	// Token: 0x060000EF RID: 239 RVA: 0x00069F9C File Offset: 0x0006819C
	private void OnMouseEnter()
	{
		if (!this.nonono)
		{
			if (this.Cam == null)
			{
				this.Cam = GameObject.Find("Main Camera").GetComponent<Camera>();
			}
			this.pidor = UnityEngine.Object.Instantiate<GameObject>(this.okno, new Vector3(this.Cam.ScreenToWorldPoint(Input.mousePosition).x, this.Cam.ScreenToWorldPoint(Input.mousePosition).y, -9.5f), new Quaternion(0f, 0f, 0f, 0f));
			if (PlayerPrefs.GetInt("language") == 0)
			{
				this.text_en = this.text_en.Replace("|", "\n");
				this.pidor.transform.Find("Text").GetComponent<TextMesh>().text = this.text_en;
				return;
			}
			this.text = this.text.Replace("|", "\n");
			this.pidor.transform.Find("Text").GetComponent<TextMesh>().text = this.text;
		}
	}

	// Token: 0x060000F0 RID: 240 RVA: 0x0006A0C2 File Offset: 0x000682C2
	public void OnMouseExit()
	{
		if (!this.nonono)
		{
			UnityEngine.Object.Destroy(this.pidor);
		}
	}

	// Token: 0x04000190 RID: 400
	private GameObject pidor;

	// Token: 0x04000191 RID: 401
	public string text;

	// Token: 0x04000192 RID: 402
	public string text_en;

	// Token: 0x04000193 RID: 403
	public GameObject okno;

	// Token: 0x04000194 RID: 404
	public Camera Cam;

	// Token: 0x04000195 RID: 405
	public bool nonono;
}
