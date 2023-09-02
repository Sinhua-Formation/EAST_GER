using System;
using UnityEngine;

// Token: 0x0200000A RID: 10
public class CascadScrupt : MonoBehaviour
{
	// Token: 0x06000029 RID: 41 RVA: 0x000098FB File Offset: 0x00007AFB
	private void Awake()
	{
		this.global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
	}

	// Token: 0x0600002A RID: 42 RVA: 0x00009914 File Offset: 0x00007B14
	private void OnMouseDown()
	{
		if (!this.turn_on)
		{
			this.Cascad.SetActive(true);
		}
		else
		{
			this.Cascad.SetActive(false);
		}
		if (this.global1.data[21] > 1991 && !this.turn_on)
		{
			this.PostExit.SetActive(true);
		}
		else if (this.global1.data[21] > 1991 && this.turn_on)
		{
			this.PostExit.SetActive(false);
		}
		this.turn_on = !this.turn_on;
	}

	// Token: 0x0600002B RID: 43 RVA: 0x000099A6 File Offset: 0x00007BA6
	private void OnMouseEnter()
	{
		base.GetComponent<SpriteRenderer>().sprite = this.on;
	}

	// Token: 0x0600002C RID: 44 RVA: 0x000099B9 File Offset: 0x00007BB9
	private void OnMouseExit()
	{
		base.GetComponent<SpriteRenderer>().sprite = this.off;
	}

	// Token: 0x04000031 RID: 49
	public Sprite on;

	// Token: 0x04000032 RID: 50
	public Sprite off;

	// Token: 0x04000033 RID: 51
	private bool turn_on;

	// Token: 0x04000034 RID: 52
	public GameObject Cascad;

	// Token: 0x04000035 RID: 53
	public GameObject PostExit;

	// Token: 0x04000036 RID: 54
	public GlobalScript global1;
}
