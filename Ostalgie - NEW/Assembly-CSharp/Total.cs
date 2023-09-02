using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200004B RID: 75
public class Total : MonoBehaviour
{
	// Token: 0x06000169 RID: 361 RVA: 0x0018585D File Offset: 0x00183A5D
	private void Awake()
	{
		this.audio_now = base.GetComponent<AudioSource>();
	}

	// Token: 0x0600016A RID: 362 RVA: 0x0018586C File Offset: 0x00183A6C
	private bool isInQue(int number)
	{
		for (int i = 0; i < this.toPlay.Count; i++)
		{
			if (number == this.toPlay[i])
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600016B RID: 363 RVA: 0x001858A1 File Offset: 0x00183AA1
	public void Play(int number)
	{
		if (this.isInQue(number))
		{
			return;
		}
		this.toPlay.Add(number);
	}

	// Token: 0x0600016C RID: 364 RVA: 0x001858BC File Offset: 0x00183ABC
	private void Update()
	{
		if (!this.audio_now.isPlaying && this.toPlay.Count > 0)
		{
			this.audio_now.PlayOneShot(this.all[this.toPlay[0]]);
			this.toPlay.RemoveAt(0);
		}
	}

	// Token: 0x04000237 RID: 567
	public AudioClip[] all = new AudioClip[10];

	// Token: 0x04000238 RID: 568
	private List<int> toPlay = new List<int>();

	// Token: 0x04000239 RID: 569
	private AudioSource audio_now;
}
