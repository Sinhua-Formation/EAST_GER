using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000046 RID: 70
public class StartGameScript : MonoBehaviour
{
	// Token: 0x0600014E RID: 334 RVA: 0x001545E4 File Offset: 0x001527E4
	private void Start()
	{
		SceneManager.LoadScene("Main");
	}
}
