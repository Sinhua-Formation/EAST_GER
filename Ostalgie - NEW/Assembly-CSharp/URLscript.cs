using System;
using UnityEngine;

// Token: 0x0200004D RID: 77
public class URLscript : MonoBehaviour
{
	// Token: 0x06000171 RID: 369 RVA: 0x00185A60 File Offset: 0x00183C60
	private void OnMouseDown()
	{
		Application.OpenURL(this.url);
	}

	// Token: 0x0400023F RID: 575
	public string url;
}
