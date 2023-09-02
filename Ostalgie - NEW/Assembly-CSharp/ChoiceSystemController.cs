using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200000C RID: 12
public class ChoiceSystemController : MonoBehaviour
{
	// Token: 0x06000035 RID: 53 RVA: 0x00009AA0 File Offset: 0x00007CA0
	private void Awake()
	{
		this.global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
		if (PlayerPrefs.GetInt("language") == 0)
		{
			this.Set(new int[7], new string[]
			{
				"GDR's path",
				"PPR's path",
				"CSSR's path",
				"HPR's path",
				"SRR's path",
				"PRB's path",
				"USSR's path"
			}, new List<string>[]
			{
				new List<string>
				{
					"Historical",
					"Random",
					"Mielke, Authoritarianism",
					"Mielke, National Bolshevism",
					"Honecker, Automation",
					"Krenz, by 1948"
				},
				new List<string>
				{
					"Historical",
					"Random",
					"Interfere in elections (✓Vorotnikov)",
					"Mijal, national-syndicalism",
					"Kwasniewski, faster than Solidarity"
				},
				new List<string>
				{
					"Historical",
					"Random",
					"Husák, New Nation",
					"Adamec, Liberation Theology",
					"Štrougal, Confederation",
					"Czech superiority (✓Vorotnikov)"
				},
				new List<string>
				{
					"Historical",
					"Random",
					"USSR published Nagy (✓Vorotnikov)",
					"Nemeth, red capitalism",
					"Borbéy, new regent",
					"Kraus, two steps back"
				},
				new List<string>
				{
					"Historical",
					"Random",
					"Ceausescu, Red Dynasty",
					"Apostol, Back to Socialism",
					"Interference (✓Vorotnikov)",
					"Verdeț, Civil War"
				},
				new List<string>
				{
					"Historical",
					"Random",
					"Zhivkov, Yugoslavia (✘Yugoslavia)",
					"Mladenov, monarcho-socialism",
					"Solakov, bulgarization",
					"Lilov, capitalism & socialism "
				},
				new List<string>
				{
					"Historical",
					"Random",
					"Yakovlev (✘Cuba)",
					"Vorotnikov (✘Cuba)",
					"Incident in 1990"
				}
			});
			return;
		}
		this.Set(new int[7], new string[]
		{
			"Курс ГДР",
			"Курс ПНР",
			"Курс ЧССР",
			"Курс ВНР",
			"Курс СРР",
			"Курс НРБ",
			"Курс СССР"
		}, new List<string>[]
		{
			new List<string>
			{
				"Исторический",
				"Случайный",
				"Мильке, авторитаризм",
				"Мильке, национал-большевизм",
				"Хонеккер, автоматизация",
				"Кренц, к 1948"
			},
			new List<string>
			{
				"Исторический",
				"Случайный",
				"Вмешательство в выборы (✓Воротников)",
				"Мияль, национал-синдикализм",
				"Квасьневский, быстрее Солидарности"
			},
			new List<string>
			{
				"Исторический",
				"Случайный",
				"Гусак, новая нация",
				"Адамец, теология освобождения",
				"Штроугал, конфедерация",
				"Гавел, чехонационализм (✓Воротников)"
			},
			new List<string>
			{
				"Исторический",
				"Случайный",
				"СССР публикует Надя (✓Воротников)",
				"Немет, красный капитализм",
				"Борбей, новый регент",
				"Краус, два шага назад"
			},
			new List<string>
			{
				"Исторический",
				"Случайный",
				"Чаушеску, красная династия",
				"Апостол, назад к социализму",
				"Ввод войск (✓Воротников)",
				"Вердец, гражданская война"
			},
			new List<string>
			{
				"Исторический",
				"Случайный",
				"Живков, Югославия (✘Югославия)",
				"Младенов, монархо-социализм",
				"Солаков, болгаризация",
				"Лилов, капитализм и социализм"
			},
			new List<string>
			{
				"Исторический",
				"Случайный",
				"Яковлев (✘Куба)",
				"Воротников (✘Куба)",
				"Инцидент 1990"
			}
		});
	}

	// Token: 0x06000036 RID: 54 RVA: 0x00009F52 File Offset: 0x00008152
	public void Set(int[] currentSelectedChoices, string[] choiceTypeNames, List<string>[] choicesNames)
	{
		this.currentSelectedChoices = currentSelectedChoices;
		this.choicesNames = choicesNames;
		this.choiceTypeNames = choiceTypeNames;
		this.Repaint();
	}

	// Token: 0x06000037 RID: 55 RVA: 0x00009F70 File Offset: 0x00008170
	private void Repaint()
	{
		this.subWindow.gameObject.SetActive(this.selectedChoiceType != -1);
		if (this.selectedChoiceType != -1)
		{
			for (int i = 0; i < this.subButtons.Length; i++)
			{
				if (i > this.choicesNames[this.selectedChoiceType].Count - 1)
				{
					this.subButtons[i].gameObject.SetActive(false);
				}
				else
				{
					this.subButtons[i].gameObject.SetActive(true);
					this.subButtons[i].ChangeText(this.choicesNames[this.selectedChoiceType][i]);
					this.subButtons[i].ChangeSelected(this.currentSelectedChoices[this.selectedChoiceType] == i);
					this.subButtons[i].transform.localPosition = new Vector3((this.subWindowTR.localPosition.x + this.subWindowBL.localPosition.x) * 0.5f, Mathf.Lerp(this.subWindowTR.localPosition.y, this.subWindowBL.localPosition.y, (float)i / (float)(this.choicesNames[this.selectedChoiceType].Count - 1)), this.subButtons[i].transform.localPosition.z);
				}
			}
		}
		for (int j = 0; j < this.mainButtons.Length; j++)
		{
			if (j > this.choiceTypeNames.Length - 1)
			{
				this.mainButtons[j].gameObject.SetActive(false);
			}
			else
			{
				this.mainButtons[j].ChangeText(this.choiceTypeNames[j]);
				this.mainButtons[j].ChangeSelected(this.selectedChoiceType == j);
				this.mainButtons[j].transform.localPosition = new Vector3((this.mainWindowTR.localPosition.x + this.mainWindowBL.localPosition.x) * 0.5f, Mathf.Lerp(this.mainWindowTR.localPosition.y, this.mainWindowBL.localPosition.y, (float)j / (float)(this.choiceTypeNames.Length - 1)), this.mainButtons[j].transform.localPosition.z);
			}
		}
	}

	// Token: 0x06000038 RID: 56 RVA: 0x0000A1C0 File Offset: 0x000083C0
	public void ChoiceMade(int choiceType, int choiceValue)
	{
		Debug.Log(string.Format("Choice {0} is {1} now", choiceType, choiceValue));
		this.global1.allcountries[choiceType + 1].paths = choiceValue;
		this.game1.Repaint();
	}

	// Token: 0x06000039 RID: 57 RVA: 0x0000A1FD File Offset: 0x000083FD
	public void CloseSubWindow()
	{
		this.selectedChoiceType = -1;
		this.Repaint();
	}

	// Token: 0x0600003A RID: 58 RVA: 0x0000A20C File Offset: 0x0000840C
	public void ReceiveButtonPress(int num)
	{
		if (num >= 100)
		{
			num -= 100;
			this.selectedChoiceType = ((this.selectedChoiceType == num) ? -1 : num);
			this.Repaint();
			return;
		}
		this.currentSelectedChoices[this.selectedChoiceType] = num;
		this.ChoiceMade(this.selectedChoiceType, num);
		this.Repaint();
	}

	// Token: 0x0400003E RID: 62
	public Transform mainWindowTR;

	// Token: 0x0400003F RID: 63
	public Transform mainWindowBL;

	// Token: 0x04000040 RID: 64
	public Transform subWindowTR;

	// Token: 0x04000041 RID: 65
	public Transform subWindowBL;

	// Token: 0x04000042 RID: 66
	public Transform subWindow;

	// Token: 0x04000043 RID: 67
	public ChoiceButton[] mainButtons;

	// Token: 0x04000044 RID: 68
	public ChoiceButton[] subButtons;

	// Token: 0x04000045 RID: 69
	private int selectedChoiceType = -1;

	// Token: 0x04000046 RID: 70
	private int[] currentSelectedChoices;

	// Token: 0x04000047 RID: 71
	private string[] choiceTypeNames;

	// Token: 0x04000048 RID: 72
	private List<string>[] choicesNames;

	// Token: 0x04000049 RID: 73
	public GlobalScript global1;

	// Token: 0x0400004A RID: 74
	public GameStartScript game1;
}
