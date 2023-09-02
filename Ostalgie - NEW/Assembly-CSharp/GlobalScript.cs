using System;
using UnityEngine;

// Token: 0x02000024 RID: 36
public class GlobalScript : MonoBehaviour
{
	// Token: 0x060000A5 RID: 165 RVA: 0x0005DCAC File Offset: 0x0005BEAC
	public void MusicReset()
	{
		this.music[this.now_playing].UnloadAudioData();
		int num = this.now_playing;
		while (this.now_playing == num)
		{
			if (this.bitss == 1)
			{
				this.now_playing = UnityEngine.Random.Range(0, 29);
			}
			else if (this.bitss == 2)
			{
				this.now_playing = UnityEngine.Random.Range(29, 49);
			}
			else if (this.bitss == 3)
			{
				this.now_playing = UnityEngine.Random.Range(49, 70);
			}
			else if (this.bitss == 4)
			{
				this.now_playing = UnityEngine.Random.Range(70, 87);
			}
			else if (this.bitss == 5)
			{
				this.now_playing = UnityEngine.Random.Range(87, 102);
			}
			else if (this.bitss == 6)
			{
				this.now_playing = UnityEngine.Random.Range(102, 114);
			}
			else if (this.bitss == 7)
			{
				this.now_playing = UnityEngine.Random.Range(114, 130);
			}
			else if (this.bitss == 8)
			{
				this.now_playing = UnityEngine.Random.Range(130, 139);
			}
			else if (this.bitss == 9)
			{
				this.now_playing = UnityEngine.Random.Range(139, 152);
			}
			else if (this.bitss == 10)
			{
				this.now_playing = UnityEngine.Random.Range(282, 296);
			}
			else if (this.bitss == 11)
			{
				this.now_playing = UnityEngine.Random.Range(152, 201);
			}
			else if (this.bitss == 12)
			{
				this.now_playing = UnityEngine.Random.Range(201, 250);
			}
			else if (this.bitss == 13)
			{
				this.now_playing = UnityEngine.Random.Range(250, 282);
			}
		}
		this.music[this.now_playing].LoadAudioData();
		this.is_ready_to_play = true;
	}

	// Token: 0x060000A6 RID: 166 RVA: 0x0005DE94 File Offset: 0x0005C094
	private void Awake()
	{
		this.bitss = UnityEngine.Random.Range(1, 11);
		if (!PlayerPrefs.HasKey("voice_ost"))
		{
			PlayerPrefs.SetInt("voice_ost", 5);
		}
		this.voice = PlayerPrefs.GetInt("voice_ost");
		if (PlayerPrefs.HasKey("autosave_check"))
		{
			this.autosave = PlayerPrefs.GetInt("autosave_check");
		}
		Application.targetFrameRate = 60;
	}

	// Token: 0x060000A7 RID: 167 RVA: 0x0005DEFC File Offset: 0x0005C0FC
	private void FixedUpdate()
	{
		if (base.GetComponent<AudioSource>().volume != (float)this.voice / 100f)
		{
			base.GetComponent<AudioSource>().volume = (float)this.voice / 100f;
		}
		if (this.music[this.now_playing].loadState == AudioDataLoadState.Failed)
		{
			this.MusicReset();
			return;
		}
		if (this.is_ready_to_play && this.music[this.now_playing].loadState == AudioDataLoadState.Loaded)
		{
			this.is_ready_to_play = false;
			base.GetComponent<AudioSource>().PlayOneShot(this.music[this.now_playing]);
			return;
		}
		if (!this.is_ready_to_play && !base.GetComponent<AudioSource>().isPlaying)
		{
			this.MusicReset();
		}
	}

	// Token: 0x0400010D RID: 269
	public int[] Events_number = new int[1100];

	// Token: 0x0400010E RID: 270
	public float[] Events_time = new float[1100];

	// Token: 0x0400010F RID: 271
	public bool[] Events_active = new bool[1100];

	// Token: 0x04000110 RID: 272
	public Region[] regions = new Region[5];

	// Token: 0x04000111 RID: 273
	public int number_event = -1;

	// Token: 0x04000112 RID: 274
	public int number_otvet = -1;

	// Token: 0x04000113 RID: 275
	public int this_stump = -1;

	// Token: 0x04000114 RID: 276
	public bool is_progorel;

	// Token: 0x04000115 RID: 277
	public bool[] event_done = new bool[1100];

	// Token: 0x04000116 RID: 278
	public int[] eventVariantChosen = new int[1100];

	// Token: 0x04000117 RID: 279
	public bool achivki_sosut;

	// Token: 0x04000118 RID: 280
	public Country[] allcountries = new Country[55];

	// Token: 0x04000119 RID: 281
	public int speed;

	// Token: 0x0400011A RID: 282
	public int voice = 5;

	// Token: 0x0400011B RID: 283
	public bool[] diff = new bool[4];

	// Token: 0x0400011C RID: 284
	public Game_Event[] events = new Game_Event[40];

	// Token: 0x0400011D RID: 285
	public bool is_save_bylo;

	// Token: 0x0400011E RID: 286
	public bool is_elect;

	// Token: 0x0400011F RID: 287
	public bool is_speech;

	// Token: 0x04000120 RID: 288
	public bool automat;

	// Token: 0x04000121 RID: 289
	public bool is_liber;

	// Token: 0x04000122 RID: 290
	public bool povod;

	// Token: 0x04000123 RID: 291
	public bool is_konst_max = true;

	// Token: 0x04000124 RID: 292
	public bool iron_and_blood;

	// Token: 0x04000125 RID: 293
	public bool turn_on = true;

	// Token: 0x04000126 RID: 294
	public int issleduetsya;

	// Token: 0x04000127 RID: 295
	public int map_type = 1;

	// Token: 0x04000128 RID: 296
	public bool is_gkchp;

	// Token: 0x04000129 RID: 297
	public bool bylo;

	// Token: 0x0400012A RID: 298
	public bool neizucheno = true;

	// Token: 0x0400012B RID: 299
	public int autosave;

	// Token: 0x0400012C RID: 300
	public int[] party_number = new int[5];

	// Token: 0x0400012D RID: 301
	public string[] party_name = new string[5];

	// Token: 0x0400012E RID: 302
	public bool[] is_party_ally = new bool[5];

	// Token: 0x0400012F RID: 303
	public bool[] is_party_enabled = new bool[5];

	// Token: 0x04000130 RID: 304
	public int[] party_ideology = new int[5];

	// Token: 0x04000131 RID: 305
	public string[] politics_name = new string[10];

	// Token: 0x04000132 RID: 306
	public string[] politics_charact = new string[10];

	// Token: 0x04000133 RID: 307
	public string[] politics_opis = new string[10];

	// Token: 0x04000134 RID: 308
	public AudioClip[] music = new AudioClip[166];

	// Token: 0x04000135 RID: 309
	public int now_playing;

	// Token: 0x04000136 RID: 310
	public bool is_ready_to_play;

	// Token: 0x04000137 RID: 311
	public int bitss = 1;

	// Token: 0x04000138 RID: 312
	public string[] new_texts;

	// Token: 0x04000139 RID: 313
	public string[] doctr = new string[24];

	// Token: 0x0400013A RID: 314
	public bool[] science = new bool[10];

	// Token: 0x0400013B RID: 315
	public int[] science_time = new int[10];

	// Token: 0x0400013C RID: 316
	public int[] data_old = new int[9];

	// Token: 0x0400013D RID: 317
	public int[] data = new int[150];

	// Token: 0x0400013E RID: 318
	public string sovietPremiereName;

	// Token: 0x0400013F RID: 319
	public Sprite crisis;
}
