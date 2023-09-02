using System;
using UnityEngine;

// Token: 0x0200003A RID: 58
public class Politic_party_name_show : MonoBehaviour
{
	// Token: 0x06000114 RID: 276 RVA: 0x0006B1EC File Offset: 0x000693EC
	private void Awake()
	{
		this.global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
		base.GetComponent<TextMesh>().text = this.global1.party_name[this.this_number];
		if (this.global1.party_ideology[this.this_number] == 1)
		{
			base.GetComponent<OkoshkoScript>().text = "Социал-демократы";
			base.GetComponent<OkoshkoScript>().text_en = "Social-democrats";
			OkoshkoScript component = base.GetComponent<OkoshkoScript>();
			component.text += "\n(Линия Партии:\nРеформизм/Центризм)";
			OkoshkoScript component2 = base.GetComponent<OkoshkoScript>();
			component2.text_en += "\n(Party line:\nReformism/Centrism)";
			return;
		}
		if (this.global1.party_ideology[this.this_number] == 2)
		{
			base.GetComponent<OkoshkoScript>().text = "Центристы";
			base.GetComponent<OkoshkoScript>().text_en = "Centrists";
			OkoshkoScript component3 = base.GetComponent<OkoshkoScript>();
			component3.text += "\n(Линия Партии:\nЦентризм/Правость)";
			OkoshkoScript component4 = base.GetComponent<OkoshkoScript>();
			component4.text_en += "\n(Party line:\nCentrism/Right-wing)";
			return;
		}
		if (this.global1.party_ideology[this.this_number] == 3)
		{
			base.GetComponent<OkoshkoScript>().text = "Правые";
			base.GetComponent<OkoshkoScript>().text_en = "Right-wings";
			OkoshkoScript component5 = base.GetComponent<OkoshkoScript>();
			component5.text += "\n(Линия Партии:\nЭтатизм/Правость)";
			OkoshkoScript component6 = base.GetComponent<OkoshkoScript>();
			component6.text_en += "\n(Party line:\nStatism/Right-wing)";
			return;
		}
		if (this.global1.party_ideology[this.this_number] == 10)
		{
			if (this.global1.data[0] != 2)
			{
				base.GetComponent<OkoshkoScript>().text = "Леворадикалы";
				base.GetComponent<OkoshkoScript>().text_en = "Left radicals";
			}
			else
			{
				base.GetComponent<OkoshkoScript>().text = "Праворадикалы";
				base.GetComponent<OkoshkoScript>().text_en = "Right radicals";
			}
			OkoshkoScript component7 = base.GetComponent<OkoshkoScript>();
			component7.text += "\n(Линия Партии:\nЭтатизм)";
			OkoshkoScript component8 = base.GetComponent<OkoshkoScript>();
			component8.text_en += "\n(Party line:\nStatism)";
		}
	}

	// Token: 0x040001B4 RID: 436
	private GlobalScript global1;

	// Token: 0x040001B5 RID: 437
	public int this_number;
}
