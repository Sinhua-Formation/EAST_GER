using System;
using UnityEngine;

// Token: 0x0200004C RID: 76
public class TranslateScript : MonoBehaviour
{
	// Token: 0x0600016E RID: 366 RVA: 0x0018592E File Offset: 0x00183B2E
	private void Awake()
	{
		this.Repaint();
	}

	// Token: 0x0600016F RID: 367 RVA: 0x00185938 File Offset: 0x00183B38
	public void Repaint()
	{
		if (PlayerPrefs.GetInt("language") == 0)
		{
			for (int i = 0; i < this.meshes.Length; i++)
			{
				this.meshes[i].text = this.english_text[i];
				if (this.english_text2[i].Length > 1)
				{
					TextMesh textMesh = this.meshes[i];
					textMesh.text = textMesh.text + "\n" + this.english_text2[i];
				}
			}
			return;
		}
		for (int j = 0; j < this.meshes.Length; j++)
		{
			this.meshes[j].text = this.russian_text[j];
			if (this.russian_text2[j].Length > 1)
			{
				TextMesh textMesh2 = this.meshes[j];
				textMesh2.text = textMesh2.text + "\n" + this.russian_text2[j];
			}
		}
	}

	// Token: 0x0400023A RID: 570
	public string[] english_text = new string[20];

	// Token: 0x0400023B RID: 571
	public string[] russian_text = new string[20];

	// Token: 0x0400023C RID: 572
	public TextMesh[] meshes = new TextMesh[20];

	// Token: 0x0400023D RID: 573
	public string[] english_text2 = new string[20];

	// Token: 0x0400023E RID: 574
	public string[] russian_text2 = new string[20];
}
