using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200001C RID: 28
public class EvetnnashScript : MonoBehaviour
{
	// Token: 0x0600008A RID: 138 RVA: 0x0005AD77 File Offset: 0x00058F77
	private void Awake()
	{
		this.map1 = GameObject.Find("MapChanges").GetComponent<MapChangesScript>();
		this.global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
	}

	// Token: 0x0600008B RID: 139 RVA: 0x0005ADA3 File Offset: 0x00058FA3
	public void OnMouseDown()
	{
		this.global1.speed = 0;
		this.map1.EventRead();
		SceneManager.LoadSceneAsync(this.new_scene);
	}

	// Token: 0x0600008C RID: 140 RVA: 0x0005ADC8 File Offset: 0x00058FC8
	private void OnMouseEnter()
	{
		if (base.gameObject.GetComponent<SpriteRenderer>() != null)
		{
			base.gameObject.GetComponent<SpriteRenderer>().sprite = this.navel;
		}
	}

	// Token: 0x0600008D RID: 141 RVA: 0x0005ADF3 File Offset: 0x00058FF3
	private void OnMouseExit()
	{
		if (base.gameObject.GetComponent<SpriteRenderer>() != null)
		{
			base.gameObject.GetComponent<SpriteRenderer>().sprite = this.nenavel;
		}
	}

	// Token: 0x040000CE RID: 206
	private MapChangesScript map1;

	// Token: 0x040000CF RID: 207
	public string new_scene = "";

	// Token: 0x040000D0 RID: 208
	public Sprite navel;

	// Token: 0x040000D1 RID: 209
	public Sprite nenavel;

	// Token: 0x040000D2 RID: 210
	private GlobalScript global1;
}
