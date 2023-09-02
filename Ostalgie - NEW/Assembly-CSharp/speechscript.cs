using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000044 RID: 68
public class speechscript : MonoBehaviour
{
	// Token: 0x06000141 RID: 321 RVA: 0x001540D9 File Offset: 0x001522D9
	private void Awake()
	{
		this.global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
		this.Repaint();
	}

	// Token: 0x06000142 RID: 322 RVA: 0x001540F8 File Offset: 0x001522F8
	private void OnMouseDown()
	{
		if (!this.global1.is_speech)
		{
			this.global1.is_speech = true;
			this.Repaint();
			this.global1.number_event = 1;
			this.global1.event_done[1] = true;
			SceneManager.LoadScene("Event");
		}
	}

	// Token: 0x06000143 RID: 323 RVA: 0x00154148 File Offset: 0x00152348
	private void OnMouseEnter()
	{
		base.GetComponent<SpriteRenderer>().sprite = this.on;
	}

	// Token: 0x06000144 RID: 324 RVA: 0x0015415B File Offset: 0x0015235B
	private void OnMouseExit()
	{
		if (!this.global1.is_speech)
		{
			base.GetComponent<SpriteRenderer>().sprite = this.off;
		}
	}

	// Token: 0x06000145 RID: 325 RVA: 0x0015417B File Offset: 0x0015237B
	private void Repaint()
	{
		if (this.global1.is_speech)
		{
			base.GetComponent<SpriteRenderer>().sprite = this.on;
			return;
		}
		base.GetComponent<SpriteRenderer>().sprite = this.off;
	}

	// Token: 0x04000202 RID: 514
	private GlobalScript global1;

	// Token: 0x04000203 RID: 515
	public Sprite on;

	// Token: 0x04000204 RID: 516
	public Sprite off;
}
