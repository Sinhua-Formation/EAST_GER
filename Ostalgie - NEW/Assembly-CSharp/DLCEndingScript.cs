using System;
using UnityEngine;

// Token: 0x02000015 RID: 21
public class DLCEndingScript : MonoBehaviour
{
	// Token: 0x06000061 RID: 97 RVA: 0x0001DEA8 File Offset: 0x0001C0A8
	public void Init()
	{
		string arg = "en";
		if (PlayerPrefs.GetInt("language") == 0)
		{
			this.language = SystemLanguage.English;
		}
		else
		{
			arg = "ru";
			this.language = SystemLanguage.Russian;
		}
		TextAsset textAsset = Resources.Load(string.Format("{0}_text/dlcending_text", arg)) as TextAsset;
		this.credits_text = textAsset.text.Split(new char[]
		{
			'\n'
		});
		Resources.UnloadAsset(textAsset);
	}

	// Token: 0x04000088 RID: 136
	public SystemLanguage language = SystemLanguage.English;

	// Token: 0x04000089 RID: 137
	public static DLCEndingScript inst;

	// Token: 0x0400008A RID: 138
	public string[] credits_text;
}
