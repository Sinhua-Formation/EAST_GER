using System;
using UnityEngine;

// Token: 0x02000035 RID: 53
public class perehodscript : MonoBehaviour
{
	// Token: 0x06000103 RID: 259 RVA: 0x0005AE31 File Offset: 0x00059031
	private void Start()
	{
	}

	// Token: 0x06000104 RID: 260 RVA: 0x0006AEDD File Offset: 0x000690DD
	private void OnMouseDown()
	{
		GameObject.Find("Main Camera").transform.position = new Vector3(this.x, this.y, -10f);
	}

	// Token: 0x06000105 RID: 261 RVA: 0x0006AF09 File Offset: 0x00069109
	private void OnMouseEnter()
	{
		if (base.gameObject.GetComponent<SpriteRenderer>() != null)
		{
			base.gameObject.GetComponent<SpriteRenderer>().sprite = this.navel;
		}
	}

	// Token: 0x06000106 RID: 262 RVA: 0x0006AF34 File Offset: 0x00069134
	private void OnMouseExit()
	{
		if (base.gameObject.GetComponent<SpriteRenderer>() != null)
		{
			base.gameObject.GetComponent<SpriteRenderer>().sprite = this.nenavel;
		}
	}

	// Token: 0x040001A3 RID: 419
	public Sprite nenavel;

	// Token: 0x040001A4 RID: 420
	public Sprite navel;

	// Token: 0x040001A5 RID: 421
	public float x;

	// Token: 0x040001A6 RID: 422
	public float y;
}
