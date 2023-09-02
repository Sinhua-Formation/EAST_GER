using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000017 RID: 23
public class ElectScript : MonoBehaviour
{
	// Token: 0x0600006E RID: 110 RVA: 0x000435B4 File Offset: 0x000417B4
	private void Awake()
	{
		this.global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
		this.Repaint();
		if (PlayerPrefs.GetInt("language") == 0)
		{
			this.texts[0].text = "Political system";
			this.texts[1].text = "Parties";
			this.texts[2].text = "Party line";
			this.texts[3].text = "Type of economy";
			this.texts[4].text = "Freedom";
			this.texts[5].text = "Elections";
			this.texts[6].text = "Leader";
			this.texts[7].text = "Sovmin";
			this.texts[8].text = "Ideology";
			this.texts[9].text = "Diplomacy";
			this.texts[10].text = "Science";
			this.texts[11].text = "Economy";
			this.texts[12].text = "Alliance";
			this.texts[13].text = "Allowed";
			this.texts[15].text = "Speech";
		}
		this.texts[14].text = (this.global1.data[33] / 10).ToString() + "." + Mathf.Abs(this.global1.data[33] % 10).ToString();
		this.texts[16].text = this.global1.data[14].ToString();
	}

	// Token: 0x0600006F RID: 111 RVA: 0x00043774 File Offset: 0x00041974
	private void OnMouseDown()
	{
		if (!this.global1.is_elect && this.global1.data[15] > 6)
		{
			this.global1.is_elect = true;
			this.Repaint();
			this.global1.event_done[2] = true;
			this.global1.data[8] -= 10;
			this.global1.number_event = 2;
			SceneManager.LoadScene("Event");
		}
	}

	// Token: 0x06000070 RID: 112 RVA: 0x000437EC File Offset: 0x000419EC
	private void OnMouseEnter()
	{
		base.GetComponent<SpriteRenderer>().sprite = this.on;
	}

	// Token: 0x06000071 RID: 113 RVA: 0x000437FF File Offset: 0x000419FF
	private void OnMouseExit()
	{
		if (!this.global1.is_elect)
		{
			base.GetComponent<SpriteRenderer>().sprite = this.off;
		}
	}

	// Token: 0x06000072 RID: 114 RVA: 0x0004381F File Offset: 0x00041A1F
	private void Repaint()
	{
		if (this.global1.is_elect)
		{
			base.GetComponent<SpriteRenderer>().sprite = this.on;
			return;
		}
		base.GetComponent<SpriteRenderer>().sprite = this.off;
	}

	// Token: 0x040000A0 RID: 160
	private GlobalScript global1;

	// Token: 0x040000A1 RID: 161
	public Sprite on;

	// Token: 0x040000A2 RID: 162
	public Sprite off;

	// Token: 0x040000A3 RID: 163
	public TextMesh[] texts = new TextMesh[16];

	// Token: 0x040000A4 RID: 164
	public Sprite[] politics = new Sprite[60];
}
