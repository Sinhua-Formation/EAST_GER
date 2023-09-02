using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000026 RID: 38
public class LanguageScript : MonoBehaviour
{
	// Token: 0x060000B1 RID: 177 RVA: 0x0005F6D0 File Offset: 0x0005D8D0
	private void Awake()
	{
		if (this.number != 0 || this.start)
		{
			if (this.number == 0 && PlayerPrefs.HasKey("language"))
			{
				SceneManager.LoadScene("Main");
			}
			return;
		}
		if (PlayerPrefs.GetInt("language") == 0)
		{
			this.language_now.text = "English";
			return;
		}
		this.language_now.text = "Русский";
	}

	// Token: 0x060000B2 RID: 178 RVA: 0x0005F73C File Offset: 0x0005D93C
	private void OnMouseDown()
	{
		PlayerPrefs.SetInt("language", this.number);
		if (this.start)
		{
			SceneManager.LoadScene("Main");
			return;
		}
		if (PlayerPrefs.GetInt("language") == 0)
		{
			this.language_now.text = "English";
			return;
		}
		this.language_now.text = "Русский";
	}

	// Token: 0x060000B3 RID: 179 RVA: 0x0005F799 File Offset: 0x0005D999
	private void OnMouseEnter()
	{
		if (this.start)
		{
			base.GetComponent<SpriteRenderer>().sprite = this.on;
		}
	}

	// Token: 0x060000B4 RID: 180 RVA: 0x0005F7B4 File Offset: 0x0005D9B4
	private void OnMouseExit()
	{
		if (this.start)
		{
			base.GetComponent<SpriteRenderer>().sprite = this.off;
		}
	}

	// Token: 0x04000149 RID: 329
	public int number;

	// Token: 0x0400014A RID: 330
	public bool start;

	// Token: 0x0400014B RID: 331
	public TextMesh language_now;

	// Token: 0x0400014C RID: 332
	public Sprite on;

	// Token: 0x0400014D RID: 333
	public Sprite off;
}
