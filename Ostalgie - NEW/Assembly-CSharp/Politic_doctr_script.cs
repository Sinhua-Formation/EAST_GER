using System;
using UnityEngine;

// Token: 0x02000039 RID: 57
public class Politic_doctr_script : MonoBehaviour
{
	// Token: 0x06000112 RID: 274 RVA: 0x0006B18C File Offset: 0x0006938C
	private void Awake()
	{
		this.global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
		string text = this.global1.doctr[this.global1.data[this.doctr]];
		text = text.Replace("|", "\n");
		base.GetComponent<TextMesh>().text = text;
	}

	// Token: 0x040001B2 RID: 434
	private GlobalScript global1;

	// Token: 0x040001B3 RID: 435
	public int doctr;
}
