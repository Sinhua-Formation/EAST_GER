using System;
using UnityEngine;

// Token: 0x0200001D RID: 29
public class Exitscript : MonoBehaviour
{
	// Token: 0x0600008F RID: 143 RVA: 0x0005AE31 File Offset: 0x00059031
	private void Start()
	{
	}

	// Token: 0x06000090 RID: 144 RVA: 0x0005AE33 File Offset: 0x00059033
	private void OnMouseDown()
	{
		Application.Quit();
	}

	// Token: 0x06000091 RID: 145 RVA: 0x0005AE3A File Offset: 0x0005903A
	private void OnMouseEnter()
	{
		if (PlayerPrefs.GetInt("language") == 0)
		{
			base.gameObject.GetComponent<SpriteRenderer>().sprite = this.eng_navel;
			return;
		}
		base.gameObject.GetComponent<SpriteRenderer>().sprite = this.navel;
	}

	// Token: 0x06000092 RID: 146 RVA: 0x0005AE75 File Offset: 0x00059075
	private void OnMouseExit()
	{
		if (PlayerPrefs.GetInt("language") == 0)
		{
			base.gameObject.GetComponent<SpriteRenderer>().sprite = this.eng_nenavel;
			return;
		}
		base.gameObject.GetComponent<SpriteRenderer>().sprite = this.nenavel;
	}

	// Token: 0x040000D3 RID: 211
	public Sprite nenavel;

	// Token: 0x040000D4 RID: 212
	public Sprite navel;

	// Token: 0x040000D5 RID: 213
	public Sprite eng_nenavel;

	// Token: 0x040000D6 RID: 214
	public Sprite eng_navel;
}
