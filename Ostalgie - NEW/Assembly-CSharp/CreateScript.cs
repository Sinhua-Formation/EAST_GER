using System;
using UnityEngine;

// Token: 0x02000010 RID: 16
public class CreateScript : MonoBehaviour
{
	// Token: 0x0600004D RID: 77 RVA: 0x0000EF28 File Offset: 0x0000D128
	private void Awake()
	{
		if (GameObject.Find("Global(Clone)") == null)
		{
			UnityEngine.Object.Instantiate<GameObject>(this.un);
			UnityEngine.Object.DontDestroyOnLoad(GameObject.Find("Global(Clone)"));
		}
		if (GameObject.Find("Ach(Clone)") == null)
		{
			UnityEngine.Object.Instantiate<GameObject>(this.ach);
			UnityEngine.Object.DontDestroyOnLoad(GameObject.Find("Ach(Clone)"));
		}
	}

	// Token: 0x0400006C RID: 108
	public GameObject un;

	// Token: 0x0400006D RID: 109
	public GameObject ach;
}
