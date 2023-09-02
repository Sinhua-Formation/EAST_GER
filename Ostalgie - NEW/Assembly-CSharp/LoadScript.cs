using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200002A RID: 42
public class LoadScript : MonoBehaviour
{
	// Token: 0x060000CA RID: 202 RVA: 0x00062432 File Offset: 0x00060632
	public void OnMouseDown()
	{
		SceneManager.LoadSceneAsync(this.new_scene);
	}

	// Token: 0x060000CB RID: 203 RVA: 0x00062440 File Offset: 0x00060640
	private void OnMouseEnter()
	{
		if (base.gameObject.GetComponent<SpriteRenderer>() != null)
		{
			if (PlayerPrefs.GetInt("language") == 0)
			{
				base.gameObject.GetComponent<SpriteRenderer>().sprite = this.eng_navel;
				return;
			}
			base.gameObject.GetComponent<SpriteRenderer>().sprite = this.navel;
		}
	}

	// Token: 0x060000CC RID: 204 RVA: 0x0006249C File Offset: 0x0006069C
	private void OnMouseExit()
	{
		if (base.gameObject.GetComponent<SpriteRenderer>() != null)
		{
			if (PlayerPrefs.GetInt("language") == 0)
			{
				base.gameObject.GetComponent<SpriteRenderer>().sprite = this.eng_nenavel;
				return;
			}
			base.gameObject.GetComponent<SpriteRenderer>().sprite = this.nenavel;
		}
	}

	// Token: 0x0400015F RID: 351
	public string new_scene;

	// Token: 0x04000160 RID: 352
	public Sprite nenavel;

	// Token: 0x04000161 RID: 353
	public Sprite navel;

	// Token: 0x04000162 RID: 354
	public Sprite eng_nenavel;

	// Token: 0x04000163 RID: 355
	public Sprite eng_navel;
}
