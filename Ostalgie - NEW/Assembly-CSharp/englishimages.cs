using System;
using UnityEngine;

// Token: 0x02000019 RID: 25
public class englishimages : MonoBehaviour
{
	// Token: 0x0600007D RID: 125 RVA: 0x00058684 File Offset: 0x00056884
	private void Awake()
	{
		this.global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
		this.global1.turn_on = true;
		if (!PlayerPrefs.HasKey("language"))
		{
			PlayerPrefs.SetInt("language", 0);
		}
		if (PlayerPrefs.HasKey("language") && PlayerPrefs.GetInt("language") == 0)
		{
			GameObject.Find("NG1").GetComponent<SpriteRenderer>().sprite = this.new_game_nenavel;
			GameObject.Find("ZAG1").GetComponent<SpriteRenderer>().sprite = this.load_nenavel;
			GameObject.Find("VYH1").GetComponent<SpriteRenderer>().sprite = this.exit_nenavel;
			GameObject.Find("AVT1").GetComponent<SpriteRenderer>().sprite = this.authores_nenavel;
		}
		this.kometa_int = PlayerPrefs.GetInt("kometa");
		if (this.kometa_int >= 12)
		{
			this.kometa.text = "Pax\nRomana";
			this.load1.new_scene = "Roma";
		}
	}

	// Token: 0x040000BB RID: 187
	public string this_scene;

	// Token: 0x040000BC RID: 188
	public Sprite new_game_nenavel;

	// Token: 0x040000BD RID: 189
	public Sprite load_nenavel;

	// Token: 0x040000BE RID: 190
	public Sprite exit_nenavel;

	// Token: 0x040000BF RID: 191
	public Sprite authores_nenavel;

	// Token: 0x040000C0 RID: 192
	private GlobalScript global1;

	// Token: 0x040000C1 RID: 193
	public TextMesh kometa;

	// Token: 0x040000C2 RID: 194
	private int kometa_int;

	// Token: 0x040000C3 RID: 195
	public LoadScript load1;
}
