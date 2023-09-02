using System;
using UnityEngine;

// Token: 0x0200002F RID: 47
public class Need_save : MonoBehaviour
{
	// Token: 0x060000E6 RID: 230 RVA: 0x00069DC3 File Offset: 0x00067FC3
	private void Awake()
	{
		this.global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
		this.Textotext();
	}

	// Token: 0x060000E7 RID: 231 RVA: 0x00069DE0 File Offset: 0x00067FE0
	private void Textotext()
	{
		if (PlayerPrefs.GetInt("language") == 0)
		{
			if (this.global1.autosave == 0)
			{
				this.text.text = "No";
				return;
			}
			if (this.global1.autosave == 1)
			{
				this.text.text = "Monthly";
				return;
			}
			if (this.global1.autosave == 2)
			{
				this.text.text = "Half year";
				return;
			}
		}
		else
		{
			if (this.global1.autosave == 0)
			{
				this.text.text = "Нет";
				return;
			}
			if (this.global1.autosave == 1)
			{
				this.text.text = "Ежемес.";
				return;
			}
			if (this.global1.autosave == 2)
			{
				this.text.text = "Полгода";
			}
		}
	}

	// Token: 0x060000E8 RID: 232 RVA: 0x00069EB0 File Offset: 0x000680B0
	private void OnMouseDown()
	{
		if (this.is_right)
		{
			if (this.global1.autosave < 2)
			{
				this.global1.autosave++;
			}
			else
			{
				this.global1.autosave = 0;
			}
		}
		else if (this.global1.autosave > 0)
		{
			this.global1.autosave--;
		}
		else
		{
			this.global1.autosave = 2;
		}
		PlayerPrefs.SetInt("autosave_check", this.global1.autosave);
		this.Textotext();
	}

	// Token: 0x0400018A RID: 394
	public bool is_right;

	// Token: 0x0400018B RID: 395
	public TextMesh text;

	// Token: 0x0400018C RID: 396
	private GlobalScript global1;
}
