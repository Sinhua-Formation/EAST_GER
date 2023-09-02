using System;
using UnityEngine;

// Token: 0x02000042 RID: 66
public class Show_diplomacy_data_script : MonoBehaviour
{
	// Token: 0x0600013B RID: 315 RVA: 0x001537A8 File Offset: 0x001519A8
	private void Awake()
	{
		this.global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
		this.text = base.GetComponent<TextMesh>();
		this.okno = base.GetComponent<OkoshkoScript>();
		this.name_ru = this.okno.text;
		this.name_en = this.okno.text_en;
		this.Repaint();
	}

	// Token: 0x0600013C RID: 316 RVA: 0x0015380A File Offset: 0x00151A0A
	private void Update()
	{
		this.Repaint();
	}

	// Token: 0x0600013D RID: 317 RVA: 0x00153814 File Offset: 0x00151A14
	public void Repaint()
	{
		this.text.text = (((this.global1.data[this.num] < 0) ? "-" : "") + Mathf.Abs(this.global1.data[this.num] / 10)).ToString() + "." + Mathf.Abs(this.global1.data[this.num] % 10).ToString();
		if (PlayerPrefs.GetInt("language") == 0)
		{
			string text = string.Concat(new string[]
			{
				this.name_en,
				": ",
				(((this.global1.data_old[this.num] < 0) ? "-" : "+") + Mathf.Abs(this.global1.data_old[this.num] / 10)).ToString(),
				".",
				Mathf.Abs(this.global1.data_old[this.num] % 10).ToString()
			});
			if (this.okno.text_en != text)
			{
				this.okno.text_en = text;
			}
		}
		else
		{
			string text = string.Concat(new string[]
			{
				this.name_ru,
				": ",
				(((this.global1.data_old[this.num] < 0) ? "-" : "+") + Mathf.Abs(this.global1.data_old[this.num] / 10)).ToString(),
				".",
				Mathf.Abs(this.global1.data_old[this.num] % 10).ToString()
			});
			if (this.okno.text != text)
			{
				this.okno.text = text;
			}
		}
		if (this.num == 6)
		{
			if (PlayerPrefs.GetInt("language") == 0)
			{
				if (this.global1.data[6] > 900)
				{
					OkoshkoScript okoshkoScript = this.okno;
					okoshkoScript.text_en += "\n<color=red>Аuthoritarian</color>";
					return;
				}
				if (this.global1.data[6] > 790)
				{
					OkoshkoScript okoshkoScript2 = this.okno;
					okoshkoScript2.text_en += "\n<color=red>Conservative</color>";
					return;
				}
				if (this.global1.data[6] > 590)
				{
					OkoshkoScript okoshkoScript3 = this.okno;
					okoshkoScript3.text_en += "\n<color=green>Moderate</color>";
					return;
				}
				if (this.global1.data[6] > 390)
				{
					OkoshkoScript okoshkoScript4 = this.okno;
					okoshkoScript4.text_en += "\n<color=green>Reformer</color>";
					return;
				}
				if (this.global1.data[6] > 190)
				{
					OkoshkoScript okoshkoScript5 = this.okno;
					okoshkoScript5.text_en += "\n<color=yellow>Liberal</color>";
					return;
				}
				OkoshkoScript okoshkoScript6 = this.okno;
				okoshkoScript6.text_en += "\n<color=yellow>Westernizer</color>";
				return;
			}
			else
			{
				if (this.global1.data[6] > 900)
				{
					OkoshkoScript okoshkoScript7 = this.okno;
					okoshkoScript7.text += "\n<color=red>Авторитарист</color>";
					return;
				}
				if (this.global1.data[6] > 790)
				{
					OkoshkoScript okoshkoScript8 = this.okno;
					okoshkoScript8.text += "\n<color=red>Консерватор</color>";
					return;
				}
				if (this.global1.data[6] > 590)
				{
					OkoshkoScript okoshkoScript9 = this.okno;
					okoshkoScript9.text += "\n<color=green>Умеренный</color>";
					return;
				}
				if (this.global1.data[6] > 390)
				{
					OkoshkoScript okoshkoScript10 = this.okno;
					okoshkoScript10.text += "\n<color=green>Реформист</color>";
					return;
				}
				if (this.global1.data[6] > 190)
				{
					OkoshkoScript okoshkoScript11 = this.okno;
					okoshkoScript11.text += "\n<color=yellow>Либерал</color>";
					return;
				}
				OkoshkoScript okoshkoScript12 = this.okno;
				okoshkoScript12.text += "\n<color=yellow>Западник</color>";
			}
		}
	}

	// Token: 0x040001ED RID: 493
	private GlobalScript global1;

	// Token: 0x040001EE RID: 494
	public int num;

	// Token: 0x040001EF RID: 495
	private TextMesh text;

	// Token: 0x040001F0 RID: 496
	private OkoshkoScript okno;

	// Token: 0x040001F1 RID: 497
	private string name_ru;

	// Token: 0x040001F2 RID: 498
	private string name_en;
}
