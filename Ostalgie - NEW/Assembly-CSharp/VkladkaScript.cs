using System;
using UnityEngine;

// Token: 0x0200004F RID: 79
public class VkladkaScript : MonoBehaviour
{
	// Token: 0x0600017B RID: 379 RVA: 0x00185CAD File Offset: 0x00183EAD
	private void Awake()
	{
		this.global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
		this.elect1 = GameObject.Find("KrasnayaNEnazhataya 6").GetComponent<ElectScript>();
	}

	// Token: 0x0600017C RID: 380 RVA: 0x00185CDC File Offset: 0x00183EDC
	private void OnMouseDown()
	{
		if (!this.is_showed)
		{
			this.vkladka.SetActive(true);
			this.is_showed = true;
			for (int i = 1; i < 4; i++)
			{
				Transform transform = this.vkladka.transform.Find("Min" + i.ToString());
				transform.transform.Find("Button").GetComponent<Politic_set_script>().dolshnost = this.dolshnost;
				transform.transform.Find("Button").GetComponent<Politic_set_script>().candidat = this.candidats[i - 1];
				if (this.global1.data[0] < 49 || this.global1.data[0] > 51)
				{
					transform.transform.Find("Pol").GetComponent<SpriteRenderer>().sprite = this.elect1.politics[(this.global1.data[0] - 1) * 10 + this.candidats[i - 1]];
				}
				else if (this.global1.data[0] >= 49 && this.global1.data[0] <= 51 && this.global1.data[114] == 100)
				{
					transform.transform.Find("Pol").GetComponent<SpriteRenderer>().sprite = this.elect1.politics[this.global1.data[0] * 10 + this.candidats[i - 1]];
				}
				else if (this.global1.data[0] >= 49 && this.global1.data[0] <= 51 && this.global1.data[114] != 100)
				{
					transform.transform.Find("Pol").GetComponent<SpriteRenderer>().sprite = this.elect1.politics[150 + this.candidats[i - 1]];
				}
				transform.transform.Find("Text").GetComponent<TextMesh>().text = this.global1.politics_name[this.candidats[i - 1]];
				transform.transform.Find("Text1").GetComponent<TextMesh>().text = this.global1.politics_charact[this.candidats[i - 1]];
				transform.transform.Find("Text2").GetComponent<TextMesh>().text = this.global1.politics_opis[this.candidats[i - 1]];
			}
			return;
		}
		this.vkladka.SetActive(false);
		this.is_showed = false;
	}

	// Token: 0x04000247 RID: 583
	public GameObject vkladka;

	// Token: 0x04000248 RID: 584
	public bool is_showed;

	// Token: 0x04000249 RID: 585
	public GameObject other;

	// Token: 0x0400024A RID: 586
	public int dolshnost;

	// Token: 0x0400024B RID: 587
	public int[] candidats = new int[3];

	// Token: 0x0400024C RID: 588
	private GlobalScript global1;

	// Token: 0x0400024D RID: 589
	private ElectScript elect1;
}
