using System;
using System.IO;
using ReqEventsDLC;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200004A RID: 74
public class TimeScript : MonoBehaviour
{
	// Token: 0x06000158 RID: 344 RVA: 0x00155A50 File Offset: 0x00153C50
	private bool pastDate(int day, int month, int year)
	{
		return (this.global1.data[19] >= day && this.global1.data[20] == month && this.global1.data[21] == year) || (this.global1.data[20] > month && this.global1.data[21] == year) || this.global1.data[21] > year;
	}

	// Token: 0x06000159 RID: 345 RVA: 0x00155AC8 File Offset: 0x00153CC8
	private bool checkWas(int place, int num)
	{
		if (!this.events[place].activeSelf && !this.global1.event_done[num])
		{
			this.this_num_event = num;
			this.this_num_place = place;
		}
		return this.events[place].activeSelf || this.global1.event_done[num];
	}

	// Token: 0x0600015A RID: 346 RVA: 0x00155B22 File Offset: 0x00153D22
	private bool FindNumOfEvent(int num)
	{
		Debug.Log(num);
		return true;
	}

	// Token: 0x0600015B RID: 347 RVA: 0x00155B30 File Offset: 0x00153D30
	private void Awake()
	{
		this.map1 = GameObject.Find("MapChanges").GetComponent<MapChangesScript>();
		this.global1 = GameObject.Find("Global(Clone)").GetComponent<GlobalScript>();
		this.goto_economy = GameObject.Find("Button (2)").GetComponent<EvetnnashScript>();
		this.goto_pause = GameObject.Find("Button (0)").GetComponent<SpeedScript>();
		this.achieves = GameObject.Find("Ach(Clone)");
		if (this.global1.data[0] >= 49 && this.global1.data[0] <= 51)
		{
			this.yug1 = GameObject.Find("Yugoglobal(Clone)").GetComponent<Yugoglobal>();
			this.view.GetComponent<EvetnnashScript>().new_scene = "Creator";
			this.view.transform.GetChild(0).GetComponent<TextMesh>().text = this.yug1.science_text[51];
		}
		this.Repaint(false);
		if (this.global1.data[0] == 10 || this.global1.data[0] == 12 || this.global1.data[0] == 18)
		{
			this.newcountries.SetActive(true);
		}
		else
		{
			try
			{
				if (Application.platform == RuntimePlatform.WindowsPlayer)
				{
					if (File.Exists(Application.dataPath + "\\lefty".ToString() + ".txt"))
					{
						this.newcountries.SetActive(true);
					}
				}
				else if (File.Exists(Application.dataPath + "/lefty".ToString() + ".txt"))
				{
					this.newcountries.SetActive(true);
				}
			}
			catch
			{
			}
		}
		if (this.global1.data[0] == 5 && this.global1.data[59] == 1)
		{
			this.special[0].SetActive(true);
			this.donedone = true;
		}
		else if ((this.global1.data[0] == 6 && this.global1.data[59] == 2) || (this.global1.allcountries[6].paths == 4 && this.global1.event_done[1067]))
		{
			this.special[1].SetActive(true);
			this.donedone = true;
		}
		else if (this.special[0].activeSelf)
		{
			this.special[0].SetActive(false);
		}
		else if (this.special[1].activeSelf)
		{
			this.special[1].SetActive(false);
		}
		if (this.global1.neizucheno)
		{
			this.thishappened.SetActive(true);
			this.thishappened.GetComponent<ScienceHappenedScript>().this_num = 10;
			this.thishappened.GetComponent<ScienceHappenedScript>().IsHappened();
		}
		if (this.global1.data[20] == 13)
		{
			this.global1.data[20] = 1;
			this.global1.data[21]++;
		}
		this.Recrisis();
		if (this.global1.data[0] >= 49 && this.global1.data[0] <= 51)
		{
			this.CheckYugoWars();
		}
	}

	// Token: 0x0600015C RID: 348 RVA: 0x00155E50 File Offset: 0x00154050
	private void Autosasvemethod()
	{
		this.goto_pause.OnMouseDown();
		if (this.global1.iron_and_blood)
		{
			this.Autosavej.number = 5;
		}
		else
		{
			this.Autosavej.number = 1;
		}
		this.Autosavej.OnMouseDown();
	}

	// Token: 0x0600015D RID: 349 RVA: 0x00155E90 File Offset: 0x00154090
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && !this.map1.okno.active && !this.is_showed)
		{
			this.probel.GetComponent<SpeedScript>().Probel();
		}
		if (this.map1.okno.active && this.is_showed && this.global1.speed != 0)
		{
			this.global1.speed = 0;
		}
		this.now_time += (float)this.global1.speed * Time.deltaTime;
		if (this.now_time >= 8f)
		{
			this.now_time = 0f;
			this.Repaint(true);
		}
	}

	// Token: 0x0600015E RID: 350 RVA: 0x00155F44 File Offset: 0x00154144
	private void CheckYugoWars()
	{
		if (this.global1.data[14] <= 0)
		{
			this.global1.allcountries[15].Gosstroy = 9;
		}
		else if (this.global1.data[14] <= 2)
		{
			this.global1.allcountries[15].Gosstroy = 0;
		}
		else if (this.global1.data[14] <= 3)
		{
			this.global1.allcountries[15].Gosstroy = 1;
		}
		else
		{
			this.global1.allcountries[15].Gosstroy = 2;
		}
		this.global1.allcountries[15].isSEV = this.global1.allcountries[this.global1.data[0]].isSEV;
		this.global1.allcountries[15].isOVD = this.global1.allcountries[this.global1.data[0]].isOVD;
		this.global1.allcountries[15].Vyshi = this.global1.allcountries[this.global1.data[0]].Vyshi;
		if (this.global1.data[10] < 500 && this.yug1.gameState.battle_royal)
		{
			this.global1.data[10] = 500;
		}
		this.global1.data[135] = 0;
		if (!this.yug1.gameState.yugcountries[0].is_independent)
		{
			this.global1.data[135]++;
		}
		if (!this.yug1.gameState.yugcountries[1].is_independent)
		{
			this.global1.data[135]++;
		}
		if (!this.yug1.gameState.yugcountries[2].is_independent)
		{
			this.global1.data[135]++;
		}
		if (!this.yug1.gameState.yugcountries[3].is_independent)
		{
			this.global1.data[135]++;
		}
		if (!this.yug1.gameState.yugcountries[4].is_independent)
		{
			this.global1.data[135]++;
		}
		if (!this.yug1.gameState.yugcountries[5].is_independent)
		{
			this.global1.data[135]++;
		}
		if (!this.yug1.gameState.yugcountries[6].is_independent)
		{
			this.global1.data[135]++;
		}
		if (!this.yug1.gameState.yugcountries[7].is_independent)
		{
			this.global1.data[135]++;
		}
		if (!this.yug1.gameState.yugcountries[8].is_independent)
		{
			this.global1.data[135]++;
		}
		if (!this.yug1.gameState.yugcountries[9].is_independent)
		{
			this.global1.data[135]++;
		}
		if (!this.yug1.gameState.yugcountries[10].is_independent)
		{
			this.global1.data[135]++;
		}
		if (!this.yug1.gameState.yugcountries[11].is_independent)
		{
			this.global1.data[135]++;
		}
		if (this.yug1.gameState.battle_royal && this.yug1.gameState.yugcountries[11].is_exist && this.global1.event_done[102])
		{
			this.yug1.gameState.yugcountries[10].name = this.yug1.science_text[109];
		}
		else if (this.global1.allcountries[6].Gosstroy == 9 && this.global1.event_done[313])
		{
			this.yug1.gameState.yugcountries[10].name = this.yug1.science_text[109];
		}
		else if (this.global1.allcountries[20].Gosstroy == 9 && this.global1.event_done[315])
		{
			this.yug1.gameState.yugcountries[10].name = this.yug1.science_text[112];
		}
		if (this.global1.allcountries[5].Gosstroy == 9 && this.global1.event_done[39] && this.global1.event_done[313])
		{
			this.yug1.gameState.yugcountries[9].name = this.yug1.science_text[111];
		}
		if (this.global1.data[114] != 100)
		{
			if (this.global1.data[112] != 0)
			{
				if (this.global1.data[112] == 1)
				{
					if (PlayerPrefs.GetInt("language") == 0)
					{
						this.global1.politics_name[2] = "Drnovšek";
						this.global1.politics_charact[2] = "Democratizator";
					}
					else
					{
						this.global1.politics_name[2] = "Дрновшек";
						this.global1.politics_charact[2] = "Демократизатор";
					}
				}
				else if (this.global1.data[112] == 2)
				{
					if (PlayerPrefs.GetInt("language") == 0)
					{
						this.global1.politics_name[2] = "Bulc";
						this.global1.politics_charact[2] = "New Left";
					}
					else
					{
						this.global1.politics_name[2] = "Булц";
						this.global1.politics_charact[2] = "Новый левый";
					}
				}
				else if (this.global1.data[112] == 3)
				{
					if (PlayerPrefs.GetInt("language") == 0)
					{
						this.global1.politics_name[2] = "Jović";
						this.global1.politics_charact[2] = "Milosevic's puppet";
					}
					else
					{
						this.global1.politics_name[2] = "Йович";
						this.global1.politics_charact[2] = "Марионетка Милошевича";
					}
				}
				else if (this.global1.data[112] == 4)
				{
					if (PlayerPrefs.GetInt("language") == 0)
					{
						this.global1.politics_name[2] = "Šuvar";
						this.global1.politics_charact[2] = "Against separatism";
					}
					else
					{
						this.global1.politics_name[2] = "Шувар";
						this.global1.politics_charact[2] = "Борец с сепаратизмом";
					}
				}
				else if (this.global1.data[112] == 5)
				{
					if (PlayerPrefs.GetInt("language") == 0)
					{
						this.global1.politics_name[2] = "Mesić";
						this.global1.politics_charact[2] = "Croatian nationalist";
					}
					else
					{
						this.global1.politics_name[2] = "Месич";
						this.global1.politics_charact[2] = "Хорватский националист";
					}
				}
				else if (this.global1.data[112] == 6)
				{
					if (PlayerPrefs.GetInt("language") == 0)
					{
						this.global1.politics_name[2] = "Kostić";
						this.global1.politics_charact[2] = "Master of Compromises";
					}
					else
					{
						this.global1.politics_name[2] = "Костич";
						this.global1.politics_charact[2] = "Мастер компромиссов";
					}
				}
				else if (this.global1.data[112] == 7)
				{
					if (PlayerPrefs.GetInt("language") == 0)
					{
						this.global1.politics_name[2] = "Joška";
						this.global1.politics_charact[2] = "New Tito";
					}
					else
					{
						this.global1.politics_name[2] = "Йошка";
						this.global1.politics_charact[2] = "Новый Тито";
					}
				}
				else if (this.global1.data[112] == 8)
				{
					if (PlayerPrefs.GetInt("language") == 0)
					{
						this.global1.politics_name[2] = "Tripalo";
						this.global1.politics_charact[2] = "Left dissident";
					}
					else
					{
						this.global1.politics_name[2] = "Трипало";
						this.global1.politics_charact[2] = "Левый диссидент";
					}
				}
				else if (this.global1.data[112] == 9)
				{
					if (PlayerPrefs.GetInt("language") == 0)
					{
						this.global1.politics_name[2] = "Bajramović";
						this.global1.politics_charact[2] = "Fighter agains separatism";
					}
					else
					{
						this.global1.politics_name[2] = "Байрамович";
						this.global1.politics_charact[2] = "Борец с сепаратизмом";
					}
				}
				else if (this.global1.data[112] == 10)
				{
					if (PlayerPrefs.GetInt("language") == 0)
					{
						this.global1.politics_name[2] = "Marković";
						this.global1.politics_charact[2] = "Eminence red";
					}
					else
					{
						this.global1.politics_name[2] = "Маркович";
						this.global1.politics_charact[2] = "Красный кардинал";
					}
				}
				else if (this.global1.data[112] == 11)
				{
					if (PlayerPrefs.GetInt("language") == 0)
					{
						this.global1.politics_name[2] = "Latin";
						this.global1.politics_charact[2] = "Markovich's protégé";
					}
					else
					{
						this.global1.politics_name[2] = "Латин";
						this.global1.politics_charact[2] = "Протеже Марковича";
					}
				}
			}
		}
		else if (!this.yug1.gameState.battle_royal)
		{
			if (this.global1.data[0] == 49)
			{
				if (this.global1.data[150] == 0 && this.global1.data[148] == 0)
				{
					this.global1.data[11] = 0;
				}
				else if (this.global1.data[150] == 1 && this.global1.data[148] == 2)
				{
					this.global1.data[11] = 1;
				}
				else if (this.global1.data[150] == 1 && this.global1.data[148] == 1)
				{
					this.global1.data[11] = 2;
				}
				else if (this.global1.data[150] == 0 && this.global1.data[148] == 1)
				{
					this.global1.data[11] = 3;
				}
			}
			else if (this.global1.data[0] == 50)
			{
				if (this.global1.data[136] == 1 && this.global1.data[137] == 0)
				{
					this.global1.data[11] = 0;
				}
				else if (this.global1.data[136] == 0 && this.global1.data[138] == 0)
				{
					this.global1.data[11] = 3;
				}
				else if (this.global1.data[136] == 1 && this.global1.data[137] == 1)
				{
					this.global1.data[11] = 2;
				}
				else if (this.global1.data[136] == 0 && this.global1.data[138] == 1)
				{
					this.global1.data[11] = 1;
				}
			}
			else if (this.global1.data[0] == 51)
			{
				if (this.global1.data[116] == 1 && this.global1.data[118] == 1)
				{
					this.global1.data[11] = 0;
				}
				else if (this.global1.data[116] == 2 && this.global1.data[118] == 1)
				{
					this.global1.data[11] = 1;
				}
				else if ((this.global1.data[117] == 1 || this.global1.data[117] == 2) && this.global1.data[118] == 0)
				{
					this.global1.data[11] = 2;
				}
				else if (this.global1.data[117] == 0 && this.global1.data[118] == 0)
				{
					this.global1.data[11] = 3;
				}
			}
		}
		if (this.yug_little.yug1 == null)
		{
			this.yug_little.Awake();
		}
		else if (this.global1.data[19] % 7 == 0)
		{
			this.yug_little.Repaint();
		}
		if (this.yug1.gameState.regionUnderAttack >= 0)
		{
			this.global1.number_event = 354;
			SceneManager.LoadScene("Event");
			return;
		}
		for (int i = 0; i < this.yug1.gameState.regionsAttacked.Length; i++)
		{
			if (this.yug1.gameState.regionsAttacked[i] >= 0)
			{
				this.yug1.gameState.regionUnderAttack = this.yug1.gameState.regionsAttacked[i];
				this.yug1.gameState.who_attack = this.yug1.gameState.whoAttacked[i];
				this.yug1.gameState.regionsAttacked[i] = -1;
				this.yug1.gameState.whoAttacked[i] = -1;
				this.global1.number_event = 354;
				SceneManager.LoadScene("Event");
			}
		}
	}

	// Token: 0x0600015F RID: 351 RVA: 0x00156DB8 File Offset: 0x00154FB8
	public void Reborn()
	{
		if (!this.is_showed)
		{
			this.ending.SetActive(true);
			this.is_showed = true;
			this.save_speed = this.global1.speed;
			this.global1.speed = 0;
			return;
		}
		this.is_showed = false;
		this.ending.SetActive(false);
		this.global1.speed = this.save_speed;
	}

	// Token: 0x06000160 RID: 352 RVA: 0x00156E22 File Offset: 0x00155022
	private void Reelect()
	{
		this.vybory = false;
		this.global1.is_elect = true;
		this.global1.event_done[2] = true;
		this.global1.number_event = 2;
		SceneManager.LoadScene("Event");
	}

	// Token: 0x06000161 RID: 353 RVA: 0x00156E5B File Offset: 0x0015505B
	private void VyzovEvent(int number_event)
	{
		this.global1.event_done[number_event] = true;
		this.global1.number_event = number_event;
		SceneManager.LoadScene("Event");
	}

	// Token: 0x06000162 RID: 354 RVA: 0x00156E81 File Offset: 0x00155081
	private void DeathChoose(int this_event_n)
	{
		this.vybory = false;
		this.global1.is_elect = true;
		this.global1.event_done[this_event_n] = true;
		this.global1.number_event = this_event_n;
		SceneManager.LoadScene("Event");
	}

	// Token: 0x06000163 RID: 355 RVA: 0x00156EBC File Offset: 0x001550BC
	private void Recrisis()
	{
		for (int i = 0; i < this.re_war.Length; i++)
		{
			this.re_war[i].Repaint();
		}
		bool flag = false;
		if (this.global1.data[3] + this.global1.data[22] / 100 <= 300)
		{
			this.crisis[2].sprite = this.global1.crisis;
			this.crisis_color[2].color = Color.red;
			if (!flag)
			{
				this.crisis_show.SetActive(true);
				this.crisis_show.GetComponent<SpriteRenderer>().sprite = this.crisis_spr[0];
				this.crisis_show.GetComponent<OkoshkoScript>().text = "Народные беспорядки";
				this.crisis_show.GetComponent<OkoshkoScript>().text_en = "People's riots";
				flag = true;
			}
		}
		else if (this.crisis[2].sprite != null)
		{
			this.crisis[2].sprite = null;
			this.crisis_color[2].color = Color.white;
			if (!flag)
			{
				this.crisis_show.SetActive(false);
			}
		}
		if (this.global1.data[71] > 0)
		{
			this.crisis[4].sprite = this.global1.crisis;
			this.crisis_color[4].color = Color.red;
		}
		else if (this.crisis[4].sprite != null)
		{
			this.crisis[4].sprite = null;
			this.crisis_color[4].color = Color.white;
		}
		if (this.global1.data[4] - this.global1.data[22] / 10 >= 840 || (this.global1.data[3] <= 450 && this.global1.data[4] - this.global1.data[22] / 10 >= 750) || (this.global1.data[3] <= 650 && this.global1.data[4] - this.global1.data[22] / 10 >= 800))
		{
			if ((this.global1.data[3] <= 450 && this.global1.data[4] - this.global1.data[22] / 10 >= 750) || (this.global1.data[3] <= 650 && this.global1.data[4] - this.global1.data[22] / 10 >= 800))
			{
				this.crisis[2].sprite = this.global1.crisis;
				this.crisis[3].sprite = this.global1.crisis;
				this.crisis_color[2].color = Color.red;
				this.crisis_color[3].color = Color.red;
				if (!flag)
				{
					this.crisis_show.SetActive(true);
					this.crisis_show.GetComponent<SpriteRenderer>().sprite = this.crisis_spr[0];
					this.crisis_show.GetComponent<OkoshkoScript>().text = "Народные беспорядки";
					this.crisis_show.GetComponent<OkoshkoScript>().text_en = "People's riots";
					flag = true;
				}
			}
			else if (this.global1.data[4] - this.global1.data[22] / 10 >= 840)
			{
				this.crisis[3].sprite = this.global1.crisis;
				this.crisis_color[3].color = Color.red;
				if (!flag)
				{
					this.crisis_show.SetActive(true);
					this.crisis_show.GetComponent<SpriteRenderer>().sprite = this.crisis_spr[0];
					this.crisis_show.GetComponent<OkoshkoScript>().text = "Народные беспорядки";
					this.crisis_show.GetComponent<OkoshkoScript>().text_en = "People's riots";
					flag = true;
				}
			}
		}
		else if (this.crisis[3].sprite != null)
		{
			this.crisis[3].sprite = null;
			this.crisis_color[3].color = Color.white;
			if (!flag)
			{
				this.crisis_show.SetActive(false);
			}
		}
		if (this.global1.data[1] < 400 || (this.global1.data[1] < 550 && this.global1.data[2] + this.global1.data[22] / 5 <= 550))
		{
			if (this.global1.data[1] < 400)
			{
				this.crisis[0].sprite = this.global1.crisis;
				this.crisis_color[0].color = Color.red;
				if (!flag)
				{
					this.crisis_show.SetActive(true);
					this.crisis_show.GetComponent<SpriteRenderer>().sprite = this.crisis_spr[1];
					this.crisis_show.GetComponent<OkoshkoScript>().text = "Волнения в Партии";
					this.crisis_show.GetComponent<OkoshkoScript>().text_en = "Unrest in the Party";
				}
			}
			else if (this.global1.data[1] < 550 && this.global1.data[2] + this.global1.data[22] / 5 <= 550)
			{
				this.crisis[0].sprite = this.global1.crisis;
				this.crisis_color[0].color = Color.red;
				this.crisis[1].sprite = this.global1.crisis;
				this.crisis_color[1].color = Color.red;
				if (!flag)
				{
					this.crisis_show.SetActive(true);
					this.crisis_show.GetComponent<SpriteRenderer>().sprite = this.crisis_spr[1];
					this.crisis_show.GetComponent<OkoshkoScript>().text = "Волнения в Партии";
					this.crisis_show.GetComponent<OkoshkoScript>().text_en = "Unrest in the Party";
				}
			}
		}
		else if (this.crisis[0].sprite != null)
		{
			this.crisis[0].sprite = null;
			this.crisis_color[0].color = Color.white;
			this.crisis_color[1].color = Color.white;
			if (!flag)
			{
				this.crisis_show.SetActive(false);
			}
		}
		if (!this.donedone)
		{
			if (this.global1.data[0] == 5 && this.global1.data[59] == 1)
			{
				this.special[0].SetActive(true);
			}
			else if (this.global1.data[0] == 6 && this.global1.data[59] == 2)
			{
				this.special[1].SetActive(true);
			}
			this.donedone = true;
		}
	}

	// Token: 0x06000164 RID: 356 RVA: 0x001575A4 File Offset: 0x001557A4
	private void YugoModifiesChanges()
	{
		if (this.yug1.gameState.modifies[1] == 1)
		{
			this.global1.data[4] -= 5;
			this.global1.data[31] -= 5;
		}
		if (this.yug1.gameState.modifies[2] == 1)
		{
			if (this.global1.data[19] == 7)
			{
				this.global1.data[3] += 3;
			}
		}
		else if (this.yug1.gameState.modifies[2] == 2)
		{
			if (this.global1.data[19] == 7)
			{
				this.global1.data[3] += 3;
				this.global1.data[4] -= 3;
				this.global1.data[8] += 5;
			}
		}
		else if (this.yug1.gameState.modifies[2] == 3)
		{
			if (this.global1.data[19] == 7)
			{
				this.global1.data[3] += 3;
				this.global1.data[4] -= 3;
				this.global1.data[8] += 2;
			}
		}
		else if (this.yug1.gameState.modifies[2] == 4)
		{
			this.global1.data[3]++;
			this.global1.data[4] -= 4;
			this.global1.data[8] -= 6;
			this.global1.data[9] -= 2;
		}
		if (this.yug1.gameState.modifies[3] == 1)
		{
			this.global1.data[9] += 25;
			this.global1.data[8] += 25;
		}
		if (this.yug1.gameState.modifies[4] == 1)
		{
			this.global1.data[3] += 20;
			this.global1.data[9] -= 5;
			this.global1.data[8] -= 5;
			this.global1.data[31] -= 5;
		}
		if (this.yug1.gameState.modifies[5] == 1)
		{
			this.global1.data[3] += 15;
			this.global1.data[9] -= 10;
			this.global1.data[31] += 5;
		}
		if (this.yug1.gameState.modifies[6] == 1)
		{
			this.global1.data[8] -= 10;
			this.global1.data[26] -= 25;
			this.global1.data[1] += 10;
			if (this.global1.data[26] <= 0)
			{
				this.yug1.gameState.modifies[6] = 0;
			}
		}
		else if (this.yug1.gameState.modifies[6] == 2)
		{
			this.global1.data[8] -= 2;
			this.global1.data[26] -= 5;
			if (this.global1.data[26] <= 0)
			{
				this.yug1.gameState.modifies[6] = 0;
			}
		}
		if (this.yug1.gameState.modifies[7] == 1)
		{
			this.global1.data[10] += 15;
			this.global1.data[6] += 5;
			this.global1.data[8] -= 5;
		}
		if (this.yug1.gameState.modifies[8] >= 1 && this.yug1.gameState.modifies[8] <= 4)
		{
			this.global1.data[8] += 7;
			this.yug1.gameState.modifies[8]++;
		}
		if (this.yug1.gameState.modifies[9] == 1)
		{
			if (this.global1.data[19] == 7 && this.global1.data[20] % 3 == 0)
			{
				this.global1.data[9] += 40;
				this.global1.data[8] += 20;
			}
		}
		else if (this.yug1.gameState.modifies[9] == 2 && this.global1.data[19] == 7 && this.global1.data[20] % 3 == 0)
		{
			this.global1.data[9] += 20;
		}
		if (this.yug1.gameState.modifies[10] == 1)
		{
			this.global1.data[9] += 20;
		}
		if (this.yug1.gameState.modifies[11] == 1)
		{
			if (this.global1.data[19] == 7 && this.global1.data[20] % 3 == 0)
			{
				this.global1.data[9] += 60;
				this.global1.data[8] += 10;
			}
		}
		else if (this.yug1.gameState.modifies[11] == 2 && this.global1.data[19] == 7)
		{
			this.global1.data[9] += 60;
			this.global1.data[8] += 10;
		}
		if (this.yug1.gameState.modifies[12] == 1)
		{
			this.global1.data[3] -= 30;
			this.global1.data[31] -= 3;
		}
		else if (this.yug1.gameState.modifies[12] == 2)
		{
			this.global1.data[3] += 10;
			this.global1.data[9] -= 3;
			this.global1.data[31] += 5;
		}
		else if (this.yug1.gameState.modifies[12] == 3)
		{
			this.global1.data[3] += 10;
			this.global1.data[9]--;
			this.global1.data[8]--;
			this.global1.data[31] -= 5;
			if (this.global1.data[19] == 7 && this.global1.data[20] % 6 == 0)
			{
				this.global1.data[115]++;
			}
		}
		else if (this.yug1.gameState.modifies[12] == 4)
		{
			this.global1.data[1] -= 3;
			this.global1.data[9] -= 10;
			this.global1.data[31] += 5;
		}
		else if (this.yug1.gameState.modifies[12] == 5)
		{
			this.global1.data[3] += 10;
			this.global1.data[9] += 5;
			this.global1.data[8] += 5;
			this.global1.data[31] -= 3;
			if (this.global1.data[19] == 7 && this.global1.data[20] % 6 == 0)
			{
				this.global1.data[115]++;
			}
		}
		else if (this.yug1.gameState.modifies[12] == 6)
		{
			if (this.global1.data[20] >= 2 && this.global1.data[21] == 1991)
			{
				this.yug1.gameState.modifies[12] = 0;
			}
			else
			{
				this.global1.data[3] -= 4;
				this.global1.data[9] -= 5;
				this.global1.data[31] += 5;
			}
		}
		else if (this.yug1.gameState.modifies[12] == 7)
		{
			this.global1.data[3] -= 2;
			this.global1.data[9] -= 3;
			this.global1.data[31] += 5;
		}
		if (this.global1.data[21] >= 1991)
		{
			this.yug1.gameState.modifies[12] = 0;
		}
		if (this.yug1.gameState.modifies[13] == 1)
		{
			this.global1.data[3] -= 5;
			this.global1.data[9] -= 5;
			this.global1.data[4] += 10;
		}
		if (this.yug1.gameState.modifies[14] == 1)
		{
			this.global1.data[9] += 5;
			this.global1.data[8] -= 10;
			this.global1.data[6] += 5;
			this.global1.data[4] -= 15;
		}
		if (this.yug1.gameState.modifies[15] == 1)
		{
			this.global1.data[9] += 7;
			this.global1.data[1] += 5;
			this.global1.data[3] += 10;
		}
		if (this.yug1.gameState.modifies[16] == 1)
		{
			this.global1.data[9] -= 10;
			this.global1.data[8] -= 10;
		}
		if (this.yug1.gameState.modifies[17] == 1)
		{
			this.global1.data[8] -= 5;
			this.global1.data[3] -= 2;
			this.global1.data[4] += 5;
			this.global1.data[26] -= 25;
			this.global1.data[1] += 5;
			this.global1.data[1]--;
		}
		if (this.yug1.gameState.modifies[18] == 1)
		{
			this.global1.data[8] -= 2;
			this.global1.data[5] -= 2;
		}
		if (this.yug1.gameState.modifies[19] == 1)
		{
			this.global1.data[9] -= 4;
			if (this.global1.science[2])
			{
				this.yug1.gameState.modifies[19] = 0;
			}
		}
		if (this.yug1.gameState.modifies[20] == 1)
		{
			this.global1.data[4] -= 4;
		}
		if (this.yug1.gameState.modifies[21] == 1 && this.global1.data[19] == 7)
		{
			this.global1.data[3] -= 4;
			this.global1.data[1] -= 4;
		}
		if (this.yug1.gameState.modifies[20] == 1)
		{
			this.global1.data[9] -= 3;
			this.global1.data[3] -= 2;
		}
		else if (this.yug1.gameState.modifies[20] == 2)
		{
			this.global1.data[8] -= 3;
			this.global1.data[3] -= 2;
		}
		if (this.yug1.gameState.modifies[21] == 1)
		{
			this.global1.data[6] += 2;
			this.global1.data[3] -= 3;
		}
		else if (this.yug1.gameState.modifies[21] == 2)
		{
			this.global1.data[10] += 3;
			this.global1.data[6] -= 3;
		}
		if (this.yug1.gameState.modifies[22] == 1)
		{
			this.global1.data[6] += 2;
			this.global1.data[3] -= 3;
		}
		else if (this.yug1.gameState.modifies[22] == 2)
		{
			this.global1.data[10] += 3;
			this.global1.data[6] -= 3;
		}
		if (this.yug1.gameState.modifies[23] == 1)
		{
			this.global1.data[9] -= 2;
			this.global1.data[1]--;
			this.global1.data[3]--;
			this.global1.data[6]++;
		}
	}

	// Token: 0x06000165 RID: 357 RVA: 0x0015849C File Offset: 0x0015669C
	private void YugoEvents()
	{
		Debug.Log("YUGEVENSTART");
		if (this.global1.data[162] != 3 && this.global1.data[20] >= 4 && this.global1.data[21] == 1989 && this.global1.data[0] == 51 && !this.events[15].activeSelf && !this.global1.event_done[266])
		{
			this.this_num_event = 266;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 15 && this.global1.data[20] >= 5 && this.global1.data[21] == 1991 && this.global1.data[128] == 0 && !this.global1.event_done[305] && !this.global1.event_done[306] && !this.global1.event_done[307] && !this.global1.event_done[312] && this.global1.data[115] >= 15 && this.global1.data[126] >= 1 && !this.events[15].activeSelf && !this.global1.event_done[308])
		{
			this.this_num_event = 308;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.allcountries[7].paths <= 0 && !this.global1.allcountries[7].isOVD && !this.global1.allcountries[7].isSEV && !this.global1.is_gkchp && this.global1.allcountries[7].paths != 2 && this.global1.data[162] != 3 && ((this.global1.data[126] == 0 && this.global1.data[115] <= 3 && ((this.yug1.gameState.yugregions[1].owner == this.yug1.gameState.player && !this.yug1.gameState.yugcountries[1].peace_with[8]) || !this.yug1.gameState.yugcountries[1].peace_with[0] || !this.yug1.gameState.yugcountries[1].peace_with[3] || !this.yug1.gameState.yugcountries[1].peace_with[11] || (this.yug1.gameState.yugregions[3].owner == this.yug1.gameState.player && !this.yug1.gameState.yugcountries[3].peace_with[8]) || !this.yug1.gameState.yugcountries[3].peace_with[0] || !this.yug1.gameState.yugcountries[3].peace_with[1] || !this.yug1.gameState.yugcountries[3].peace_with[11] || (this.yug1.gameState.yugregions[8].owner == this.yug1.gameState.player && !this.yug1.gameState.yugcountries[8].peace_with[1]) || !this.yug1.gameState.yugcountries[8].peace_with[0] || !this.yug1.gameState.yugcountries[8].peace_with[3] || !this.yug1.gameState.yugcountries[8].peace_with[11])) || (this.global1.data[161] == 4 && this.global1.data[114] != 100 && this.global1.data[52] == 3)) && !this.events[7].activeSelf && !this.global1.event_done[62])
		{
			this.this_num_event = 62;
			this.this_num_place = 7;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if ((this.global1.data[4] >= 980 || this.global1.data[1] <= 300 || this.global1.data[3] <= 300) && this.global1.data[162] <= 2 && !this.events[15].activeSelf && !this.global1.event_done[312])
		{
			this.this_num_event = 317;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if ((this.pastDate(this.global1.data[49], 9, 1990) || (this.global1.data[7] <= 600 && this.global1.event_done[1066])) && this.global1.allcountries[6].paths == 4 && !this.checkWas(15, 361))
		{
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 17 && this.global1.data[20] >= 6 && this.global1.data[21] == 1989 && this.global1.data[0] == 51 && !this.events[15].activeSelf && !this.global1.event_done[267])
		{
			this.this_num_event = 267;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 11 && this.global1.data[20] >= 12 && this.global1.data[21] == 1989 && !this.events[15].activeSelf && !this.global1.event_done[268])
		{
			this.this_num_event = 268;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 24 && this.global1.data[20] >= 2 && this.global1.data[21] == 1990 && this.global1.data[118] == 0 && this.global1.data[115] >= 3 && this.global1.data[117] == 1 && this.global1.data[116] == 2 && this.global1.data[0] == 51 && !this.events[15].activeSelf && !this.global1.event_done[269])
		{
			this.this_num_event = 269;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 24 && this.global1.data[20] >= 2 && this.global1.data[21] == 1990 && this.global1.data[118] == 1 && this.global1.data[0] == 51 && !this.events[15].activeSelf && !this.global1.event_done[270])
		{
			this.this_num_event = 270;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 22 && this.global1.data[20] >= 4 && this.global1.data[21] == 1990 && !this.events[15].activeSelf && !this.global1.event_done[271])
		{
			this.this_num_event = 271;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 13 && this.global1.data[20] >= 5 && this.global1.data[21] == 1990 && this.global1.data[118] == 1 && this.global1.data[150] == 1 && this.global1.data[0] == 51 && !this.events[15].activeSelf && !this.global1.event_done[272])
		{
			this.this_num_event = 272;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && ((this.global1.data[20] >= 6 && this.global1.data[21] >= 1990) || this.global1.data[21] >= 1991) && this.global1.data[168] == 0 && this.global1.data[12] != 2 && this.global1.data[116] == 1 && this.global1.data[118] == 1 && !this.events[15].activeSelf && !this.global1.event_done[273])
		{
			this.this_num_event = 273;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.event_done[273] && this.global1.data[12] != 2 && this.global1.data[116] == 1 && this.global1.data[118] == 1 && !this.yug1.gameState.yugcountries[2].is_exist && !this.events[15].activeSelf && !this.global1.event_done[274])
		{
			this.this_num_event = 274;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 17 && this.global1.data[20] >= 8 && this.global1.data[21] == 1990 && this.global1.data[116] == 1 && this.yug1.gameState.yugcountries[2].is_exist && !this.events[15].activeSelf && !this.global1.event_done[275])
		{
			this.this_num_event = 275;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 19 && this.global1.data[20] >= 5 && this.global1.data[21] == 1991 && this.global1.data[168] == 0 && this.global1.data[116] == 1 && this.yug1.gameState.yugcountries[8].peace_with[1] && !this.events[15].activeSelf && !this.global1.event_done[276])
		{
			this.this_num_event = 276;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 14 && this.global1.data[20] >= 9 && this.global1.data[21] == 1991 && this.global1.data[168] == 0 && this.global1.data[116] == 1 && this.yug1.gameState.yugcountries[2].is_exist && this.yug1.gameState.yugcountries[8].peace_with[1] && this.yug1.gameState.yugregions[1].owner == 1 && !this.events[15].activeSelf && !this.global1.event_done[277])
		{
			this.this_num_event = 277;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 3 && this.global1.data[20] >= 9 && this.global1.data[21] == 1991 && this.global1.data[131] == 0 && this.global1.data[168] == 0 && this.global1.data[116] == 1 && this.global1.data[0] == 51 && (this.yug1.gameState.yugcountries[8].peace_with[1] || this.yug1.gameState.yugregions[8].owner == 1) && !this.yug1.gameState.yugcountries[2].is_exist && !this.events[15].activeSelf && !this.global1.event_done[278])
		{
			this.this_num_event = 278;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 22 && this.global1.data[20] >= 1 && this.global1.data[21] == 1991 && this.global1.data[0] == 51 && this.global1.data[117] == 2 && !this.events[15].activeSelf && !this.global1.event_done[279])
		{
			this.this_num_event = 279;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 6 && this.global1.data[20] >= 4 && this.global1.data[21] == 1991 && this.global1.data[0] == 51 && this.global1.data[117] == 2 && this.global1.data[116] == 1 && !this.events[15].activeSelf && !this.global1.event_done[280])
		{
			this.this_num_event = 280;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 22 && this.global1.data[20] >= 6 && this.global1.data[21] == 1990 && this.global1.data[117] == 2 && this.global1.data[0] == 51 && !this.events[15].activeSelf && !this.global1.event_done[281])
		{
			this.this_num_event = 281;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 2 && this.global1.data[20] >= 2 && this.global1.data[21] == 1989 && !this.events[15].activeSelf && !this.global1.event_done[282])
		{
			this.this_num_event = 282;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 4 && this.global1.data[20] >= 3 && this.global1.data[21] == 1989 && !this.events[15].activeSelf && !this.global1.event_done[283])
		{
			this.this_num_event = 283;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 1 && this.global1.data[20] >= 4 && this.global1.data[21] == 1989 && !this.events[15].activeSelf && !this.global1.event_done[284])
		{
			this.this_num_event = 284;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 15 && this.global1.data[20] >= 6 && this.global1.data[21] == 1989 && !this.events[15].activeSelf && !this.global1.event_done[285])
		{
			this.this_num_event = 285;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 1 && this.global1.data[20] >= 9 && this.global1.data[21] == 1989 && this.global1.data[157] != 0 && !this.events[15].activeSelf && !this.global1.event_done[286])
		{
			this.this_num_event = 286;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[19] >= 3 && this.global1.data[20] >= 11 && this.global1.data[21] == 1989 && !this.events[15].activeSelf && !this.global1.event_done[287])
		{
			this.this_num_event = 287;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 18 && this.global1.data[20] >= 1 && this.global1.data[21] == 1990 && !this.events[15].activeSelf && !this.global1.event_done[288])
		{
			this.this_num_event = 288;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 20 && this.global1.data[20] >= 1 && this.global1.data[21] == 1990 && !this.events[15].activeSelf && !this.global1.event_done[289])
		{
			this.this_num_event = 289;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 21 && this.global1.data[20] >= 1 && this.global1.data[21] == 1990 && !this.events[15].activeSelf && !this.global1.event_done[290])
		{
			this.this_num_event = 290;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 22 && this.global1.data[20] >= 1 && this.global1.data[21] == 1990 && !this.events[15].activeSelf && !this.global1.event_done[291])
		{
			this.this_num_event = 291;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 23 && this.global1.data[20] >= 1 && this.global1.data[21] == 1990 && this.global1.data[127] == 1 && this.global1.data[126] >= 1 && !this.events[15].activeSelf && !this.global1.event_done[292])
		{
			this.this_num_event = 292;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 24 && this.global1.data[20] >= 1 && this.global1.data[21] == 1990 && this.global1.data[123] == 1 && this.global1.data[126] >= 1 && !this.global1.event_done[293])
		{
			this.this_num_event = 293;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 25 && this.global1.data[20] >= 1 && this.global1.data[21] == 1990 && this.global1.data[126] >= 1 && !this.events[15].activeSelf && !this.global1.event_done[294])
		{
			this.this_num_event = 294;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[124] == 0 && this.global1.data[126] == 1 && !this.events[15].activeSelf && !this.global1.event_done[295])
		{
			this.this_num_event = 295;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 4 && this.global1.data[20] >= 3 && this.global1.data[21] == 1990 && !this.events[15].activeSelf && !this.global1.event_done[296])
		{
			this.this_num_event = 296;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 25 && this.global1.data[20] >= 3 && this.global1.data[21] == 1990 && !this.events[15].activeSelf && !this.global1.event_done[297])
		{
			this.this_num_event = 297;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 1 && this.global1.data[20] >= 4 && this.global1.data[21] == 1990 && !this.events[15].activeSelf && !this.global1.event_done[298])
		{
			this.this_num_event = 298;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 5 && this.global1.data[20] >= 5 && this.global1.data[21] == 1990 && !this.events[15].activeSelf && !this.global1.event_done[299])
		{
			this.this_num_event = 299;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 7 && this.global1.data[20] >= 8 && this.global1.data[21] == 1990 && this.global1.data[125] == 1 && !this.events[15].activeSelf && !this.global1.event_done[300])
		{
			this.this_num_event = 300;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 23 && this.global1.data[20] >= 12 && this.global1.data[21] == 1990 && this.global1.data[157] == 2 && !this.events[15].activeSelf && !this.global1.event_done[301])
		{
			this.this_num_event = 301;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 5 && this.global1.data[20] >= 4 && this.global1.data[21] == 1989 && !this.events[15].activeSelf && !this.global1.event_done[302])
		{
			this.this_num_event = 302;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 15 && this.global1.data[20] >= 5 && this.global1.data[21] == 1989 && !this.events[15].activeSelf && !this.global1.event_done[303])
		{
			this.this_num_event = 303;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 15 && this.global1.data[20] >= 5 && this.global1.data[21] == 1990 && !this.events[15].activeSelf && !this.global1.event_done[312] && !this.global1.event_done[304])
		{
			this.this_num_event = 304;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 15 && this.global1.data[20] >= 5 && this.global1.data[21] == 1991 && this.yug1.gameState.yugregions[1].owner == 1 && this.global1.data[128] == 2 && !this.global1.event_done[312] && !this.yug1.gameState.yugcountries[1].is_independent && !this.events[15].activeSelf && !this.global1.event_done[305])
		{
			this.this_num_event = 305;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 15 && this.global1.data[20] >= 5 && this.global1.data[21] == 1991 && this.yug1.gameState.modifies[5] == 0 && (this.global1.data[128] == 0 || this.global1.data[128] == 1 || this.global1.data[169] == 1) && !this.global1.event_done[312] && !this.events[15].activeSelf && !this.global1.event_done[308] && !this.global1.event_done[306])
		{
			this.this_num_event = 306;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 15 && this.global1.data[20] >= 5 && this.global1.data[21] == 1991 && !this.global1.event_done[312] && ((this.global1.data[128] == 2 && this.yug1.gameState.yugcountries[1].is_independent) || (this.global1.data[112] == 9 && this.yug1.gameState.yugcountries[10].is_independent && this.yug1.gameState.yugregions[10].owner == 10)) && !this.events[15].activeSelf && !this.global1.event_done[307])
		{
			this.this_num_event = 307;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 1 && this.global1.data[20] >= 7 && this.global1.data[21] == 1991 && this.global1.data[129] == 1 && !this.global1.event_done[312] && this.global1.data[168] != 0 && !this.events[15].activeSelf && !this.global1.event_done[309])
		{
			this.this_num_event = 309;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[132] == 5 && this.global1.data[128] == 2 && !this.global1.event_done[312] && !this.events[15].activeSelf && !this.global1.event_done[310])
		{
			this.this_num_event = 310;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 25 && this.global1.data[20] >= 6 && this.global1.data[21] == 1991 && this.global1.data[168] == 0 && this.global1.data[157] == 2 && !this.events[15].activeSelf && !this.global1.event_done[311])
		{
			this.this_num_event = 311;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[135] <= 9 && !this.events[15].activeSelf && !this.global1.event_done[312])
		{
			this.this_num_event = 312;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[131] == 1 && this.global1.data[135] <= 11 && this.global1.data[19] >= 1 && this.global1.data[20] >= 9 && !this.events[15].activeSelf && !this.global1.event_done[313])
		{
			this.this_num_event = 313;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && ((this.global1.data[20] >= 5 && this.global1.data[21] >= 1990) || this.global1.data[21] > 1990) && !this.events[15].activeSelf && !this.global1.event_done[314])
		{
			this.this_num_event = 314;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[130] == 0 && !this.events[15].activeSelf && !this.global1.event_done[315])
		{
			this.this_num_event = 315;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 8 && this.global1.data[20] >= 9 && this.global1.data[21] == 1991 && this.global1.data[130] == 3 && !this.events[15].activeSelf && !this.global1.event_done[316])
		{
			this.this_num_event = 316;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 2 && this.global1.data[20] >= 5 && this.global1.data[21] == 1989 && this.global1.data[0] == 50 && !this.events[15].activeSelf && !this.global1.event_done[318])
		{
			this.this_num_event = 318;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 2 && this.global1.data[20] >= 12 && this.global1.data[21] == 1989 && this.global1.data[0] == 50 && !this.events[15].activeSelf && !this.global1.event_done[319])
		{
			this.this_num_event = 319;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 26 && this.global1.data[20] >= 3 && this.global1.data[21] == 1990 && this.global1.data[0] == 50 && !this.events[15].activeSelf && !this.global1.event_done[320])
		{
			this.this_num_event = 320;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 2 && this.global1.data[20] >= 9 && this.global1.data[21] == 1990 && this.global1.data[0] == 50 && !this.events[15].activeSelf && !this.global1.event_done[321])
		{
			this.this_num_event = 321;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 18 && this.global1.data[20] >= 11 && this.global1.data[21] == 1990 && this.global1.data[0] == 50 && !this.events[15].activeSelf && !this.global1.event_done[322])
		{
			this.this_num_event = 322;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 1 && this.global1.data[20] >= 3 && this.global1.data[21] == 1991 && this.global1.data[0] == 50 && !this.events[15].activeSelf && !this.global1.event_done[323])
		{
			this.this_num_event = 323;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 25 && this.global1.data[20] >= 3 && this.global1.data[21] == 1991 && this.global1.data[136] == 1 && this.global1.data[0] == 50 && this.global1.data[128] == 2 && this.global1.data[148] == 2 && this.yug1.gameState.yugregions[1].owner == 1 && !this.events[15].activeSelf && !this.global1.event_done[324])
		{
			this.this_num_event = 324;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 3 && this.global1.data[20] >= 4 && this.global1.data[21] == 1991 && this.global1.data[0] == 50 && this.global1.data[139] == 1 && !this.events[15].activeSelf && !this.global1.event_done[325])
		{
			this.this_num_event = 325;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[19] >= 10 && this.global1.data[20] >= 4 && this.global1.data[21] == 1991 && this.global1.data[0] == 50 && this.global1.data[136] == 1 && this.global1.data[137] == 0 && !this.events[15].activeSelf && !this.global1.event_done[326])
		{
			this.this_num_event = 326;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 2 && this.global1.data[20] >= 5 && this.global1.data[21] == 1991 && this.global1.data[0] == 50 && this.global1.data[136] == 1 && !this.events[15].activeSelf && !this.global1.event_done[327])
		{
			this.this_num_event = 327;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 3 && this.global1.data[20] >= 6 && this.global1.data[138] == 0 && this.global1.data[21] == 1991 && this.global1.data[136] == 1 && this.global1.data[0] == 50 && this.global1.data[115] <= 10 && !this.events[15].activeSelf && !this.global1.event_done[328])
		{
			this.this_num_event = 328;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 24 && this.global1.data[20] >= 7 && this.global1.data[21] == 1991 && this.global1.data[168] == 0 && this.global1.data[0] == 50 && !this.events[15].activeSelf && !this.global1.event_done[329])
		{
			this.this_num_event = 329;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 14 && this.global1.data[20] >= 10 && this.global1.data[21] == 1991 && this.global1.data[168] == 0 && this.global1.data[0] == 50 && this.global1.data[136] == 1 && !this.events[15].activeSelf && !this.global1.event_done[330])
		{
			this.this_num_event = 330;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 7 && this.global1.data[20] >= 10 && this.global1.data[21] == 1991 && !this.yug1.gameState.yugcountries[1].peace_with[8] && this.yug1.gameState.yugregions[1].owner == 1 && !this.events[15].activeSelf && !this.global1.event_done[331])
		{
			this.this_num_event = 331;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 14 && this.global1.data[20] >= 11 && this.global1.data[21] == 1991 && this.global1.allcountries[7].Gosstroy == 2 && (this.global1.data[140] >= 3 || this.global1.data[141] >= 3 || this.global1.data[143] >= 3) && !this.events[15].activeSelf && !this.global1.event_done[332])
		{
			this.this_num_event = 332;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 10 && this.global1.data[20] >= 1 && this.global1.data[21] == 1989 && !this.events[15].activeSelf && !this.global1.event_done[333])
		{
			this.this_num_event = 333;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 20 && this.global1.data[20] >= 2 && this.global1.data[21] == 1989 && this.global1.data[0] == 49 && !this.events[15].activeSelf && !this.global1.event_done[334])
		{
			this.this_num_event = 334;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 28 && this.global1.data[20] >= 2 && this.global1.data[21] == 1989 && this.global1.data[0] == 49 && !this.events[15].activeSelf && !this.global1.event_done[335])
		{
			this.this_num_event = 335;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 20 && this.global1.data[20] >= 3 && this.global1.data[21] == 1989 && !this.events[15].activeSelf && !this.global1.event_done[336])
		{
			this.this_num_event = 336;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 28 && this.global1.data[20] >= 3 && this.global1.data[21] == 1989 && this.global1.data[0] == 49 && !this.events[15].activeSelf && !this.global1.event_done[337])
		{
			this.this_num_event = 337;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 28 && this.global1.data[20] >= 6 && this.global1.data[21] == 1989 && this.global1.data[0] == 49 && !this.events[15].activeSelf && !this.global1.event_done[338])
		{
			this.this_num_event = 338;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 2 && this.global1.data[20] >= 12 && this.global1.data[21] == 1989 && !this.events[15].activeSelf && !this.global1.event_done[339])
		{
			this.this_num_event = 339;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.yug1.gameState.yugcountries[10].is_independent && this.global1.data[0] == 49 && !this.events[15].activeSelf && !this.global1.event_done[340])
		{
			this.this_num_event = 340;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[19] >= 3 && this.global1.data[20] >= 7 && this.global1.data[21] == 1990 && this.global1.data[0] == 49 && this.global1.data[126] == 0 && !this.events[15].activeSelf && !this.global1.event_done[341])
		{
			this.this_num_event = 341;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 23 && this.global1.data[20] >= 9 && this.global1.data[21] == 1990 && this.global1.data[0] == 49 && this.global1.data[152] >= 1 && !this.events[15].activeSelf && !this.global1.event_done[342])
		{
			this.this_num_event = 342;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 3 && this.global1.data[20] >= 11 && this.global1.data[21] == 1990 && this.global1.data[0] == 49 && this.global1.data[147] == 1 && !this.events[15].activeSelf && !this.global1.event_done[343])
		{
			this.this_num_event = 343;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 9 && this.global1.data[20] >= 12 && this.global1.data[21] == 1990 && ((this.global1.data[147] == 1 && this.yug1.gameState.yugcountries[8].is_player) || this.yug1.gameState.yugcountries[1].is_player || this.yug1.gameState.yugcountries[3].is_player) && !this.events[15].activeSelf && !this.global1.event_done[344])
		{
			this.this_num_event = 344;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 9 && this.global1.data[20] >= 3 && this.global1.data[21] == 1991 && this.global1.data[0] == 49 && this.global1.data[147] == 1 && this.global1.data[154] != 1 && this.global1.data[148] != 1 && !this.events[15].activeSelf && !this.global1.event_done[345])
		{
			this.this_num_event = 345;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 25 && this.global1.data[20] >= 3 && this.global1.data[21] == 1991 && this.global1.data[0] == 49 && this.global1.data[116] == 1 && this.yug1.gameState.yugregions[1].owner == 1 && !this.events[15].activeSelf && !this.global1.event_done[346])
		{
			this.this_num_event = 346;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[19] >= 31 && this.global1.data[20] >= 4 && this.global1.data[21] == 1991 && this.global1.data[0] == 49 && this.global1.data[148] == 1 && !this.events[15].activeSelf && !this.global1.event_done[347])
		{
			this.this_num_event = 347;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[19] >= 7 && this.global1.data[20] >= 7 && this.global1.data[21] == 1991 && this.global1.data[0] == 49 && !this.events[15].activeSelf && !this.global1.event_done[348])
		{
			this.this_num_event = 348;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[19] >= 13 && this.global1.data[20] >= 7 && this.global1.data[21] == 1991 && this.global1.data[0] == 49 && this.global1.data[118] == 1 && this.global1.data[116] == 2 && !this.events[15].activeSelf && !this.global1.event_done[349])
		{
			this.this_num_event = 349;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 20 && this.global1.data[20] >= 10 && this.global1.data[21] == 1991 && this.global1.data[168] == 0 && this.global1.data[0] == 49 && this.global1.data[136] == 1 && (this.global1.data[144] == 0 || this.global1.data[144] == 2) && !this.events[15].activeSelf && !this.global1.event_done[350])
		{
			this.this_num_event = 350;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[131] == 0 && this.global1.data[157] != 0 && this.global1.data[135] <= 10 && !this.events[15].activeSelf && !this.global1.event_done[351])
		{
			this.this_num_event = 351;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[149] == 1 && this.global1.allcountries[4].Gosstroy == 2 && this.global1.data[0] == 49 && !this.events[15].activeSelf && !this.global1.event_done[353] && !this.global1.event_done[352])
		{
			this.this_num_event = 352;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[135] <= 8 && this.global1.data[149] == 1 && this.global1.data[0] == 49 && !this.events[15].activeSelf && !this.global1.event_done[353])
		{
			this.this_num_event = 353;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 1 && this.global1.data[20] >= 6 && this.global1.data[21] == 1989 && !this.global1.event_done[355])
		{
			this.this_num_event = 355;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 14 && this.global1.data[20] >= 2 && this.global1.data[21] == 1990 && this.global1.data[6] <= 600 && !this.global1.event_done[356])
		{
			this.this_num_event = 356;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (((this.yug1.gameState.yugcountries[3].army < this.yug1.gameState.yugcountries[6].army && !this.yug1.gameState.yugcountries[3].peace_with[8]) || (this.yug1.gameState.yugcountries[3].army < this.yug1.gameState.yugcountries[8].army && !this.yug1.gameState.yugcountries[3].peace_with[6])) && this.global1.data[0] == 50 && !this.global1.event_done[357])
		{
			this.this_num_event = 357;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[9] == 17 && this.global1.data[8] == 76 && this.global1.data[0] == 50 && !this.global1.event_done[358])
		{
			this.this_num_event = 358;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 15 && this.global1.data[20] >= 7 && this.global1.data[21] == 1991 && this.global1.data[128] == 2 && this.global1.data[0] == 50 && this.yug1.gameState.yugregions[1].owner == 1 && this.yug1.gameState.yugregions[4].owner == 3 && !this.global1.event_done[346] && !this.global1.event_done[359])
		{
			this.this_num_event = 359;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 9 && this.global1.data[20] >= 6 && this.global1.data[21] == 1991 && this.global1.data[148] == 2 && this.global1.data[0] == 50 && this.yug1.gameState.yugregions[6].owner == 3 && this.global1.data[171] == 0 && !this.global1.event_done[346] && !this.global1.event_done[360])
		{
			this.this_num_event = 360;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 2 && this.global1.data[20] >= 9 && this.global1.data[21] == 1990 && (this.global1.data[0] == 49 || this.global1.data[0] == 51) && !this.events[15].activeSelf && !this.global1.event_done[362])
		{
			this.this_num_event = 362;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 29 && this.global1.data[20] >= 11 && this.global1.data[21] == 1990 && this.global1.data[156] != 2 && !this.events[15].activeSelf && !this.global1.event_done[363])
		{
			this.this_num_event = 363;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 3 && this.global1.data[20] >= 9 && this.global1.data[21] == 1989 && !this.events[15].activeSelf && !this.global1.event_done[364])
		{
			this.this_num_event = 364;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 7 && this.global1.data[20] >= 12 && this.global1.data[21] == 1989 && this.global1.data[163] != 1 && !this.events[15].activeSelf && !this.global1.event_done[365])
		{
			this.this_num_event = 365;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 25 && this.global1.data[20] >= 4 && this.global1.data[21] == 1991 && !this.global1.allcountries[49].isOVD && !this.global1.allcountries[50].isOVD && !this.global1.allcountries[51].isOVD && this.global1.data[163] == 2 && !this.events[15].activeSelf && !this.global1.event_done[366])
		{
			this.this_num_event = 366;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 17 && this.global1.data[20] >= 12 && this.global1.data[21] == 1989 && this.global1.data[165] >= 2 && !this.events[27].activeSelf && !this.global1.event_done[368])
		{
			this.this_num_event = 368;
			this.this_num_place = 27;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[20] >= 5 && this.global1.data[21] == 1991 && this.global1.data[164] == 6 && !this.events[27].activeSelf && !this.global1.event_done[372])
		{
			this.this_num_event = 372;
			this.this_num_place = 27;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[19] >= 4 && this.global1.data[20] >= 7 && this.global1.data[21] == 1989 && this.global1.data[165] >= 2 && !this.events[27].activeSelf && !this.global1.event_done[367])
		{
			this.this_num_event = 367;
			this.this_num_place = 27;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[19] >= 24 && this.global1.data[20] >= 10 && this.global1.data[21] == 1990 && this.global1.data[165] >= 2 && !this.events[27].activeSelf && !this.global1.event_done[369])
		{
			this.this_num_event = 369;
			this.this_num_place = 27;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[19] >= 11 && this.global1.data[20] >= 4 && this.global1.data[21] == 1991 && this.global1.data[165] >= 2 && !this.events[27].activeSelf && !this.global1.event_done[370])
		{
			this.this_num_event = 370;
			this.this_num_place = 27;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[20] >= 5 && this.global1.data[21] == 1991 && this.global1.allcountries[17].Westalgie >= 200 && this.global1.data[164] >= 3 && !this.events[27].activeSelf && !this.global1.event_done[371])
		{
			this.this_num_event = 371;
			this.this_num_place = 27;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[19] >= 9 && this.global1.data[20] >= 8 && this.global1.data[21] == 1989 && this.global1.data[165] >= 2 && !this.events[27].activeSelf && !this.global1.event_done[380])
		{
			this.this_num_event = 380;
			this.this_num_place = 27;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[19] >= 9 && this.global1.data[20] >= 6 && this.global1.data[21] == 1990 && this.global1.data[165] >= 2 && this.global1.data[0] != 49 && this.global1.data[0] != 50 && this.global1.data[0] != 51 && !this.events[27].activeSelf && !this.global1.event_done[381])
		{
			this.this_num_event = 381;
			this.this_num_place = 27;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[20] >= 6 && this.global1.data[21] == 1991 && this.global1.data[164] == 6 && this.global1.data[0] != 49 && this.global1.data[0] != 50 && this.global1.data[0] != 51 && !this.events[27].activeSelf && !this.global1.event_done[382])
		{
			this.this_num_event = 382;
			this.this_num_place = 27;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[3] <= 500 && (!this.yug1.gameState.yugcountries[1].peace_with[2] || !this.yug1.gameState.yugcountries[1].peace_with[3] || !this.yug1.gameState.yugcountries[1].peace_with[0] || !this.yug1.gameState.yugcountries[1].peace_with[4] || !this.yug1.gameState.yugcountries[1].peace_with[5] || !this.yug1.gameState.yugcountries[1].peace_with[5] || !this.yug1.gameState.yugcountries[1].peace_with[6] || !this.yug1.gameState.yugcountries[1].peace_with[7] || !this.yug1.gameState.yugcountries[1].peace_with[8] || !this.yug1.gameState.yugcountries[1].peace_with[9] || !this.yug1.gameState.yugcountries[1].peace_with[10] || !this.yug1.gameState.yugcountries[1].peace_with[11] || !this.yug1.gameState.yugcountries[3].peace_with[0] || !this.yug1.gameState.yugcountries[3].peace_with[1] || !this.yug1.gameState.yugcountries[3].peace_with[2] || !this.yug1.gameState.yugcountries[3].peace_with[4] || !this.yug1.gameState.yugcountries[3].peace_with[5] || !this.yug1.gameState.yugcountries[3].peace_with[6] || !this.yug1.gameState.yugcountries[3].peace_with[7] || !this.yug1.gameState.yugcountries[3].peace_with[8] || !this.yug1.gameState.yugcountries[3].peace_with[9] || !this.yug1.gameState.yugcountries[3].peace_with[10] || !this.yug1.gameState.yugcountries[3].peace_with[11] || !this.yug1.gameState.yugcountries[8].peace_with[0] || !this.yug1.gameState.yugcountries[8].peace_with[1] || !this.yug1.gameState.yugcountries[8].peace_with[2] || !this.yug1.gameState.yugcountries[8].peace_with[3] || !this.yug1.gameState.yugcountries[8].peace_with[4] || !this.yug1.gameState.yugcountries[8].peace_with[5] || !this.yug1.gameState.yugcountries[8].peace_with[6] || !this.yug1.gameState.yugcountries[8].peace_with[7] || !this.yug1.gameState.yugcountries[8].peace_with[9] || !this.yug1.gameState.yugcountries[8].peace_with[10] || !this.yug1.gameState.yugcountries[8].peace_with[11]) && !this.events[15].activeSelf && !this.global1.event_done[373])
		{
			this.this_num_event = 373;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[130] == 1 && this.global1.data[162] != 3 && this.global1.data[19] >= 11 && this.global1.data[20] >= 11 && this.global1.data[21] == 1990 && !this.events[15].activeSelf && !this.global1.event_done[374])
		{
			this.this_num_event = 374;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 8 && this.global1.data[20] >= 3 && this.global1.data[21] == 1991 && this.global1.data[116] == 1 && this.global1.data[137] == 0 && this.yug1.gameState.yugregions[1].owner == 1 && this.yug1.gameState.yugregions[3].owner == 3 && !this.events[15].activeSelf && !this.global1.event_done[375])
		{
			this.this_num_event = 375;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 20 && this.global1.data[20] >= 1 && this.global1.data[21] == 1990 && this.global1.data[126] == 0 && !this.events[15].activeSelf && !this.global1.event_done[376])
		{
			this.this_num_event = 376;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 15 && this.global1.data[20] >= 9 && this.global1.data[21] == 1990 && this.global1.data[0] == 50 && this.global1.data[137] == 0 && this.global1.data[136] == 1 && !this.events[15].activeSelf && !this.global1.event_done[377])
		{
			this.this_num_event = 377;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 18 && this.global1.data[20] >= 9 && this.global1.data[21] == 1990 && this.global1.data[0] == 50 && this.global1.data[137] == 0 && this.global1.data[136] == 1 && !this.events[15].activeSelf && !this.global1.event_done[378])
		{
			this.this_num_event = 378;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 20 && this.global1.data[20] >= 12 && this.global1.data[21] == 1990 && this.global1.data[0] == 50 && this.global1.data[137] == 0 && this.global1.data[136] == 1 && !this.events[15].activeSelf && !this.global1.event_done[379])
		{
			this.this_num_event = 379;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && (this.global1.data[156] == 3 || this.global1.allcountries[20].Gosstroy == 2) && this.global1.data[157] == 2 && this.global1.data[128] == 2 && this.global1.data[21] == 1991 && !this.global1.event_done[383])
		{
			this.this_num_event = 383;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 15 && this.global1.data[20] >= 5 && this.global1.data[21] == 1990 && this.yug1.gameState.yugregions[10].owner == 10 && this.yug1.gameState.yugcountries[10].is_exist && !this.global1.event_done[384])
		{
			this.this_num_event = 384;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 20 && this.global1.data[20] >= 11 && this.global1.data[21] == 1990 && this.yug1.gameState.yugregions[10].owner == 10 && this.yug1.gameState.yugcountries[10].is_exist && !this.yug1.gameState.yugcountries[10].is_independent && !this.global1.event_done[385])
		{
			this.this_num_event = 385;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 20 && this.global1.data[20] >= 9 && this.global1.data[21] == 1991 && this.yug1.gameState.yugregions[10].owner == 10 && this.yug1.gameState.yugcountries[10].is_exist && !this.yug1.gameState.yugcountries[10].is_independent && (this.global1.data[176] == 7 || this.global1.data[176] == 8 || this.global1.data[176] == 2) && !this.global1.event_done[386])
		{
			this.this_num_event = 386;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 20 && this.global1.data[20] >= 11 && this.global1.data[21] == 1991 && this.yug1.gameState.yugregions[10].owner == 10 && this.yug1.gameState.yugcountries[10].is_exist && !this.yug1.gameState.yugcountries[10].is_independent && this.global1.data[130] == 6 && !this.global1.event_done[387])
		{
			this.this_num_event = 387;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 3 && this.global1.data[20] >= 4 && this.global1.data[21] == 1989 && this.yug1.gameState.yugregions[10].owner != 10 && !this.global1.event_done[388])
		{
			this.this_num_event = 388;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 5 && this.global1.data[20] >= 2 && this.global1.data[21] == 1990 && this.yug1.gameState.yugregions[10].owner != 10 && !this.global1.event_done[389])
		{
			this.this_num_event = 389;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 3 && this.global1.data[20] >= 9 && this.global1.data[21] == 1990 && this.yug1.gameState.yugregions[10].owner != 10 && !this.global1.event_done[390])
		{
			this.this_num_event = 390;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 10 && this.global1.data[20] >= 10 && this.global1.data[21] == 1990 && this.global1.data[0] == 51 && !this.global1.event_done[391])
		{
			this.this_num_event = 391;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 3 && this.global1.data[20] >= 12 && this.global1.data[21] == 1990 && !this.global1.event_done[392])
		{
			this.this_num_event = 392;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 13 && this.global1.data[20] >= 6 && this.global1.data[21] == 1990 && this.global1.data[0] == 49 && !this.global1.event_done[393])
		{
			this.this_num_event = 393;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && ((this.global1.data[20] >= 6 && this.global1.data[21] == 1989) || (this.global1.data[20] <= 6 && this.global1.data[21] == 1990)) && this.global1.data[148] == 0 && (this.global1.data[3] <= 450 || this.global1.data[5] <= 350) && !this.global1.event_done[394])
		{
			this.this_num_event = 394;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[20] <= 11 && this.global1.data[21] == 1990 && this.global1.data[148] == 0 && this.global1.data[179] == 0 && (!this.global1.event_done[394] || !this.global1.event_done[397]) && (this.global1.data[3] <= 450 || this.global1.data[1] <= 450) && !this.global1.event_done[395])
		{
			this.this_num_event = 395;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 17 && this.global1.data[20] >= 11 && this.global1.data[21] == 1990 && this.global1.data[148] == 0 && this.global1.data[154] == 0 && this.global1.data[0] == 49 && !this.global1.event_done[396])
		{
			this.this_num_event = 396;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && ((this.global1.data[20] >= 6 && this.global1.data[21] == 1989) || (this.global1.data[20] <= 6 && this.global1.data[21] == 1990)) && this.global1.data[148] == 0 && this.global1.data[3] <= 500 && this.global1.data[0] == 49 && !this.global1.event_done[397])
		{
			this.this_num_event = 397;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 9 && this.global1.data[20] >= 8 && this.global1.data[21] == 1989 && !this.global1.event_done[398])
		{
			this.this_num_event = 398;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 22 && this.global1.data[20] >= 1 && this.global1.data[21] == 1990 && this.global1.data[126] >= 1 && this.yug1.gameState.yugregions[10].owner == 8 && !this.events[15].activeSelf && !this.global1.event_done[399] && !this.global1.event_done[400])
		{
			this.this_num_event = 399;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 22 && this.global1.data[20] >= 1 && this.global1.data[21] == 1990 && this.global1.data[126] >= 1 && !this.events[15].activeSelf && !this.global1.event_done[400])
		{
			this.this_num_event = 400;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 12 && this.global1.data[20] >= 6 && this.global1.data[21] == 1990 && this.global1.data[137] == 2 && !this.events[15].activeSelf && !this.global1.event_done[401])
		{
			this.this_num_event = 401;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[162] != 3 && this.global1.data[19] >= 20 && this.global1.data[20] >= 6 && this.global1.data[21] == 1991 && this.global1.data[156] == 3 && this.global1.data[179] >= 1 && this.global1.data[148] != 2 && !this.events[15].activeSelf && !this.global1.event_done[402])
		{
			this.this_num_event = 402;
			this.this_num_place = 15;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		Debug.Log("YUGEVENDONE");
	}

	// Token: 0x06000166 RID: 358 RVA: 0x00160270 File Offset: 0x0015E470
	private void DLCpaths()
	{
		if (this.global1.data[19] >= this.global1.data[47] && this.global1.data[20] >= 8 && this.global1.data[21] >= 1989 && (this.global1.allcountries[1].paths == 2 || this.global1.allcountries[1].paths == 3) && !this.events[1].activeSelf && !this.global1.event_done[1001])
		{
			this.this_num_event = 1001;
			this.this_num_place = 1;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[19] >= this.global1.data[47] && this.global1.data[20] >= 11 && this.global1.data[21] >= 1989 && this.global1.allcountries[1].paths == 2 && !this.events[1].activeSelf && !this.global1.event_done[1002])
		{
			this.this_num_event = 1002;
			this.this_num_place = 1;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[19] >= 3 && ((this.global1.data[20] >= 10 && this.global1.data[21] >= 1991) || (this.global1.data[7] <= 500 && this.global1.data[21] >= 1990) || (this.global1.data[7] <= 700 && this.global1.data[21] >= 1991)) && this.global1.allcountries[1].paths == 2 && !this.events[1].activeSelf && !this.global1.event_done[1003])
		{
			this.this_num_event = 1003;
			this.this_num_place = 1;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (((this.global1.data[20] >= this.global1.data[47] + this.global1.data[48] && this.global1.data[21] >= 1990) || this.global1.data[21] >= 1991) && this.global1.allcountries[1].paths == 3 && !this.events[1].activeSelf && !this.global1.event_done[1004])
		{
			this.this_num_event = 1004;
			this.this_num_place = 1;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[20] >= this.global1.data[48] + this.global1.data[49] && this.global1.data[21] >= 1991 && this.global1.allcountries[1].paths == 3 && !this.events[1].activeSelf && !this.global1.event_done[1005])
		{
			this.this_num_event = 1005;
			this.this_num_place = 1;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[19] >= this.global1.data[48] && this.global1.data[20] >= 3 && this.global1.data[21] >= 1990 && this.global1.allcountries[1].paths == 4 && !this.events[1].activeSelf && !this.global1.event_done[92])
		{
			this.this_num_event = 92;
			this.this_num_place = 1;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[19] >= this.global1.data[48] && this.global1.data[20] >= 11 && this.global1.data[21] >= 1989 && this.global1.allcountries[1].paths == 4 && !this.events[1].activeSelf && !this.global1.event_done[1007])
		{
			this.this_num_event = 1007;
			this.this_num_place = 1;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[19] >= 5 && ((this.global1.data[20] >= 10 && this.global1.data[21] >= 1991) || (this.global1.data[7] <= 500 && this.global1.data[20] >= 5 && this.global1.data[21] == 1990) || (this.global1.data[7] <= 700 && this.global1.data[20] >= 5 && this.global1.data[21] == 1991)) && this.global1.allcountries[1].paths == 4 && !this.events[1].activeSelf && !this.global1.event_done[1008])
		{
			this.this_num_event = 1008;
			this.this_num_place = 1;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[19] >= this.global1.data[47] && this.global1.data[20] >= 8 && this.global1.data[21] >= 1989 && this.global1.allcountries[1].paths == 5 && !this.events[1].activeSelf && !this.global1.event_done[89])
		{
			this.this_num_event = 89;
			this.this_num_place = 1;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[19] >= 4 && this.global1.data[20] >= 9 && this.global1.data[21] >= 1989 && this.global1.allcountries[1].paths == 5 && !this.events[1].activeSelf && !this.global1.event_done[1010])
		{
			this.this_num_event = 1010;
			this.this_num_place = 1;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[19] >= 2 && ((this.global1.data[20] >= 10 && this.global1.data[21] >= 1991) || (this.global1.data[7] <= 500 && this.global1.data[20] >= 5 && this.global1.data[21] == 1990) || (this.global1.data[7] <= 700 && this.global1.data[20] >= 5 && this.global1.data[21] == 1991)) && this.global1.allcountries[1].paths == 5 && !this.events[1].activeSelf && !this.global1.event_done[1011])
		{
			this.this_num_event = 1011;
			this.this_num_place = 1;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (((this.global1.data[7] <= 600 && this.global1.data[21] == 1989) || (this.global1.data[7] <= 750 && this.global1.data[21] == 1990) || this.global1.data[21] >= 1991) && this.global1.data[19] >= this.global1.data[49] && this.global1.allcountries[1].paths == 6 && !this.events[1].activeSelf && !this.global1.event_done[1012])
		{
			this.this_num_event = 1012;
			this.this_num_place = 1;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if ((this.global1.data[21] >= 1991 || this.global1.data[7] <= 665) && this.global1.allcountries[1].paths == 6 && !this.events[1].activeSelf && this.global1.event_done[1012] && !this.global1.event_done[1013])
		{
			this.this_num_event = 1013;
			this.this_num_place = 1;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[19] >= 5 && this.global1.data[20] >= 5 && this.global1.data[21] >= 1991 && this.global1.allcountries[1].paths == 6 && !this.events[1].activeSelf && !this.global1.event_done[1014])
		{
			this.this_num_event = 1014;
			this.this_num_place = 1;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		if (this.global1.data[19] >= 2 && this.global1.data[20] >= 8 && this.global1.data[21] >= 1989 && this.global1.allcountries[2].paths == 2 && !this.events[2].activeSelf && !this.global1.event_done[8])
		{
			this.this_num_event = 8;
			this.this_num_place = 2;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[19] >= 26 && this.global1.data[20] >= 8 && this.global1.data[21] >= 1989 && this.global1.allcountries[2].paths == 2 && !this.events[2].activeSelf && !this.global1.event_done[1016])
		{
			this.this_num_event = 1016;
			this.this_num_place = 2;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[21] >= 1990 && this.global1.allcountries[2].paths == 2 && !this.events[2].activeSelf && !this.global1.event_done[1017])
		{
			this.this_num_event = 1017;
			this.this_num_place = 2;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[20] >= 2 && this.global1.allcountries[2].paths == 3 && !this.events[2].activeSelf && !this.global1.event_done[1018])
		{
			this.this_num_event = 1018;
			this.this_num_place = 2;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[19] >= 25 && this.global1.data[20] >= 1 && this.global1.data[21] >= 1990 && this.global1.allcountries[2].paths == 3 && !this.events[2].activeSelf && !this.global1.event_done[1019])
		{
			this.this_num_event = 1019;
			this.this_num_place = 2;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[19] >= 14 && this.global1.data[20] >= 2 && this.global1.data[21] >= 1991 && this.global1.allcountries[2].paths == 3 && !this.events[2].activeSelf && !this.global1.event_done[1020])
		{
			this.this_num_event = 1020;
			this.this_num_place = 2;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.allcountries[2].paths == 4 && !this.events[2].activeSelf && !this.global1.event_done[1021])
		{
			this.this_num_event = 1021;
			this.this_num_place = 2;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (this.global1.data[19] >= 2 && this.global1.data[20] >= 8 && this.global1.data[21] >= 1989 && this.global1.allcountries[2].paths == 4 && !this.events[2].activeSelf && !this.global1.event_done[1022])
		{
			this.this_num_event = 1022;
			this.this_num_place = 2;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		else if (((this.global1.data[20] >= 10 && this.global1.data[21] >= 1991) || (this.global1.is_gkchp && this.global1.allcountries[7].Gosstroy > 1) || this.global1.allcountries[this.global1.data[0]].Vyshi || this.global1.data[7] <= 210 || (this.global1.allcountries[4].Gosstroy >= 1 && !this.global1.allcountries[4].isSEV && !this.global1.allcountries[4].isOVD && this.global1.allcountries[2].Gosstroy >= 1 && !this.global1.allcountries[2].isSEV && !this.global1.allcountries[2].isOVD)) && this.global1.allcountries[2].paths == 4 && !this.events[2].activeSelf && !this.global1.event_done[65])
		{
			this.this_num_event = 65;
			this.this_num_place = 2;
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
		if (this.global1.allcountries[3].paths > 1)
		{
			if (this.global1.data[19] >= this.global1.data[49] && this.global1.data[20] >= 10 && this.global1.data[21] >= 1989 && this.global1.allcountries[3].paths == 2 && !this.events[3].activeSelf && !this.global1.event_done[1024])
			{
				this.this_num_event = 1024;
				this.this_num_place = 3;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.global1.data[19] >= this.global1.data[49] && this.global1.data[20] >= 9 && this.global1.data[21] >= 1990 && this.global1.allcountries[3].paths == 2 && !this.events[3].activeSelf && !this.global1.event_done[1025])
			{
				this.this_num_event = 1025;
				this.this_num_place = 3;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.global1.data[19] >= this.global1.data[48] && this.global1.data[20] >= 2 && this.global1.data[21] >= 1991 && this.global1.allcountries[3].paths == 2 && !this.events[3].activeSelf && !this.global1.event_done[1026])
			{
				this.this_num_event = 1026;
				this.this_num_place = 3;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.global1.data[19] >= this.global1.data[49] && this.global1.data[20] >= 10 && this.global1.data[21] >= 1989 && this.global1.allcountries[3].paths == 3 && !this.events[3].activeSelf && !this.global1.event_done[1027])
			{
				this.this_num_event = 1027;
				this.this_num_place = 3;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.global1.data[19] >= this.global1.data[49] && this.global1.data[20] >= 9 && this.global1.data[21] >= 1990 && this.global1.allcountries[3].paths == 3 && !this.events[3].activeSelf && !this.global1.event_done[1028])
			{
				this.this_num_event = 1028;
				this.this_num_place = 3;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.global1.data[19] >= this.global1.data[48] && this.global1.data[20] >= 2 && this.global1.data[21] >= 1991 && this.global1.allcountries[3].paths == 3 && !this.events[3].activeSelf && !this.global1.event_done[1029])
			{
				this.this_num_event = 1029;
				this.this_num_place = 3;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.pastDate(this.global1.data[49], 10, 1989) && this.global1.allcountries[3].paths == 4 && !this.checkWas(3, 1030))
			{
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if ((this.pastDate(this.global1.data[49], 0, 1990) || (this.global1.data[7] <= 400 && this.global1.event_done[1030])) && this.global1.allcountries[3].paths == 4 && !this.checkWas(3, 1031))
			{
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if ((this.pastDate(0, this.global1.data[49] + this.global1.data[48], 1991) || (this.global1.data[7] <= 300 && this.global1.event_done[1031])) && this.global1.allcountries[3].paths == 4 && !this.checkWas(3, 1032))
			{
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.pastDate(this.global1.data[49], 10, 1989) && this.global1.allcountries[3].paths == 5 && !this.checkWas(3, 1033))
			{
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if ((this.pastDate(this.global1.data[49], 0, 1990) || (this.global1.data[7] <= 659 && this.global1.event_done[1033])) && this.global1.allcountries[3].paths == 5 && !this.checkWas(3, 1034))
			{
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if ((this.pastDate(0, this.global1.data[49] + this.global1.data[48], 1991) || (this.global1.data[7] <= 300 && this.global1.event_done[1034])) && this.global1.allcountries[3].paths == 5 && !this.checkWas(3, 1035))
			{
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
		}
		if (this.global1.allcountries[4].paths > 1)
		{
			if ((this.pastDate(this.global1.data[49], 7, 1989) || this.global1.data[7] <= 870) && this.global1.allcountries[4].paths == 2 && !this.checkWas(4, 1036))
			{
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.pastDate(this.global1.data[49], 11, 1989) && this.global1.allcountries[4].paths == 2 && !this.checkWas(4, 1037))
			{
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if ((this.pastDate(this.global1.data[49], 0, 1991) || (this.global1.data[7] <= 370 && this.global1.event_done[1037])) && this.global1.allcountries[4].paths == 2 && !this.checkWas(4, 1038))
			{
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if ((this.pastDate(this.global1.data[49], 7, 1989) || this.global1.data[7] <= 870) && this.global1.allcountries[4].paths == 3 && !this.checkWas(4, 1039))
			{
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if ((this.pastDate(this.global1.data[49], 0, 1990) || (this.global1.data[7] <= 370 && this.global1.event_done[1039])) && this.global1.allcountries[4].paths == 3 && !this.checkWas(4, 1040))
			{
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if ((this.pastDate(this.global1.data[49], 0, 1991) || (this.global1.data[7] <= 370 && this.global1.event_done[1037])) && this.global1.allcountries[4].paths == 3 && !this.checkWas(4, 1041))
			{
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if ((this.pastDate(this.global1.data[49], 7, 1989) || this.global1.data[7] <= 870) && this.global1.allcountries[4].paths == 4 && !this.checkWas(4, 1042))
			{
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if ((this.pastDate(this.global1.data[49], 0, 1990) || (this.global1.data[7] <= 470 && this.global1.event_done[1042])) && this.global1.allcountries[4].paths == 4 && !this.checkWas(4, 1043))
			{
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if ((this.pastDate(this.global1.data[49], 0, 1991) || (this.global1.data[7] <= 370 && this.global1.event_done[1043])) && this.global1.allcountries[4].paths == 4 && this.global1.data[0] != 5 && !this.checkWas(4, 1044))
			{
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if ((this.pastDate(this.global1.data[49], 0, 1991) || (this.global1.data[7] <= 370 && this.global1.event_done[1043])) && this.global1.allcountries[4].paths == 4 && this.global1.data[0] == 5 && !this.checkWas(4, 1045))
			{
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if ((this.pastDate(this.global1.data[49], 7, 1989) || this.global1.data[7] <= 870) && this.global1.allcountries[4].paths == 5 && !this.checkWas(4, 1046))
			{
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if ((this.pastDate(this.global1.data[49], 0, 1990) || (this.global1.data[7] <= 570 && this.global1.event_done[1046])) && this.global1.allcountries[4].paths == 5 && !this.checkWas(4, 1047))
			{
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if ((this.pastDate(this.global1.data[49], 0, 1991) || (this.global1.data[7] <= 370 && this.global1.event_done[1047])) && this.global1.allcountries[4].paths == 5 && !this.checkWas(4, 1048))
			{
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
		}
		if (this.global1.allcountries[5].paths > 1)
		{
			if (this.pastDate(this.global1.data[49], 4, 1989) && this.global1.allcountries[5].paths == 2 && !this.checkWas(5, 1049) && !this.global1.event_done[1044])
			{
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.pastDate(this.global1.data[49], 6, 1990) && this.global1.allcountries[5].paths == 2 && !this.checkWas(5, 46) && !this.global1.event_done[1044])
			{
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if ((this.pastDate(this.global1.data[49], 10, 1991) || (this.global1.data[7] <= 370 && this.global1.event_done[46])) && this.global1.allcountries[5].paths == 2 && !this.checkWas(4, 1050) && !this.global1.event_done[1044])
			{
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.pastDate(this.global1.data[49], 3, 1989) && this.global1.allcountries[5].paths == 3 && !this.checkWas(5, 1051) && !this.global1.event_done[1044])
			{
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.pastDate(this.global1.data[49], 11, 1989) && this.global1.allcountries[5].paths == 3 && !this.checkWas(5, 1052) && !this.global1.event_done[1044])
			{
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if ((this.pastDate(this.global1.data[49], 2, 1991) || (this.global1.data[7] <= 370 && this.global1.event_done[1052])) && this.global1.allcountries[5].paths == 3 && !this.checkWas(5, 1053) && !this.global1.event_done[1044])
			{
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.pastDate(this.global1.data[49], 12, 1989) && this.global1.allcountries[5].paths == 4 && !this.checkWas(5, 1054) && !this.global1.event_done[1044])
			{
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.pastDate(this.global1.data[49], 5, 1990) && this.global1.allcountries[5].paths == 4 && !this.checkWas(5, 1055) && !this.global1.event_done[1044])
			{
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if ((this.pastDate(this.global1.data[49], 2, 1991) || (this.global1.data[7] <= 470 && this.global1.event_done[1055])) && this.global1.allcountries[5].paths == 4 && !this.checkWas(5, 1056) && !this.global1.event_done[1044])
			{
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if ((this.pastDate(this.global1.data[49], 0, 1990) || this.global1.data[7] <= 750) && this.global1.allcountries[5].paths == 5 && !this.checkWas(5, 1057) && !this.global1.event_done[1044])
			{
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.pastDate(this.global1.data[49], 3, 1990) && this.global1.allcountries[5].paths == 5 && !this.checkWas(5, 1058) && !this.global1.event_done[1044])
			{
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if ((this.pastDate(this.global1.data[49], 9, 1991) || ((this.global1.data[7] <= 370 || !this.global1.allcountries[5].isOVD) && this.global1.event_done[1058])) && this.global1.allcountries[5].paths == 5 && !this.checkWas(5, 1059) && !this.global1.event_done[1044])
			{
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
		}
		if (this.global1.allcountries[6].paths > 1)
		{
			if ((this.pastDate(this.global1.data[49], 11, 1989) || this.global1.data[7] <= 870) && this.global1.allcountries[6].paths == 2 && !this.checkWas(6, 1060))
			{
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if ((this.pastDate(this.global1.data[49], 9, 1990) || (this.global1.data[7] <= 600 && this.global1.event_done[1060])) && this.global1.allcountries[6].paths == 2 && !this.checkWas(6, 1061))
			{
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if ((this.pastDate(0, this.global1.data[49] + this.global1.data[48], 1991) || (this.global1.data[7] <= 400 && this.global1.event_done[1061])) && this.global1.allcountries[6].paths == 2 && !this.checkWas(6, 1062))
			{
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if ((this.pastDate(this.global1.data[49], 11, 1989) || this.global1.data[7] <= 770) && this.global1.allcountries[6].paths == 3 && !this.checkWas(6, 1063))
			{
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if ((this.pastDate(this.global1.data[49], 2, 1990) || (this.global1.data[7] <= 470 && this.global1.event_done[1063])) && this.global1.allcountries[6].paths == 3 && !this.checkWas(6, 1064))
			{
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if ((this.pastDate(20, 20, 1990) || (this.global1.data[7] <= 370 && this.global1.event_done[1064])) && this.global1.allcountries[6].paths == 3 && !this.checkWas(6, 1065))
			{
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if ((this.pastDate(this.global1.data[49], 11, 1989) || this.global1.data[7] <= 780) && this.global1.allcountries[6].paths == 4 && !this.checkWas(6, 1066))
			{
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if ((this.pastDate(this.global1.data[49], 9, 1990) || (this.global1.data[7] <= 600 && this.global1.event_done[1066])) && this.global1.allcountries[6].paths == 4 && this.global1.data[0] != 49 && this.global1.data[0] != 50 && this.global1.data[0] != 51 && !this.checkWas(6, 1067))
			{
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if ((this.pastDate(0, 2, 1991) || (this.global1.data[7] <= 400 && this.global1.event_done[1067])) && this.global1.allcountries[6].paths == 4 && !this.checkWas(6, 1068))
			{
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if ((this.pastDate(this.global1.data[49], 11, 1989) || this.global1.data[7] <= 770) && this.global1.allcountries[6].paths == 5 && !this.checkWas(6, 1063))
			{
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if ((this.pastDate(6, 7, 1990) || (this.global1.data[7] <= 280 && this.global1.event_done[1063])) && this.global1.allcountries[6].paths == 5 && !this.checkWas(6, 1070))
			{
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if ((this.pastDate(20, 12, 1990) || (this.global1.data[7] <= 70 && this.global1.event_done[1070])) && this.global1.allcountries[6].paths == 5 && !this.checkWas(6, 1071))
			{
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
		}
		if (this.global1.allcountries[7].paths > 1)
		{
			if (this.pastDate(2, 4, 1989) && (this.global1.allcountries[7].paths == 2 || this.global1.allcountries[7].paths == 3) && !this.checkWas(7, 1072))
			{
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.pastDate(5, 5, 1989) && this.global1.allcountries[7].paths == 2 && !this.checkWas(7, 1073))
			{
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if ((this.pastDate(2, 7, 1990) || (this.global1.data[7] <= 480 && this.global1.event_done[1073])) && this.global1.allcountries[7].paths == 2 && !this.checkWas(7, 1074))
			{
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.pastDate(1, 5, 1989) && this.global1.allcountries[7].paths == 3 && !this.checkWas(7, 1075))
			{
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if ((this.pastDate(13, 7, 1990) || (this.global1.data[7] <= 590 && this.global1.event_done[1075])) && this.global1.allcountries[7].paths == 3 && !this.checkWas(7, 1076))
			{
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.pastDate(7, 10, 1990) && this.global1.allcountries[7].paths == 4 && !this.checkWas(7, 62))
			{
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
		}
		if (this.global1.allcountries[17].Westalgie + this.global1.data[7] >= 1300 && !this.checkWas(21, 1078))
		{
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			return;
		}
		if (this.global1.allcountries[17].Westalgie >= 300 && this.global1.allcountries[1].Gosstroy == 2 && this.global1.data[0] != 1 && !this.checkWas(21, 1079))
		{
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			return;
		}
		if (this.global1.event_done[1045] && this.global1.allcountries[4].paths == 4 && this.global1.allcountries[6].paths == 3 && this.global1.data[0] == 5 && this.global1.data[50] == 1 && !this.checkWas(4, 1080))
		{
			this.events[this.this_num_place].SetActive(true);
			this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
		}
	}

	// Token: 0x06000167 RID: 359 RVA: 0x00163808 File Offset: 0x00161A08
	private void Repaint(bool need_to_pluse)
	{
		if (need_to_pluse)
		{
			int[] array = new int[9];
			int num;
			for (int i = 1; i < array.Length; i = num + 1)
			{
				array[i] = this.global1.data[i];
				num = i;
			}
			if (this.is_showed)
			{
				this.save_speed = this.global1.speed;
				this.global1.speed = 0;
			}
			ref int ptr = ref this.global1.data[19];
			ref int ptr2 = ref ptr;
			num = ptr;
			ptr2 = num + 1;
			if ((this.global1.data[20] == 2 && this.global1.data[19] == 29) || (this.global1.data[19] == 31 && (this.global1.data[20] == 4 || this.global1.data[20] == 6 || this.global1.data[20] == 9 || this.global1.data[20] == 11)) || (this.global1.data[19] == 32 && (this.global1.data[20] == 1 || this.global1.data[20] == 3 || this.global1.data[20] == 5 || this.global1.data[20] == 7 || this.global1.data[20] == 8 || this.global1.data[20] == 10 || this.global1.data[20] == 12)))
			{
				this.global1.data[19] = 1;
				ptr = ref this.global1.data[20];
				ref int ptr3 = ref ptr;
				num = ptr;
				ptr3 = num + 1;
				this.global1.bylo = false;
				if (this.global1.data[21] < 1992 && !this.global1.bylo)
				{
					int num2;
					if (this.global1.data[30] * 2 / 10 + 40 <= 0)
					{
						if (this.global1.data[26] > 0 && (this.global1.data[0] != 5 || (this.global1.data[0] == 5 && !this.global1.event_done[94])))
						{
							num2 = 10;
						}
						else if (this.global1.data[26] > 0 && this.global1.data[0] == 5 && this.global1.event_done[94] && this.global1.data[34] == 11)
						{
							num2 = 40;
						}
						else if (this.global1.data[26] > 0 && this.global1.data[0] == 5 && this.global1.event_done[94] && this.global1.data[34] == 4)
						{
							num2 = this.global1.data[30] * 2 / 10 + 25;
						}
						else
						{
							num2 = this.global1.data[30] * 2 / 10;
						}
					}
					else if (this.global1.data[30] <= 250)
					{
						if (this.global1.data[26] > 0 && (this.global1.data[0] != 5 || (this.global1.data[0] == 5 && !this.global1.event_done[94])))
						{
							num2 = (this.global1.data[30] * 2 - this.global1.data[26] / 4) / 10;
						}
						else if (this.global1.data[26] > 0 && this.global1.data[0] == 5 && this.global1.event_done[94] && this.global1.data[34] == 11)
						{
							num2 = this.global1.data[30] * 2 / 10 + 40;
						}
						else if (this.global1.data[26] > 0 && this.global1.data[0] == 5 && this.global1.event_done[94] && this.global1.data[34] == 4)
						{
							num2 = this.global1.data[30] * 2 / 10 + 25;
						}
						else
						{
							num2 = this.global1.data[30] * 2 / 10;
						}
					}
					else if (this.global1.data[26] > 0 && (this.global1.data[0] != 5 || (this.global1.data[0] == 5 && !this.global1.event_done[94])))
					{
						num2 = (500 - this.global1.data[26] / 4) / 10;
					}
					else if (this.global1.data[26] > 0 && this.global1.data[0] == 5 && this.global1.event_done[94] && this.global1.data[34] == 11)
					{
						num2 = 90;
					}
					else if (this.global1.data[26] > 0 && this.global1.data[0] == 5 && this.global1.event_done[94] && this.global1.data[34] == 4)
					{
						num2 = 75;
					}
					else
					{
						num2 = 50;
					}
					int num3;
					if (this.global1.data[23] > this.global1.data[24])
					{
						num3 = (this.global1.data[23] - this.global1.data[24]) * 2 - 1;
					}
					else
					{
						num3 = (this.global1.data[24] - this.global1.data[23]) * -2 + 1;
					}
					string @string = PlayerPrefs.GetString("V1");
					PlayerPrefs.SetString("V1", @string + "\n" + (100 + num2 + num3).ToString() + "%");
					@string = PlayerPrefs.GetString("I2");
					PlayerPrefs.SetString("I2", @string + "\n" + (this.global1.data[5] * 10 / (64 + (this.global1.data[21] - 1984))).ToString() + "%");
					int num4 = (this.global1.data[23] - this.global1.data[24]) / (1992 - this.global1.data[21]);
					int num5 = this.global1.data[5] * 10 / (64 + (this.global1.data[21] - 1984)) / 100;
					@string = PlayerPrefs.GetString("S3");
					PlayerPrefs.SetString("S3", @string + "\n" + ((num4 + num5) * -1).ToString() + "%");
					float num6 = ((float)(100 + num2 + num3) + (float)(this.global1.data[5] * 10 / (64 + (this.global1.data[21] - 1984))) - (float)((num4 + num5) * -1)) / 100f;
					@string = PlayerPrefs.GetString("R3");
					PlayerPrefs.SetString("R3", @string + "\n" + num6.ToString() + "%");
				}
			}
			if (this.global1.data[20] == 13)
			{
				this.global1.data[20] = 1;
				ptr = ref this.global1.data[21];
				ref int ptr4 = ref ptr;
				num = ptr;
				ptr4 = num + 1;
			}
			if (this.izuchenp)
			{
				this.thishappened.SetActive(true);
				this.thishappened.GetComponent<ScienceHappenedScript>().this_num = this.sci_num + ((this.global1.data[0] >= 49 && this.global1.data[0] <= 51) ? 11 : 0);
				this.thishappened.GetComponent<ScienceHappenedScript>().IsHappened();
				this.izuchenp = false;
				this.global1.neizucheno = true;
			}
			if (this.global1.data[97] <= 0)
			{
				this.global1.data[97] = this.global1.data[7];
			}
			if (this.global1.data[97] - this.global1.data[7] >= 400)
			{
				this.global1.data[97] = this.global1.data[7];
				ptr = ref this.global1.data[65];
				ref int ptr5 = ref ptr;
				num = ptr;
				ptr5 = num - 1;
			}
			if (this.global1.data[0] == 12 && this.global1.data[19] == 3 && (this.global1.data[20] == 6 || this.global1.data[20] == 1))
			{
				this.global1.event_done[250] = false;
			}
			if (this.global1.allcountries[1].paths > 0 || this.global1.allcountries[2].paths > 0 || this.global1.allcountries[3].paths > 0 || this.global1.allcountries[4].paths > 0 || this.global1.allcountries[5].paths > 0 || this.global1.allcountries[6].paths > 0 || this.global1.allcountries[7].paths > 0)
			{
				this.DLCpaths();
			}
			if ((this.global1.data[0] == 45 || this.global1.data[0] == 8 || this.global1.data[0] == 11) && ReqEventForDLC.RequrementsDLC04(ref this.this_num_event, ref this.this_num_place, ref this.global1))
			{
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.global1.data[0] >= 49 && this.global1.data[0] <= 51)
			{
				if (!this.yug1.gameState.battle_royal)
				{
					this.YugoEvents();
				}
				else if (this.global1.data[19] <= 3 && this.global1.data[20] >= 2 && this.global1.data[21] == 1989 && !this.global1.event_done[1108])
				{
					this.this_num_event = 1108;
					this.this_num_place = 15;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[19] >= 13 && this.global1.data[20] >= 2 && this.global1.data[21] == 1989 && !this.global1.event_done[1100])
				{
					this.this_num_event = 1100;
					this.this_num_place = 15;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[19] <= 3 && this.global1.data[20] >= 3 && this.global1.data[21] == 1989 && !this.global1.event_done[1101])
				{
					this.this_num_event = 1101;
					this.this_num_place = 15;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[19] <= 3 && this.global1.data[20] >= 6 && this.global1.data[21] == 1989 && this.yug1.gameState.yugcountries[11].is_exist && this.yug1.gameState.player != 11 && !this.global1.event_done[1102])
				{
					this.this_num_event = 1102;
					this.this_num_place = 15;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (!this.yug1.gameState.yugcountries[10].is_exist && this.global1.event_done[1101] && !this.global1.event_done[1103])
				{
					this.this_num_event = 1103;
					this.this_num_place = 15;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (!this.yug1.gameState.yugcountries[9].is_exist && this.global1.event_done[1101] && !this.global1.event_done[1105])
				{
					this.this_num_event = 1105;
					this.this_num_place = 15;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (!this.yug1.gameState.yugcountries[0].is_exist && this.global1.event_done[1101] && !this.global1.event_done[1106])
				{
					this.this_num_event = 1106;
					this.this_num_place = 15;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.yug1.gameState.yugcountries[this.yug1.gameState.player].have_regions >= 8 && !this.global1.event_done[1107])
				{
					this.this_num_event = 1107;
					this.this_num_place = 15;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[19] == 15 && this.global1.data[20] % 6 == 0)
				{
					this.this_num_event = 1104;
					this.this_num_place = 15;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
			}
			if (((this.global1.data[19] >= this.global1.data[48] && this.global1.data[20] >= 1 && this.global1.data[21] >= 1989) || this.global1.data[21] >= 1990) && this.global1.data[0] != 12 && !this.events[7].activeSelf && !this.global1.event_done[3])
			{
				this.this_num_event = 3;
				this.this_num_place = 7;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.global1.allcountries[7].paths != 3 && ((this.global1.data[19] >= this.global1.data[48] && this.global1.data[20] >= 7 && this.global1.data[21] >= 1989) || this.global1.data[21] >= 1990) && !this.events[7].activeSelf && !this.global1.event_done[4])
			{
				this.this_num_event = 4;
				this.this_num_place = 7;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.global1.allcountries[7].paths != 3 && (this.global1.data[7] <= 860 || (this.global1.data[21] == 1990 && this.global1.data[7] <= 900) || (this.global1.data[21] > 1990 && this.global1.data[7] <= 920)) && !this.global1.is_gkchp && !this.events[7].activeSelf && !this.global1.event_done[5])
			{
				this.this_num_event = 5;
				this.this_num_place = 7;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if ((this.global1.data[7] <= 600 || (this.global1.data[21] == 1990 && this.global1.data[7] <= 675) || (this.global1.data[21] > 1990 && this.global1.data[7] <= 750)) && !this.events[7].activeSelf && !this.global1.event_done[6] && this.global1.event_done[5])
			{
				this.this_num_event = 6;
				this.this_num_place = 7;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (!this.global1.allcountries[6].Torg && this.global1.data[0] != 12 && !this.global1.allcountries[5].Torg && this.global1.data[0] != 5 && this.global1.data[0] != 10 && this.global1.data[0] != 12 && this.global1.data[0] != 18 && ((this.global1.data[19] >= this.global1.data[48] && this.global1.data[20] >= 1 && this.global1.data[21] >= 1990) || (this.global1.data[20] >= 2 && this.global1.data[21] >= 1990)) && this.global1.allcountries[6].Gosstroy <= 0 && this.global1.allcountries[5].Gosstroy <= 0 && !this.events[7].activeSelf && !this.global1.event_done[7])
			{
				this.this_num_event = 7;
				this.this_num_place = 7;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.global1.data[0] != 2 && this.global1.allcountries[2].paths <= 0 && this.global1.allcountries[2].Gosstroy == 1 && !this.events[2].activeSelf && !this.global1.event_done[8])
			{
				this.this_num_event = 8;
				this.this_num_place = 2;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.global1.data[0] != 4 && this.global1.allcountries[4].paths <= 0 && this.global1.allcountries[4].Gosstroy == 2 && !this.events[4].activeSelf && !this.global1.event_done[9])
			{
				this.this_num_event = 9;
				this.this_num_place = 4;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.global1.data[0] != 6 && this.global1.allcountries[6].paths <= 0 && this.global1.allcountries[6].Gosstroy == 1 && !this.events[6].activeSelf && !this.global1.event_done[10])
			{
				this.this_num_event = 10;
				this.this_num_place = 6;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.global1.data[0] != 3 && this.global1.allcountries[3].paths <= 0 && this.global1.allcountries[3].Gosstroy == 1 && !this.events[3].activeSelf && !this.global1.event_done[11])
			{
				this.this_num_event = 11;
				this.this_num_place = 3;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.global1.data[0] != 5 && this.global1.allcountries[5].paths <= 0 && this.global1.allcountries[5].Gosstroy == 1 && !this.events[5].activeSelf && !this.global1.event_done[12])
			{
				this.this_num_event = 12;
				this.this_num_place = 5;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.global1.allcountries[7].Gosstroy == 0 && !this.global1.allcountries[7].Vyshi && !this.global1.is_gkchp && this.global1.data[0] != 10 && this.global1.data[0] != 12 && this.global1.data[0] != 18 && this.global1.data[15] < 8 && (((this.global1.data[0] < 49 || this.global1.data[0] > 51) && this.global1.data[21] >= 1990 && this.global1.data[20] >= 3) || this.global1.data[21] >= 1991) && !this.events[7].activeSelf && !this.global1.event_done[34])
			{
				this.this_num_event = 34;
				this.this_num_place = 7;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.global1.allcountries[7].paths <= 2 && ((this.global1.data[21] >= 1990 && !this.global1.is_gkchp) || (this.global1.is_gkchp && this.global1.allcountries[7].Gosstroy > 1)) && this.global1.data[20] >= 3 + this.global1.data[51] && !this.events[7].activeSelf && !this.global1.event_done[35])
			{
				this.this_num_event = 35;
				this.this_num_place = 7;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.global1.allcountries[7].paths <= 0 && this.global1.data[7] <= 200 && !this.global1.is_gkchp && !this.events[7].activeSelf && !this.global1.event_done[36])
			{
				this.this_num_event = 36;
				this.this_num_place = 7;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.global1.allcountries[7].paths <= 0 && (this.global1.data[14] <= 1 || this.global1.data[15] <= 6 || (this.global1.data[15] <= 7 && this.global1.data[17] <= 15)) && this.global1.data[0] != 20 && this.global1.data[0] != 49 && this.global1.data[0] != 50 && this.global1.data[0] != 51 && this.global1.data[0] != 12 && !this.global1.allcountries[7].Vyshi && !this.global1.is_elect && !this.global1.is_gkchp && ((this.global1.data[20] >= this.global1.data[47] && this.global1.data[21] >= 1990) || this.global1.data[21] >= 1991) && !this.events[7].activeSelf && !this.global1.event_done[37])
			{
				this.this_num_event = 37;
				this.this_num_place = 7;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.global1.data[0] != 2 && this.global1.allcountries[2].paths <= 0 && this.global1.allcountries[2].Gosstroy == 2 && !this.events[2].activeSelf && !this.global1.event_done[38])
			{
				this.this_num_event = 38;
				this.this_num_place = 2;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.global1.data[0] != 5 && this.global1.allcountries[5].paths <= 0 && this.global1.allcountries[5].Gosstroy == 2 && !this.events[5].activeSelf && !this.global1.event_done[39])
			{
				this.this_num_event = 39;
				this.this_num_place = 5;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.global1.data[0] != 6 && this.global1.allcountries[6].paths <= 0 && this.global1.allcountries[6].Gosstroy == 0 && this.global1.data[20] >= 2 && this.global1.data[21] >= 1990 && !this.events[6].activeSelf && !this.global1.event_done[40])
			{
				this.this_num_event = 40;
				this.this_num_place = 6;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (((this.global1.data[20] >= 5 && this.global1.data[21] >= 1990) || this.global1.allcountries[7].Gosstroy == 2) && !this.events[7].activeSelf && !this.global1.event_done[41])
			{
				this.this_num_event = 41;
				this.this_num_place = 7;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.global1.allcountries[9].Gosstroy == 1 && !this.events[9].activeSelf && !this.global1.event_done[42])
			{
				this.this_num_event = 42;
				this.this_num_place = 9;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.global1.data[0] != 3 && this.global1.allcountries[3].paths <= 0 && this.global1.allcountries[3].Gosstroy == 0 && this.global1.data[20] >= 3 && this.global1.data[21] >= 1990 && !this.events[3].activeSelf && !this.global1.event_done[43])
			{
				this.this_num_event = 43;
				this.this_num_place = 3;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.global1.data[0] != 4 && this.global1.allcountries[4].paths <= 0 && this.global1.allcountries[4].Gosstroy == 1 && this.global1.data[20] >= 4 && this.global1.data[21] >= 1990 && !this.events[4].activeSelf && !this.global1.event_done[44])
			{
				this.this_num_event = 44;
				this.this_num_place = 4;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.global1.allcountries[20].Gosstroy == 1 && this.global1.data[0] != 20 && !this.events[20].activeSelf && !this.global1.event_done[45])
			{
				this.this_num_event = 45;
				this.this_num_place = 20;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.global1.data[0] != 5 && this.global1.allcountries[5].paths <= 0 && this.global1.allcountries[5].Gosstroy == 0 && this.global1.data[20] >= 6 && this.global1.data[21] >= 1990 && !this.events[5].activeSelf && !this.global1.event_done[46])
			{
				this.this_num_event = 46;
				this.this_num_place = 5;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.global1.data[0] != 6 && this.global1.allcountries[6].paths <= 0 && this.global1.allcountries[6].Gosstroy == 2 && !this.events[6].activeSelf && !this.global1.event_done[47])
			{
				this.this_num_event = 47;
				this.this_num_place = 6;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.global1.allcountries[15].Gosstroy == 2 && !this.events[15].activeSelf && (this.global1.data[0] < 49 || this.global1.data[0] > 51) && !this.global1.event_done[48])
			{
				this.this_num_event = 48;
				this.this_num_place = 15;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.global1.data[0] != 2 && this.global1.allcountries[2].paths <= 0 && this.global1.allcountries[2].Gosstroy == 0 && this.global1.data[20] >= 12 && this.global1.data[21] >= 1990 && !this.events[2].activeSelf && !this.global1.event_done[49])
			{
				this.this_num_event = 49;
				this.this_num_place = 2;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.global1.allcountries[7].paths <= 0 && ((!this.global1.allcountries[7].isOVD && !this.global1.allcountries[7].isSEV) || this.global1.data[7] <= 170 || (this.global1.allcountries[this.global1.data[0]].Vyshi && this.global1.data[7] >= 500 && this.global1.data[0] != 20 && this.global1.data[0] != 49 && this.global1.data[0] != 50 && this.global1.data[0] != 51)) && this.global1.data[0] != 10 && this.global1.data[0] != 12 && !this.global1.is_gkchp && this.global1.data[20] >= 11 && (this.global1.data[21] == 1990 || (this.global1.data[21] == 1989 && this.global1.data[0] != 4)) && !this.events[7].activeSelf && !this.global1.event_done[62])
			{
				this.this_num_event = 62;
				this.this_num_place = 7;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.global1.allcountries[7].paths <= 2 && (!this.global1.is_gkchp || (this.global1.is_gkchp && this.global1.allcountries[7].Gosstroy > 1)) && this.global1.data[0] != 12 && !this.global1.allcountries[7].Vyshi && this.global1.data[0] != 20 && this.global1.data[0] != 49 && this.global1.data[0] != 50 && this.global1.data[0] != 51 && this.global1.data[14] <= 2 && this.global1.data[14] <= 2 && this.global1.data[20] >= 1 && this.global1.data[21] >= 1991 && !this.events[7].activeSelf && !this.global1.event_done[63])
			{
				this.this_num_event = 63;
				this.this_num_place = 7;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (((this.global1.data[19] >= this.global1.data[48] && this.global1.data[20] >= 2 && this.global1.data[21] >= 1991) || this.global1.data[21] >= 1992) && this.global1.data[0] != 20 && this.global1.data[0] != 49 && this.global1.data[0] != 50 && this.global1.data[0] != 51 && !this.events[7].activeSelf && this.global1.event_done[35] && !this.global1.event_done[64])
			{
				this.this_num_event = 64;
				this.this_num_place = 7;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if ((!this.global1.is_gkchp || (this.global1.is_gkchp && this.global1.allcountries[7].Gosstroy > 1)) && !this.global1.allcountries[this.global1.data[0]].Vyshi && (this.global1.data[7] <= 210 || (this.global1.data[20] >= 8 && this.global1.allcountries[4].Gosstroy >= 1 && !this.global1.allcountries[4].isSEV && !this.global1.allcountries[4].isOVD && this.global1.allcountries[2].Gosstroy >= 1 && !this.global1.allcountries[2].isSEV && !this.global1.allcountries[2].isOVD)) && this.global1.data[20] >= 2 && this.global1.data[21] >= 1991 && !this.events[7].activeSelf && !this.global1.event_done[65])
			{
				this.this_num_event = 65;
				this.this_num_place = 7;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.global1.allcountries[7].paths <= 2 && (!this.global1.is_gkchp || (this.global1.is_gkchp && this.global1.allcountries[7].Gosstroy > 1)) && this.global1.allcountries[7].isOVD && ((this.global1.data[0] != 1 && this.global1.data[0] <= 6 && this.global1.allcountries[1].Gosstroy == 2 && this.global1.data[10] >= 501) || (!this.global1.allcountries[7].isSEV && this.global1.data[53] - this.global1.data[7] >= 90) || this.global1.data[7] <= 120) && !this.events[7].activeSelf && !this.global1.event_done[66])
			{
				this.this_num_event = 66;
				this.this_num_place = 7;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if ((!this.global1.is_gkchp || (this.global1.is_gkchp && this.global1.allcountries[7].Gosstroy > 1)) && !this.global1.allcountries[7].Vyshi && this.global1.data[20] >= 2 && this.global1.data[21] >= 1991 && !this.events[7].activeSelf && !this.global1.event_done[67])
			{
				this.this_num_event = 67;
				this.this_num_place = 7;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if ((!this.global1.is_gkchp || (this.global1.is_gkchp && this.global1.allcountries[7].Gosstroy > 1)) && this.global1.allcountries[7].isOVD && this.global1.data[20] >= 6 && this.global1.data[21] >= 1991 && !this.events[7].activeSelf && !this.global1.event_done[68])
			{
				this.this_num_event = 68;
				this.this_num_place = 7;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if ((!this.global1.is_gkchp || (this.global1.is_gkchp && this.global1.allcountries[7].Gosstroy > 1)) && this.global1.allcountries[7].paths != 3 && this.global1.allcountries[7].isSEV && (this.global1.data[7] <= 75 || this.global1.data[53] - this.global1.data[7] >= 90) && !this.events[7].activeSelf && !this.global1.event_done[69])
			{
				this.this_num_event = 69;
				this.this_num_place = 7;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.global1.allcountries[7].paths <= 0 && !this.global1.is_gkchp && !this.global1.allcountries[7].isOVD && !this.global1.allcountries[7].isSEV && (this.global1.data[7] <= 59 || (this.global1.data[53] - this.global1.data[7] >= 20 && this.global1.data[21] >= 1991)) && !this.events[7].activeSelf && !this.global1.event_done[70])
			{
				this.this_num_event = 70;
				this.this_num_place = 7;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.global1.is_gkchp && (this.global1.allcountries[7].paths != 4 || (!this.global1.allcountries[7].isSEV && !this.global1.allcountries[7].isOVD)) && this.global1.allcountries[7].Gosstroy <= 1 && !this.events[7].activeSelf && !this.global1.event_done[71])
			{
				this.this_num_event = 71;
				this.this_num_place = 7;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.global1.is_gkchp && this.global1.allcountries[7].Gosstroy > 1 && !this.events[7].activeSelf && !this.global1.event_done[72])
			{
				this.this_num_event = 72;
				this.this_num_place = 7;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if ((!this.global1.is_gkchp || (this.global1.is_gkchp && this.global1.allcountries[7].Gosstroy > 1)) && (this.global1.data[7] <= 20 || (this.global1.data[53] - this.global1.data[7] >= 30 && this.global1.event_done[72])) && !this.events[7].activeSelf && !this.global1.event_done[73])
			{
				this.this_num_event = 73;
				this.this_num_place = 7;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (((!this.global1.is_gkchp && this.global1.allcountries[7].Gosstroy > 1) || (this.global1.is_gkchp && this.global1.allcountries[7].Gosstroy > 1)) && (this.global1.data[7] <= 0 || (this.global1.data[53] - this.global1.data[7] >= 20 && this.global1.event_done[73])) && !this.events[7].activeSelf && !this.global1.event_done[74])
			{
				this.this_num_event = 74;
				this.this_num_place = 7;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (((this.global1.data[19] >= this.global1.data[48] && this.global1.data[20] >= 6 && this.global1.data[21] >= 1990) || this.global1.data[21] >= 1991 || this.global1.allcountries[7].Gosstroy == 2) && !this.events[12].activeSelf && !this.global1.event_done[75] && this.global1.data[0] != 12)
			{
				this.this_num_event = 75;
				this.this_num_place = 12;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (((this.global1.data[19] >= this.global1.data[48] && this.global1.data[20] >= 4 && this.global1.data[21] >= 1989) || this.global1.data[21] >= 1990) && !this.events[11].activeSelf && !this.global1.event_done[76])
			{
				this.this_num_event = 76;
				this.this_num_place = 11;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.global1.allcountries[20].Gosstroy == 2 && this.global1.data[0] != 20 && !this.events[20].activeSelf && !this.global1.event_done[77])
			{
				this.this_num_event = 77;
				this.this_num_place = 20;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.global1.allcountries[1].Gosstroy == 1 && this.global1.allcountries[1].paths <= 0 && this.global1.data[0] != 1 && !this.events[1].activeSelf && !this.global1.event_done[89])
			{
				this.this_num_event = 89;
				this.this_num_place = 1;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.global1.data[7] <= 665 && this.global1.allcountries[1].paths <= 0 && this.global1.data[0] != 1 && !this.events[1].activeSelf && !this.global1.event_done[90] && this.global1.event_done[89])
			{
				this.this_num_event = 90;
				this.this_num_place = 1;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.global1.allcountries[1].Gosstroy == 2 && this.global1.allcountries[1].paths <= 0 && this.global1.data[0] != 1 && !this.events[1].activeSelf && !this.global1.event_done[91])
			{
				this.this_num_event = 91;
				this.this_num_place = 1;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (!this.global1.event_done[62] && this.global1.allcountries[7].paths != 3 && ((this.global1.allcountries[7].Gosstroy == 2 && this.global1.data[5] >= 700) || (this.global1.allcountries[7].Vyshi && this.global1.data[5] >= 500) || this.global1.data[5] >= 900) && this.global1.data[0] != 18 && this.global1.data[0] != 20 && this.global1.data[0] != 49 && this.global1.data[0] != 50 && this.global1.data[0] != 51 && this.global1.data[20] >= this.global1.data[47] + this.global1.data[48] && !this.events[7].activeSelf && !this.global1.event_done[107] && this.global1.data[0] != 12)
			{
				this.this_num_event = 107;
				this.this_num_place = 7;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (((this.global1.data[19] >= this.global1.data[48] && this.global1.data[20] >= 3 && this.global1.data[21] >= 1990) || this.global1.data[21] >= 1991) && this.global1.allcountries[1].paths <= 0 && !this.global1.event_done[89] && this.global1.allcountries[1].Gosstroy == 0 && this.global1.data[0] != 1 && !this.events[1].activeSelf && !this.global1.event_done[92])
			{
				this.this_num_event = 92;
				this.this_num_place = 1;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.global1.data[0] != 1 && this.global1.data[0] != 18 && this.global1.data[0] != 10 && this.global1.data[0] != 12 && this.global1.data[0] != 18 && this.global1.data[0] != 20 && this.global1.data[0] != 49 && this.global1.data[0] != 50 && this.global1.data[0] != 51 && this.global1.data[21] >= 1990 && this.global1.data[0] != 4 && (this.global1.data[27] + this.global1.data[28] + this.global1.data[29] <= 0 || this.global1.data[29] > 0) && (this.global1.data[11] != 0 || (this.global1.allcountries[this.global1.data[0]].isSEV && this.global1.allcountries[this.global1.data[0]].isOVD && !this.global1.allcountries[7].isSEV && !this.global1.allcountries[7].isOVD)) && !this.events[7].activeSelf && !this.global1.event_done[108])
			{
				this.this_num_event = 108;
				this.this_num_place = 7;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.global1.allcountries[15].isOVD && this.global1.allcountries[4].paths <= 0 && this.global1.science[9] && this.global1.allcountries[5].isOVD && this.global1.allcountries[5].isSEV && this.global1.allcountries[3].isOVD && this.global1.allcountries[3].isSEV && this.global1.allcountries[this.global1.data[0]].isOVD && this.global1.allcountries[this.global1.data[0]].isSEV && !this.global1.allcountries[4].isOVD && !this.global1.allcountries[4].isSEV && !this.global1.allcountries[7].isSEV && !this.global1.allcountries[7].isOVD && !this.events[1].activeSelf && !this.global1.event_done[129])
			{
				this.this_num_event = 129;
				this.this_num_place = 4;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			if (((this.global1.data[19] >= this.global1.data[47] && this.global1.data[20] >= 1 && this.global1.data[21] >= 1989) || this.global1.data[21] >= 1990) && !this.events[21].activeSelf && !this.global1.event_done[13])
			{
				this.this_num_event = 13;
				this.this_num_place = 21;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (((this.global1.data[19] >= this.global1.data[47] && this.global1.data[20] >= 8 - this.global1.data[47] / 7 && this.global1.data[21] >= 1989) || this.global1.data[21] >= 1990) && !this.events[8].activeSelf && !this.global1.event_done[14])
			{
				this.this_num_event = 14;
				this.this_num_place = 8;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (((this.global1.data[19] >= this.global1.data[47] && this.global1.data[20] >= 5 && this.global1.data[21] >= 1989) || this.global1.data[21] >= 1990) && !this.events[22].activeSelf && !this.global1.event_done[15])
			{
				this.this_num_event = 15;
				this.this_num_place = 22;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (((this.global1.data[19] >= this.global1.data[47] && this.global1.data[20] >= 6 && this.global1.data[21] >= 1989) || this.global1.data[21] >= 1990) && !this.events[16].activeSelf && !this.global1.event_done[16])
			{
				this.this_num_event = 16;
				this.this_num_place = 16;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.global1.data[7] <= 935 && this.global1.allcountries[11].Gosstroy >= 1 && !this.events[11].activeSelf && !this.global1.event_done[17] && this.global1.event_done[76])
			{
				this.this_num_event = 17;
				this.this_num_place = 11;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (((this.global1.data[19] >= this.global1.data[47] && this.global1.data[20] >= 11 && this.global1.data[21] >= 1989) || this.global1.data[21] >= 1990) && !this.global1.allcountries[19].Stasi && !this.events[19].activeSelf && !this.global1.event_done[18])
			{
				this.this_num_event = 18;
				this.this_num_place = 19;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (((this.global1.data[19] >= this.global1.data[47] && this.global1.data[20] >= 9 && this.global1.data[21] >= 1989) || this.global1.data[21] >= 1990) && this.global1.allcountries[19].Stasi && !this.events[19].activeSelf && !this.global1.event_done[19])
			{
				this.this_num_event = 19;
				this.this_num_place = 19;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.global1.science[5] && (this.global1.data[0] < 49 || this.global1.data[0] > 51) && this.global1.data[0] != 10 && this.global1.data[0] != 12 && this.global1.data[0] != 18 && !this.events[7].activeSelf && !this.global1.event_done[59])
			{
				this.this_num_event = 59;
				this.this_num_place = 7;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.global1.science[8] && (this.global1.data[0] < 49 || this.global1.data[0] > 51) && this.global1.data[0] != 10 && this.global1.data[0] != 12 && this.global1.data[0] != 18 && !this.events[7].activeSelf && !this.global1.event_done[60])
			{
				this.this_num_event = 60;
				this.this_num_place = 7;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.global1.science[2] && (this.global1.data[0] < 49 || this.global1.data[0] > 51) && this.global1.data[0] != 10 && this.global1.data[0] != 12 && this.global1.data[0] != 18 && !this.events[7].activeSelf && !this.global1.event_done[61])
			{
				this.this_num_event = 61;
				this.this_num_place = 7;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.global1.data[20] >= 11 && !this.events[25].activeSelf && !this.global1.event_done[50])
			{
				this.this_num_event = 50;
				this.this_num_place = 25;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.global1.data[20] >= 1 && this.global1.data[21] >= 1990 && this.global1.data[0] != 12 && !this.events[0].activeSelf && !this.global1.event_done[51])
			{
				this.this_num_event = 51;
				this.this_num_place = 0;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.global1.data[20] >= 8 && this.global1.data[21] >= 1990 && !this.events[14].activeSelf && !this.global1.event_done[53])
			{
				this.this_num_event = 53;
				this.this_num_place = 14;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.global1.data[20] >= 7 && this.global1.data[21] >= 1991 && this.global1.allcountries[7].isSEV && !this.global1.allcountries[this.global1.data[0]].Vyshi && !this.events[0].activeSelf && !this.global1.event_done[54])
			{
				this.this_num_event = 54;
				this.this_num_place = 0;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (((this.global1.data[19] >= this.global1.data[47] && this.global1.data[20] >= 11 && this.global1.data[21] >= 1990) || this.global1.data[21] >= 1991) && this.global1.data[0] == 1 && !this.events[0].activeSelf && !this.global1.event_done[78])
			{
				this.this_num_event = 78;
				this.this_num_place = 0;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (((this.global1.data[19] >= this.global1.data[47] && this.global1.data[20] >= 6 && this.global1.data[21] >= 1991) || this.global1.data[21] >= 1992) && !this.global1.allcountries[7].Vyshi && (!this.global1.is_gkchp || (this.global1.is_gkchp && this.global1.allcountries[7].Gosstroy > 1)) && ((this.global1.allcountries[7].isSEV && this.global1.allcountries[7].isOVD) || (this.global1.data[7] <= 750 && this.global1.allcountries[7].Gosstroy >= 1)) && !this.events[7].activeSelf && !this.global1.event_done[79])
			{
				this.this_num_event = 79;
				this.this_num_place = 7;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (((this.global1.data[19] >= this.global1.data[47] && this.global1.data[20] >= 3 && this.global1.data[21] >= 1991) || this.global1.data[21] >= 1992) && !this.events[23].activeSelf && !this.global1.event_done[80])
			{
				this.this_num_event = 80;
				this.this_num_place = 23;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (((this.global1.data[19] >= this.global1.data[47] && this.global1.data[20] >= 3 && this.global1.data[21] >= 1991) || this.global1.data[21] >= 1992) && !this.events[14].activeSelf && !this.global1.event_done[81])
			{
				this.this_num_event = 81;
				this.this_num_place = 14;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.global1.science[9] && (this.global1.data[0] < 49 || this.global1.data[0] > 51) && !this.events[7].activeSelf && !this.global1.event_done[87] && this.global1.data[0] != 18)
			{
				this.this_num_event = 87;
				this.this_num_place = 7;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if ((this.global1.data[14] >= 4 || this.global1.allcountries[this.global1.data[0]].Vyshi || this.global1.data[11] == 3) && this.global1.data[0] != 49 && this.global1.data[0] != 50 && this.global1.data[0] != 51 && this.global1.data[0] != 10 && this.global1.data[0] != 12 && this.global1.data[0] != 18 && this.global1.data[0] != 1 && !this.events[6].activeSelf && !this.global1.event_done[106])
			{
				this.this_num_event = 106;
				this.this_num_place = 6;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (((this.global1.data[2] <= 200 && this.global1.allcountries[7].isOVD) || (this.global1.data[10] >= 700 && !this.global1.allcountries[this.global1.data[0]].Vyshi)) && this.global1.data[21] >= 1991 && this.global1.data[0] != 18 && (this.global1.data[0] < 49 || this.global1.data[0] > 51) && this.global1.science[9] && !this.events[7].activeSelf && !this.global1.event_done[105])
			{
				this.this_num_event = 105;
				this.this_num_place = 7;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.global1.allcountries[7].paths <= 0 && (!this.global1.is_gkchp || (this.global1.is_gkchp && this.global1.allcountries[7].Gosstroy > 1 && !this.global1.allcountries[7].Vyshi)) && !this.global1.allcountries[7].Vyshi && this.global1.data[2] == 0 && this.global1.data[6] >= 900 && ((this.global1.data[20] > 10 && this.global1.data[21] >= 1989) || this.global1.data[21] >= 1990) && this.global1.data[0] != 20 && this.global1.data[0] != 49 && this.global1.data[0] != 50 && this.global1.data[0] != 51 && this.global1.data[0] != 10 && this.global1.data[0] != 12 && this.global1.data[0] != 18 && !this.events[7].activeSelf && !this.global1.event_done[128])
			{
				this.this_num_event = 128;
				this.this_num_place = 7;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.global1.allcountries[7].paths <= 0 && (!this.global1.is_gkchp || (this.global1.is_gkchp && this.global1.allcountries[7].Gosstroy > 1 && !this.global1.allcountries[7].Vyshi)) && this.global1.data[6] - this.global1.data[2] / 4 >= 900 && ((this.global1.data[20] > 10 && this.global1.data[21] >= 1989) || this.global1.data[21] >= 1990) && this.global1.data[0] != 20 && this.global1.data[0] != 49 && this.global1.data[0] != 50 && this.global1.data[0] != 51 && this.global1.data[0] != 10 && this.global1.data[0] != 12 && this.global1.data[0] != 18 && !this.events[7].activeSelf && !this.global1.event_done[128])
			{
				this.this_num_event = 128;
				this.this_num_place = 7;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.global1.data[20] == 7 && this.global1.data[21] == 1989 && !this.events[24].activeSelf && !this.global1.event_done[130])
			{
				this.this_num_event = 130;
				this.this_num_place = 24;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			else if (this.pastDate(1, 2, 1990) && !this.events[26].activeSelf && !this.global1.event_done[253])
			{
				this.this_num_event = 253;
				this.this_num_place = 26;
				this.events[this.this_num_place].SetActive(true);
				this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
			}
			if (this.global1.data[0] == 5)
			{
				if (((this.global1.data[20] >= this.global1.data[47] + this.global1.data[48] && this.global1.data[21] >= 1991) || this.global1.data[21] >= 1992) && !this.events[5].activeSelf && !this.global1.event_done[102])
				{
					this.this_num_event = 102;
					this.this_num_place = 5;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[20] >= 8 && this.global1.data[20] <= 9 && this.global1.data[21] == 1989 && this.global1.data[14] <= 2 && !this.events[5].activeSelf && !this.global1.event_done[95])
				{
					this.this_num_event = 95;
					this.this_num_place = 5;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[19] >= this.global1.data[49] && this.global1.event_done[98] && ((this.global1.allcountries[this.global1.data[0]].isSEV && this.global1.allcountries[7].isSEV) || (this.global1.allcountries[this.global1.data[0]].isOVD && this.global1.allcountries[7].isOVD)) && !this.global1.is_gkchp && (this.global1.data[11] == 0 || this.global1.data[11] == 5) && !this.events[5].activeSelf && !this.global1.event_done[99])
				{
					this.this_num_event = 99;
					this.this_num_place = 5;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (((this.global1.data[20] >= 2 && this.global1.data[21] >= 1990) || this.global1.data[21] >= 1991) && this.global1.data[19] >= this.global1.data[49] && this.global1.event_done[98] && this.global1.data[11] != 0 && !this.events[5].activeSelf && !this.global1.event_done[100])
				{
					this.this_num_event = 100;
					this.this_num_place = 5;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[19] >= this.global1.data[49] && this.global1.data[11] != 0 && (this.global1.data[14] >= 4 || this.global1.data[11] == 3) && !this.events[5].activeSelf && !this.global1.event_done[103])
				{
					this.this_num_event = 103;
					this.this_num_place = 5;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[20] >= 11 && this.global1.data[11] == 0 && this.global1.data[21] == 1989 && !this.events[5].activeSelf && !this.global1.event_done[96])
				{
					this.this_num_event = 96;
					this.this_num_place = 5;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[20] >= 3 && this.global1.data[11] == 0 && this.global1.data[21] == 1989 && !this.events[5].activeSelf && !this.global1.event_done[93])
				{
					this.this_num_event = 93;
					this.this_num_place = 5;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[20] >= 4 && this.global1.data[11] == 0 && this.global1.data[21] == 1989 && !this.events[5].activeSelf && !this.global1.event_done[94])
				{
					this.this_num_event = 94;
					this.this_num_place = 5;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[31] >= 700 && this.global1.data[21] >= 1990 && !this.events[5].activeSelf && !this.global1.event_done[110])
				{
					this.this_num_event = 110;
					this.this_num_place = 5;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (((this.global1.data[3] - this.global1.data[4] <= 100 && this.global1.data[21] >= 1990) || this.global1.data[3] <= 250 || this.global1.data[4] >= 750) && this.global1.event_done[95] && !this.global1.event_done[98] && this.global1.data[11] == 0 && !this.events[5].activeSelf && !this.global1.event_done[97])
				{
					this.this_num_event = 97;
					this.this_num_place = 5;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (((this.global1.data[3] - this.global1.data[4] <= -200 && this.global1.data[21] >= 1990) || this.global1.data[3] <= 215) && this.global1.event_done[97] && this.global1.data[11] == 0 && !this.events[5].activeSelf && !this.global1.event_done[98])
				{
					this.this_num_event = 98;
					this.this_num_place = 5;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[11] > 1 && ((this.global1.data[21] >= 1990 && this.global1.data[20] >= 3) || this.global1.data[21] >= 1991) && !this.events[5].activeSelf && !this.global1.event_done[101])
				{
					this.this_num_event = 101;
					this.this_num_place = 5;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
			}
			else if (this.global1.data[0] == 10)
			{
				if (this.pastDate(28, 6, 1989) && !this.events[10].activeSelf && !this.global1.event_done[195])
				{
					this.this_num_event = 195;
					this.this_num_place = 10;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[4] > 750 && this.global1.data[11] != 0 && this.global1.data[3] < 500 && this.global1.data[5] < 300 && this.global1.data[15] < 8 && this.global1.allcountries[5].Gosstroy != 0 && this.global1.allcountries[5].Gosstroy != 9 && !this.events[10].activeSelf && !this.global1.event_done[254])
				{
					this.this_num_event = 254;
					this.this_num_place = 10;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.pastDate(1, 1, 1989) && !this.events[10].activeSelf && !this.global1.event_done[208])
				{
					this.this_num_event = 208;
					this.this_num_place = 10;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.pastDate(1, 7, 1990) && this.global1.data[101] == 1 && (this.global1.data[10] > 850 || this.global1.data[7] < 500) && !this.events[10].activeSelf && !this.global1.event_done[255])
				{
					this.this_num_event = 255;
					this.this_num_place = 10;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.pastDate(1, 12, 1989) && !this.events[10].activeSelf && !this.global1.event_done[196])
				{
					this.this_num_event = 196;
					this.this_num_place = 10;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if ((this.global1.data[20] >= this.global1.data[64] + 4 || (this.global1.data[20] <= 4 && this.global1.data[64] >= 8 && this.global1.data[20] >= this.global1.data[64] - 9)) && !this.events[10].activeSelf && !this.global1.event_done[197])
				{
					this.this_num_event = 197;
					this.this_num_place = 10;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.pastDate(3, 2, 1991) && !this.events[10].activeSelf && !this.global1.event_done[198])
				{
					this.this_num_event = 198;
					this.this_num_place = 10;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[65] <= 0 && !this.events[10].activeSelf && !this.global1.event_done[199])
				{
					this.this_num_event = 199;
					this.this_num_place = 10;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.pastDate(1, 12, 1991) && !this.events[10].activeSelf && !this.global1.event_done[200])
				{
					this.this_num_event = 200;
					this.this_num_place = 10;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.pastDate(1, 5, 1991) && !this.events[10].activeSelf && !this.global1.event_done[201])
				{
					this.this_num_event = 201;
					this.this_num_place = 10;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if ((this.global1.data[4] > 400 || this.global1.data[1] < 550) && this.global1.data[16] < 13 && !this.events[10].activeSelf && !this.global1.event_done[202])
				{
					this.this_num_event = 202;
					this.this_num_place = 10;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.pastDate(1, 11, 1991) && this.global1.data[66] == 1 && this.global1.data[11] == 3 && !this.events[10].activeSelf && !this.global1.event_done[203])
				{
					this.this_num_event = 203;
					this.this_num_place = 10;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (((this.pastDate(1, 3, 1991) && this.global1.allcountries[16].Gosstroy != 0) || (!this.global1.allcountries[16].Torg && !this.global1.allcountries[7].isSEV)) && !this.events[16].activeSelf && !this.global1.event_done[204])
				{
					this.this_num_event = 204;
					this.this_num_place = 16;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.pastDate(1, 3, 1989) && !this.events[10].activeSelf && !this.global1.event_done[205])
				{
					this.this_num_event = 205;
					this.this_num_place = 10;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.pastDate(1, 1, 1991) && this.global1.science[9] && !this.events[10].activeSelf && !this.global1.event_done[206])
				{
					this.this_num_event = 206;
					this.this_num_place = 10;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.pastDate(1, 12, 1990) && !this.events[10].activeSelf && !this.global1.event_done[207])
				{
					this.this_num_event = 207;
					this.this_num_place = 10;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.pastDate(1, 10, 1990) && !this.events[10].activeSelf && !this.global1.event_done[208])
				{
					this.this_num_event = 208;
					this.this_num_place = 10;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[5] < 200 && this.global1.data[21] > 1989 && !this.events[10].activeSelf && !this.global1.event_done[209])
				{
					this.this_num_event = 209;
					this.this_num_place = 10;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.pastDate(1, 9, 1989) && !this.events[24].activeSelf && !this.global1.event_done[210])
				{
					this.this_num_event = 210;
					this.this_num_place = 24;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.pastDate(1, 12, 1990) && !this.events[10].activeSelf && !this.global1.event_done[243])
				{
					this.this_num_event = 243;
					this.this_num_place = 10;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[11] == 2 && (this.global1.data[20] >= this.global1.data[64] + 2 || (this.global1.data[20] <= 2 && this.global1.data[64] >= 10 && this.global1.data[20] >= this.global1.data[64] - 11)) && !this.events[10].activeSelf && !this.global1.event_done[194])
				{
					this.this_num_event = 194;
					this.this_num_place = 10;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
			}
			else if (this.global1.data[0] == 2)
			{
				if (this.global1.data[20] >= 0 && !this.events[2].activeSelf && !this.global1.event_done[132])
				{
					this.this_num_event = 132;
					this.this_num_place = 2;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.event_done[132] && !this.events[2].activeSelf && !this.global1.event_done[133])
				{
					this.this_num_event = 133;
					this.this_num_place = 2;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[20] >= 2 && !this.events[2].activeSelf && !this.global1.event_done[134])
				{
					this.this_num_event = 134;
					this.this_num_place = 2;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[20] >= 6 && !this.events[2].activeSelf && !this.global1.event_done[135])
				{
					this.this_num_event = 135;
					this.this_num_place = 2;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.event_done[135] && !this.events[2].activeSelf && !this.global1.event_done[136])
				{
					this.this_num_event = 136;
					this.this_num_place = 2;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (!this.global1.event_done[141] && this.global1.event_done[136] && this.global1.is_elect && !this.events[2].activeSelf && !this.global1.event_done[137])
				{
					this.this_num_event = 137;
					this.this_num_place = 2;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[20] >= 8 && !this.events[2].activeSelf && !this.global1.event_done[138])
				{
					this.this_num_event = 138;
					this.this_num_place = 2;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[15] > 7 && this.global1.event_done[138] && (this.global1.is_party_enabled[3] || this.global1.is_party_enabled[4]) && (this.global1.data[4] >= 600 || this.global1.data[3] <= 400) && !this.events[2].activeSelf && !this.global1.event_done[139])
				{
					this.this_num_event = 139;
					this.this_num_place = 2;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[20] >= this.global1.data[47] + this.global1.data[48] && this.global1.allcountries[1].Gosstroy <= 0 && !this.events[1].activeSelf && !this.global1.event_done[140])
				{
					this.this_num_event = 140;
					this.this_num_place = 1;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (((this.global1.data[20] >= 6 && this.global1.data[21] >= 1990) || this.global1.data[21] >= 1991) && (this.global1.data[4] - this.global1.data[3] >= 200 || (this.global1.data[3] <= 300 && this.global1.data[21] >= 1991) || (this.global1.data[4] >= 700 && this.global1.data[3] <= 500 && this.global1.data[21] >= 1991) || this.global1.data[17] >= 17 || this.global1.data[14] >= 4) && !this.events[2].activeSelf && !this.global1.event_done[141])
				{
					this.this_num_event = 141;
					this.this_num_place = 2;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[21] >= 1990 && (this.global1.data[18] >= 21 || this.global1.data[31] >= 700 || this.global1.data[14] >= 4 || this.global1.data[14] <= 0) && !this.events[2].activeSelf && !this.global1.event_done[142])
				{
					this.this_num_event = 142;
					this.this_num_place = 2;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (((this.global1.data[20] >= this.global1.data[47] + this.global1.data[48] && this.global1.data[21] >= 1991) || this.global1.data[21] >= 1992) && (this.global1.data[8] >= 100 || this.global1.data[34] >= 1) && !this.events[2].activeSelf && !this.global1.event_done[143])
				{
					this.this_num_event = 143;
					this.this_num_place = 2;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.is_gkchp && this.global1.allcountries[7].Gosstroy >= 2 && this.global1.data[31] >= 600 && ((this.global1.data[20] >= this.global1.data[49] && this.global1.data[21] >= 1991) || this.global1.data[21] >= 1992) && !this.events[2].activeSelf && !this.global1.event_done[144])
				{
					this.this_num_event = 144;
					this.this_num_place = 2;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (((this.global1.data[20] >= this.global1.data[47] + this.global1.data[48] && this.global1.data[21] >= 1990) || this.global1.data[21] >= 1991) && (this.global1.data[14] <= 2 || this.global1.data[17] <= 14) && (this.global1.is_party_enabled[1] || this.global1.is_party_enabled[2]) && !this.events[2].activeSelf && !this.global1.event_done[145])
				{
					this.this_num_event = 145;
					this.this_num_place = 2;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (((this.global1.data[20] >= this.global1.data[47] + this.global1.data[48] && this.global1.data[21] >= 1990) || this.global1.data[21] >= 1991) && this.global1.data[11] != 2 && (this.global1.data[14] <= 0 || this.global1.data[31] > 600) && this.global1.data[18] <= 19 && !this.events[2].activeSelf && !this.global1.event_done[146])
				{
					this.this_num_event = 146;
					this.this_num_place = 2;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
			}
			else if (this.global1.data[0] == 4)
			{
				if (((this.global1.data[19] >= this.global1.data[47] + this.global1.data[48] && this.global1.data[20] >= 1) || this.global1.data[20] >= 2) && !this.events[4].activeSelf && !this.global1.event_done[147])
				{
					this.this_num_event = 147;
					this.this_num_place = 4;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (((this.global1.data[19] >= this.global1.data[47] + this.global1.data[48] && this.global1.data[20] >= 5) || this.global1.data[20] >= 6) && !this.events[4].activeSelf && !this.global1.event_done[148])
				{
					this.this_num_event = 148;
					this.this_num_place = 4;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (((this.global1.data[19] >= this.global1.data[47] + this.global1.data[48] && this.global1.data[20] >= 6) || this.global1.data[20] >= 7) && !this.events[4].activeSelf && !this.global1.event_done[149])
				{
					this.this_num_event = 149;
					this.this_num_place = 4;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (((this.global1.data[19] >= 22 && this.global1.data[20] >= 9) || this.global1.data[20] >= 10) && !this.events[4].activeSelf && !this.global1.event_done[150])
				{
					this.this_num_event = 150;
					this.this_num_place = 4;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (((this.global1.data[19] >= this.global1.data[47] + this.global1.data[48] && this.global1.data[20] >= 7) || this.global1.data[20] >= 8) && !this.events[4].activeSelf && !this.global1.event_done[152])
				{
					this.this_num_event = 152;
					this.this_num_place = 4;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (((this.global1.data[19] >= this.global1.data[47] + this.global1.data[48] && this.global1.data[20] >= 7) || this.global1.data[20] >= 8) && !this.events[4].activeSelf && !this.global1.event_done[151])
				{
					this.this_num_event = 151;
					this.this_num_place = 4;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[19] >= this.global1.data[47] + this.global1.data[48] && !this.events[4].activeSelf && this.global1.event_done[152] && !this.global1.event_done[153])
				{
					this.this_num_event = 153;
					this.this_num_place = 4;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (((this.global1.data[20] >= (1000 - this.global1.data[2]) / 100 && this.global1.data[21] >= 1990) || this.global1.data[21] >= 1991) && !this.global1.allcountries[7].Vyshi && !this.events[4].activeSelf && !this.global1.event_done[154])
				{
					this.this_num_event = 154;
					this.this_num_place = 4;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (((this.global1.data[20] >= 11 && this.global1.data[21] >= 1990) || this.global1.data[21] >= 1991) && !this.events[4].activeSelf && !this.global1.event_done[155])
				{
					this.this_num_event = 155;
					this.this_num_place = 4;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[20] >= this.global1.data[47] + this.global1.data[48] && this.global1.data[21] >= 1991 && !this.events[4].activeSelf && !this.global1.event_done[156])
				{
					this.this_num_event = 156;
					this.this_num_place = 4;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[20] >= 11 && !this.events[4].activeSelf && !this.global1.event_done[157])
				{
					this.this_num_event = 157;
					this.this_num_place = 4;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[19] >= this.global1.data[47] + this.global1.data[48] && (this.global1.data[57] == 10 || (this.global1.event_done[151] && this.global1.data[57] == 0)) && this.global1.data[60] == 1 && this.global1.data[50] == 1 && this.global1.data[11] != 3 && !this.events[4].activeSelf && !this.global1.event_done[158])
				{
					this.this_num_event = 158;
					this.this_num_place = 4;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[31] >= 700 && this.global1.data[21] >= 1991 && this.global1.data[11] != 3 && (this.global1.allcountries[5].Gosstroy != 0 || this.global1.event_done[46]) && this.global1.allcountries[5].Gosstroy != 9 && !this.events[5].activeSelf && !this.global1.event_done[159])
				{
					this.this_num_event = 159;
					this.this_num_place = 5;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[31] >= 700 && this.global1.data[21] >= 1991 && this.global1.data[11] != 3 && this.global1.allcountries[7].Vyshi && this.global1.event_done[159] && !this.events[7].activeSelf && !this.global1.event_done[160])
				{
					this.this_num_event = 160;
					this.this_num_place = 7;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[19] >= this.global1.data[47] + this.global1.data[48] && this.global1.data[21] >= 1990 && this.global1.data[6] >= 700 && this.global1.data[14] <= 2 && this.global1.data[11] == 1 && !this.events[4].activeSelf && !this.global1.event_done[161])
				{
					this.this_num_event = 161;
					this.this_num_place = 4;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
			}
			else if (this.global1.data[0] == 20)
			{
				if (this.global1.data[19] >= this.global1.data[47] + this.global1.data[48] && this.global1.data[20] >= 1 && !this.events[20].activeSelf && !this.global1.event_done[165])
				{
					this.this_num_event = 165;
					this.this_num_place = 20;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[19] >= 1 && this.global1.data[20] >= 3 && !this.events[20].activeSelf && !this.global1.event_done[166])
				{
					this.this_num_event = 166;
					this.this_num_place = 20;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[19] >= this.global1.data[47] + this.global1.data[48] && !this.events[20].activeSelf && !this.global1.event_done[167] && this.global1.event_done[12])
				{
					this.this_num_event = 167;
					this.this_num_place = 20;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[19] >= this.global1.data[47] + this.global1.data[48] && !this.global1.allcountries[this.global1.data[0]].Vyshi && ((this.global1.data[20] >= 3 && this.global1.data[21] >= 1990) || this.global1.data[21] >= 1991) && !this.events[20].activeSelf && !this.global1.event_done[168])
				{
					this.this_num_event = 168;
					this.this_num_place = 20;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[19] >= this.global1.data[47] + this.global1.data[48] && this.global1.allcountries[8].Torg && this.global1.data[21] == 1989 && !this.events[20].activeSelf && !this.global1.event_done[169])
				{
					this.this_num_event = 169;
					this.this_num_place = 20;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[57] <= 0 && this.global1.data[11] == 2 && !this.events[20].activeSelf && !this.global1.event_done[170])
				{
					this.this_num_event = 170;
					this.this_num_place = 20;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[19] >= this.global1.data[47] + this.global1.data[48] && this.global1.data[57] < 1000 && this.global1.data[20] >= 11 && !this.events[20].activeSelf && !this.global1.event_done[171])
				{
					this.this_num_event = 171;
					this.this_num_place = 20;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[19] >= this.global1.data[47] + this.global1.data[48] && this.global1.data[15] < 7 && this.global1.data[7] < 850 && !this.events[20].activeSelf && !this.global1.event_done[172])
				{
					this.this_num_event = 172;
					this.this_num_place = 20;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[19] >= this.global1.data[47] + this.global1.data[48] && this.global1.data[20] >= 7 && !this.events[20].activeSelf && !this.global1.event_done[173] && this.global1.event_done[4])
				{
					this.this_num_event = 173;
					this.this_num_place = 20;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[19] >= this.global1.data[47] + this.global1.data[48] && this.global1.data[16] < 13 && this.global1.data[7] < 800 && !this.global1.event_done[174])
				{
					this.this_num_event = 174;
					this.this_num_place = 20;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[21] >= 1990 && this.global1.data[57] < 100 && this.global1.data[11] == 2 && (this.global1.data[3] < 500 || this.global1.data[4] > 500) && !this.global1.event_done[175])
				{
					this.this_num_event = 175;
					this.this_num_place = 20;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if ((this.global1.data[3] < 300 || this.global1.data[4] > 700 || this.global1.data[7] < 750) && !this.global1.event_done[176])
				{
					this.this_num_event = 176;
					this.this_num_place = 20;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if ((this.global1.data[3] < 300 || this.global1.data[4] > 700 || this.global1.data[7] < 600) && !this.global1.allcountries[this.global1.data[0]].Vyshi && this.global1.data[21] >= 1991 && !this.global1.event_done[177] && this.global1.event_done[176])
				{
					this.this_num_event = 177;
					this.this_num_place = 20;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[56] >= 100 && this.global1.data[20] >= 6 && this.global1.data[11] == 0 && this.global1.data[21] >= 1991 && !this.global1.event_done[178])
				{
					this.this_num_event = 178;
					this.this_num_place = 20;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
			}
			else if (this.global1.data[0] == 6)
			{
				if (((this.global1.data[20] >= this.global1.data[47] + this.global1.data[48] && this.global1.data[21] >= 1989) || this.global1.data[21] >= 1990) && this.global1.data[11] == 0 && this.global1.data[14] <= 2 && this.global1.data[2] <= 700 && !this.events[6].activeSelf && !this.global1.event_done[111])
				{
					this.this_num_event = 111;
					this.this_num_place = 6;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[21] >= 1990 && this.global1.data[11] == 2 && this.global1.data[16] <= 11 && this.global1.data[31] >= 750 && this.global1.data[15] >= 8 && !this.events[6].activeSelf && !this.global1.event_done[1000])
				{
					this.this_num_event = 1000;
					this.this_num_place = 6;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (((this.global1.data[20] >= 5 && this.global1.data[21] >= 1989) || this.global1.data[21] >= 1990) && this.global1.data[11] == 0 && this.global1.data[17] <= 16 && (this.global1.data[10] >= 250 || this.global1.data[4] >= 250 || this.global1.data[2] <= 500) && !this.events[6].activeSelf && !this.global1.event_done[112])
				{
					this.this_num_event = 112;
					this.this_num_place = 6;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.event_done[48] && !this.events[6].activeSelf && !this.global1.event_done[113])
				{
					this.this_num_event = 113;
					this.this_num_place = 6;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if ((this.global1.data[14] <= 2 || this.global1.data[17] <= 16) && (this.global1.data[3] <= 400 || this.global1.data[4] >= 700 || this.global1.data[2] <= 200) && !this.events[6].activeSelf && !this.global1.event_done[114])
				{
					this.this_num_event = 114;
					this.this_num_place = 6;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[21] >= 1990 && this.global1.data[11] != 0 && !this.events[6].activeSelf && !this.global1.event_done[116])
				{
					this.this_num_event = 116;
					this.this_num_place = 6;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[21] >= 1990 && (this.global1.data[14] >= 3 || this.global1.data[18] >= 21) && !this.global1.allcountries[this.global1.data[0]].Vyshi && !this.events[6].activeSelf && !this.global1.event_done[117])
				{
					this.this_num_event = 117;
					this.this_num_place = 6;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (((this.global1.data[20] >= this.global1.data[47] + this.global1.data[48] && this.global1.data[21] >= 1990) || this.global1.data[21] >= 1991) && this.global1.data[11] != 0 && !this.events[6].activeSelf && !this.global1.event_done[119])
				{
					this.this_num_event = 119;
					this.this_num_place = 6;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (((this.global1.data[20] >= this.global1.data[47] + this.global1.data[48] && this.global1.data[21] >= 1990) || this.global1.data[21] >= 1991) && this.global1.data[11] == 0 && !this.events[6].activeSelf && !this.global1.event_done[120])
				{
					this.this_num_event = 120;
					this.this_num_place = 6;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if ((this.global1.data[18] >= 21 || this.global1.data[18] <= 18 || this.global1.data[14] <= 0 || this.global1.data[14] >= 4 || (this.global1.data[22] > 700 && this.global1.data[31] > 700)) && this.global1.data[21] >= 1991 && !this.events[6].activeSelf && !this.global1.event_done[123])
				{
					this.this_num_event = 123;
					this.this_num_place = 6;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[11] == 2 && this.global1.data[14] <= 4 && (this.global1.data[1] + this.global1.data[2] <= 1100 || this.global1.data[4] - this.global1.data[3] >= 300 || this.global1.data[3] <= 350) && !this.events[6].activeSelf && !this.global1.event_done[124])
				{
					this.this_num_event = 124;
					this.this_num_place = 6;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (((this.global1.data_old[8] < 0 && this.global1.data[8] + this.global1.data_old[0] * 4 <= 0) || this.global1.data[24] - this.global1.data[23] >= 25) && this.global1.data[21] >= 1990 && !this.events[6].activeSelf && !this.global1.event_done[125])
				{
					this.this_num_event = 125;
					this.this_num_place = 6;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[10] >= 700 && this.global1.data[21] >= 1990 && !this.events[6].activeSelf && !this.global1.event_done[126])
				{
					this.this_num_event = 126;
					this.this_num_place = 6;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if ((this.global1.data[11] == 1 || (this.global1.data[11] != 0 && this.global1.data[31] >= 600)) && !this.events[this.global1.data[0]].activeSelf && !this.global1.event_done[118])
				{
					this.this_num_event = 118;
					this.this_num_place = 6;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[59] == 3 && this.global1.data[0] == 6 && this.global1.data[6] > 400 && this.global1.data[21] >= 1991 && this.global1.allcountries[this.global1.data[0]].isOVD && (this.global1.data[54] >= 7 || (this.global1.allcountries[15].isOVD && this.global1.data[54] >= 5)) && !this.global1.allcountries[15].Help && (this.global1.allcountries[20].isSEV || this.global1.allcountries[20].isOVD) && ((this.global1.allcountries[20].Gosstroy == 0 && this.global1.data[14] < 3) || (this.global1.allcountries[20].Gosstroy == 1 && this.global1.data[14] == 3)) && !this.events[6].activeSelf && !this.global1.event_done[121])
				{
					this.this_num_event = 121;
					this.this_num_place = 6;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if ((this.global1.data[14] >= 4 || this.global1.allcountries[this.global1.data[0]].Vyshi) && this.global1.event_done[106] && !this.events[this.global1.data[0]].activeSelf && !this.global1.event_done[122])
				{
					this.this_num_event = 122;
					this.this_num_place = 6;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[11] == 0 && this.global1.data[14] <= 3 && !this.global1.allcountries[this.global1.data[0]].Vyshi && this.global1.data[2] + this.global1.data[1] <= 1050 && !this.events[this.global1.data[0]].activeSelf && !this.global1.event_done[115])
				{
					this.this_num_event = 115;
					this.this_num_place = 6;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[11] != 0 && ((this.global1.data[20] >= this.global1.data[47] + this.global1.data[48] && this.global1.data[21] >= 1990) || this.global1.data[21] >= 1991) && !this.events[this.global1.data[0]].activeSelf && !this.global1.event_done[127])
				{
					this.this_num_event = 127;
					this.this_num_place = 6;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
			}
			else if (this.global1.data[0] == 12)
			{
				if (this.global1.data[20] == 6 && this.global1.data[21] == 1990 && !this.events[12].activeSelf && !this.global1.event_done[228])
				{
					this.this_num_event = 228;
					this.this_num_place = 12;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.pastDate(1, 8, 1991) && ((this.global1.data[80] == 100 && this.global1.data[81] == 0) || (this.global1.data[82] == 1 && this.global1.data[81] == 0 && this.global1.data[80] >= 60)) && !this.events[12].activeSelf && !this.global1.event_done[229])
				{
					this.this_num_event = 229;
					this.this_num_place = 12;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.pastDate(1, 10, 1990) && this.global1.data[83] == 1 && !this.events[12].activeSelf && !this.global1.event_done[230])
				{
					this.this_num_event = 230;
					this.this_num_place = 12;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.pastDate(14, 1, 1989) && !this.events[12].activeSelf && !this.global1.event_done[231])
				{
					this.this_num_event = 231;
					this.this_num_place = 12;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.pastDate(1, 12, 1990) && !this.events[12].activeSelf && !this.global1.event_done[232] && this.global1.data[84] == 1)
				{
					this.this_num_event = 232;
					this.this_num_place = 12;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.pastDate(1, 9, 1990) && this.global1.allcountries[19].Gosstroy != 2 && !this.events[12].activeSelf && !this.global1.event_done[233])
				{
					this.this_num_event = 233;
					this.this_num_place = 12;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.pastDate(1, 2, 1991) && !this.events[12].activeSelf && !this.global1.event_done[234])
				{
					this.this_num_event = 234;
					this.this_num_place = 12;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.pastDate(1, 8, 1989) && !this.events[12].activeSelf && !this.global1.event_done[235] && this.global1.data[11] != 0 && this.global1.data[1] <= 750)
				{
					this.this_num_event = 235;
					this.this_num_place = 12;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.pastDate(1, 3, 1990) && !this.events[12].activeSelf && !this.global1.event_done[236] && this.global1.data[11] != 0 && ((this.global1.data[1] <= 750 && this.global1.data[86] == 1) || (this.global1.data[1] <= 850 && this.global1.data[86] == 2)))
				{
					this.this_num_event = 236;
					this.this_num_place = 12;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.pastDate(1, 11, 1991) && this.global1.data[87] == 1 && !this.events[12].activeSelf && !this.global1.event_done[237])
				{
					this.this_num_event = 237;
					this.this_num_place = 12;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.pastDate(1, 8, 1990) && !this.events[12].activeSelf && !this.global1.event_done[239])
				{
					this.this_num_event = 239;
					this.this_num_place = 12;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.pastDate(15, 2, 1989) && !this.events[12].activeSelf && !this.global1.event_done[240])
				{
					this.this_num_event = 240;
					this.this_num_place = 12;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.pastDate(1, 10, 1990) && !this.events[12].activeSelf && !this.global1.event_done[246] && this.global1.data[4] >= 600)
				{
					this.this_num_event = 246;
					this.this_num_place = 12;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.pastDate(1, 7, 1990) && !this.events[12].activeSelf && !this.global1.event_done[247] && this.global1.data[96] == 1 && this.global1.data[80] <= 60 && this.global1.data[91] == 1)
				{
					this.this_num_event = 247;
					this.this_num_place = 12;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[0] == 12 && this.global1.science[6] && !this.events[12].activeSelf && !this.global1.event_done[248])
				{
					this.this_num_event = 248;
					this.this_num_place = 12;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.pastDate(1, 1, 1991) && !this.events[12].activeSelf && !this.global1.event_done[249] && this.global1.data[11] == 3 && this.global1.data[81] == 1 && this.global1.data[4] >= 600 && this.global1.data[80] <= 60)
				{
					this.this_num_event = 249;
					this.this_num_place = 12;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if ((this.global1.data[5] < 100 || this.global1.data[4] >= 850 || this.global1.data[3] < 450) && (this.global1.data[90] == 1 || this.global1.data[92] == 1 || this.global1.data[93] == 1 || this.global1.data[94] == 1) && this.global1.data[88] <= 0 && !this.events[12].activeSelf && !this.global1.event_done[250])
				{
					this.this_num_event = 250;
					this.this_num_place = 12;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[0] == 12 && this.global1.science[2] && !this.events[12].activeSelf && !this.global1.event_done[251])
				{
					this.this_num_event = 251;
					this.this_num_place = 12;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[80] >= 60 && this.global1.data[21] > 1989 && this.global1.data[4] <= 250 && !this.events[12].activeSelf && !this.global1.event_done[252])
				{
					this.this_num_event = 252;
					this.this_num_place = 12;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.pastDate(1, 3, 1989) && !this.events[12].activeSelf && !this.global1.event_done[258] && this.global1.data[11] == 0 && this.global1.data[1] <= 750)
				{
					this.this_num_event = 258;
					this.this_num_place = 12;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.pastDate(1, 5, 1989) && !this.events[12].activeSelf && this.global1.event_done[258] && !this.global1.event_done[259] && this.global1.data[92] == 1 && this.global1.data[11] == 0 && this.global1.data[1] <= 800)
				{
					this.this_num_event = 259;
					this.this_num_place = 12;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
			}
			else if (this.global1.data[0] == 3)
			{
				if (((this.global1.data[19] >= this.global1.data[49] && this.global1.data[20] >= 1 && this.global1.data[21] >= 1989) || this.global1.data[21] >= 1990) && !this.events[3].activeSelf && !this.global1.event_done[179])
				{
					this.this_num_event = 179;
					this.this_num_place = 3;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (((this.global1.data[19] >= this.global1.data[49] && this.global1.data[20] >= 3 && this.global1.data[21] >= 1989) || this.global1.data[21] >= 1990) && !this.events[3].activeSelf && !this.global1.event_done[180])
				{
					this.this_num_event = 180;
					this.this_num_place = 3;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (((this.global1.data[19] >= this.global1.data[49] && this.global1.data[20] >= 6 && this.global1.data[21] >= 1989) || this.global1.data[21] >= 1990) && !this.global1.event_done[181] && !this.events[3].activeSelf)
				{
					this.this_num_event = 181;
					this.this_num_place = 3;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if ((this.global1.data[3] <= 327 || this.global1.data[4] >= 930 || this.global1.data[7] <= 650 || this.global1.data[1] <= 300) && !this.global1.event_done[182] && !this.events[3].activeSelf)
				{
					this.this_num_event = 182;
					this.this_num_place = 3;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[19] >= this.global1.data[49] && (!this.global1.event_done[190] || this.global1.data[57] == 10) && this.global1.event_done[182] && !this.global1.event_done[183] && !this.events[3].activeSelf)
				{
					this.this_num_event = 183;
					this.this_num_place = 3;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[19] >= this.global1.data[49] + this.global1.data[48] && this.global1.event_done[183] && !this.global1.event_done[184] && !this.events[3].activeSelf)
				{
					this.this_num_event = 184;
					this.this_num_place = 3;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (((this.global1.data[19] >= this.global1.data[49] && this.global1.data[20] >= 3 && this.global1.data[21] >= 1990) || this.global1.data[21] >= 1991) && this.global1.data[11] != 3 && !this.global1.event_done[185] && !this.events[3].activeSelf)
				{
					this.this_num_event = 185;
					this.this_num_place = 3;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[19] >= this.global1.data[49] && this.global1.data[21] >= 1990 && this.global1.data[14] <= 2 && (this.global1.data[3] < 400 || this.global1.data[4] > 800) && !this.global1.event_done[186] && !this.events[3].activeSelf)
				{
					this.this_num_event = 186;
					this.this_num_place = 3;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (((this.global1.data[20] >= this.global1.data[49] + this.global1.data[48] && this.global1.data[21] >= 1990) || this.global1.data[21] >= 1991) && this.global1.data[11] < 2 && !this.global1.event_done[187] && !this.events[3].activeSelf)
				{
					this.this_num_event = 187;
					this.this_num_place = 3;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (((this.global1.data[19] >= this.global1.data[49] && this.global1.data[20] >= 9 && this.global1.data[21] >= 1990) || this.global1.data[21] >= 1991) && !this.global1.event_done[188] && !this.events[3].activeSelf)
				{
					this.this_num_event = 188;
					this.this_num_place = 3;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (((this.global1.data[19] >= this.global1.data[49] && this.global1.data[20] >= 3 && this.global1.data[21] >= 1991) || this.global1.data[21] >= 1992) && !this.global1.allcountries[3].Vyshi && !this.global1.allcountries[7].Vyshi && !this.global1.event_done[189] && !this.events[3].activeSelf)
				{
					this.this_num_event = 189;
					this.this_num_place = 3;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[11] == 0 && (this.global1.event_done[183] || (this.global1.data[20] >= 11 && this.global1.data[21] >= 1991) || this.global1.data[21] >= 1992) && (this.global1.data[4] >= 900 || this.global1.data[3] <= 300 || this.global1.data[1] <= 300 || this.global1.allcountries[7].Vyshi) && !this.global1.event_done[190] && !this.events[3].activeSelf)
				{
					this.this_num_event = 190;
					this.this_num_place = 3;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (((this.global1.data[20] >= this.global1.data[49] + this.global1.data[48] && this.global1.data[21] >= 1991) || this.global1.data[21] >= 1992) && !this.global1.event_done[191] && !this.events[3].activeSelf)
				{
					this.this_num_event = 191;
					this.this_num_place = 3;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[11] <= 1 && this.global1.allcountries[2].Gosstroy == 2 && !this.global1.event_done[192] && !this.events[3].activeSelf)
				{
					this.this_num_event = 192;
					this.this_num_place = 3;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[19] >= this.global1.data[49] && this.global1.event_done[192] && this.global1.data[60] == 10 && !this.global1.event_done[193] && !this.events[3].activeSelf)
				{
					this.this_num_event = 193;
					this.this_num_place = 3;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
			}
			else if (this.global1.data[0] == 18)
			{
				if (this.global1.data[11] == 2 && this.global1.data[4] > 650 && this.global1.data[15] < 8 && !this.events[26].activeSelf && !this.global1.event_done[211])
				{
					this.this_num_event = 211;
					this.this_num_place = 26;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[11] == 3 && this.global1.data[16] < 13 && (this.global1.data[20] >= this.global1.data[76] + 5 || (this.global1.data[20] <= 5 && this.global1.data[76] >= 7 && this.global1.data[20] >= this.global1.data[76] - 8)) && !this.events[26].activeSelf && !this.global1.event_done[212])
				{
					this.this_num_event = 212;
					this.this_num_place = 26;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[11] != 3 && this.global1.allcountries[1].Gosstroy == 2 && !this.global1.allcountries[1].isSEV && !this.global1.allcountries[1].isOVD && !this.events[1].activeSelf && !this.global1.event_done[363])
				{
					this.this_num_event = 363;
					this.this_num_place = 1;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.pastDate(2, 4, 1989) && !this.events[26].activeSelf && !this.global1.event_done[213])
				{
					this.this_num_event = 213;
					this.this_num_place = 26;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.allcountries[7].Gosstroy > 0 && !this.events[26].activeSelf && !this.global1.event_done[214])
				{
					this.this_num_event = 214;
					this.this_num_place = 26;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.pastDate(1, 2, 1990) && !this.events[7].activeSelf && !this.global1.event_done[215])
				{
					this.this_num_event = 215;
					this.this_num_place = 7;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.pastDate(1, 1, 1990) && this.global1.data[7] < 700 && this.global1.data[14] >= 3 && this.global1.data[77] > 0 && this.global1.data[10] < 500 && !this.global1.science[9] && !this.events[26].activeSelf && !this.global1.event_done[216])
				{
					this.this_num_event = 216;
					this.this_num_place = 26;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[7] < 600 && this.global1.data[77] > 0 && this.pastDate(1, 8, 1990) && this.global1.data[10] > 900 && this.global1.data[14] <= 2 && !this.events[26].activeSelf && !this.global1.event_done[217])
				{
					this.this_num_event = 217;
					this.this_num_place = 26;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[11] == 2 && this.global1.data[4] > 800 && !this.events[26].activeSelf && !this.global1.event_done[218])
				{
					this.this_num_event = 218;
					this.this_num_place = 26;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[11] == 3 && this.global1.data[14] <= 3 && (this.global1.data[20] >= this.global1.data[76] + 2 || (this.global1.data[20] <= 2 && this.global1.data[76] >= 10 && this.global1.data[20] >= this.global1.data[76] - 11)) && !this.events[26].activeSelf && !this.global1.event_done[219])
				{
					this.this_num_event = 219;
					this.this_num_place = 26;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.pastDate(1, 4, 1991) && !this.events[26].activeSelf && !this.global1.event_done[220])
				{
					this.this_num_event = 220;
					this.this_num_place = 26;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.pastDate(1, 3 + this.global1.data[51], 1990) && !this.events[26].activeSelf && !this.global1.event_done[221])
				{
					this.this_num_event = 221;
					this.this_num_place = 26;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.pastDate(1, 5, 1989) && this.global1.data[11] < 3 && !this.events[26].activeSelf && !this.global1.event_done[222])
				{
					this.this_num_event = 222;
					this.this_num_place = 26;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.pastDate(1, 2, 1991) && !this.events[26].activeSelf && !this.global1.event_done[223])
				{
					this.this_num_event = 223;
					this.this_num_place = 26;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.pastDate(1, 11, 1990) && !this.events[26].activeSelf && !this.global1.event_done[224])
				{
					this.this_num_event = 224;
					this.this_num_place = 26;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.pastDate(1, 10, 1991) && !this.events[26].activeSelf && !this.global1.event_done[225])
				{
					this.this_num_event = 225;
					this.this_num_place = 26;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.pastDate(1, 4, 1990) && !this.events[26].activeSelf && !this.global1.event_done[226])
				{
					this.this_num_event = 226;
					this.this_num_place = 26;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.pastDate(1, 1, 1989) && !this.events[26].activeSelf && !this.global1.event_done[242])
				{
					this.this_num_event = 242;
					this.this_num_place = 26;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (!this.events[26].activeSelf && (!this.global1.event_done[244] & this.global1.science[8]))
				{
					this.this_num_event = 244;
					this.this_num_place = 26;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.pastDate(1, 12, 1990) && this.global1.data[7] < 500 && !this.events[26].activeSelf && !this.global1.event_done[245])
				{
					this.this_num_event = 245;
					this.this_num_place = 26;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (!this.global1.allcountries[this.global1.data[0]].isSEV && !this.events[26].activeSelf && !this.global1.event_done[256])
				{
					this.this_num_event = 256;
					this.this_num_place = 26;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[11] == 1 && this.global1.data[7] <= 669 && !this.events[26].activeSelf && !this.global1.event_done[257])
				{
					this.this_num_event = 257;
					this.this_num_place = 26;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
			}
			else if (this.global1.data[0] == 1)
			{
				if (((this.global1.data[19] >= this.global1.data[49] && this.global1.data[20] >= 1 && this.global1.data[21] >= 1989) || this.global1.data[21] >= 1990) && !this.events[1].activeSelf && !this.global1.event_done[20])
				{
					this.this_num_event = 20;
					this.this_num_place = 1;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (((this.global1.data[19] >= this.global1.data[49] && this.global1.data[20] >= 8 && this.global1.data[21] >= 1989) || this.global1.data[21] >= 1990) && !this.events[1].activeSelf && !this.global1.event_done[21])
				{
					this.this_num_event = 21;
					this.this_num_place = 1;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (((this.global1.data[19] >= this.global1.data[49] && this.global1.data[20] >= 8 && this.global1.data[21] >= 1989) || this.global1.data[21] >= 1990) && !this.events[1].activeSelf && !this.global1.event_done[22])
				{
					this.this_num_event = 22;
					this.this_num_place = 1;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[7] <= 940 && (this.global1.data[27] + this.global1.data[28] + this.global1.data[29] <= 0 || this.global1.data[29] > 0) && !this.events[1].activeSelf && !this.global1.event_done[23])
				{
					this.this_num_event = 23;
					this.this_num_place = 1;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if ((this.global1.data[5] < 600 || this.global1.data[3] < 400) && this.global1.data[4] >= 600 && (this.global1.data[27] + this.global1.data[28] + this.global1.data[29] <= 0 || this.global1.data[29] > 0) && !this.events[1].activeSelf && !this.global1.event_done[24])
				{
					this.this_num_event = 24;
					this.this_num_place = 1;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.allcountries[2].paths != 2 && this.global1.allcountries[2].paths != 3 && (this.global1.allcountries[2].Gosstroy >= 1 || (this.global1.event_done[24] && this.global1.event_done[23])) && (this.global1.data[27] + this.global1.data[28] + this.global1.data[29] <= 0 || this.global1.data[29] > 0) && !this.events[1].activeSelf && !this.global1.event_done[25])
				{
					this.this_num_event = 25;
					this.this_num_place = 1;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (((this.global1.allcountries[5].Gosstroy >= 1 && this.global1.allcountries[6].Gosstroy >= 1) || (this.global1.event_done[25] && this.global1.event_done[24] && this.global1.event_done[23])) && (this.global1.data[27] + this.global1.data[28] + this.global1.data[29] <= 0 || this.global1.data[29] > 0) && !this.events[1].activeSelf && !this.global1.event_done[26])
				{
					this.this_num_event = 26;
					this.this_num_place = 1;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if ((this.global1.data[3] < 500 || this.global1.data[4] > 500) && !this.events[1].activeSelf && !this.global1.event_done[27])
				{
					this.this_num_event = 27;
					this.this_num_place = 1;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (((this.global1.data[19] >= this.global1.data[49] && this.global1.data[20] >= 9 && this.global1.data[21] >= 1989) || this.global1.data[21] >= 1990) && this.global1.data[16] == 10 && !this.global1.event_done[32] && !this.events[1].activeSelf && !this.global1.event_done[28])
				{
					this.this_num_event = 28;
					this.this_num_place = 1;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (((this.global1.data[19] >= this.global1.data[49] && this.global1.data[20] >= 9 && this.global1.data[21] >= 1989) || this.global1.data[21] >= 1990) && this.global1.data[14] < 3 && this.global1.data[1] <= 600 && this.global1.data[11] != 3 && !this.events[1].activeSelf && !this.global1.event_done[29])
				{
					this.this_num_event = 29;
					this.this_num_place = 1;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (((this.global1.data[19] >= this.global1.data[49] && this.global1.data[20] >= 10 && this.global1.data[21] >= 1989) || this.global1.data[21] >= 1990) && !this.events[1].activeSelf && !this.global1.event_done[30])
				{
					this.this_num_event = 30;
					this.this_num_place = 1;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (((this.global1.data[3] <= 400 && this.global1.data[21] == 1989) || (this.global1.data[3] <= 500 && this.global1.data[21] > 1989) || (this.global1.data[4] >= 600 && this.global1.data[21] > 1990) || (this.global1.data[4] >= 650 && this.global1.data[21] == 1990) || (this.global1.data[4] >= 700 && this.global1.data[21] == 1989) || (((this.global1.data[2] < 500 && this.global1.data[21] == 1989) || (this.global1.data[2] < 575 && this.global1.data[21] == 1990) || (this.global1.data[2] < 650 && this.global1.data[21] > 1990)) && this.global1.data[22] < 700) || this.global1.data[1] < 500) && ((this.global1.data[19] >= this.global1.data[49] && this.global1.data[20] >= 9) || this.global1.data[20] >= 10) && this.global1.data[11] == 0 && !this.events[1].activeSelf && !this.global1.event_done[31])
				{
					this.this_num_event = 31;
					this.this_num_place = 1;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (((this.global1.data[19] >= this.global1.data[49] && this.global1.data[20] >= 11 && this.global1.data[21] >= 1989) || this.global1.data[21] >= 1990) && this.global1.data[11] >= 2 && !this.events[1].activeSelf && !this.global1.event_done[32])
				{
					this.this_num_event = 32;
					this.this_num_place = 1;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if ((this.global1.data[3] < 300 || this.global1.data[4] >= 650) && (this.global1.data[11] != 0 || this.global1.data[28] >= 5 || this.global1.data[27] >= 1) && !this.events[1].activeSelf && !this.global1.event_done[33])
				{
					this.this_num_event = 33;
					this.this_num_place = 1;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if ((this.global1.data[3] <= 250 || this.global1.data[4] >= 800 || this.global1.data[14] >= 4 || this.global1.data[11] == 3) && !this.events[1].activeSelf && !this.global1.event_done[55])
				{
					this.this_num_event = 55;
					this.this_num_place = 1;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if ((this.global1.data[3] <= 200 || this.global1.data[4] >= 900) && this.global1.data[0] != 20 && this.global1.data[0] != 49 && this.global1.data[0] != 50 && this.global1.data[0] != 51 && this.global1.data[21] >= 1990 && !this.events[1].activeSelf && !this.global1.event_done[56])
				{
					this.this_num_event = 56;
					this.this_num_place = 1;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[20] >= 10 && this.global1.data[19] >= 3 && !this.global1.is_gkchp && this.global1.data[21] >= 1990 && !this.events[1].activeSelf && !this.global1.event_done[57])
				{
					this.this_num_event = 57;
					this.this_num_place = 1;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.eventVariantChosen[1098] != 2 && ((this.global1.data[20] >= this.global1.data[47] + this.global1.data[48] && this.global1.data[21] >= 1990) || this.global1.data[21] >= 1991) && this.global1.data[11] != 0 && !this.events[1].activeSelf && !this.global1.event_done[58])
				{
					this.this_num_event = 58;
					this.this_num_place = 1;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[20] <= 10 && this.global1.data[21] <= 1989 && this.global1.data[11] != 0 && !this.events[1].activeSelf && !this.global1.event_done[1098])
				{
					this.this_num_event = 1098;
					this.this_num_place = 1;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (((this.global1.data[20] >= (this.global1.data[47] + this.global1.data[48] + this.global1.data[49]) / 2 && this.global1.data[21] >= 1991) || this.global1.data[21] >= 1992) && !this.events[1].activeSelf && !this.global1.event_done[82])
				{
					this.this_num_event = 82;
					this.this_num_place = 1;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (((this.global1.data[19] >= this.global1.data[49] && this.global1.data[20] >= 9 && this.global1.data[21] >= 1989) || this.global1.data[21] >= 1990) && !this.events[1].activeSelf && !this.global1.event_done[83])
				{
					this.this_num_event = 83;
					this.this_num_place = 1;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (((this.global1.data[19] >= this.global1.data[49] && this.global1.data[20] >= 4 && this.global1.data[21] >= 1990) || this.global1.data[21] >= 1991) && !this.events[1].activeSelf && !this.global1.event_done[84])
				{
					this.this_num_event = 84;
					this.this_num_place = 1;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.science[0] && this.global1.science[3] && this.global1.science[4] && this.global1.data[0] != 10 && this.global1.data[0] != 12 && this.global1.data[0] != 18 && this.global1.data[21] >= 1990 && !this.events[1].activeSelf && !this.global1.event_done[85])
				{
					this.this_num_event = 85;
					this.this_num_place = 1;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if ((!this.global1.allcountries[7].isOVD || (this.global1.is_gkchp && this.global1.allcountries[7].Gosstroy >= 2)) && this.global1.regions[2].buildings[12].is_builded && this.global1.data[21] >= 1991 && !this.events[1].activeSelf && !this.global1.event_done[86])
				{
					this.this_num_event = 86;
					this.this_num_place = 1;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
				else if (this.global1.data[22] >= 700 && this.global1.data[0] == 1 && this.global1.data[31] >= 600 && this.global1.data[20] >= this.global1.data[48] + this.global1.data[49] && this.global1.data[21] >= 1990 && !this.events[1].activeSelf && !this.global1.event_done[131])
				{
					this.this_num_event = 131;
					this.this_num_place = 1;
					this.events[this.this_num_place].SetActive(true);
					this.events[this.this_num_place].GetComponent<EventScript>().Reset(this.this_num_event);
				}
			}
			if (this.global1.data[19] == 30 && this.global1.data[20] == 11 && this.global1.data[21] == 1991 && !this.global1.allcountries[7].isOVD && !this.global1.allcountries[7].isSEV)
			{
				ptr = ref this.global1.data[7];
				ptr -= 10;
			}
			int num7 = 0;
			num7 -= 17 - this.global1.data[18];
			num7 -= 13 - this.global1.data[17];
			num7 -= 9 - this.global1.data[16];
			num7 -= 5 - this.global1.data[15];
			if (num7 <= 5 || (num7 <= 8 && this.global1.data[16] == 13 && (this.global1.data[18] <= 19 || this.global1.data[18] >= 22)))
			{
				this.global1.data[14] = 0;
			}
			else if (num7 <= 7)
			{
				this.global1.data[14] = 1;
			}
			else if (num7 <= 10)
			{
				this.global1.data[14] = 2;
			}
			else if (num7 <= 13)
			{
				this.global1.data[14] = 3;
			}
			else if (num7 <= 16)
			{
				this.global1.data[14] = 4;
			}
			else if (num7 > 16)
			{
				this.global1.data[14] = 5;
			}
			if (this.global1.data[33] <= 190)
			{
				this.global1.data[18] = 23;
			}
			else if (this.global1.data[33] <= 390)
			{
				this.global1.data[18] = 22;
			}
			else if (this.global1.data[33] <= 590)
			{
				this.global1.data[18] = 21;
			}
			else if (this.global1.data[33] <= 790)
			{
				this.global1.data[18] = 20;
			}
			else if (this.global1.data[33] <= 990)
			{
				this.global1.data[18] = 19;
			}
			else if (this.global1.data[33] > 990)
			{
				this.global1.data[18] = 18;
			}
			if (this.global1.data[22] < 0)
			{
				this.global1.data[22] = 0;
			}
			else if (this.global1.data[22] > 1000)
			{
				this.global1.data[22] = 1000;
			}
			if (this.global1.data[31] < 0)
			{
				this.global1.data[31] = 0;
			}
			else if (this.global1.data[31] > 1000)
			{
				this.global1.data[31] = 1000;
			}
			if (this.global1.data[33] < -100)
			{
				this.global1.data[33] = -100;
			}
			else if (this.global1.data[33] > 1300)
			{
				this.global1.data[33] = 1300;
			}
			this.global1.data[23] = 0;
			this.global1.data[25] = 0;
			if (this.global1.data[0] >= 49 && this.global1.data[0] <= 51)
			{
				this.global1.data[23] = 25;
				if (this.global1.allcountries[7].isSEV)
				{
					ptr = ref this.global1.data[23];
					ptr += 25;
				}
				if (this.global1.allcountries[this.global1.data[0]].isOVD || (this.global1.allcountries[7].isSEV && this.global1.allcountries[this.global1.data[0]].isSEV))
				{
					ptr = ref this.global1.data[23];
					ptr -= 25;
				}
			}
			else
			{
				this.global1.data[23] = 0;
			}
			bool flag = false;
			for (int j = 0; j < this.global1.allcountries.Length; j = num + 1)
			{
				if (this.global1.allcountries[j] != null)
				{
					if (this.global1.allcountries[j].Torg && !this.global1.allcountries[j].isSEV)
					{
						ptr = ref this.global1.data[25];
						ref int ptr6 = ref ptr;
						num = ptr;
						ptr6 = num + 1;
						ptr = ref this.global1.data[23];
						ptr += 2;
					}
					else if (this.global1.allcountries[j].Torg && this.global1.allcountries[j].isSEV && this.global1.allcountries[this.global1.data[0]].isSEV)
					{
						ptr = ref this.global1.data[23];
						ref int ptr7 = ref ptr;
						num = ptr;
						ptr7 = num + 1;
					}
					if (j == 7 && this.global1.allcountries[j].isSEV && this.global1.data[0] == 6)
					{
						ptr = ref this.global1.data[23];
						ptr += 15 - this.global1.allcountries[7].Gosstroy * 5;
					}
					else if ((this.global1.allcountries[j].isSEV && this.global1.allcountries[this.global1.data[0]].isSEV && this.global1.allcountries[j].Gosstroy == 0) || (this.global1.allcountries[j].isSEV && this.global1.allcountries[j].Gosstroy == 9 && j < 7))
					{
						ptr = ref this.global1.data[23];
						ptr += 9;
					}
					else if (this.global1.allcountries[j].isSEV && this.global1.allcountries[this.global1.data[0]].isSEV && (this.global1.allcountries[j].Gosstroy == 1 || this.global1.allcountries[j].Gosstroy == 9))
					{
						ptr = ref this.global1.data[23];
						ptr += 6;
					}
					else if (this.global1.allcountries[j].isSEV && this.global1.allcountries[this.global1.data[0]].isSEV && this.global1.allcountries[j].Gosstroy == 2)
					{
						ptr = ref this.global1.data[23];
						ptr += 4;
					}
					else if (this.global1.allcountries[j].Vyshi)
					{
						ptr = ref this.global1.data[23];
						ptr += 3;
					}
					if (this.global1.allcountries[j].isOVD && j != this.global1.data[0] && j == 4 && !this.global1.allcountries[3].isOVD && !this.global1.allcountries[5].isOVD && !this.global1.allcountries[7].isOVD)
					{
						this.global1.allcountries[j].isOVD = false;
					}
					else if (this.global1.allcountries[j].isOVD && (j != 4 || !this.global1.event_done[129]) && j != this.global1.data[0] && j <= 6 && !this.global1.allcountries[j].Torg && this.global1.allcountries[j].Gosstroy == 0 && this.global1.data[6] < 690 && !this.global1.allcountries[7].isOVD)
					{
						this.global1.allcountries[j].isOVD = false;
					}
					else if (this.global1.allcountries[j].isOVD && (j != 4 || !this.global1.event_done[129]) && j != this.global1.data[0] && this.global1.allcountries[j].Gosstroy == 2 && this.global1.data[6] > 300 && !this.global1.allcountries[7].isOVD)
					{
						this.global1.allcountries[j].isOVD = false;
					}
					else if (this.global1.allcountries[j].isOVD && (j != 4 || !this.global1.event_done[129]) && j != this.global1.data[0] && j <= 6 && !this.global1.allcountries[j].Money && !this.global1.allcountries[j].Torg && this.global1.allcountries[j].Gosstroy == 1 && (this.global1.data[6] < 400 || this.global1.data[6] > 690) && !this.global1.allcountries[7].isOVD)
					{
						this.global1.allcountries[j].isOVD = false;
					}
					else if (this.global1.allcountries[j].isSEV && (j != 4 || !this.global1.event_done[129]) && j != this.global1.data[0] && j <= 6 && !this.global1.allcountries[j].Torg && this.global1.allcountries[j].Gosstroy == 0 && this.global1.data[6] < 600 && !this.global1.allcountries[7].isSEV)
					{
						this.global1.allcountries[j].isSEV = false;
					}
					else if (this.global1.allcountries[j].isSEV && (j != 4 || !this.global1.event_done[129]) && j != this.global1.data[0] && this.global1.allcountries[j].Gosstroy == 2 && this.global1.data[6] > 390 && !this.global1.allcountries[7].isSEV)
					{
						this.global1.allcountries[j].isSEV = false;
					}
					else if (this.global1.allcountries[j].isSEV && j != this.global1.data[0] && j <= 6 && (j != 4 || !this.global1.event_done[129]) && !this.global1.allcountries[j].Money && !this.global1.allcountries[j].Torg && this.global1.allcountries[j].Gosstroy == 1 && (this.global1.data[6] < 300 || this.global1.data[6] > 790) && !this.global1.allcountries[7].isSEV)
					{
						this.global1.allcountries[j].isSEV = false;
					}
					else if (this.global1.allcountries[j].isSEV && (j != 4 || !this.global1.event_done[129]) && j != this.global1.data[0] && j <= 6 && this.global1.allcountries[j].Vyshi && !this.global1.allcountries[7].isSEV)
					{
						this.global1.allcountries[j].isSEV = false;
					}
					else if (this.global1.allcountries[j].Torg && (j != 24 || this.global1.allcountries[24].Stasi) && j != 12 && (j < 40 || j > 43) && j != this.global1.data[0] && !this.global1.allcountries[j].isSEV && !this.global1.allcountries[j].isOVD && this.global1.allcountries[j].Gosstroy == 0 && this.global1.data[6] < 500 && !this.global1.allcountries[7].isSEV)
					{
						this.global1.allcountries[j].Torg = false;
					}
					else if (this.global1.allcountries[j].Torg && (j != 24 || this.global1.allcountries[24].Stasi) && j != 12 && (j < 40 || j > 43) && j != this.global1.data[0] && j != 21 && !this.global1.allcountries[j].isSEV && !this.global1.allcountries[j].isOVD && this.global1.allcountries[j].Gosstroy == 2 && this.global1.data[6] > 490 && !this.global1.allcountries[7].isSEV && !this.global1.allcountries[this.global1.data[0]].Vyshi)
					{
						this.global1.allcountries[j].Torg = false;
					}
					else if (this.global1.allcountries[j].Torg && (j != 24 || this.global1.allcountries[24].Stasi) && j != 12 && (j < 40 || j > 43) && j != this.global1.data[0] && !this.global1.allcountries[j].isSEV && !this.global1.allcountries[j].isOVD && this.global1.allcountries[j].Gosstroy == 1 && this.global1.data[6] < 250 && !this.global1.allcountries[7].isSEV)
					{
						this.global1.allcountries[j].Torg = false;
					}
					if ((this.global1.allcountries[j].isSEV || this.global1.allcountries[j].isOVD) && this.global1.data[0] != j)
					{
						flag = true;
					}
				}
				num = j;
			}
			if (!flag)
			{
				this.global1.allcountries[this.global1.data[0]].isSEV = false;
				this.global1.allcountries[this.global1.data[0]].isOVD = false;
			}
			if (this.global1.allcountries[this.global1.data[0]].isSEV)
			{
				ptr = ref this.global1.data[23];
				ptr -= 10;
			}
			if (this.global1.data[38] < 0 && this.global1.data[15] > 6)
			{
				ptr = ref this.global1.data[15];
				ref int ptr8 = ref ptr;
				num = ptr;
				ptr8 = num - 1;
				int num8 = this.global1.data[38];
				this.global1.data[38] = 10 + num8;
				if (this.global1.data[15] == 6)
				{
					for (int k = 1; k < this.global1.is_party_ally.Length; k = num + 1)
					{
						bool flag2 = this.global1.is_party_ally[k];
						if (this.global1.is_party_enabled[k])
						{
							ptr = ref this.global1.data[6];
							ptr += 10;
							ptr = ref this.global1.data[2];
							ptr -= 150;
							ptr = ref this.global1.data[3];
							ptr -= this.global1.party_number[k] * 3;
							ptr = ref this.global1.data[4];
							ptr += this.global1.party_number[k] * 3;
							this.global1.is_party_ally[k] = false;
							this.global1.is_party_enabled[k] = false;
							this.global1.party_number[k] = 0;
						}
						num = k;
					}
					this.global1.is_konst_max = true;
					this.global1.data[41] = 0;
				}
			}
			else if (this.global1.data[38] > 10 && this.global1.data[15] < 9)
			{
				ptr = ref this.global1.data[15];
				ref int ptr9 = ref ptr;
				num = ptr;
				ptr9 = num + 1;
				if (this.global1.data[15] == 9 && this.global1.data[17] >= 16 && !this.vybory)
				{
					this.vybory = true;
				}
				ptr = ref this.global1.data[65];
				ref int ptr10 = ref ptr;
				num = ptr;
				ptr10 = num - 1;
				int num9 = this.global1.data[38];
				this.global1.data[38] = Mathf.Abs(10 - num9);
				for (int l = 0; l < this.global1.is_party_enabled.Length; l = num + 1)
				{
					if (!this.global1.is_party_enabled[l])
					{
						ptr = ref this.global1.data[1];
						ptr -= 10;
						ptr = ref this.global1.data[2];
						ptr += 50;
						ptr = ref this.global1.data[3];
						ptr += 10;
						ptr = ref this.global1.data[4];
						ptr += 25;
						ptr = ref this.global1.data[6];
						ptr -= 15;
						this.global1.is_party_enabled[l] = true;
						this.global1.party_number[l] = 0;
					}
					num = l;
				}
			}
			if (this.global1.data[39] < 0 && this.global1.data[16] > 11)
			{
				int num10 = this.global1.data[39];
				if (this.global1.data[16] == 13 && num10 >= -10)
				{
					this.global1.data[39] = 5;
				}
				else
				{
					this.global1.data[39] = 10 + num10;
				}
				if (this.global1.data[16] == 12)
				{
					this.global1.data[16] = 10;
				}
				else
				{
					ptr = ref this.global1.data[16];
					ref int ptr11 = ref ptr;
					num = ptr;
					ptr11 = num - 1;
				}
			}
			else if (this.global1.data[39] < 0 && this.global1.data[16] == 11)
			{
				this.global1.data[16] = 10;
				ptr = ref this.global1.data[1];
				ptr += 200;
				int num11 = this.global1.data[39];
				this.global1.data[39] = 10 + num11;
			}
			else if (this.global1.data[39] > 10 && this.global1.data[16] < 13)
			{
				int num12 = this.global1.data[39];
				if (this.global1.data[16] <= 11 && num12 < 20)
				{
					this.global1.data[39] = 5;
				}
				else
				{
					this.global1.data[39] = Mathf.Abs(10 - num12);
				}
				if (this.global1.data[16] == 10)
				{
					this.global1.data[16] = 12;
				}
				else
				{
					ptr = ref this.global1.data[16];
					ref int ptr12 = ref ptr;
					num = ptr;
					ptr12 = num + 1;
				}
				ptr = ref this.global1.data[65];
				ref int ptr13 = ref ptr;
				num = ptr;
				ptr13 = num - 1;
				ptr = ref this.global1.data[5];
				ptr -= this.global1.data[5] / (16 - this.global1.data[16]);
			}
			if (this.global1.data[40] < 0 && this.global1.data[17] > 14)
			{
				ptr = ref this.global1.data[17];
				ref int ptr14 = ref ptr;
				num = ptr;
				ptr14 = num - 1;
				int num13 = this.global1.data[40];
				this.global1.data[40] = 10 + num13;
			}
			else if (this.global1.data[40] > 10 && this.global1.data[17] < 17)
			{
				ptr = ref this.global1.data[17];
				ref int ptr15 = ref ptr;
				num = ptr;
				ptr15 = num + 1;
				ptr = ref this.global1.data[65];
				ref int ptr16 = ref ptr;
				num = ptr;
				ptr16 = num - 1;
				if (this.global1.data[17] == 17 && this.global1.data[15] >= 8 && !this.vybory)
				{
					this.vybory = true;
				}
				int num14 = this.global1.data[40];
				this.global1.data[40] = Mathf.Abs(10 - num14);
			}
			if (this.global1.allcountries[7].Gosstroy == 0 && this.global1.allcountries[7].paths <= 0 && this.global1.data[21] >= 1990 && this.global1.data[20] >= 12 && !this.global1.is_gkchp && !this.global1.event_done[34])
			{
				this.global1.event_done[34] = true;
				this.global1.allcountries[7].Gosstroy = 1;
				this.global1.allcountries[7].subideology = 8;
			}
			if (this.global1.allcountries[6].Gosstroy == 0 && !this.global1.allcountries[7].Vyshi && this.global1.data[0] != 6 && (this.global1.data[7] <= 720 || (this.global1.data[21] == 1989 && this.global1.data[20] == 11 && this.global1.data[7] <= 770)))
			{
				int num15 = 0;
				if (this.global1.allcountries[6].Torg)
				{
					num15 += 2;
				}
				if (this.global1.allcountries[6].Help)
				{
					num15 += 5;
				}
				if (this.global1.allcountries[6].Stasi)
				{
					num15 += 2;
				}
				if (this.global1.allcountries[6].Donat || this.global1.data[20] == 1)
				{
					num15 += 2;
				}
				if (this.global1.data[7] <= (72 - num15) * 10 || (this.global1.data[21] == 1989 && this.global1.data[20] == 11 && this.global1.data[7] <= (77 - num15) * 10))
				{
					this.global1.allcountries[6].Gosstroy = 1;
					this.global1.allcountries[6].subideology = 11;
					this.global1.allcountries[6].Torg = false;
					this.global1.allcountries[6].Stasi = false;
				}
			}
			if (this.global1.allcountries[1].Gosstroy == 0 && this.global1.allcountries[1].paths <= 0 && this.global1.data[0] != 1 && (((this.global1.data[7] <= 750 || (this.global1.data[21] == 1989 && this.global1.data[20] == 10 && this.global1.data[7] <= 813)) && !this.global1.event_done[89]) || (this.global1.data[7] <= 580 && this.global1.event_done[89])))
			{
				int num16 = 0;
				if (this.global1.allcountries[1].Torg)
				{
					num16 += 2;
				}
				if (this.global1.allcountries[1].Help)
				{
					num16 += 5;
				}
				if (this.global1.allcountries[1].Stasi)
				{
					num16 += 2;
				}
				if (this.global1.allcountries[1].Donat || this.global1.data[20] == 1)
				{
					num16 += 2;
				}
				if (((this.global1.data[7] <= (75 - num16) * 10 || (this.global1.data[21] == 1989 && this.global1.data[20] == 10 && this.global1.data[7] <= (81 - num16) * 10 + 3)) && !this.global1.event_done[89]) || (this.global1.data[7] <= (58 - num16) * 10 && this.global1.event_done[89]))
				{
					this.global1.allcountries[1].Gosstroy = 1;
					this.global1.allcountries[1].subideology = 8;
					this.global1.allcountries[1].Torg = false;
					this.global1.allcountries[1].Stasi = false;
				}
			}
			if (this.global1.allcountries[1].Gosstroy == 1 && this.global1.allcountries[1].paths <= 0 && (!this.global1.is_gkchp || (this.global1.is_gkchp && this.global1.allcountries[7].Gosstroy > 0)) && this.global1.data[0] != 1 && ((this.global1.data[7] <= 530 && !this.global1.event_done[91]) || (this.global1.data[7] <= 500 && this.global1.event_done[91])))
			{
				int num17 = 0;
				if (this.global1.allcountries[1].Torg)
				{
					num17 += 2;
				}
				if (this.global1.allcountries[1].Help)
				{
					num17 += 5;
				}
				if (this.global1.allcountries[1].Stasi)
				{
					num17 += 2;
				}
				if (this.global1.allcountries[1].Donat || this.global1.data[20] == 1)
				{
					num17 += 2;
				}
				if (this.global1.data[7] <= (53 - num17) * 10 && !this.global1.event_done[91])
				{
					this.global1.allcountries[1].Gosstroy = 2;
					this.global1.allcountries[1].subideology = 15;
					this.global1.allcountries[1].Torg = false;
					this.global1.allcountries[1].Stasi = false;
				}
				else if (this.global1.data[7] <= (50 - num17) * 10 && this.global1.event_done[91])
				{
					this.global1.allcountries[1].Gosstroy = 2;
					this.global1.allcountries[1].subideology = 15;
					this.global1.allcountries[1].Torg = false;
					this.global1.allcountries[1].Stasi = false;
					this.global1.allcountries[1].isSEV = false;
					this.global1.allcountries[1].isOVD = false;
				}
			}
			if (this.global1.allcountries[3].Gosstroy == 0 && this.global1.allcountries[3].paths <= 0 && ((this.global1.data[21] != 1989 && this.global1.data[7] <= 660) || this.global1.data[7] <= 659))
			{
				int num18 = 0;
				if (this.global1.allcountries[3].Torg)
				{
					num18 += 2;
				}
				if (this.global1.allcountries[3].Help)
				{
					num18 += 5;
				}
				if (this.global1.allcountries[3].Stasi)
				{
					num18 += 2;
				}
				if (this.global1.allcountries[3].Donat || this.global1.data[20] == 1)
				{
					num18 += 2;
				}
				if ((this.global1.data[21] != 1989 && this.global1.data[7] <= (66 - num18) * 10) || this.global1.data[7] <= (66 - num18) * 10 - 1)
				{
					this.global1.allcountries[3].Gosstroy = 1;
					this.global1.allcountries[3].subideology = 11;
					this.global1.allcountries[3].Torg = false;
					this.global1.allcountries[3].Stasi = false;
				}
			}
			if (this.global1.allcountries[4].Gosstroy == 1 && this.global1.allcountries[4].paths <= 0 && (!this.global1.is_gkchp || (this.global1.is_gkchp && this.global1.allcountries[7].Gosstroy > 0)) && (((this.global1.data[7] <= 870 || (this.global1.data[21] == 1989 && this.global1.data[20] == 10 && this.global1.data[7] <= 920)) && !this.global1.event_done[9]) || (this.global1.data[7] <= 780 && this.global1.event_done[9])))
			{
				int num19 = 0;
				if (this.global1.allcountries[4].Torg)
				{
					num = num19;
					num19 = num + 1;
				}
				if (this.global1.allcountries[4].Help)
				{
					num19 += 5;
				}
				if (this.global1.allcountries[4].Stasi)
				{
					num19 += 2;
				}
				if (this.global1.allcountries[4].Donat || this.global1.data[20] == 1)
				{
					num19 += 3;
				}
				if (((this.global1.data[7] <= (87 - num19) * 10 || (this.global1.data[21] == 1989 && this.global1.data[20] == 10 && this.global1.data[7] <= (92 - num19) * 10)) && !this.global1.event_done[9]) || (this.global1.data[7] <= (78 - num19) * 10 && this.global1.event_done[9]))
				{
					this.global1.allcountries[4].Gosstroy = 2;
					this.global1.allcountries[4].subideology = 15;
					this.global1.allcountries[4].Torg = false;
					this.global1.allcountries[4].Stasi = false;
				}
			}
			if (this.global1.allcountries[2].Gosstroy == 0 && this.global1.allcountries[2].paths <= 0 && (this.global1.data[7] <= 940 || (this.global1.data[21] == 1989 && this.global1.data[20] == 8 && this.global1.data[7] <= 941)))
			{
				int num20 = 0;
				if (this.global1.allcountries[2].Torg)
				{
					num20 += 3;
				}
				if (this.global1.allcountries[2].Help)
				{
					num20 += 5;
				}
				if (this.global1.allcountries[2].Stasi)
				{
					num20 += 2;
				}
				if (this.global1.allcountries[2].Donat || this.global1.data[20] == 1)
				{
					num20 += 4;
				}
				if (this.global1.data[7] < (94 - num20) * 10 || (this.global1.data[21] == 1989 && this.global1.data[20] == 8 && this.global1.data[7] <= (95 - num20) * 10 - 9))
				{
					this.global1.allcountries[2].Gosstroy = 1;
					this.global1.allcountries[2].subideology = 11;
					this.global1.allcountries[2].Torg = false;
					this.global1.allcountries[2].Stasi = false;
				}
			}
			if (this.global1.allcountries[2].Gosstroy == 9 && this.global1.allcountries[2].paths <= 0 && (!this.global1.is_gkchp || (this.global1.is_gkchp && this.global1.allcountries[7].Gosstroy > 0)) && this.global1.data[7] <= 850)
			{
				int num21 = 0;
				if (this.global1.allcountries[2].Torg)
				{
					num = num21;
					num21 = num + 1;
				}
				if (this.global1.allcountries[2].Help)
				{
					num21 += 5;
				}
				if (this.global1.allcountries[2].Stasi)
				{
					num21 += 2;
				}
				if (this.global1.allcountries[2].Donat || this.global1.data[20] == 1)
				{
					num21 += 3;
				}
				if (this.global1.data[7] <= (85 - num21) * 10)
				{
					this.global1.allcountries[2].Gosstroy = 1;
					this.global1.allcountries[2].subideology = 11;
					this.global1.allcountries[2].Torg = false;
					this.global1.allcountries[2].Stasi = false;
				}
			}
			if (this.global1.allcountries[5].Gosstroy == 0 && this.global1.allcountries[5].paths <= 0 && this.global1.data[0] != 5 && (this.global1.data[7] <= 660 || (this.global1.data[21] == 1989 && this.global1.data[19] > 10 && this.global1.data[20] == 12 && this.global1.data[7] <= 670) || (this.global1.data[7] <= 460 && this.global1.event_done[46])))
			{
				int num22 = 0;
				if (this.global1.allcountries[5].Torg)
				{
					num22 += 2;
				}
				if (this.global1.allcountries[5].Help)
				{
					num22 += 5;
				}
				if (this.global1.allcountries[5].Stasi)
				{
					num22 += 3;
				}
				if (this.global1.allcountries[5].Donat || this.global1.data[20] == 1)
				{
					num = num22;
					num22 = num + 1;
				}
				if (((this.global1.data[7] <= (66 - num22) * 10 || (this.global1.data[21] == 1989 && this.global1.data[19] > 10 && this.global1.data[20] == 12 && this.global1.data[7] <= (67 - num22) * 10)) && !this.global1.event_done[46]) || this.global1.data[7] <= (46 - num22) * 10)
				{
					this.global1.allcountries[5].Gosstroy = 1;
					this.global1.allcountries[5].subideology = 11;
					this.global1.allcountries[5].Torg = false;
					this.global1.allcountries[5].Stasi = false;
				}
			}
			if (this.global1.allcountries[2].Gosstroy == 1 && this.global1.allcountries[2].paths <= 0 && (!this.global1.is_gkchp || (this.global1.is_gkchp && this.global1.allcountries[7].Gosstroy > 0)) && ((this.global1.data[7] <= 480 && !this.global1.event_done[38]) || (this.global1.data[7] <= 540 && this.global1.data[20] > 1 && this.global1.data[21] != 1989 && !this.global1.event_done[38]) || (this.global1.data[7] <= 400 && this.global1.event_done[38])))
			{
				int num23 = 0;
				if (this.global1.allcountries[2].Torg)
				{
					num = num23;
					num23 = num + 1;
				}
				if (this.global1.allcountries[2].Help)
				{
					num23 += 5;
				}
				if (this.global1.allcountries[2].Stasi)
				{
					num23 += 2;
				}
				if (this.global1.allcountries[2].Donat)
				{
					num23 += 3;
				}
				else if (this.global1.data[20] == 1)
				{
					num = num23;
					num23 = num + 1;
				}
				if ((this.global1.data[7] <= (48 - num23) * 10 && !this.global1.event_done[38]) || (this.global1.data[7] <= (54 - num23) * 10 && this.global1.data[20] > 1 && this.global1.data[21] != 1989 && !this.global1.event_done[38]) || this.global1.data[7] <= (40 - num23) * 10)
				{
					this.global1.allcountries[2].Gosstroy = 2;
					this.global1.allcountries[2].subideology = 15;
					this.global1.allcountries[2].Torg = false;
					this.global1.allcountries[2].Stasi = false;
				}
			}
			if (this.global1.allcountries[5].Gosstroy == 1 && this.global1.allcountries[5].paths <= 0 && (!this.global1.is_gkchp || (this.global1.is_gkchp && this.global1.allcountries[7].Gosstroy > 0)) && this.global1.data[0] != 5 && (this.global1.data[7] <= 340 || (this.global1.data[21] > 1990 && this.global1.data[7] <= 440)))
			{
				int num24 = 0;
				if (this.global1.allcountries[5].Torg)
				{
					num24 += 2;
				}
				if (this.global1.allcountries[5].Help)
				{
					num24 += 5;
				}
				if (this.global1.allcountries[5].Stasi)
				{
					num24 += 3;
				}
				if (this.global1.allcountries[5].Donat || this.global1.data[20] == 1)
				{
					num = num24;
					num24 = num + 1;
				}
				if (this.global1.data[7] <= (34 - num24) * 10 || (this.global1.data[21] > 1990 && this.global1.data[7] <= (44 - num24) * 10))
				{
					this.global1.allcountries[5].Gosstroy = 2;
					this.global1.allcountries[5].subideology = 13;
					this.global1.allcountries[5].Torg = false;
					this.global1.allcountries[5].Stasi = false;
				}
			}
			if (this.global1.allcountries[5].Gosstroy == 9 && this.global1.allcountries[5].paths <= 0 && (!this.global1.is_gkchp || (this.global1.is_gkchp && this.global1.allcountries[7].Gosstroy > 0)) && this.global1.data[0] != 5 && this.global1.data[7] <= 150)
			{
				int num25 = 0;
				if (this.global1.allcountries[5].Torg)
				{
					num25 += 2;
				}
				if (this.global1.allcountries[5].Help)
				{
					num25 += 5;
				}
				if (this.global1.allcountries[5].Stasi)
				{
					num25 += 3;
				}
				if (this.global1.allcountries[5].Donat || this.global1.data[20] == 1)
				{
					num = num25;
					num25 = num + 1;
				}
				if (this.global1.data[7] <= (15 - num25) * 10)
				{
					this.global1.allcountries[5].Gosstroy = 2;
					this.global1.allcountries[5].subideology = 13;
					this.global1.allcountries[5].Torg = false;
					this.global1.allcountries[5].Stasi = false;
				}
			}
			if (this.global1.allcountries[9].Gosstroy == 0 && ((this.global1.data[7] <= 225 * (1 + this.global1.allcountries[7].Gosstroy) && !this.global1.event_done[42]) || this.global1.data[7] <= 150 * (1 + this.global1.allcountries[7].Gosstroy)))
			{
				int num26 = 0;
				if (this.global1.allcountries[9].Torg)
				{
					num26 += 2;
				}
				if (this.global1.allcountries[9].Help)
				{
					num26 += 5;
				}
				if (this.global1.allcountries[9].Stasi)
				{
					num26 += 2;
				}
				if (this.global1.allcountries[9].Donat || this.global1.data[20] == 1)
				{
					num26 += 2;
				}
				if ((this.global1.data[7] <= (22 * (1 + this.global1.allcountries[7].Gosstroy) - num26) * 10 && !this.global1.event_done[42]) || this.global1.data[7] <= (15 * (1 + this.global1.allcountries[7].Gosstroy) - num26) * 10)
				{
					this.global1.allcountries[9].Gosstroy = 1;
					this.global1.allcountries[9].subideology = 9;
					this.global1.allcountries[9].Torg = false;
					this.global1.allcountries[9].Stasi = false;
				}
			}
			if (this.global1.allcountries[20].Gosstroy == 0 && this.global1.data[0] != 20 && ((((this.global1.data[7] <= 380 && this.global1.data[21] <= 1990) || (this.global1.data[7] <= 680 && this.global1.data[21] > 1990)) && !this.global1.event_done[45]) || (((this.global1.data[7] <= 480 && this.global1.data[21] > 1990) || (this.global1.data[7] <= 280 && this.global1.data[21] <= 1990)) && !this.global1.event_done[45])))
			{
				int num27 = 0;
				if (this.global1.allcountries[20].Torg)
				{
					num27 += 2;
				}
				if (this.global1.allcountries[20].Help)
				{
					num27 += 5;
				}
				if (this.global1.allcountries[20].Stasi)
				{
					num27 += 2;
				}
				if (this.global1.allcountries[20].Donat || this.global1.data[20] == 1)
				{
					num27 += 2;
				}
				if ((((this.global1.data[7] <= (38 - num27) * 10 && this.global1.data[21] <= 1990) || (this.global1.data[7] <= (68 - num27) * 10 && this.global1.data[21] > 1990)) && !this.global1.event_done[45]) || (((this.global1.data[7] <= (48 - num27) * 10 && this.global1.data[21] > 1990) || (this.global1.data[7] <= (28 - num27) * 10 && this.global1.data[21] <= 1990)) && this.global1.event_done[45]))
				{
					this.global1.allcountries[20].Gosstroy = 1;
					this.global1.allcountries[20].subideology = 11;
					this.global1.allcountries[20].Torg = false;
					this.global1.allcountries[20].Stasi = false;
				}
			}
			if (this.global1.allcountries[6].Gosstroy == 1 && this.global1.allcountries[6].paths <= 0 && (!this.global1.is_gkchp || (this.global1.is_gkchp && this.global1.allcountries[7].Gosstroy > 0)) && this.global1.data[0] != 6 && ((this.global1.data[7] <= 280 && !this.global1.event_done[47]) || this.global1.data[7] <= 220))
			{
				int num28 = 0;
				if (this.global1.allcountries[6].Torg)
				{
					num28 += 2;
				}
				if (this.global1.allcountries[6].Help)
				{
					num28 += 5;
				}
				if (this.global1.allcountries[6].Stasi)
				{
					num28 += 2;
				}
				if (this.global1.allcountries[6].Donat || this.global1.data[20] == 1)
				{
					num28 += 2;
				}
				if ((this.global1.data[7] <= (28 - num28) * 10 && !this.global1.event_done[47]) || this.global1.data[7] <= (22 - num28) * 10)
				{
					this.global1.allcountries[6].Gosstroy = 2;
					this.global1.allcountries[6].subideology = 14;
					this.global1.allcountries[6].Torg = false;
					this.global1.allcountries[6].Stasi = false;
				}
			}
			if (this.global1.allcountries[15].Gosstroy == 1 && (this.global1.data[0] < 49 || this.global1.data[0] > 51) && ((this.global1.data[7] <= 240 && this.global1.data[21] >= 1989) || (this.global1.data[20] >= 9 && this.global1.data[21] >= 1990) || (this.global1.data[7] <= 600 && this.global1.data[21] >= 1990)))
			{
				int num29 = 0;
				if (this.global1.allcountries[15].Torg)
				{
					num29 += 2;
				}
				if (this.global1.allcountries[15].Help)
				{
					num29 += 5;
				}
				if (this.global1.allcountries[15].Stasi)
				{
					num29 += 2;
				}
				if (this.global1.allcountries[15].Donat || this.global1.data[20] == 1)
				{
					num29 += 2;
				}
				if (this.global1.data[7] <= (24 - num29) * 10 || (this.global1.data[20] >= 9 && this.global1.data[21] >= 1990) || (this.global1.data[7] <= (60 - num29) * 10 && this.global1.data[21] >= 1990))
				{
					this.global1.allcountries[15].Gosstroy = 2;
					this.global1.allcountries[15].subideology = 13;
					this.global1.allcountries[15].Torg = false;
					this.global1.allcountries[15].Stasi = false;
				}
			}
			if (this.global1.allcountries[20].Gosstroy == 1 && (!this.global1.is_gkchp || (this.global1.is_gkchp && this.global1.allcountries[7].Gosstroy > 0)) && ((this.global1.data[7] <= 100 && !this.global1.event_done[77]) || this.global1.data[7] <= 1))
			{
				int num30 = 0;
				if (this.global1.allcountries[20].Torg)
				{
					num30 += 2;
				}
				if (this.global1.allcountries[20].Help)
				{
					num30 += 5;
				}
				if (this.global1.allcountries[20].Stasi)
				{
					num30 += 2;
				}
				if (this.global1.allcountries[20].Donat || this.global1.data[20] == 1)
				{
					num30 += 2;
				}
				if ((this.global1.data[7] <= (10 - num30) * 10 && !this.global1.event_done[77]) || this.global1.data[7] <= (1 - num30) * 10)
				{
					this.global1.allcountries[20].Gosstroy = 2;
					this.global1.allcountries[20].subideology = 14;
					this.global1.allcountries[20].Torg = false;
					this.global1.allcountries[20].Stasi = false;
				}
			}
			if (this.global1.allcountries[this.global1.data[0]].Vyshi && (this.global1.data[6] > 650 || this.global1.data[14] <= 1 || this.global1.data[16] <= 11))
			{
				this.global1.allcountries[this.global1.data[0]].Vyshi = false;
				ptr = ref this.global1.data[6];
				ptr += 50;
				ptr = ref this.global1.data[4];
				ptr += 150;
				ptr = ref this.global1.data[10];
				ptr += 100;
			}
			int num31 = 0;
			int num32 = 0;
			int num33 = 0;
			int num34 = 0;
			int num35 = 0;
			if (this.global1.data[15] > 7)
			{
				for (int m = 1; m < this.global1.is_party_ally.Length; m = num + 1)
				{
					bool flag3 = this.global1.is_party_ally[m];
					if (this.global1.is_party_ally[m] && this.global1.party_ideology[m] == 1 && (this.global1.data[18] < 21 || this.global1.data[18] > 22))
					{
						this.global1.is_party_ally[m] = false;
					}
					else if (this.global1.is_party_ally[m] && this.global1.party_ideology[m] == 2 && this.global1.data[18] < 22)
					{
						this.global1.is_party_ally[m] = false;
					}
					else if (this.global1.is_party_ally[m] && this.global1.party_ideology[m] == 3 && this.global1.data[18] > 18 && this.global1.data[18] < 23)
					{
						this.global1.is_party_ally[m] = false;
					}
					else if (this.global1.is_party_ally[m] && this.global1.party_ideology[m] == 10 && this.global1.data[18] > 19)
					{
						this.global1.is_party_ally[m] = false;
					}
					num = m;
				}
			}
			if (this.global1.data[15] >= 7 && !this.global1.is_party_enabled[1] && !this.global1.is_party_enabled[2] && !this.global1.is_party_enabled[3] && !this.global1.is_party_enabled[4])
			{
				this.global1.data[15] = 6;
				this.global1.data[38] = 10;
				this.global1.is_konst_max = true;
				this.global1.data[41] = 0;
			}
			if (this.global1.is_party_enabled[1])
			{
				if (!this.global1.is_party_ally[1])
				{
					if (this.global1.party_ideology[1] == 1)
					{
						num31 += this.global1.party_number[1];
					}
					else if (this.global1.party_ideology[1] == 2)
					{
						num32 += this.global1.party_number[1];
					}
					else if (this.global1.party_ideology[1] == 3)
					{
						num33 += this.global1.party_number[1];
					}
					else if (this.global1.party_ideology[1] == 10)
					{
						num34 += this.global1.party_number[1];
					}
				}
				else
				{
					num35 += this.global1.party_number[1];
				}
			}
			if (this.global1.is_party_enabled[2])
			{
				if (!this.global1.is_party_ally[2])
				{
					if (this.global1.party_ideology[2] == 1)
					{
						num31 += this.global1.party_number[2];
					}
					else if (this.global1.party_ideology[2] == 2)
					{
						num32 += this.global1.party_number[2];
					}
					else if (this.global1.party_ideology[2] == 3)
					{
						num33 += this.global1.party_number[2];
					}
					else if (this.global1.party_ideology[2] == 10)
					{
						num34 += this.global1.party_number[2];
					}
				}
				else
				{
					num35 += this.global1.party_number[2];
				}
			}
			if (this.global1.is_party_enabled[3])
			{
				if (!this.global1.is_party_ally[3])
				{
					if (this.global1.party_ideology[3] == 1)
					{
						num31 += this.global1.party_number[3];
					}
					else if (this.global1.party_ideology[3] == 2)
					{
						num32 += this.global1.party_number[3];
					}
					else if (this.global1.party_ideology[3] == 3)
					{
						num33 += this.global1.party_number[3];
					}
					else if (this.global1.party_ideology[3] == 10)
					{
						num34 += this.global1.party_number[3];
					}
				}
				else
				{
					num35 += this.global1.party_number[3];
				}
			}
			if (this.global1.is_party_enabled[4])
			{
				if (!this.global1.is_party_ally[4])
				{
					if (this.global1.party_ideology[4] == 1)
					{
						num31 += this.global1.party_number[4];
					}
					else if (this.global1.party_ideology[4] == 2)
					{
						num32 += this.global1.party_number[4];
					}
					else if (this.global1.party_ideology[4] == 3)
					{
						num33 += this.global1.party_number[4];
					}
					else if (this.global1.party_ideology[4] == 10)
					{
						num34 += this.global1.party_number[4];
					}
				}
				else
				{
					num35 += this.global1.party_number[4];
				}
			}
			num35 += this.global1.party_number[0];
			if (this.global1.data[15] == 6)
			{
				this.global1.data[41] = 0;
			}
			else if (num31 > num32 && num31 > num33 && num31 > num35 && num31 > num34)
			{
				this.global1.data[41] = 1;
			}
			else if (num33 > num31 && num33 > num32 && num33 > num35 && num32 > num34)
			{
				this.global1.data[41] = 3;
			}
			else if (num34 > num31 && num34 > num32 && num34 > num35 && num32 < num34)
			{
				this.global1.data[41] = 4;
			}
			else if (num35 > num31 && num35 > num32 && num35 > num33 && num35 > num34)
			{
				this.global1.data[41] = 0;
			}
			else
			{
				this.global1.data[41] = 2;
			}
			if (num35 > 266 || this.global1.data[15] <= 6)
			{
				this.global1.is_konst_max = true;
			}
			else
			{
				this.global1.is_konst_max = false;
			}
			if (this.global1.data[8] < 0)
			{
				this.goto_pause.OnMouseDown();
				if (this.global1.automat)
				{
					ptr = ref this.global1.data[1];
					ptr += this.global1.data[8] * 10;
					ptr = ref this.global1.data[3];
					ptr += this.global1.data[8] * 10;
					ptr = ref this.global1.data[5];
					ptr += this.global1.data[8] * 5;
					this.global1.data[8] = 1;
				}
				else
				{
					this.goto_economy.OnMouseDown();
				}
			}
			if (this.global1.data[20] == 1 && this.global1.data[19] == 1 && this.global1.data[21] > 1989)
			{
				for (int n = 0; n < this.global1.allcountries.Length; n = num + 1)
				{
					if (this.global1.allcountries[n] != null)
					{
						if (((this.global1.allcountries[n].isSEV && this.global1.allcountries[n].Donat && n > 0 && n < 7) || n == 24) && this.global1.is_konst_max)
						{
							this.global1.allcountries[n].Donat = false;
						}
						else if (((n > 11 && n < 13) || n == 15) && this.global1.is_konst_max)
						{
							this.global1.allcountries[n].Donat = false;
							this.global1.allcountries[n].Stasi = false;
						}
						else if (n > 16 && n < 18 && this.global1.is_konst_max)
						{
							this.global1.allcountries[n].Stasi = false;
							this.global1.allcountries[n].Help = false;
						}
						else if ((n == 7 && this.global1.is_konst_max) || n == 0)
						{
							this.global1.allcountries[n].Stasi = false;
						}
					}
					num = n;
				}
			}
			if (this.global1.allcountries[7].isSEV && this.global1.allcountries[7].Donat && this.global1.is_konst_max && this.global1.data[19] == 1 && ((this.global1.data[20] % 3 == 0 && this.global1.data[21] <= 1989) || (this.global1.data[20] % 4 == 0 && this.global1.data[21] > 1989)))
			{
				this.global1.allcountries[7].Donat = false;
			}
			if (this.global1.data[19] == 1)
			{
				if (this.global1.data[20] == 6 && this.global1.data[21] == 1990)
				{
					this.global1.allcountries[31].subideology = 15;
				}
				if (this.global1.data[0] == 49 || this.global1.data[0] == 50 || this.global1.data[0] == 51)
				{
					if (this.yug1.gameState.battle_royal)
					{
						if (this.global1.data[20] == 4 && this.global1.data[21] == 1989)
						{
							this.yug1.StartBattleRoyal();
						}
						else if (this.global1.data[20] == 2 && this.global1.data[21] == 1989)
						{
							this.yug1.SetBattleRoyal();
						}
					}
					this.yug1.MoneyGetBot();
					if (this.global1.data[21] < 1992)
					{
						for (int num36 = 0; num36 < this.yug1.gameState.yugcountries.Length; num36 = num + 1)
						{
							this.yug1.gameState.yugcountries[num36].have_regions = this.yug1.SummRegions(num36);
							num = num36;
						}
						for (int num37 = 0; num37 < this.yug1.gameState.yugregions.Length; num37 = num + 1)
						{
							if (this.yug1.gameState.yugregions[num37].owner != this.yug1.gameState.player)
							{
								this.yug1.BuildingBot(num37, this.yug1.gameState.yugregions[num37].level);
							}
							num = num37;
						}
					}
					if (this.yug1.gameState.modifies[8] > 0)
					{
						ptr = ref this.yug1.gameState.modifies_time[8];
						ref int ptr17 = ref ptr;
						num = ptr;
						ptr17 = num + 1;
						if (this.yug1.gameState.modifies_time[8] > 3)
						{
							this.yug1.gameState.modifies_time[8] = 0;
							this.yug1.gameState.modifies[8] = 0;
						}
					}
					if (this.yug1.gameState.modifies[12] > 0)
					{
						ptr = ref this.yug1.gameState.modifies_time[12];
						ref int ptr18 = ref ptr;
						num = ptr;
						ptr18 = num + 1;
						if ((this.yug1.gameState.modifies_time[12] > 6 && this.yug1.gameState.modifies[12] == 2) || this.yug1.gameState.modifies_time[12] > 12)
						{
							this.yug1.gameState.modifies_time[12] = 0;
							this.yug1.gameState.modifies[12] = 0;
						}
					}
				}
				if (this.global1.data[0] == 10)
				{
					if (this.global1.data[100] > 0 && this.global1.event_done[255])
					{
						ptr = ref this.global1.data[9];
						ptr -= 5;
						ptr = ref this.global1.data[31];
						ptr += 5;
						ptr = ref this.global1.data[8];
						ptr -= this.global1.data[8] / 10;
					}
					else if (this.global1.data[100] > 0)
					{
						ptr = ref this.global1.data[9];
						ptr -= 5;
						ptr = ref this.global1.data[31];
						ptr += 5;
					}
				}
				else if (this.global1.data[0] == 18 && this.global1.data[13] == 8)
				{
					ptr = ref this.global1.data[7];
					ref int ptr19 = ref ptr;
					num = ptr;
					ptr19 = num + 1;
				}
				if (this.global1.allcountries[0].Stasi)
				{
					this.global1.allcountries[0].Stasi = false;
				}
				if (this.global1.allcountries[this.global1.data[0]].Help)
				{
					this.global1.allcountries[this.global1.data[0]].Help = false;
				}
				if (this.global1.data[0] == 20)
				{
					if (this.global1.data[19] % 3 == 0 && this.global1.data[23] >= this.global1.data[24])
					{
						ptr = ref this.global1.data[24];
						ref int ptr20 = ref ptr;
						num = ptr;
						ptr20 = num + 1;
					}
					if (this.global1.data[23] - this.global1.data[24] > 15)
					{
						ptr = ref this.global1.data[23];
						ptr += (this.global1.data[23] - this.global1.data[24]) / 3 * 2;
					}
				}
				if ((this.global1.allcountries[7].isOVD && this.global1.is_gkchp) || (this.global1.allcountries[7].paths == 3 && this.global1.event_done[1075]))
				{
					ptr = ref this.global1.data[7];
					ref int ptr21 = ref ptr;
					num = ptr;
					ptr21 = num + 1;
				}
				else if ((this.global1.event_done[4] || (this.global1.data[0] == 18 && this.global1.data[79] == 1)) && this.global1.data[21] < 1992 && (!this.global1.is_gkchp || !this.global1.allcountries[7].isOVD))
				{
					if (this.global1.event_done[4] && (this.global1.data[7] > 300 || this.global1.data[21] > 1989))
					{
						ptr = ref this.global1.data[7];
						ptr -= 10;
					}
					if (this.global1.data[30] > 0 && this.global1.data[0] != 20 && this.global1.data[0] != 49 && this.global1.data[0] != 50 && this.global1.data[0] != 51)
					{
						ptr = ref this.global1.data[8];
						ptr -= this.global1.data[30] / 50;
						ptr = ref this.global1.data[30];
						ptr -= this.global1.data[30] / 50;
						if (this.global1.data[0] == 18)
						{
							if (this.global1.data[16] == 10)
							{
								ptr = ref this.global1.data[5];
								ptr -= 22;
							}
							else if (this.global1.data[16] == 12)
							{
								ptr = ref this.global1.data[5];
								ptr -= 12;
							}
						}
					}
				}
				if (this.global1.allcountries[this.global1.data[0]].Vyshi && this.global1.data[21] <= 1991)
				{
					ptr = ref this.global1.data[7];
					ptr -= 2 * (1992 - this.global1.data[21]);
					ptr = ref this.global1.data[10];
					ptr -= 1992 - this.global1.data[21];
				}
				if (this.global1.diff[0])
				{
					ptr = ref this.global1.data[5];
					ptr -= 2 * (this.global1.data[21] - 1988);
					if (this.global1.data[21] < 1992 || !this.global1.is_gkchp || !this.global1.allcountries[7].isOVD)
					{
						ptr = ref this.global1.data[7];
						ref int ptr22 = ref ptr;
						num = ptr;
						ptr22 = num - 1;
					}
					ptr = ref this.global1.data[10];
					ptr += 5 - this.global1.data[14];
				}
				if (this.global1.data[0] == 20)
				{
					ptr = ref this.global1.data[8];
					ptr += 3;
				}
				if (this.global1.data[0] != 12)
				{
					if (this.global1.diff[1])
					{
						ptr = ref this.global1.data[5];
						ptr -= 3 * (this.global1.data[21] - 1988);
						if (this.global1.data[21] < 1992 || !this.global1.is_gkchp || !this.global1.allcountries[7].isOVD)
						{
							ptr = ref this.global1.data[7];
							ref int ptr23 = ref ptr;
							num = ptr;
							ptr23 = num - 1;
						}
						ptr = ref this.global1.data[10];
						ptr += 5 - this.global1.data[14];
					}
					else if (this.global1.diff[2])
					{
						ptr = ref this.global1.data[5];
						ptr -= this.global1.data[21] - 1988;
						if (this.global1.data[21] < 1992 || !this.global1.is_gkchp || !this.global1.allcountries[7].isOVD)
						{
							ptr = ref this.global1.data[7];
							ref int ptr24 = ref ptr;
							num = ptr;
							ptr24 = num - 1;
						}
						ptr = ref this.global1.data[10];
						ptr += 5 - this.global1.data[14];
					}
					else if (this.global1.diff[4])
					{
						ptr = ref this.global1.data[7];
						ptr -= 3;
						ptr = ref this.global1.data[8];
						ptr -= this.global1.data[21] - 1985;
					}
					if (this.global1.science[5])
					{
						if (this.global1.data[63] <= (this.global1.data[21] - 1989) * 2 + 4 && this.global1.data[21] <= 1991)
						{
							ptr = ref this.global1.data[8];
							ptr -= this.global1.data[63];
							this.global1.data[63] = (this.global1.data[21] - 1989) * 2;
						}
						else
						{
							ptr = ref this.global1.data[8];
							ptr -= this.global1.data[63] / 2;
							ptr = ref this.global1.data[63];
							ptr -= 4;
						}
					}
					else if (this.global1.science[4])
					{
						if (this.global1.data[63] <= (this.global1.data[21] - 1988) * 2 + 4 && this.global1.data[21] <= 1991)
						{
							ptr = ref this.global1.data[8];
							ptr -= this.global1.data[63];
							this.global1.data[63] = (this.global1.data[21] - 1988) * 2;
						}
						else
						{
							ptr = ref this.global1.data[8];
							ptr -= this.global1.data[63] / 2;
							ptr = ref this.global1.data[63];
							ptr -= 4;
						}
					}
					else if (this.global1.science[3])
					{
						if (this.global1.data[63] <= (this.global1.data[21] - 1987) * 2 + 4 && this.global1.data[21] <= 1991)
						{
							ptr = ref this.global1.data[8];
							ptr -= this.global1.data[63];
							this.global1.data[63] = (this.global1.data[21] - 1987) * 2;
						}
						else
						{
							ptr = ref this.global1.data[8];
							ptr -= this.global1.data[63] / 2;
							ptr = ref this.global1.data[63];
							ptr -= 4;
						}
					}
					else if (this.global1.data[63] <= (this.global1.data[21] - 1986) * 2 + 4 && this.global1.data[21] <= 1991)
					{
						ptr = ref this.global1.data[8];
						ptr -= this.global1.data[63];
						this.global1.data[63] = (this.global1.data[21] - 1986) * 2;
					}
					else
					{
						ptr = ref this.global1.data[8];
						ptr -= this.global1.data[63] / 2;
						ptr = ref this.global1.data[63];
						ptr -= 4;
					}
				}
				if (this.global1.data[63] < 0)
				{
					this.global1.data[63] = 0;
				}
				if (this.global1.data[0] == 12)
				{
					this.global1.data[63] = 0;
				}
				if (this.global1.allcountries[7].isOVD && this.global1.is_gkchp)
				{
					ptr = ref this.global1.data[7];
					ptr += 5;
				}
				this.global1.is_liber = false;
				if (this.global1.data[20] % 3 == 0 || this.global1.data[20] == 1)
				{
					this.global1.is_elect = false;
					this.global1.event_done[2] = false;
					if (this.global1.data[0] == 12)
					{
						if (!this.global1.allcountries[7].Vyshi)
						{
							if (this.global1.data[90] == 0 && this.global1.data[92] == 0 && this.global1.data[93] == 0 && this.global1.data[94] == 0)
							{
								if (this.global1.data[8] < 200)
								{
									ptr = ref this.global1.data[8];
									ptr += 35;
								}
								ptr = ref this.global1.data[30];
								ptr += 10;
								if (this.global1.data[9] < 200)
								{
									ptr = ref this.global1.data[9];
									ptr += 30;
								}
								this.global1.data[10] = 0;
								ptr = ref this.global1.data[2];
								ptr += 100;
							}
							else
							{
								if (this.global1.data[8] < 200)
								{
									ptr = ref this.global1.data[8];
									ptr += 70;
								}
								ptr = ref this.global1.data[30];
								ptr += 25;
								if (this.global1.data[9] < 200)
								{
									ptr = ref this.global1.data[9];
									ptr += 60;
								}
								this.global1.data[10] = 0;
								ptr = ref this.global1.data[2];
								ptr += 300;
							}
						}
						else if (this.global1.data[30] != 0)
						{
							this.global1.data[30] = 0;
						}
					}
				}
				if (this.global1.data[20] == 5 || this.global1.data[20] == 11)
				{
					this.global1.is_speech = false;
					this.global1.event_done[1] = false;
				}
				if (this.global1.event_done[35] && this.global1.data[0] != 20 && this.global1.data[0] != 49 && this.global1.data[0] != 50 && this.global1.data[0] != 51 && this.global1.data[21] < 1992 && (!this.global1.is_gkchp || (this.global1.allcountries[7].Gosstroy > 1 && this.global1.is_gkchp)))
				{
					ptr = ref this.global1.data[24];
					ref int ptr25 = ref ptr;
					num = ptr;
					ptr25 = num + 1;
				}
				for (int num38 = 0; num38 < this.global1.regions.Length; num38 = num + 1)
				{
					for (int num39 = 0; num39 < 15; num39 = num + 1)
					{
						if (this.global1.regions[num38].buildings[num39].type == 17 && this.global1.regions[num38].buildings[num39].is_builded && this.global1.regions[num38].buildings[num39].is_working)
						{
							if (this.global1.data[14] < 3)
							{
								ptr = ref this.global1.data[3];
								ref int ptr26 = ref ptr;
								num = ptr;
								ptr26 = num + 1;
							}
							else if (this.global1.data[14] > 3)
							{
								ptr = ref this.global1.data[3];
								ref int ptr27 = ref ptr;
								num = ptr;
								ptr27 = num - 1;
							}
						}
						else if (this.global1.regions[num38].buildings[num39].type == 21 && this.global1.regions[num38].buildings[num39].is_builded && this.global1.regions[num38].buildings[num39].is_working)
						{
							ptr = ref this.global1.data[5];
							ptr -= 10;
							ptr = ref this.global1.data[22];
							ptr += 5;
							ptr = ref this.global1.data[4];
							ptr += 30;
							ptr = ref this.global1.data[8];
							ptr -= 5;
							ptr = ref this.global1.data[9];
							ptr += 10;
						}
						else if (this.global1.regions[num38].buildings[num39].is_private && this.global1.regions[num38].buildings[num39].is_builded && this.global1.regions[num38].buildings[num39].is_working)
						{
							ptr = ref this.global1.data[4];
							ptr += 13 - this.global1.data[16];
						}
						num = num39;
					}
					num = num38;
				}
				if (this.global1.data[0] == 12)
				{
					for (int num40 = 114; num40 < 126; num40 = num + 1)
					{
						if (this.global1.data[num40] > 20)
						{
							ptr = ref this.global1.data[num40];
							ref int ptr28 = ref ptr;
							num = ptr;
							ptr28 = num - 1;
						}
						num = num40;
					}
					this.global1.data[89] = this.global1.data[4] / 20 + (1000 - this.global1.data[3]) / 20;
					if (this.global1.data[21] > 1989)
					{
						ptr = ref this.global1.data[89];
						ptr += 5;
					}
					if (this.global1.data[109] >= 6 || this.global1.allcountries[7].Vyshi)
					{
						ptr = ref this.global1.data[89];
						ptr += this.global1.data[4] / 20 + (1000 - this.global1.data[3]) / 20;
					}
					if (this.global1.data[109] >= 12 || this.global1.allcountries[7].Vyshi)
					{
						ptr = ref this.global1.data[89];
						ptr += this.global1.data[4] / 20 + (1000 - this.global1.data[3]) / 20;
					}
					if (this.global1.data[109] >= 18)
					{
						ptr = ref this.global1.data[89];
						ptr += this.global1.data[4] / 20 + (1000 - this.global1.data[3]) / 20;
					}
					if (this.global1.data[109] >= 24)
					{
						ptr = ref this.global1.data[89];
						ptr += this.global1.data[4] / 20 + (1000 - this.global1.data[3]) / 20;
					}
					Debug.Log(this.global1.data[113 + this.global1.data[20]]);
					Debug.Log(this.global1.data[89]);
					if (this.global1.data[110] <= 0 && this.global1.data[20] != 1 && this.global1.data[112] != 1 && (this.global1.data[90] != 0 || this.global1.data[92] != 0 || this.global1.data[93] != 0 || this.global1.data[94] != 0 || (this.global1.data[90] == 1 && this.global1.data[92] == 1 && this.global1.data[93] == 1 && this.global1.data[94] == 1 && this.global1.data[81] == 1)) && this.global1.event_done[240] && this.global1.data[88] <= 0 && this.global1.data[113 + this.global1.data[20]] < this.global1.data[89])
					{
						this.global1.data[109] = 0;
						this.VyzovEvent(241);
					}
					else if (this.global1.data[110] <= 0 && this.global1.data[20] != 1 && this.global1.data[112] != 1 && this.global1.data[90] == 0 && this.global1.data[92] == 0 && this.global1.data[93] == 0 && this.global1.data[94] == 0 && this.global1.event_done[240] && this.global1.data[88] <= 0 && this.global1.data[113 + this.global1.data[20]] < this.global1.data[89])
					{
						this.global1.data[109] = 0;
						this.VyzovEvent(237);
					}
					else if (this.global1.data[20] == 3 && this.global1.data[21] == 1989)
					{
						this.VyzovEvent(241);
					}
					if (this.global1.data[88] < 2)
					{
						ptr = ref this.global1.data[109];
						ref int ptr29 = ref ptr;
						num = ptr;
						ptr29 = num + 1;
					}
					else
					{
						this.global1.data[109] = 0;
					}
				}
				else if (this.global1.data[0] == 2 && this.global1.data[113] > 0 && !this.global1.is_party_enabled[4])
				{
					this.global1.data[113] = 0;
				}
			}
			if (this.global1.data[19] % 14 == 0)
			{
				if (this.global1.diff[2])
				{
					ptr = ref this.global1.data[10];
					ref int ptr30 = ref ptr;
					num = ptr;
					ptr30 = num + 1;
				}
				if (this.global1.data[0] >= 49 && this.global1.data[0] <= 51)
				{
					for (int num41 = 0; num41 < this.yug1.gameState.yugcountries.Length; num41 = num + 1)
					{
						this.yug1.gameState.yugcountries[num41].traded = false;
						num = num41;
					}
				}
			}
			if (this.global1.data[19] % 7 == 0)
			{
				if (this.global1.data[0] >= 49 && this.global1.data[0] <= 51 && !this.yug1.gameState.battle_royal)
				{
					this.YugoModifiesChanges();
				}
				else
				{
					ptr = ref this.global1.data[3];
					ptr += 10;
				}
				Debug.Log("MODFIEDONE");
				if (this.global1.data[0] == 49 || this.global1.data[0] == 50 || this.global1.data[0] == 51)
				{
					for (int num42 = 0; num42 < this.yug1.gameState.yugcountries.Length; num42 = num + 1)
					{
						this.yug1.gameState.yugcountries[num42].last = this.yug1.IsLastOne(num42);
						this.yug1.gameState.yugcountries[num42].have_regions = this.yug1.SummRegions(num42);
						if (this.global1.data[19] % 14 == 0)
						{
							this.yug1.ArmyAutoGrowth(num42, ref this.yug1.gameState.yugcountries[num42].army);
						}
						if (this.yug1.gameState.yugcountries[num42].temp_peace)
						{
							YugoCountry yugoCountry = this.yug1.gameState.yugcountries[num42];
							YugoCountry yugoCountry2 = yugoCountry;
							num = yugoCountry.temp_peace_time;
							yugoCountry2.temp_peace_time = num - 1;
							if (this.yug1.gameState.yugcountries[num42].temp_peace_time <= 0)
							{
								this.yug1.MakeTempPeace(num42);
							}
						}
						num = num42;
					}
					for (int num43 = 0; num43 < this.yug1.gameState.yugcountries.Length; num43 = num + 1)
					{
						if (num43 != this.yug1.gameState.player && this.yug1.gameState.yugcountries[num43].have_regions > 0 && this.yug1.gameState.yugcountries[num43].army > 49)
						{
							this.yug1.ChooseAttackBot(num43);
						}
						num = num43;
					}
					for (int num44 = 0; num44 < this.yug1.gameState.yugregions.Length; num44 = num + 1)
					{
						this.yug1.gameState.yugregions[num44].defence = this.yug1.DefenceRegionalPower(num44);
						num = num44;
					}
				}
				Debug.Log("ATTACKDONE");
				if (this.global1.data[0] == 10)
				{
					ptr = ref this.global1.data[5];
					ptr -= 5;
					if (this.global1.event_done[16] && this.global1.allcountries[16].Gosstroy != 0 && this.global1.data[73] > 0)
					{
						ptr = ref this.global1.data[73];
						ref int ptr31 = ref ptr;
						num = ptr;
						ptr31 = num - 1;
					}
					else if (this.global1.data[73] < 0)
					{
						this.global1.data[73] = 0;
					}
				}
				else if (this.global1.data[0] >= 1 && this.global1.data[0] <= 6)
				{
					int num45 = 0;
					for (int num46 = 0; num46 < this.global1.science.Length; num46 = num + 1)
					{
						if (this.global1.science[num46])
						{
							num = num45;
							num45 = num + 1;
						}
						num = num46;
					}
					if (this.global1.data[5] <= (35 - num45) * 10 && this.global1.data[71] == 0)
					{
						this.global1.data[71] = 1;
					}
					else if (this.global1.data[5] >= (49 - num45) * 10 && this.global1.data[71] == 1)
					{
						this.global1.data[71] = 0;
					}
					else if (this.global1.data[71] == 1)
					{
						ptr = ref this.global1.data[3];
						ptr -= 5;
						ptr = ref this.global1.data[1];
						ptr -= 4;
						ptr = ref this.global1.data[8];
						ptr -= 2;
					}
					if (this.global1.data[72] > 0)
					{
						ptr = ref this.global1.data[6];
						ptr += 2;
						ptr = ref this.global1.data[10];
						ptr += 2;
						ptr = ref this.global1.data[8];
						ptr -= 5;
						ptr = ref this.global1.data[22];
						ptr += 2;
					}
				}
				if (this.global1.event_done[209] && this.global1.data[5] <= 200 && this.global1.data[71] < 1)
				{
					this.global1.data[71] = 1;
				}
				else if (this.global1.data[5] >= 400 && this.global1.data[71] > 0)
				{
					this.global1.data[71] = 0;
				}
				else if (this.global1.data[71] > 0)
				{
					ptr = ref this.global1.data[3];
					ptr -= 5;
					ptr = ref this.global1.data[1];
					ptr -= 4;
					ptr = ref this.global1.data[8];
					ptr -= 2;
					ptr = ref this.global1.data[22];
					ptr -= 2;
				}
				if (this.global1.data[72] > 0)
				{
					ptr = ref this.global1.data[6];
					ptr += 2;
					ptr = ref this.global1.data[10];
					ptr += 2;
					ptr = ref this.global1.data[5];
					ptr -= 2;
					ptr = ref this.global1.data[8];
					ptr -= 5;
					ptr = ref this.global1.data[22];
					ptr += 2;
				}
				if (this.global1.diff[4] && this.global1.data[21] < 1992)
				{
					ptr = ref this.global1.data[1];
					ptr -= this.global1.data[1] / 50 / 3 * (this.global1.data[1] / 250) * (this.global1.data[1] / (600 - (this.global1.data[21] - 1989) * 150)) * (this.global1.data[21] - 1988);
					ptr = ref this.global1.data[8];
					ptr -= this.global1.data[8] / 5 / 3 * (this.global1.data[8] / 50) * (this.global1.data[8] / (80 - (this.global1.data[21] - 1989) * 15)) * (this.global1.data[21] - 1988);
					if (this.global1.data[9] > 0)
					{
						ptr = ref this.global1.data[9];
						ptr -= this.global1.data[9] / 5 / 3 * (this.global1.data[9] / 50) * (this.global1.data[9] / (80 - (this.global1.data[21] - 1989) * 15)) * (this.global1.data[21] - 1988);
					}
					else if (this.global1.data[9] <= -100)
					{
						this.global1.data[9] = -100;
					}
					ptr = ref this.global1.data[2];
					ptr -= (5 - this.global1.data[14]) * (this.global1.data[21] - 1988) * (this.global1.data[21] - 1988);
					if (this.global1.data[14] < 3 || ((this.global1.data[0] == 49 || this.global1.data[0] == 50 || this.global1.data[0] == 51) && this.global1.data[14] < 4))
					{
						ptr = ref this.global1.data[4];
						ptr += (1100 - this.global1.data[4]) / 40 / 3 * ((1100 - this.global1.data[4]) / 200) * ((1100 - this.global1.data[4]) / (500 - (this.global1.data[21] - 1989) * 150)) * (this.global1.data[21] - 1988);
					}
					else
					{
						ptr = ref this.global1.data[3];
						ptr -= this.global1.data[4] / 40 / 3 * (this.global1.data[4] / 200) * (this.global1.data[4] / (500 - (this.global1.data[21] - 1989) * 150)) * (this.global1.data[21] - 1988);
					}
				}
				if (this.global1.data[61] > 40)
				{
					ptr = ref this.global1.data[61];
					ref int ptr32 = ref ptr;
					num = ptr;
					ptr32 = num - 1;
					ptr = ref this.global1.data[10];
					ptr -= 5;
					ptr = ref this.global1.data[4];
					ptr += 2;
					ptr = ref this.global1.data[6];
					ptr -= 2;
				}
				else if (this.global1.data[61] > 30 && this.global1.data[61] < 35)
				{
					ptr = ref this.global1.data[61];
					ref int ptr33 = ref ptr;
					num = ptr;
					ptr33 = num - 1;
					ptr = ref this.global1.data[2];
					ref int ptr34 = ref ptr;
					num = ptr;
					ptr34 = num - 1;
					ptr = ref this.global1.data[4];
					ref int ptr35 = ref ptr;
					num = ptr;
					ptr35 = num - 1;
					ptr = ref this.global1.data[22];
					ptr += 2;
					ptr = ref this.global1.data[31];
					ptr += 2;
					ptr = ref this.global1.data[6];
					ref int ptr36 = ref ptr;
					num = ptr;
					ptr36 = num + 1;
					ptr = ref this.global1.data[10];
					ptr += 2;
				}
				else if (this.global1.data[61] > 20 && this.global1.data[61] < 25)
				{
					ptr = ref this.global1.data[61];
					ref int ptr37 = ref ptr;
					num = ptr;
					ptr37 = num - 1;
					ptr = ref this.global1.data[2];
					ptr += 5;
					ptr = ref this.global1.data[4];
					ptr += 2;
					ptr = ref this.global1.data[31];
					ptr -= 2;
				}
				else if (this.global1.data[61] > 10 && this.global1.data[61] < 15)
				{
					ptr = ref this.global1.data[61];
					ref int ptr38 = ref ptr;
					num = ptr;
					ptr38 = num - 1;
					ptr = ref this.global1.data[33];
					ptr -= 5;
					ptr = ref this.global1.data[6];
					ref int ptr39 = ref ptr;
					num = ptr;
					ptr39 = num - 1;
				}
				else if (this.global1.data[61] > 0 && this.global1.data[61] < 5)
				{
					ptr = ref this.global1.data[61];
					ref int ptr40 = ref ptr;
					num = ptr;
					ptr40 = num - 1;
					ptr = ref this.global1.data[33];
					ptr += 5;
					ptr = ref this.global1.data[6];
					ref int ptr41 = ref ptr;
					num = ptr;
					ptr41 = num + 1;
				}
				else
				{
					this.global1.data[61] = 0;
				}
				if (this.global1.allcountries[40].Westalgie > 100 && this.global1.allcountries[40].Westalgie < 1000)
				{
					if (this.global1.data[21] < 1991 || this.global1.allcountries[40].Westalgie > 950)
					{
						Country country = this.global1.allcountries[40];
						Country country2 = country;
						num = country.Westalgie;
						country2.Westalgie = num - 1;
					}
					else
					{
						Country country = this.global1.allcountries[40];
						country.Westalgie -= 4;
					}
				}
				else if (this.global1.allcountries[40].Westalgie >= 1000 && this.global1.allcountries[40].Gosstroy != 1 && !this.global1.event_done[1078])
				{
					this.global1.allcountries[40].Gosstroy = 1;
					this.global1.allcountries[40].subideology = 11;
					Country country = this.global1.allcountries[17];
					country.Westalgie += 5;
					ptr = ref this.global1.data[7];
					ptr += 3;
				}
				else if (this.global1.allcountries[40].Westalgie <= 0 && this.global1.allcountries[40].subideology != 3 && !this.global1.event_done[1078])
				{
					this.global1.allcountries[40].Gosstroy = 9;
					this.global1.allcountries[40].subideology = 3;
				}
				if (this.global1.allcountries[41].Westalgie > 100 && this.global1.allcountries[41].Westalgie < 1000)
				{
					if (this.global1.data[21] < 1990 || this.global1.allcountries[41].Westalgie > 950)
					{
						Country country = this.global1.allcountries[41];
						country.Westalgie -= 2;
					}
					else
					{
						Country country = this.global1.allcountries[41];
						country.Westalgie -= 5;
					}
				}
				else if (this.global1.allcountries[41].Westalgie <= 0 && this.global1.allcountries[41].Gosstroy != 1)
				{
					this.global1.allcountries[41].Gosstroy = 1;
					this.global1.allcountries[41].subideology = 11;
				}
				else if (this.global1.allcountries[41].Westalgie >= 1000 && this.global1.allcountries[41].Gosstroy != 0)
				{
					this.global1.allcountries[41].Gosstroy = 0;
					this.global1.allcountries[41].subideology = 7;
					Country country = this.global1.allcountries[17];
					country.Westalgie += 5;
					ptr = ref this.global1.data[7];
					ptr += 3;
				}
				if (this.global1.allcountries[42].Westalgie > 100 && this.global1.allcountries[42].Westalgie < 1000)
				{
					if (this.global1.allcountries[42].Westalgie > 950)
					{
						Country country = this.global1.allcountries[42];
						country.Westalgie -= 2;
					}
					else
					{
						Country country = this.global1.allcountries[42];
						country.Westalgie -= 5;
					}
				}
				else if (this.global1.allcountries[42].Westalgie <= 0 && this.global1.allcountries[42].subideology != 2)
				{
					this.global1.allcountries[42].Gosstroy = 9;
					this.global1.allcountries[42].subideology = 2;
				}
				else if (this.global1.allcountries[40].Westalgie >= 1000 && this.global1.allcountries[42].subideology != 0)
				{
					this.global1.allcountries[42].Gosstroy = 9;
					this.global1.allcountries[42].subideology = 0;
					Country country = this.global1.allcountries[17];
					country.Westalgie += 5;
					ptr = ref this.global1.data[7];
					ptr += 3;
				}
				if (this.global1.allcountries[43].Westalgie > 100 && this.global1.allcountries[43].Westalgie < 1000)
				{
					if (this.global1.data[21] < 1990 || this.global1.allcountries[43].Westalgie > 950)
					{
						Country country = this.global1.allcountries[43];
						country.Westalgie -= 2;
					}
					else
					{
						Country country = this.global1.allcountries[43];
						country.Westalgie -= 5;
					}
					if (this.global1.allcountries[19].Gosstroy > 1)
					{
						Country country = this.global1.allcountries[43];
						Country country3 = country;
						num = country.Westalgie;
						country3.Westalgie = num - 1;
					}
					if (this.global1.allcountries[16].Gosstroy > 0)
					{
						Country country = this.global1.allcountries[43];
						Country country4 = country;
						num = country.Westalgie;
						country4.Westalgie = num - 1;
					}
				}
				else if (this.global1.allcountries[43].Westalgie <= 0 && this.global1.allcountries[43].Gosstroy != 9)
				{
					this.global1.allcountries[43].Gosstroy = 9;
					this.global1.allcountries[43].subideology = 2;
				}
				else if (this.global1.allcountries[43].Westalgie >= 1000 && this.global1.allcountries[43].Gosstroy != 1)
				{
					this.global1.allcountries[43].Gosstroy = 1;
					this.global1.allcountries[43].subideology = 9;
					Country country = this.global1.allcountries[17];
					country.Westalgie += 5;
					ptr = ref this.global1.data[7];
					ptr += 3;
				}
				if (this.global1.data[41] == 1)
				{
					ptr = ref this.global1.data[3];
					ptr -= num31 / 30 * (this.global1.data[21] - 1988);
				}
				else if (this.global1.data[41] == 2)
				{
					ptr = ref this.global1.data[4];
					ptr += num31 / 30 * (this.global1.data[21] - 1988);
				}
				else if (this.global1.data[41] == 3)
				{
					ptr = ref this.global1.data[4];
					ptr += num31 / 30 * (this.global1.data[21] - 1988);
					ptr = ref this.global1.data[3];
					ptr -= num31 / 30 * (this.global1.data[21] - 1988);
				}
				else if (this.global1.data[41] == 4)
				{
					ptr = ref this.global1.data[10];
					ptr += 2;
					ptr = ref this.global1.data[6];
					ref int ptr42 = ref ptr;
					num = ptr;
					ptr42 = num + 1;
					ptr = ref this.global1.data[9];
					ref int ptr43 = ref ptr;
					num = ptr;
					ptr43 = num + 1;
					ptr = ref this.global1.data[31];
					ref int ptr44 = ref ptr;
					num = ptr;
					ptr44 = num + 1;
					ptr = ref this.global1.data[22];
					ref int ptr45 = ref ptr;
					num = ptr;
					ptr45 = num + 1;
					ptr = ref this.global1.data[1];
					ptr -= 5;
				}
				if (!this.global1.is_konst_max)
				{
					ptr = ref this.global1.data[4];
					ptr += this.global1.data[21] - 1988;
					ptr = ref this.global1.data[3];
					ptr -= this.global1.data[21] - 1988;
				}
				ptr = ref this.global1.data[4];
				ptr -= this.global1.data[15] - 7;
				ptr = ref this.global1.data[3];
				ptr -= this.global1.data[15] - 7;
				ptr = ref this.global1.data[2];
				ptr += this.global1.data[15] - 7;
				ptr = ref this.global1.data[4];
				ptr -= this.global1.data[17] - 15;
				ptr = ref this.global1.data[3];
				ptr -= this.global1.data[17] - 15;
				ptr = ref this.global1.data[2];
				ptr += this.global1.data[17] - 15;
				if (this.global1.allcountries[this.global1.data[0]].Vyshi)
				{
					if (this.global1.data[4] > 500)
					{
						ptr = ref this.global1.data[4];
						ptr -= 25;
						if (this.global1.data[0] == 4 && this.global1.data[11] == 3)
						{
							ptr = ref this.global1.data[4];
							ptr -= 5;
						}
					}
					else if (this.global1.data[4] > 300)
					{
						ptr = ref this.global1.data[4];
						ptr -= 5;
						if (this.global1.data[0] == 4 && this.global1.data[11] == 3)
						{
							ptr = ref this.global1.data[4];
							ref int ptr46 = ref ptr;
							num = ptr;
							ptr46 = num - 1;
						}
					}
					else
					{
						ptr = ref this.global1.data[4];
						ref int ptr47 = ref ptr;
						num = ptr;
						ptr47 = num - 1;
					}
					if (this.global1.data[22] > 0)
					{
						ptr = ref this.global1.data[22];
						ref int ptr48 = ref ptr;
						num = ptr;
						ptr48 = num - 1;
					}
					if (this.global1.data[1] < 500)
					{
						ptr = ref this.global1.data[1];
						ptr += 5;
					}
					ptr = ref this.global1.data[8];
					ptr += 20;
					if (this.global1.data[5] > 900)
					{
						ptr = ref this.global1.data[5];
						ptr -= 9;
					}
					else if (this.global1.data[5] > 700)
					{
						ptr = ref this.global1.data[5];
						ptr -= 6;
					}
					else if (this.global1.data[5] > 500)
					{
						ptr = ref this.global1.data[5];
						ptr -= 3;
					}
					else
					{
						ptr = ref this.global1.data[4];
						ref int ptr49 = ref ptr;
						num = ptr;
						ptr49 = num - 1;
					}
				}
				if (this.global1.data[16] < 12 || this.global1.data[21] > 1991)
				{
					ptr = ref this.global1.data[5];
					ptr -= this.global1.data[5] / 690 * (this.global1.data[5] / 60);
				}
				else
				{
					ptr = ref this.global1.data[5];
					ptr -= this.global1.data[5] / (690 - (this.global1.data[16] - 11) * 125) * (this.global1.data[5] / 60);
				}
				if (!this.global1.allcountries[this.global1.data[0]].Vyshi || this.global1.data[21] > 1991)
				{
					ptr = ref this.global1.data[22];
					ptr -= this.global1.data[22] / 700 * (this.global1.data[22] / 100);
				}
				else
				{
					ptr = ref this.global1.data[22];
					ptr -= this.global1.data[22] / 500 * (this.global1.data[22] / 100);
				}
				if (this.global1.event_done[5])
				{
					ptr = ref this.global1.data[3];
					ptr -= this.global1.data[3] / 700 * (this.global1.data[3] / 80);
					ptr = ref this.global1.data[4];
					ptr += (1000 - this.global1.data[4]) / 700 * ((1000 - this.global1.data[4]) / 80);
				}
				else if (this.global1.event_done[4])
				{
					ptr = ref this.global1.data[3];
					ptr -= this.global1.data[3] / 700 * (this.global1.data[3] / 160);
					ptr = ref this.global1.data[4];
					ptr += (1000 - this.global1.data[4]) / 700 * ((1000 - this.global1.data[4]) / 160);
				}
				ptr = ref this.global1.data[8];
				ptr -= this.global1.data[8] / 100 * (this.global1.data[8] / 100);
				ptr = ref this.global1.data[1];
				ptr -= this.global1.data[10] / 200;
				if (this.global1.data[3] > 300)
				{
					ptr = ref this.global1.data[3];
					ptr -= this.global1.data[10] / 300;
				}
				if (this.global1.data[4] < 700)
				{
					ptr = ref this.global1.data[4];
					ptr += this.global1.data[10] / 400;
				}
				if (this.global1.data[16] >= 12)
				{
					ptr = ref this.global1.data[8];
					ptr += this.global1.data[8] / 50;
				}
				if (this.global1.data[14] <= 0 && this.global1.data[18] > 18)
				{
					ptr = ref this.global1.data[33];
					ref int ptr50 = ref ptr;
					num = ptr;
					ptr50 = num + 1;
				}
				else if (this.global1.data[14] <= 1 && this.global1.data[18] > 19)
				{
					ptr = ref this.global1.data[33];
					ref int ptr51 = ref ptr;
					num = ptr;
					ptr51 = num + 1;
				}
				else if (this.global1.data[14] <= 2 && this.global1.data[18] > 20)
				{
					ptr = ref this.global1.data[33];
					ref int ptr52 = ref ptr;
					num = ptr;
					ptr52 = num + 1;
				}
				else if (this.global1.data[14] <= 3 && this.global1.data[18] > 21)
				{
					ptr = ref this.global1.data[33];
					ref int ptr53 = ref ptr;
					num = ptr;
					ptr53 = num + 1;
				}
				else if (this.global1.data[14] <= 4 && this.global1.data[18] > 22)
				{
					ptr = ref this.global1.data[33];
					ref int ptr54 = ref ptr;
					num = ptr;
					ptr54 = num + 1;
				}
				else if (this.global1.data[14] >= 5 && this.global1.data[18] < 23)
				{
					ptr = ref this.global1.data[33];
					ref int ptr55 = ref ptr;
					num = ptr;
					ptr55 = num - 1;
				}
				else if (this.global1.data[14] >= 4 && this.global1.data[18] < 22)
				{
					ptr = ref this.global1.data[33];
					ref int ptr56 = ref ptr;
					num = ptr;
					ptr56 = num - 1;
				}
				else if (this.global1.data[14] >= 3 && this.global1.data[18] < 21)
				{
					ptr = ref this.global1.data[33];
					ref int ptr57 = ref ptr;
					num = ptr;
					ptr57 = num - 1;
				}
				else if (this.global1.data[14] >= 1 && this.global1.data[18] < 20)
				{
					ptr = ref this.global1.data[33];
					ref int ptr58 = ref ptr;
					num = ptr;
					ptr58 = num - 1;
				}
				if (this.global1.data[15] <= 7 && this.global1.data[18] > 20)
				{
					ptr = ref this.global1.data[33];
					ref int ptr59 = ref ptr;
					num = ptr;
					ptr59 = num + 1;
				}
				else if (this.global1.data[15] <= 8 && this.global1.data[18] > 21)
				{
					ptr = ref this.global1.data[33];
					ref int ptr60 = ref ptr;
					num = ptr;
					ptr60 = num + 1;
				}
				else if (this.global1.data[15] >= 9 && this.global1.data[18] < 21)
				{
					ptr = ref this.global1.data[33];
					ref int ptr61 = ref ptr;
					num = ptr;
					ptr61 = num - 1;
				}
				else if (this.global1.data[15] >= 8 && this.global1.data[18] < 20)
				{
					ptr = ref this.global1.data[33];
					ref int ptr62 = ref ptr;
					num = ptr;
					ptr62 = num - 1;
				}
				if (this.global1.data[17] <= 14 && this.global1.data[18] > 19)
				{
					ptr = ref this.global1.data[33];
					ref int ptr63 = ref ptr;
					num = ptr;
					ptr63 = num + 1;
				}
				else if (this.global1.data[17] <= 15 && this.global1.data[18] > 20)
				{
					ptr = ref this.global1.data[33];
					ref int ptr64 = ref ptr;
					num = ptr;
					ptr64 = num + 1;
				}
				else if (this.global1.data[17] <= 16 && this.global1.data[18] > 21)
				{
					ptr = ref this.global1.data[33];
					ref int ptr65 = ref ptr;
					num = ptr;
					ptr65 = num + 1;
				}
				else if (this.global1.data[17] >= 17 && this.global1.data[18] < 22)
				{
					ptr = ref this.global1.data[33];
					ref int ptr66 = ref ptr;
					num = ptr;
					ptr66 = num - 1;
				}
				else if (this.global1.data[17] >= 16 && this.global1.data[18] < 20)
				{
					ptr = ref this.global1.data[33];
					ref int ptr67 = ref ptr;
					num = ptr;
					ptr67 = num - 1;
				}
				else if (this.global1.data[17] >= 15 && this.global1.data[18] < 19)
				{
					ptr = ref this.global1.data[33];
					ref int ptr68 = ref ptr;
					num = ptr;
					ptr68 = num - 1;
				}
				if (this.global1.data[0] == 1 && this.global1.data[10] < 30 - this.global1.data[14] - this.global1.data[14])
				{
					ptr = ref this.global1.data[10];
					ref int ptr69 = ref ptr;
					num = ptr;
					ptr69 = num + 1;
				}
				bool[][] array2 = new bool[this.global1.regions.Length][];
				for (int num47 = 0; num47 < array2.Length; num47 = num + 1)
				{
					array2[num47] = new bool[3];
					num = num47;
				}
				if (this.global1.data[0] >= 49 && this.global1.data[0] <= 51)
				{
					for (int num48 = 0; num48 < this.yug1.gameState.yugregions.Length; num48 = num + 1)
					{
						if (this.yug1.gameState.yugregions[num48].owner == this.yug1.gameState.player)
						{
							if (this.yug1.gameState.yugregions[num48].level <= 0)
							{
								array2[this.yug1.gameState.yugregions[num48].inreg][0] = true;
							}
							else if (this.yug1.gameState.yugregions[num48].level <= 5)
							{
								array2[this.yug1.gameState.yugregions[num48].inreg][1] = true;
							}
							else if (this.yug1.gameState.yugregions[num48].level <= 10)
							{
								array2[this.yug1.gameState.yugregions[num48].inreg][2] = true;
							}
						}
						num = num48;
					}
				}
				for (int num49 = 0; num49 < this.global1.regions.Length; num49 = num + 1)
				{
					for (int num50 = 0; num50 < 15; num50 = num + 1)
					{
						if (this.global1.data[0] < 49 || this.global1.data[0] > 51 || num49 == 2 || (array2[num49][0] && num50 < 5) || (array2[num49][1] && num50 < 10) || (array2[num49][2] && num50 < 15))
						{
							if (this.global1.regions[num49].buildings[num50].type == 1 && this.global1.regions[num49].buildings[num50].is_builded && this.global1.regions[num49].buildings[num50].is_working)
							{
								ptr = ref this.global1.data[8];
								ref int ptr70 = ref ptr;
								num = ptr;
								ptr70 = num + 1;
								ptr = ref this.global1.data[5];
								ref int ptr71 = ref ptr;
								num = ptr;
								ptr71 = num + 1;
							}
							else if (this.global1.regions[num49].buildings[num50].type == 2 && this.global1.regions[num49].buildings[num50].is_builded && this.global1.regions[num49].buildings[num50].is_working)
							{
								ptr = ref this.global1.data[8];
								ptr += 2;
								ptr = ref this.global1.data[4];
								ref int ptr72 = ref ptr;
								num = ptr;
								ptr72 = num + 1;
							}
							else if (this.global1.regions[num49].buildings[num50].type == 3 && this.global1.regions[num49].buildings[num50].is_builded && this.global1.regions[num49].buildings[num50].is_working)
							{
								ptr = ref this.global1.data[8];
								ptr -= 2;
								ptr = ref this.global1.data[4];
								ref int ptr73 = ref ptr;
								num = ptr;
								ptr73 = num - 1;
								ptr = ref this.global1.data[5];
								ref int ptr74 = ref ptr;
								num = ptr;
								ptr74 = num + 1;
							}
							else if (this.global1.regions[num49].buildings[num50].type == 4 && this.global1.regions[num49].buildings[num50].is_builded && this.global1.regions[num49].buildings[num50].is_working)
							{
								ptr = ref this.global1.data[8];
								ptr -= 2;
								ptr = ref this.global1.data[4];
								ptr -= 2;
								ptr = ref this.global1.data[9];
								ptr += 2;
							}
							else if (this.global1.regions[num49].buildings[num50].type == 5 && this.global1.regions[num49].buildings[num50].is_builded && this.global1.regions[num49].buildings[num50].is_working)
							{
								ptr = ref this.global1.data[4];
								ptr += 2;
								ptr = ref this.global1.data[3];
								ptr += 2;
							}
							else if (this.global1.regions[num49].buildings[num50].type == 6 && this.global1.data[19] == 1 && this.global1.data[20] % 2 == 0 && this.global1.regions[num49].buildings[num50].is_builded && this.global1.regions[num49].buildings[num50].is_working)
							{
								ptr = ref this.global1.data[8];
								ref int ptr75 = ref ptr;
								num = ptr;
								ptr75 = num + 1;
								ptr = ref this.global1.data[4];
								ref int ptr76 = ref ptr;
								num = ptr;
								ptr76 = num + 1;
							}
							else if (this.global1.regions[num49].buildings[num50].type == 7 && this.global1.regions[num49].buildings[num50].is_builded && this.global1.regions[num49].buildings[num50].is_working)
							{
								ptr = ref this.global1.data[1];
								ref int ptr77 = ref ptr;
								num = ptr;
								ptr77 = num + 1;
								ptr = ref this.global1.data[3];
								ref int ptr78 = ref ptr;
								num = ptr;
								ptr78 = num + 1;
								ptr = ref this.global1.data[10];
								ptr += 2;
								ptr = ref this.global1.data[2];
								ptr -= 2;
							}
							else if (this.global1.regions[num49].buildings[num50].type == 8 && this.global1.regions[num49].buildings[num50].is_builded && this.global1.regions[num49].buildings[num50].is_working)
							{
								ptr = ref this.global1.data[8];
								ptr -= 2;
								ptr = ref this.global1.data[4];
								ptr -= 2;
							}
							else if (this.global1.regions[num49].buildings[num50].type == 9 && this.global1.regions[num49].buildings[num50].is_builded && this.global1.regions[num49].buildings[num50].is_working)
							{
								ptr = ref this.global1.data[8];
								ref int ptr79 = ref ptr;
								num = ptr;
								ptr79 = num - 1;
							}
							else if (this.global1.regions[num49].buildings[num50].type == 10 && this.global1.regions[num49].buildings[num50].is_builded && this.global1.regions[num49].buildings[num50].is_working)
							{
								ptr = ref this.global1.data[8];
								ptr -= 2;
								ptr = ref this.global1.data[9];
								ptr += 2;
							}
							else if (this.global1.regions[num49].buildings[num50].type == 11 && this.global1.regions[num49].buildings[num50].is_builded && this.global1.regions[num49].buildings[num50].is_working)
							{
								ptr = ref this.global1.data[8];
								ptr -= 2;
								ptr = ref this.global1.data[3];
								ptr += 2;
							}
							else if (this.global1.regions[num49].buildings[num50].type == 12 && this.global1.regions[num49].buildings[num50].is_builded && this.global1.regions[num49].buildings[num50].is_working)
							{
								ptr = ref this.global1.data[4];
								ptr -= 2;
								ptr = ref this.global1.data[9];
								ptr += 2;
								ptr = ref this.global1.data[2];
								ref int ptr80 = ref ptr;
								num = ptr;
								ptr80 = num - 1;
							}
							else if (this.global1.regions[num49].buildings[num50].type == 13 && this.global1.regions[num49].buildings[num50].is_builded && this.global1.regions[num49].buildings[num50].is_working)
							{
								ptr = ref this.global1.data[1];
								ptr += 4;
								ptr = ref this.global1.data[3];
								ptr += (this.global1.data[1] - 500) / 250;
								ptr = ref this.global1.data[4];
								ptr -= (this.global1.data[1] - 500) / 250;
								ptr = ref this.global1.data[8];
								ref int ptr81 = ref ptr;
								num = ptr;
								ptr81 = num + 1;
							}
							else if (this.global1.regions[num49].buildings[num50].type == 14 && this.global1.regions[num49].buildings[num50].is_builded && this.global1.regions[num49].buildings[num50].is_working)
							{
								ptr = ref this.global1.data[22];
								ptr += 2;
								ptr = ref this.global1.data[1];
								ptr += 4;
								ptr = ref this.global1.data[10];
								ref int ptr82 = ref ptr;
								num = ptr;
								ptr82 = num + 1;
								ptr = ref this.global1.data[2];
								ref int ptr83 = ref ptr;
								num = ptr;
								ptr83 = num - 1;
							}
							else if (this.global1.regions[num49].buildings[num50].type == 15 && this.global1.regions[num49].buildings[num50].is_builded && this.global1.regions[num49].buildings[num50].is_working)
							{
								ptr = ref this.global1.data[8];
								ptr += 3;
								ptr = ref this.global1.data[4];
								ref int ptr84 = ref ptr;
								num = ptr;
								ptr84 = num + 1;
								ptr = ref this.global1.data[5];
								ptr += 2;
							}
							else if (this.global1.regions[num49].buildings[num50].type == 16 && this.global1.regions[num49].buildings[num50].is_builded && this.global1.regions[num49].buildings[num50].is_working)
							{
								ptr = ref this.global1.data[8];
								ptr += 2;
								ptr = ref this.global1.data[3];
								ref int ptr85 = ref ptr;
								num = ptr;
								ptr85 = num - 1;
								ptr = ref this.global1.data[5];
								ref int ptr86 = ref ptr;
								num = ptr;
								ptr86 = num + 1;
							}
							else if (this.global1.regions[num49].buildings[num50].type == 18 && this.global1.regions[num49].buildings[num50].is_builded && this.global1.regions[num49].buildings[num50].is_working)
							{
								ptr = ref this.global1.data[8];
								ptr += 3;
								ptr = ref this.global1.data[3];
								ref int ptr87 = ref ptr;
								num = ptr;
								ptr87 = num + 1;
								ptr = ref this.global1.data[10];
								ref int ptr88 = ref ptr;
								num = ptr;
								ptr88 = num - 1;
							}
							else if (this.global1.regions[num49].buildings[num50].type == 19 && this.global1.regions[num49].buildings[num50].is_builded && this.global1.regions[num49].buildings[num50].is_working)
							{
								ptr = ref this.global1.data[1];
								ptr += 3;
								ptr = ref this.global1.data[22];
								ref int ptr89 = ref ptr;
								num = ptr;
								ptr89 = num + 1;
								ptr = ref this.global1.data[4];
								ptr += 3;
								ptr = ref this.global1.data[2];
								ref int ptr90 = ref ptr;
								num = ptr;
								ptr90 = num + 1;
								ptr = ref this.global1.data[10];
								ref int ptr91 = ref ptr;
								num = ptr;
								ptr91 = num - 1;
							}
							else if (this.global1.regions[num49].buildings[num50].type == 20 && this.global1.regions[num49].buildings[num50].is_builded && this.global1.regions[num49].buildings[num50].is_working)
							{
								ptr = ref this.global1.data[3];
								ptr += 2;
								ptr = ref this.global1.data[4];
								ptr -= 2;
								ptr = ref this.global1.data[5];
								ref int ptr92 = ref ptr;
								num = ptr;
								ptr92 = num + 1;
								ptr = ref this.global1.data[8];
								ptr -= 3;
							}
							else if (this.global1.regions[num49].buildings[num50].type == 22 && this.global1.regions[num49].buildings[num50].is_builded && this.global1.regions[num49].buildings[num50].is_working)
							{
								ptr = ref this.global1.data[3];
								ptr += 2;
								ptr = ref this.global1.data[4];
								ptr -= 2;
								ptr = ref this.global1.data[8];
								ref int ptr93 = ref ptr;
								num = ptr;
								ptr93 = num - 1;
							}
							else if (this.global1.regions[num49].buildings[num50].type == 24 && this.global1.regions[num49].buildings[num50].is_builded && this.global1.regions[num49].buildings[num50].is_working)
							{
								ptr = ref this.global1.data[9];
								ptr += 5;
								ptr = ref this.global1.data[3];
								ptr += 2;
								ptr = ref this.global1.data[1];
								ptr += 4;
							}
							else if (this.global1.regions[num49].buildings[num50].type == 23 && this.global1.regions[num49].buildings[num50].is_builded && this.global1.regions[num49].buildings[num50].is_working)
							{
								if (!this.global1.allcountries[7].Vyshi)
								{
									ptr = ref this.global1.data[9];
									ptr += 2;
									ptr = ref this.global1.data[10];
									ptr -= 4;
									ptr = ref this.global1.data[22];
									ptr -= 2;
								}
								else
								{
									ptr = ref this.global1.data[8];
									ref int ptr94 = ref ptr;
									num = ptr;
									ptr94 = num - 1;
								}
								ptr = ref this.global1.data[2];
								ptr += 4;
							}
							else if (this.global1.regions[num49].buildings[num50].type == 25 && this.global1.regions[num49].buildings[num50].is_builded && this.global1.regions[num49].buildings[num50].is_working)
							{
								ptr = ref this.global1.data[4];
								ptr++;
								ptr = ref this.global1.data[6];
								ptr--;
								ptr = ref this.global1.data[3];
								ptr--;
								ptr = ref this.global1.data[31];
								ptr++;
								ptr = ref this.global1.data[5];
								ptr++;
							}
							else if (this.global1.regions[num49].buildings[num50].type == 26 && this.global1.regions[num49].buildings[num50].is_builded && this.global1.regions[num49].buildings[num50].is_working)
							{
								ptr = ref this.global1.data[4];
								ptr++;
								if ((this.global1.data[118] == 1 && this.global1.data[0] == 51) || this.global1.data[120] == 1)
								{
									ptr = ref this.global1.data[3];
									ptr += 2;
								}
								else
								{
									ptr = ref this.global1.data[3];
									ptr--;
									ptr = ref this.global1.data[1];
									ptr--;
								}
							}
							else if (this.global1.regions[num49].buildings[num50].type == 27 && this.global1.regions[num49].buildings[num50].is_builded && this.global1.regions[num49].buildings[num50].is_working)
							{
								if (this.global1.data[118] == 1 && this.global1.data[0] == 51)
								{
									ptr = ref this.global1.data[3];
									ptr -= 2;
									ptr = ref this.global1.data[1];
									ptr -= 2;
									ptr = ref this.global1.data[9];
									ptr--;
								}
								else
								{
									ptr = ref this.global1.data[3];
									ptr++;
									ptr = ref this.global1.data[1];
									ptr++;
									ptr = ref this.global1.data[4];
									ptr--;
								}
								ptr = ref this.global1.data[31];
								ptr++;
							}
							else if (this.global1.regions[num49].buildings[num50].type == 28 && this.global1.regions[num49].buildings[num50].is_builded && this.global1.regions[num49].buildings[num50].is_working)
							{
								ptr = ref this.global1.data[4];
								ptr++;
								ptr = ref this.global1.data[6];
								ptr++;
								ptr = ref this.global1.data[3];
								ptr--;
							}
							else if (this.global1.regions[num49].buildings[num50].type == 29 && this.global1.regions[num49].buildings[num50].is_builded && this.global1.regions[num49].buildings[num50].is_working)
							{
								if (this.global1.data[140] >= 1)
								{
									ptr = ref this.global1.data[3];
									ptr -= 2;
									ptr = ref this.global1.data[4];
									ptr++;
									ptr = ref this.global1.data[9];
									ptr--;
								}
								else
								{
									ptr = ref this.global1.data[3];
									ptr += 2;
								}
							}
							else if (this.global1.regions[num49].buildings[num50].type == 30 && this.global1.regions[num49].buildings[num50].is_builded && this.global1.regions[num49].buildings[num50].is_working)
							{
								ptr = ref this.global1.data[8];
								ptr += 3;
								ptr = ref this.global1.data[5];
								ptr--;
							}
							else if (this.global1.regions[num49].buildings[num50].type == 31 && this.global1.regions[num49].buildings[num50].is_builded && this.global1.regions[num49].buildings[num50].is_working)
							{
								ptr = ref this.global1.data[5];
								ptr++;
								if (this.global1.data[141] >= 1)
								{
									ptr = ref this.global1.data[3];
									ptr -= 2;
									ptr = ref this.global1.data[4];
									ptr++;
									ptr = ref this.global1.data[9];
									ptr--;
								}
								else
								{
									ptr = ref this.global1.data[3];
									ptr++;
									ptr = ref this.global1.data[1];
									ptr++;
									ptr = ref this.global1.data[4];
									ptr--;
								}
							}
							else if (this.global1.regions[num49].buildings[num50].type == 32 && this.global1.regions[num49].buildings[num50].is_builded && this.global1.regions[num49].buildings[num50].is_working)
							{
								ptr = ref this.global1.data[9];
								ptr += 3;
								ptr = ref this.global1.data[4];
								ptr--;
								ptr = ref this.global1.data[8];
								ptr--;
							}
							else if (this.global1.regions[num49].buildings[num50].type == 33 && this.global1.regions[num49].buildings[num50].is_builded && this.global1.regions[num49].buildings[num50].is_working)
							{
								if (this.global1.data[148] == 1 && this.global1.data[0] == 49)
								{
									ptr = ref this.global1.data[1];
									ptr -= 2;
									ptr = ref this.global1.data[3];
									ptr--;
								}
								else
								{
									ptr = ref this.global1.data[1];
									ptr += 2;
									ptr = ref this.global1.data[3];
									ptr++;
								}
								ptr = ref this.global1.data[4];
								ptr--;
								ptr = ref this.global1.data[8];
								ptr++;
							}
							else if (this.global1.regions[num49].buildings[num50].type == 34 && this.global1.regions[num49].buildings[num50].is_builded && this.global1.regions[num49].buildings[num50].is_working)
							{
								ptr = ref this.global1.data[3];
								ptr += 2;
								ptr = ref this.global1.data[5];
								ptr++;
								if (this.global1.data[179] == 0)
								{
									ptr = ref this.global1.data[6];
									ptr++;
								}
							}
							else if (this.global1.regions[num49].buildings[num50].type == 35 && this.global1.regions[num49].buildings[num50].is_builded && this.global1.regions[num49].buildings[num50].is_working)
							{
								ptr = ref this.global1.data[3];
								ptr += 2;
								if (this.global1.data[115] <= 8)
								{
									ptr = ref this.global1.data[6];
									ptr++;
								}
								ptr = ref this.global1.data[31];
								ptr--;
							}
							else if (this.global1.regions[num49].buildings[num50].type == 36 && this.global1.regions[num49].buildings[num50].is_builded && this.global1.regions[num49].buildings[num50].is_working)
							{
								ptr = ref this.global1.data[3];
								ptr += 2;
								ptr = ref this.global1.data[4];
								ptr--;
								ptr = ref this.global1.data[31];
								ptr++;
							}
						}
						num = num50;
					}
					num = num49;
				}
				Debug.Log("BUILDINGSDONE");
				if (this.global1.data[31] > 700)
				{
					ptr = ref this.global1.data[4];
					ptr -= (this.global1.data[31] - 500) / 100;
					ptr = ref this.global1.data[1];
					ptr += (this.global1.data[31] - 500) / 100;
					ptr = ref this.global1.data[22];
					ptr += (this.global1.data[31] - 500) / 50;
					ptr = ref this.global1.data[2];
					ptr -= (this.global1.data[31] - 500) / 100;
					ptr = ref this.global1.data[10];
					ptr += (this.global1.data[31] - 500) / 100;
				}
				else if (this.global1.data[31] < 400)
				{
					ptr = ref this.global1.data[4];
					ptr += (500 - this.global1.data[31]) / 100;
					ptr = ref this.global1.data[1];
					ptr += (500 - this.global1.data[31]) / 100;
					ptr = ref this.global1.data[22];
					ptr -= (500 - this.global1.data[31]) / 50;
					ptr = ref this.global1.data[10];
					ptr -= (500 - this.global1.data[31]) / 100;
				}
				ptr = ref this.global1.data[2];
				ptr += this.global1.data[27];
				ptr = ref this.global1.data[3];
				ptr += this.global1.data[27];
				ptr = ref this.global1.data[4];
				ptr += this.global1.data[27];
				ptr = ref this.global1.data[8];
				ptr += this.global1.data[28];
				ptr = ref this.global1.data[4];
				ptr -= this.global1.data[29];
				if (this.global1.data[26] - this.global1.data[34] > 0)
				{
					if (this.global1.data[34] >= 0)
					{
						ptr = ref this.global1.data[26];
						ptr -= this.global1.data[34];
					}
					ptr = ref this.global1.data[8];
					ptr += this.global1.data[34];
				}
				else if (this.global1.data[26] > 0)
				{
					ptr = ref this.global1.data[8];
					ptr += this.global1.data[26];
					this.global1.data[26] = 0;
				}
				if (this.global1.data[25] < 4)
				{
					ptr = ref this.global1.data[4];
					ptr += -4 + this.global1.data[25];
					ptr = ref this.global1.data[22];
					ptr += 4 - this.global1.data[25];
					ptr = ref this.global1.data[5];
					ptr += -4 + this.global1.data[25];
					ptr = ref this.global1.data[9];
					ptr += -4 + this.global1.data[25];
				}
				else if (this.global1.data[25] > 8)
				{
					ptr = ref this.global1.data[4];
					ptr += this.global1.data[25] - 8;
					ptr = ref this.global1.data[22];
					ptr += 8 - this.global1.data[25];
					ptr = ref this.global1.data[5];
					ptr += this.global1.data[25] - 8;
				}
				ptr = ref this.global1.data[8];
				ptr += (this.global1.data[23] - this.global1.data[24]) / 2;
				ptr = ref this.global1.data[3];
				ptr += (this.global1.data[23] - this.global1.data[24]) / 3;
				if (this.global1.data[23] <= this.global1.data[24])
				{
					ptr = ref this.global1.data[5];
					ptr += (this.global1.data[23] - this.global1.data[24]) / 4;
				}
				if (this.global1.data[0] == 1)
				{
					if (this.global1.data[11] == 0)
					{
						if (this.global1.data[14] < 3)
						{
							if (this.global1.data[33] < 900)
							{
								ptr = ref this.global1.data[33];
								ptr += 2;
							}
							else
							{
								ptr = ref this.global1.data[33];
								ref int ptr95 = ref ptr;
								num = ptr;
								ptr95 = num - 1;
							}
						}
						ptr = ref this.global1.data[4];
						ref int ptr96 = ref ptr;
						num = ptr;
						ptr96 = num + 1;
						ptr = ref this.global1.data[1];
						ref int ptr97 = ref ptr;
						num = ptr;
						ptr97 = num + 1;
						ptr = ref this.global1.data[2];
						ptr -= 2;
						if (this.global1.data[6] < 900)
						{
							ptr = ref this.global1.data[6];
							ref int ptr98 = ref ptr;
							num = ptr;
							ptr98 = num + 1;
						}
						ptr = ref this.global1.data[10];
						ref int ptr99 = ref ptr;
						num = ptr;
						ptr99 = num + 1;
						if (this.global1.data[31] > 500)
						{
							ptr = ref this.global1.data[31];
							ref int ptr100 = ref ptr;
							num = ptr;
							ptr100 = num - 1;
						}
					}
					else if (this.global1.data[11] == 1)
					{
						if (this.global1.data[33] < 900)
						{
							ptr = ref this.global1.data[33];
							ptr += 2;
						}
						else
						{
							ptr = ref this.global1.data[33];
							ref int ptr101 = ref ptr;
							num = ptr;
							ptr101 = num + 1;
						}
						ptr = ref this.global1.data[9];
						ref int ptr102 = ref ptr;
						num = ptr;
						ptr102 = num + 1;
						ptr = ref this.global1.data[2];
						ptr -= 12;
						ptr = ref this.global1.data[1];
						ptr -= 8;
						ptr = ref this.global1.data[4];
						ptr -= 8;
						ptr = ref this.global1.data[3];
						ptr -= 4;
						if (this.global1.data[31] < 650)
						{
							ptr = ref this.global1.data[31];
							ref int ptr103 = ref ptr;
							num = ptr;
							ptr103 = num + 1;
						}
					}
					else if (this.global1.data[11] == 2)
					{
						if (this.global1.data[33] > 600)
						{
							ptr = ref this.global1.data[33];
							ptr -= 2;
						}
						else
						{
							ptr = ref this.global1.data[33];
							ref int ptr104 = ref ptr;
							num = ptr;
							ptr104 = num + 1;
						}
						ptr = ref this.global1.data[2];
						ptr += 4;
						ptr = ref this.global1.data[3];
						ptr += 2;
						ptr = ref this.global1.data[4];
						ptr += 4;
						ptr = ref this.global1.data[1];
						ptr -= 10;
						if (this.global1.data[31] > 300)
						{
							ptr = ref this.global1.data[31];
							ref int ptr105 = ref ptr;
							num = ptr;
							ptr105 = num - 1;
						}
					}
					else if (this.global1.data[11] == 3)
					{
						if (this.global1.data[33] > 600)
						{
							ptr = ref this.global1.data[33];
							ptr -= 4;
						}
						else
						{
							ptr = ref this.global1.data[33];
							ptr -= 2;
						}
						ptr = ref this.global1.data[2];
						ptr += 6;
						ptr = ref this.global1.data[3];
						ptr += 6;
						ptr = ref this.global1.data[1];
						ptr += 6;
						ptr = ref this.global1.data[4];
						ptr += 12;
						ptr = ref this.global1.data[10];
						ref int ptr106 = ref ptr;
						num = ptr;
						ptr106 = num - 1;
						ptr = ref this.global1.data[31];
						ref int ptr107 = ref ptr;
						num = ptr;
						ptr107 = num - 1;
						if (this.global1.data[6] >= 400 && this.global1.data[21] <= 1991)
						{
							ptr = ref this.global1.data[6];
							ref int ptr108 = ref ptr;
							num = ptr;
							ptr108 = num - 1;
						}
					}
					if (this.global1.data[12] == 4)
					{
						if (this.global1.data[11] > 1)
						{
							ptr = ref this.global1.data[33];
							ptr += 2;
						}
						ptr = ref this.global1.data[4];
						ptr += 4;
						ptr = ref this.global1.data[1];
						ptr += 4;
						ptr = ref this.global1.data[2];
						ptr -= 4;
						if (this.global1.data[22] < 700)
						{
							ptr = ref this.global1.data[22];
							ptr += 2;
						}
						ptr = ref this.global1.data[8];
						ptr += 2;
						ptr = ref this.global1.data[5];
						ref int ptr109 = ref ptr;
						num = ptr;
						ptr109 = num - 1;
						ptr = ref this.global1.data[9];
						ref int ptr110 = ref ptr;
						num = ptr;
						ptr110 = num + 1;
						ptr = ref this.global1.data[3];
						ptr -= 4;
					}
					else if (this.global1.data[12] == 5)
					{
						if (this.global1.data[33] > 600)
						{
							ptr = ref this.global1.data[33];
							ptr -= 2;
						}
						else
						{
							ptr = ref this.global1.data[33];
							ref int ptr111 = ref ptr;
							num = ptr;
							ptr111 = num + 1;
						}
						if (this.global1.data[5] < 650)
						{
							ptr = ref this.global1.data[5];
							ref int ptr112 = ref ptr;
							num = ptr;
							ptr112 = num + 1;
						}
						ptr = ref this.global1.data[2];
						ptr -= 2;
						ptr = ref this.global1.data[4];
						ptr += 4;
						ptr = ref this.global1.data[8];
						ref int ptr113 = ref ptr;
						num = ptr;
						ptr113 = num + 1;
					}
					else if (this.global1.data[12] == 6)
					{
						if (this.global1.data[33] > 600)
						{
							ptr = ref this.global1.data[33];
							ptr -= 4;
						}
						else
						{
							ptr = ref this.global1.data[33];
							ptr -= 2;
						}
						ptr = ref this.global1.data[2];
						ptr += 4;
						ptr = ref this.global1.data[3];
						ptr += 4;
						ptr = ref this.global1.data[4];
						ptr += 12;
						ptr = ref this.global1.data[10];
						ref int ptr114 = ref ptr;
						num = ptr;
						ptr114 = num - 1;
						ptr = ref this.global1.data[31];
						ref int ptr115 = ref ptr;
						num = ptr;
						ptr115 = num - 1;
						if (this.global1.data[6] >= 400 && this.global1.data[21] <= 1991)
						{
							ptr = ref this.global1.data[6];
							ref int ptr116 = ref ptr;
							num = ptr;
							ptr116 = num - 1;
						}
					}
					if (this.global1.data[13] == 7)
					{
						if (this.global1.data[11] > 1)
						{
							ptr = ref this.global1.data[33];
							ptr += 2;
						}
						ptr = ref this.global1.data[4];
						ptr += 4;
						ptr = ref this.global1.data[1];
						ptr += 8;
						ptr = ref this.global1.data[2];
						ptr -= 2;
						if (this.global1.data[22] < 700)
						{
							ptr = ref this.global1.data[22];
							ptr += 4;
						}
						ptr = ref this.global1.data[5];
						ref int ptr117 = ref ptr;
						num = ptr;
						ptr117 = num - 1;
						ptr = ref this.global1.data[9];
						ref int ptr118 = ref ptr;
						num = ptr;
						ptr118 = num + 1;
						if (this.global1.data[31] < 650)
						{
							ptr = ref this.global1.data[31];
							ref int ptr119 = ref ptr;
							num = ptr;
							ptr119 = num + 1;
						}
						ptr = ref this.global1.data[3];
						ptr -= 4;
					}
					else if (this.global1.data[13] == 8)
					{
						if (!this.global1.science[4] && this.global1.data[5] < 500)
						{
							ptr = ref this.global1.data[5];
							ref int ptr120 = ref ptr;
							num = ptr;
							ptr120 = num + 1;
						}
						else if (!this.global1.science[5] && this.global1.data[5] < 600)
						{
							ptr = ref this.global1.data[5];
							ref int ptr121 = ref ptr;
							num = ptr;
							ptr121 = num + 1;
						}
						else if (this.global1.data[5] < 700)
						{
							ptr = ref this.global1.data[5];
							ref int ptr122 = ref ptr;
							num = ptr;
							ptr122 = num + 1;
						}
						ptr = ref this.global1.data[2];
						ptr -= 2;
						ptr = ref this.global1.data[1];
						ptr -= 12;
						ptr = ref this.global1.data[8];
						ptr += 1 + this.global1.data[43];
						ptr = ref this.global1.data[4];
						ptr -= 2;
					}
					else if (this.global1.data[13] == 9)
					{
						if (this.global1.data[33] > 500)
						{
							ptr = ref this.global1.data[33];
							ref int ptr123 = ref ptr;
							num = ptr;
							ptr123 = num - 1;
						}
						else if (this.global1.data[33] > 400)
						{
							ptr = ref this.global1.data[33];
							ptr -= 2;
						}
						ptr = ref this.global1.data[2];
						ptr += 3;
						ptr = ref this.global1.data[10];
						ptr -= 2;
						ptr = ref this.global1.data[1];
						ptr += 2;
						ptr = ref this.global1.data[3];
						ptr -= 2;
						ptr = ref this.global1.data[4];
						ptr += 2;
					}
				}
				else if (this.global1.data[0] == 12)
				{
					this.global1.data[10] = -1000;
					if (!this.global1.event_done[230])
					{
						this.global1.is_elect = true;
					}
					if (this.global1.data[90] != 1)
					{
						ptr = ref this.global1.data[5];
						ptr -= 2;
						ptr = ref this.global1.data[4];
						ref int ptr124 = ref ptr;
						num = ptr;
						ptr124 = num + 1;
						ptr = ref this.global1.data[3];
						ref int ptr125 = ref ptr;
						num = ptr;
						ptr125 = num - 1;
					}
					if (this.global1.data[93] != 1)
					{
						ptr = ref this.global1.data[8];
						ptr -= 2;
						ptr = ref this.global1.data[4];
						ref int ptr126 = ref ptr;
						num = ptr;
						ptr126 = num + 1;
						ptr = ref this.global1.data[3];
						ref int ptr127 = ref ptr;
						num = ptr;
						ptr127 = num - 1;
					}
					if (this.global1.data[92] != 1)
					{
						ptr = ref this.global1.data[9];
						ptr -= 2;
						ptr = ref this.global1.data[3];
						ref int ptr128 = ref ptr;
						num = ptr;
						ptr128 = num + 1;
						ptr = ref this.global1.data[4];
						ref int ptr129 = ref ptr;
						num = ptr;
						ptr129 = num - 1;
					}
					if (this.global1.data[94] != 1)
					{
						ptr = ref this.global1.data[8];
						ref int ptr130 = ref ptr;
						num = ptr;
						ptr130 = num - 1;
						ptr = ref this.global1.data[4];
						ref int ptr131 = ref ptr;
						num = ptr;
						ptr131 = num + 1;
						ptr = ref this.global1.data[3];
						ref int ptr132 = ref ptr;
						num = ptr;
						ptr132 = num - 1;
					}
					if (this.global1.data[88] > 0)
					{
						if (this.global1.data[81] == 1)
						{
							ptr = ref this.global1.data[108];
							ptr -= 7;
						}
						else if (this.global1.data[81] != 1)
						{
							ptr = ref this.global1.data[108];
							ptr -= 5;
						}
						if (this.global1.data[107] == 1)
						{
							ptr = ref this.global1.data[108];
							ref int ptr133 = ref ptr;
							num = ptr;
							ptr133 = num - 1;
						}
						else if (this.global1.data[107] == 3)
						{
							ptr = ref this.global1.data[108];
							ref int ptr134 = ref ptr;
							num = ptr;
							ptr134 = num + 1;
						}
					}
					if (this.global1.data[91] == 1)
					{
						ptr = ref this.global1.data[1];
						ptr -= 10;
					}
					if (this.global1.allcountries[7].Vyshi)
					{
						ptr = ref this.global1.data[5];
						ptr -= this.global1.data[5] / 100;
						ptr = ref this.global1.data[4];
						ptr += 6;
					}
					else if (this.global1.data[5] < 100)
					{
						ptr = ref this.global1.data[5];
						ptr += 10;
					}
					else if (this.global1.data[5] < 200)
					{
						ptr = ref this.global1.data[5];
						ptr += 5;
					}
					if (this.global1.data[11] == 0)
					{
						ptr = ref this.global1.data[9];
						ptr += 2;
						ptr = ref this.global1.data[1];
						ptr += 3;
						ptr = ref this.global1.data[4];
						ptr += 2;
						ptr = ref this.global1.data[3];
						ptr += 3;
						ptr = ref this.global1.data[2];
						ptr -= 2;
					}
					else if (this.global1.data[11] == 1)
					{
						ptr = ref this.global1.data[9];
						ptr += 2;
						ptr = ref this.global1.data[1];
						ptr -= 4;
						ptr = ref this.global1.data[4];
						ptr -= 4;
						ptr = ref this.global1.data[6];
						ptr += 2;
						ptr = ref this.global1.data[2];
						ptr -= 4;
					}
					else if (this.global1.data[11] == 2)
					{
						ptr = ref this.global1.data[1];
						ptr += 3;
						ptr = ref this.global1.data[3];
						ptr += 3;
						ptr = ref this.global1.data[4];
						ptr -= 2;
					}
					else if (this.global1.data[11] == 3)
					{
						ptr = ref this.global1.data[3];
						ref int ptr135 = ref ptr;
						num = ptr;
						ptr135 = num + 1;
						ptr = ref this.global1.data[2];
						ptr += 4;
						if (this.global1.data[6] > 400)
						{
							ptr = ref this.global1.data[6];
							ptr -= 2;
						}
					}
					if (this.global1.data[12] == 4)
					{
						ptr = ref this.global1.data[1];
						ptr -= 5;
						ptr = ref this.global1.data[4];
						ptr -= 3;
					}
					else if (this.global1.data[12] == 5)
					{
						ptr = ref this.global1.data[5];
						ptr += 2;
					}
					else if (this.global1.data[12] == 6)
					{
						ptr = ref this.global1.data[1];
						ptr += 3;
						ptr = ref this.global1.data[4];
						ptr += 3;
						ptr = ref this.global1.data[9];
						ptr += 2;
					}
					if (this.global1.data[13] == 7)
					{
						ptr = ref this.global1.data[1];
						ptr += 6;
						ptr = ref this.global1.data[4];
						ptr += 2;
					}
					else if (this.global1.data[13] == 8)
					{
						ptr = ref this.global1.data[9];
						ptr += 2;
						ptr = ref this.global1.data[4];
						ptr += 5;
						ptr = ref this.global1.data[1];
						ptr += 3;
					}
					else if (this.global1.data[13] == 9)
					{
						ptr = ref this.global1.data[1];
						ptr -= 5;
						ptr = ref this.global1.data[4];
						ptr -= 3;
						ptr = ref this.global1.data[3];
						ptr += 4;
					}
					if (this.global1.data[80] - 20 < 80)
					{
						int num51 = (80 - (this.global1.data[80] - 20)) / 20;
						if (this.global1.data[1] > 1000 - num51 * 100)
						{
							this.global1.data[1] = 1000 - num51 * 100;
						}
						if (this.global1.data[3] > 1000 - num51 * 100)
						{
							this.global1.data[3] = 1000 - num51 * 100;
						}
						if (this.global1.data[5] > 1000 - num51 * 100)
						{
							this.global1.data[5] = 1000 - num51 * 100;
						}
						if (this.global1.data[4] < num51 * 150)
						{
							this.global1.data[4] = num51 * 150;
						}
					}
				}
				else if (this.global1.data[0] == 5)
				{
					if (this.global1.data[11] == 0)
					{
						if (this.global1.data[14] <= 3)
						{
							if (this.global1.data[33] < 1000)
							{
								ptr = ref this.global1.data[33];
								ptr += 2;
							}
						}
						else if (this.global1.data[33] < 900)
						{
							ptr = ref this.global1.data[33];
							ref int ptr136 = ref ptr;
							num = ptr;
							ptr136 = num + 1;
						}
						ptr = ref this.global1.data[4];
						ptr += 2;
						ptr = ref this.global1.data[1];
						ptr += 5;
						ptr = ref this.global1.data[2];
						ptr -= 2;
						if (this.global1.data[6] < 900)
						{
							ptr = ref this.global1.data[6];
							ref int ptr137 = ref ptr;
							num = ptr;
							ptr137 = num + 1;
						}
						ptr = ref this.global1.data[10];
						ref int ptr138 = ref ptr;
						num = ptr;
						ptr138 = num + 1;
						if (this.global1.data[31] > 700)
						{
							ptr = ref this.global1.data[31];
							ref int ptr139 = ref ptr;
							num = ptr;
							ptr139 = num - 1;
						}
						else if (this.global1.data[31] < 700)
						{
							ptr = ref this.global1.data[31];
							ref int ptr140 = ref ptr;
							num = ptr;
							ptr140 = num + 1;
						}
						ptr = ref this.global1.data[9];
						ref int ptr141 = ref ptr;
						num = ptr;
						ptr141 = num + 1;
						ptr = ref this.global1.data[3];
						ptr += 2;
					}
					else if (this.global1.data[11] == 1)
					{
						if (this.global1.data[33] < 900)
						{
							ptr = ref this.global1.data[33];
							ptr += 2;
						}
						ptr = ref this.global1.data[9];
						ref int ptr142 = ref ptr;
						num = ptr;
						ptr142 = num + 1;
						ptr = ref this.global1.data[2];
						ptr -= 2;
						ptr = ref this.global1.data[4];
						ptr -= 2;
						ptr = ref this.global1.data[3];
						ptr -= 6;
						if (this.global1.data[31] < 600)
						{
							ptr = ref this.global1.data[31];
							ref int ptr143 = ref ptr;
							num = ptr;
							ptr143 = num + 1;
						}
					}
					else if (this.global1.data[11] == 2)
					{
						if (this.global1.data[33] > 800)
						{
							ptr = ref this.global1.data[33];
							ref int ptr144 = ref ptr;
							num = ptr;
							ptr144 = num - 1;
						}
						else
						{
							ptr = ref this.global1.data[33];
							ref int ptr145 = ref ptr;
							num = ptr;
							ptr145 = num + 1;
						}
						ptr = ref this.global1.data[2];
						ptr += 2;
						ptr = ref this.global1.data[4];
						ptr += 4;
						ptr = ref this.global1.data[1];
						ptr -= 5;
						if (this.global1.data[31] > 500)
						{
							ptr = ref this.global1.data[31];
							ref int ptr146 = ref ptr;
							num = ptr;
							ptr146 = num - 1;
						}
						ptr = ref this.global1.data[8];
						ptr += 2;
					}
					else if (this.global1.data[11] == 3)
					{
						ptr = ref this.global1.data[2];
						ptr += 6;
						ptr = ref this.global1.data[3];
						ptr += 5;
						ptr = ref this.global1.data[1];
						ptr -= 10;
						ptr = ref this.global1.data[4];
						ptr += 10;
						ptr = ref this.global1.data[10];
						ref int ptr147 = ref ptr;
						num = ptr;
						ptr147 = num - 1;
						ptr = ref this.global1.data[31];
						ref int ptr148 = ref ptr;
						num = ptr;
						ptr148 = num - 1;
						if (this.global1.data[6] >= 600 && this.global1.data[21] <= 1991)
						{
							ptr = ref this.global1.data[6];
							ref int ptr149 = ref ptr;
							num = ptr;
							ptr149 = num - 1;
						}
						ptr = ref this.global1.data[9];
						ref int ptr150 = ref ptr;
						num = ptr;
						ptr150 = num + 1;
					}
					if (this.global1.data[12] == 4)
					{
						ptr = ref this.global1.data[1];
						ptr += 5;
						ptr = ref this.global1.data[4];
						ref int ptr151 = ref ptr;
						num = ptr;
						ptr151 = num - 1;
						if (this.global1.data[11] == 0 && this.global1.data[21] <= 1989)
						{
							ptr = ref this.global1.data[3];
							ref int ptr152 = ref ptr;
							num = ptr;
							ptr152 = num + 1;
						}
						else
						{
							ptr = ref this.global1.data[3];
							ref int ptr153 = ref ptr;
							num = ptr;
							ptr153 = num - 1;
						}
						ptr = ref this.global1.data[8];
						ref int ptr154 = ref ptr;
						num = ptr;
						ptr154 = num - 1;
						if (this.global1.data[22] < 700)
						{
							ptr = ref this.global1.data[22];
							ref int ptr155 = ref ptr;
							num = ptr;
							ptr155 = num + 1;
						}
					}
					else if (this.global1.data[12] == 5)
					{
						ptr = ref this.global1.data[1];
						ptr -= 2;
						ptr = ref this.global1.data[3];
						ptr -= 5;
						ptr = ref this.global1.data[4];
						ptr -= 5;
						ptr = ref this.global1.data[9];
						ptr += 2;
						ptr = ref this.global1.data[8];
						ref int ptr156 = ref ptr;
						num = ptr;
						ptr156 = num - 1;
						ptr = ref this.global1.data[2];
						ptr -= 2;
					}
					else if (this.global1.data[12] == 6)
					{
						ptr = ref this.global1.data[22];
						ptr += 2;
						ptr = ref this.global1.data[2];
						ptr -= 4;
						ptr = ref this.global1.data[3];
						ptr += 2;
						ptr = ref this.global1.data[4];
						ptr += 2;
						ptr = ref this.global1.data[5];
						ref int ptr157 = ref ptr;
						num = ptr;
						ptr157 = num + 1;
						if (this.global1.data[6] > 800 && this.global1.data[21] <= 1991)
						{
							ptr = ref this.global1.data[6];
							ref int ptr158 = ref ptr;
							num = ptr;
							ptr158 = num - 1;
						}
						ptr = ref this.global1.data[10];
						ref int ptr159 = ref ptr;
						num = ptr;
						ptr159 = num + 1;
						if (this.global1.data[31] > 650)
						{
							ptr = ref this.global1.data[31];
							ref int ptr160 = ref ptr;
							num = ptr;
							ptr160 = num - 1;
						}
						ptr = ref this.global1.data[8];
						ptr += 2;
					}
					if (this.global1.data[13] == 7)
					{
						ptr = ref this.global1.data[1];
						ptr += 3;
						ptr = ref this.global1.data[4];
						ref int ptr161 = ref ptr;
						num = ptr;
						ptr161 = num + 1;
						if (this.global1.data[11] == 0 && this.global1.data[21] <= 1989)
						{
							ptr = ref this.global1.data[3];
							ptr += 3;
						}
						else
						{
							ptr = ref this.global1.data[3];
							ref int ptr162 = ref ptr;
							num = ptr;
							ptr162 = num + 1;
						}
						ptr = ref this.global1.data[8];
						ref int ptr163 = ref ptr;
						num = ptr;
						ptr163 = num - 1;
						if (this.global1.data[22] < 700)
						{
							ptr = ref this.global1.data[22];
							ref int ptr164 = ref ptr;
							num = ptr;
							ptr164 = num + 1;
						}
						ptr = ref this.global1.data[5];
						ref int ptr165 = ref ptr;
						num = ptr;
						ptr165 = num - 1;
						ptr = ref this.global1.data[9];
						ref int ptr166 = ref ptr;
						num = ptr;
						ptr166 = num + 1;
					}
					else if (this.global1.data[13] == 8)
					{
						if (this.global1.data[14] == 0 || this.global1.allcountries[this.global1.data[0]].Vyshi || (!this.global1.allcountries[this.global1.data[0]].isSEV && !this.global1.allcountries[this.global1.data[0]].isOVD))
						{
							ptr = ref this.global1.data[1];
							ptr -= 10;
						}
						else
						{
							ptr = ref this.global1.data[1];
							ptr += 2;
						}
						ptr = ref this.global1.data[2];
						ptr += 10;
						ptr = ref this.global1.data[3];
						ptr += 2;
						ptr = ref this.global1.data[4];
						ptr += 5;
						ptr = ref this.global1.data[9];
						ref int ptr167 = ref ptr;
						num = ptr;
						ptr167 = num - 1;
						ptr = ref this.global1.data[10];
						ptr -= 2;
						ptr = ref this.global1.data[5];
						ref int ptr168 = ref ptr;
						num = ptr;
						ptr168 = num + 1;
					}
					else if (this.global1.data[13] == 9)
					{
						if (this.global1.data[14] == 0 || this.global1.data[33] < 800 || this.global1.data[14] > 3 || this.global1.data[16] == 13 || this.global1.allcountries[this.global1.data[0]].Vyshi)
						{
							ptr = ref this.global1.data[1];
							ptr -= 10;
						}
						else
						{
							ptr = ref this.global1.data[1];
							ptr += 2;
						}
						ptr = ref this.global1.data[3];
						ref int ptr169 = ref ptr;
						num = ptr;
						ptr169 = num + 1;
						ptr = ref this.global1.data[4];
						ptr -= 2;
						ptr = ref this.global1.data[9];
						ptr += 2;
						ptr = ref this.global1.data[10];
						ptr += 2;
					}
				}
				else if (this.global1.data[0] == 18)
				{
					if (this.global1.data[102] > 0)
					{
						if (this.global1.data[8] - array[8] >= (this.global1.data[102] - 1) * 2)
						{
							ptr = ref this.global1.data[8];
							ptr -= this.global1.data[102];
						}
						else if (this.global1.data[8] - array[8] > 0)
						{
							ptr = ref this.global1.data[8];
							ptr -= this.global1.data[8] - array[8] - (this.global1.data[102] - 1);
						}
						else
						{
							ptr = ref this.global1.data[8];
							ptr += this.global1.data[102] - 1;
						}
						if (this.global1.data[5] > 400 - this.global1.data[102] * 20)
						{
							ptr = ref this.global1.data[5];
							ptr -= this.global1.data[102];
						}
						if (this.global1.allcountries[this.global1.data[0]].isSEV || this.global1.allcountries[7].isSEV)
						{
							ptr = ref this.global1.data[4];
							ptr += this.global1.data[102] / 2;
							ptr = ref this.global1.data[3];
							ptr -= this.global1.data[102] / 2;
						}
						if (!this.global1.allcountries[this.global1.data[0]].isSEV && !this.global1.allcountries[7].isSEV && !this.global1.allcountries[this.global1.data[0]].Vyshi)
						{
							ptr = ref this.global1.data[8];
							ptr += this.global1.data[102] * 2;
						}
					}
					if (this.global1.data[77] > 0)
					{
						ptr = ref this.global1.data[22];
						ptr += 2;
						ptr = ref this.global1.data[8];
						ptr -= this.global1.data[77];
						ptr = ref this.global1.data[3];
						ptr += this.global1.data[77];
						ptr = ref this.global1.data[10];
						ptr += this.global1.data[77] / 2;
					}
					if (this.global1.data[11] != 0)
					{
						if (this.global1.data[11] == 1)
						{
							ptr = ref this.global1.data[3];
							ptr += 2;
							ptr = ref this.global1.data[1];
							ptr += 4;
							ptr = ref this.global1.data[4];
							ptr += 3;
							ptr = ref this.global1.data[9];
							ref int ptr170 = ref ptr;
							num = ptr;
							ptr170 = num + 1;
						}
						else if (this.global1.data[11] == 2)
						{
							ptr = ref this.global1.data[3];
							ptr += 4;
							if (this.global1.data[3] - array[3] > 0)
							{
								ptr = ref this.global1.data[3];
								ptr += 3;
							}
							if (this.global1.event_done[218])
							{
								ptr = ref this.global1.data[3];
								ptr += (500 - this.global1.data[3]) / 100 * 3;
							}
							ptr = ref this.global1.data[4];
							ptr -= 2;
							ptr = ref this.global1.data[1];
							ptr += 7;
							ptr = ref this.global1.data[4];
							ptr += 2;
							ptr = ref this.global1.data[10];
							ref int ptr171 = ref ptr;
							num = ptr;
							ptr171 = num + 1;
						}
						else if (this.global1.data[11] == 3)
						{
							ptr = ref this.global1.data[3];
							ptr += 2;
							ptr = ref this.global1.data[1];
							ptr -= 3;
							ptr = ref this.global1.data[4];
							ptr += 2;
							ptr = ref this.global1.data[2];
							ptr += 4;
						}
					}
					if (this.global1.data[12] == 4)
					{
						ptr = ref this.global1.data[8];
						ptr += 2;
						if (this.global1.data[16] < 12)
						{
							ptr = ref this.global1.data[8];
							ptr += 2;
						}
						ptr = ref this.global1.data[1];
						ref int ptr172 = ref ptr;
						num = ptr;
						ptr172 = num + 1;
						ptr = ref this.global1.data[3];
						ptr -= 3;
						ptr = ref this.global1.data[4];
						ptr += 2;
					}
					else if (this.global1.data[12] == 5)
					{
						ptr = ref this.global1.data[8];
						ptr -= 2;
						ptr = ref this.global1.data[1];
						ptr -= 3;
						ptr = ref this.global1.data[5];
						ptr += 4;
						ptr = ref this.global1.data[3];
						ptr += 3;
						ptr = ref this.global1.data[4];
						ptr += 2;
					}
					else if (this.global1.data[12] == 6)
					{
						ptr = ref this.global1.data[2];
						ptr += 2;
						ptr = ref this.global1.data[4];
						ptr += 4;
						ptr = ref this.global1.data[3];
						ptr += 6;
						ptr = ref this.global1.data[1];
						ptr -= 3;
					}
					if (this.global1.data[13] == 7)
					{
						ptr = ref this.global1.data[9];
						ptr += 2;
						ptr = ref this.global1.data[10];
						ptr += 2;
						ptr = ref this.global1.data[4];
						ptr -= 2;
						ptr = ref this.global1.data[3];
						ptr -= 5;
					}
					else if (this.global1.data[13] == 8)
					{
						ptr = ref this.global1.data[1];
						ptr += 2;
						ptr = ref this.global1.data[2];
						ptr += 2;
						ptr = ref this.global1.data[4];
						ref int ptr173 = ref ptr;
						num = ptr;
						ptr173 = num - 1;
						ptr = ref this.global1.data[10];
						ptr += 3;
					}
					else if (this.global1.data[13] == 9)
					{
						ptr = ref this.global1.data[1];
						ptr -= 6;
						if (this.global1.data[16] < 12 && this.global1.data[102] > 0)
						{
							ptr = ref this.global1.data[8];
							ptr += 2;
						}
					}
				}
				else if (this.global1.data[0] == 10)
				{
					if (this.global1.data[11] == 0)
					{
						ptr = ref this.global1.data[3];
						ptr += 5;
						ptr = ref this.global1.data[1];
						ptr += 5;
						ptr = ref this.global1.data[31];
						ref int ptr174 = ref ptr;
						num = ptr;
						ptr174 = num + 1;
						ptr = ref this.global1.data[22];
						ref int ptr175 = ref ptr;
						num = ptr;
						ptr175 = num + 1;
						if (this.global1.data[21] >= 1991)
						{
							ptr = ref this.global1.data[3];
							ptr += 4;
						}
					}
					else if (this.global1.data[11] == 1)
					{
						ptr = ref this.global1.data[9];
						ptr += 2;
						ptr = ref this.global1.data[3];
						ptr -= 3;
						ptr = ref this.global1.data[1];
						ptr -= 4;
						ptr = ref this.global1.data[6];
						ptr += 2;
						if (this.global1.data[31] < 700)
						{
							ptr = ref this.global1.data[31];
							ref int ptr176 = ref ptr;
							num = ptr;
							ptr176 = num + 1;
						}
						ptr = ref this.global1.data[22];
						ref int ptr177 = ref ptr;
						num = ptr;
						ptr177 = num + 1;
					}
					else if (this.global1.data[11] == 2)
					{
						ptr = ref this.global1.data[3];
						ptr += 5;
						ptr = ref this.global1.data[1];
						ptr += 3;
						if (this.global1.data[31] < 700)
						{
							ptr = ref this.global1.data[31];
							ref int ptr178 = ref ptr;
							num = ptr;
							ptr178 = num + 1;
						}
						ptr = ref this.global1.data[22];
						ref int ptr179 = ref ptr;
						num = ptr;
						ptr179 = num + 1;
					}
					else if (this.global1.data[11] == 3)
					{
						ptr = ref this.global1.data[3];
						ptr += 5;
						ptr = ref this.global1.data[4];
						ptr += 3;
						ptr = ref this.global1.data[1];
						ptr -= 4;
						if (this.global1.data[22] > 300)
						{
							ptr = ref this.global1.data[22];
							ref int ptr180 = ref ptr;
							num = ptr;
							ptr180 = num - 1;
						}
					}
					if (this.global1.data[12] == 4)
					{
						ptr = ref this.global1.data[5];
						ref int ptr181 = ref ptr;
						num = ptr;
						ptr181 = num + 1;
						ptr = ref this.global1.data[4];
						ptr += 3;
					}
					else if (this.global1.data[12] == 5)
					{
						ptr = ref this.global1.data[10];
						ptr -= 5;
						ptr = ref this.global1.data[1];
						ptr -= 3;
						ptr = ref this.global1.data[2];
						ref int ptr182 = ref ptr;
						num = ptr;
						ptr182 = num + 1;
						ptr = ref this.global1.data[22];
						ref int ptr183 = ref ptr;
						num = ptr;
						ptr183 = num - 1;
						if (this.global1.data[6] > 700)
						{
							ptr = ref this.global1.data[6];
							ref int ptr184 = ref ptr;
							num = ptr;
							ptr184 = num - 1;
						}
					}
					else if (this.global1.data[12] == 6)
					{
						ptr = ref this.global1.data[1];
						ptr -= 5;
						ptr = ref this.global1.data[8];
						ptr += 2;
						ptr = ref this.global1.data[4];
						ptr += 3;
					}
					if (this.global1.data[13] == 7)
					{
						ptr = ref this.global1.data[4];
						ptr -= 5;
						ptr = ref this.global1.data[3];
						ptr += 4;
						ptr = ref this.global1.data[10];
						ref int ptr185 = ref ptr;
						num = ptr;
						ptr185 = num + 1;
						ptr = ref this.global1.data[2];
						ref int ptr186 = ref ptr;
						num = ptr;
						ptr186 = num - 1;
					}
					else if (this.global1.data[13] == 8)
					{
						ptr = ref this.global1.data[10];
						ptr += 3;
						ptr = ref this.global1.data[9];
						ptr += 2;
						ptr = ref this.global1.data[6];
						ptr += 2;
						ptr = ref this.global1.data[4];
						ptr -= 3;
					}
					else if (this.global1.data[13] == 9)
					{
						ptr = ref this.global1.data[1];
						ptr += 8;
						ptr = ref this.global1.data[3];
						ref int ptr187 = ref ptr;
						num = ptr;
						ptr187 = num - 1;
						ptr = ref this.global1.data[4];
						ptr += 6;
					}
				}
				else if (this.global1.data[0] == 6)
				{
					if (this.global1.data[11] == 0)
					{
						if (this.global1.data[14] < 3 && this.global1.data[33] < 850)
						{
							ptr = ref this.global1.data[33];
							ptr += 2;
						}
						ptr = ref this.global1.data[1];
						ptr -= this.global1.data[1] / 100;
						ptr = ref this.global1.data[2];
						ptr -= 2;
						if (this.global1.data[4] > 300)
						{
							ptr = ref this.global1.data[4];
							ptr -= 7;
						}
						if (this.global1.data[3] < 900)
						{
							ptr = ref this.global1.data[3];
							ptr += 7;
						}
						if (this.global1.data[6] < 900)
						{
							ptr = ref this.global1.data[6];
							ref int ptr188 = ref ptr;
							num = ptr;
							ptr188 = num + 1;
						}
						if (this.global1.data[31] > 600)
						{
							ptr = ref this.global1.data[31];
							ref int ptr189 = ref ptr;
							num = ptr;
							ptr189 = num - 1;
						}
						else if (this.global1.data[31] < 500)
						{
							ptr = ref this.global1.data[31];
							ref int ptr190 = ref ptr;
							num = ptr;
							ptr190 = num + 1;
						}
						ptr = ref this.global1.data[9];
						ptr += 2;
						ptr = ref this.global1.data[8];
						ptr -= 2;
					}
					else if (this.global1.data[11] == 1)
					{
						if (this.global1.data[33] < 900)
						{
							ptr = ref this.global1.data[33];
							ptr += 2;
						}
						ptr = ref this.global1.data[9];
						ref int ptr191 = ref ptr;
						num = ptr;
						ptr191 = num + 1;
						ptr = ref this.global1.data[2];
						ptr -= 4;
						ptr = ref this.global1.data[4];
						ptr -= 2;
						ptr = ref this.global1.data[3];
						ptr -= 6;
						ptr = ref this.global1.data[10];
						ref int ptr192 = ref ptr;
						num = ptr;
						ptr192 = num + 1;
						if (this.global1.data[31] < 700)
						{
							ptr = ref this.global1.data[31];
							ref int ptr193 = ref ptr;
							num = ptr;
							ptr193 = num + 1;
						}
					}
					else if (this.global1.data[11] == 2)
					{
						if (this.global1.data[33] > 750)
						{
							ptr = ref this.global1.data[33];
							ref int ptr194 = ref ptr;
							num = ptr;
							ptr194 = num - 1;
						}
						else
						{
							ptr = ref this.global1.data[33];
							ref int ptr195 = ref ptr;
							num = ptr;
							ptr195 = num + 1;
						}
						ptr = ref this.global1.data[2];
						ptr += 5;
						ptr = ref this.global1.data[4];
						ptr += 4;
						ptr = ref this.global1.data[1];
						ptr -= 5;
						ptr = ref this.global1.data[3];
						ptr += 5;
						if (this.global1.data[31] > 500)
						{
							ptr = ref this.global1.data[31];
							ref int ptr196 = ref ptr;
							num = ptr;
							ptr196 = num - 1;
						}
					}
					else if (this.global1.data[11] == 3)
					{
						ptr = ref this.global1.data[2];
						ptr += 6;
						ptr = ref this.global1.data[3];
						ptr += 5;
						ptr = ref this.global1.data[1];
						ptr -= 5;
						ptr = ref this.global1.data[4];
						ptr += 10;
						ptr = ref this.global1.data[10];
						ref int ptr197 = ref ptr;
						num = ptr;
						ptr197 = num - 1;
						ptr = ref this.global1.data[31];
						ref int ptr198 = ref ptr;
						num = ptr;
						ptr198 = num - 1;
						if (this.global1.data[6] >= 600 && this.global1.data[21] <= 1991)
						{
							ptr = ref this.global1.data[6];
							ref int ptr199 = ref ptr;
							num = ptr;
							ptr199 = num - 1;
						}
						ptr = ref this.global1.data[9];
						ref int ptr200 = ref ptr;
						num = ptr;
						ptr200 = num - 1;
						ptr = ref this.global1.data[8];
						ptr += 2;
					}
					if (this.global1.data[12] == 4)
					{
						ptr = ref this.global1.data[1];
						ptr += 5;
						ptr = ref this.global1.data[4];
						ref int ptr201 = ref ptr;
						num = ptr;
						ptr201 = num + 1;
						ptr = ref this.global1.data[8];
						ref int ptr202 = ref ptr;
						num = ptr;
						ptr202 = num - 1;
					}
					else if (this.global1.data[12] == 5)
					{
						ptr = ref this.global1.data[1];
						ptr -= 2;
						ptr = ref this.global1.data[3];
						ptr += 5;
						ptr = ref this.global1.data[4];
						ptr += 5;
						ptr = ref this.global1.data[9];
						ptr -= 2;
						ptr = ref this.global1.data[8];
						ptr += 3;
						ptr = ref this.global1.data[2];
						ptr += 2;
						ptr = ref this.global1.data[10];
						ref int ptr203 = ref ptr;
						num = ptr;
						ptr203 = num - 1;
					}
					else if (this.global1.data[12] == 6)
					{
						ptr = ref this.global1.data[2];
						ptr -= 4;
						ptr = ref this.global1.data[3];
						ptr -= 5;
						ptr = ref this.global1.data[4];
						ptr -= 5;
						ptr = ref this.global1.data[5];
						ref int ptr204 = ref ptr;
						num = ptr;
						ptr204 = num - 1;
						if (this.global1.data[6] < 800 && this.global1.data[21] <= 1991)
						{
							ptr = ref this.global1.data[6];
							ref int ptr205 = ref ptr;
							num = ptr;
							ptr205 = num + 1;
						}
						ptr = ref this.global1.data[10];
						ref int ptr206 = ref ptr;
						num = ptr;
						ptr206 = num + 1;
						ptr = ref this.global1.data[9];
						ptr += 2;
					}
					if (this.global1.data[13] == 7)
					{
						if (this.global1.data[11] == 0)
						{
							ptr = ref this.global1.data[1];
							ptr += 3;
						}
						else
						{
							ptr = ref this.global1.data[1];
							ptr += 5;
						}
						ptr = ref this.global1.data[4];
						ref int ptr207 = ref ptr;
						num = ptr;
						ptr207 = num + 1;
						ptr = ref this.global1.data[8];
						ref int ptr208 = ref ptr;
						num = ptr;
						ptr208 = num - 1;
						if (this.global1.data[22] < 500)
						{
							ptr = ref this.global1.data[22];
							ref int ptr209 = ref ptr;
							num = ptr;
							ptr209 = num + 1;
						}
						ptr = ref this.global1.data[9];
						ref int ptr210 = ref ptr;
						num = ptr;
						ptr210 = num - 1;
					}
					else if (this.global1.data[13] == 8)
					{
						if (this.global1.data[33] > 600)
						{
							ptr = ref this.global1.data[33];
							ptr -= 2;
						}
						else
						{
							ptr = ref this.global1.data[33];
							ref int ptr211 = ref ptr;
							num = ptr;
							ptr211 = num + 1;
						}
						if (this.global1.data[5] < 650)
						{
							ptr = ref this.global1.data[5];
							ref int ptr212 = ref ptr;
							num = ptr;
							ptr212 = num + 1;
						}
						ptr = ref this.global1.data[2];
						ref int ptr213 = ref ptr;
						num = ptr;
						ptr213 = num + 1;
						ptr = ref this.global1.data[4];
						ptr += 3;
						ptr = ref this.global1.data[8];
						ref int ptr214 = ref ptr;
						num = ptr;
						ptr214 = num + 1;
					}
					else if (this.global1.data[13] == 9)
					{
						if (this.global1.data[14] > 0 && this.global1.data[14] < 5)
						{
							ptr = ref this.global1.data[1];
							ptr -= 5;
						}
						else
						{
							ptr = ref this.global1.data[1];
							ptr += 5;
						}
						ptr = ref this.global1.data[3];
						ref int ptr215 = ref ptr;
						num = ptr;
						ptr215 = num + 1;
						ptr = ref this.global1.data[4];
						ptr += 2;
						ptr = ref this.global1.data[9];
						ptr += 2;
						ptr = ref this.global1.data[10];
						ptr += 2;
						ptr = ref this.global1.data[31];
						ref int ptr216 = ref ptr;
						num = ptr;
						ptr216 = num + 1;
					}
				}
				else if (this.global1.data[0] == 2)
				{
					if (this.global1.data[11] == 0)
					{
						this.global1.data[1] = 1000;
						this.global1.data[3] = 1000;
						this.global1.data[4] = 0;
					}
					else if (this.global1.data[11] == 1)
					{
						ptr = ref this.global1.data[33];
						ref int ptr217 = ref ptr;
						num = ptr;
						ptr217 = num + 1;
						ptr = ref this.global1.data[22];
						ref int ptr218 = ref ptr;
						num = ptr;
						ptr218 = num + 1;
						ptr = ref this.global1.data[31];
						ptr += 2;
						ptr = ref this.global1.data[1];
						ptr += 2;
						ptr = ref this.global1.data[2];
						ptr -= 5;
						ptr = ref this.global1.data[3];
						ptr -= 8;
						ptr = ref this.global1.data[4];
						ptr += 5;
						ptr = ref this.global1.data[5];
						ref int ptr219 = ref ptr;
						num = ptr;
						ptr219 = num - 1;
						ptr = ref this.global1.data[6];
						ptr += 2;
						ptr = ref this.global1.data[9];
						ref int ptr220 = ref ptr;
						num = ptr;
						ptr220 = num + 1;
						ptr = ref this.global1.data[10];
						ref int ptr221 = ref ptr;
						num = ptr;
						ptr221 = num + 1;
						ptr = ref this.global1.data[5];
						ptr -= 2;
					}
					else if (this.global1.data[11] == 2)
					{
						ptr = ref this.global1.data[33];
						ref int ptr222 = ref ptr;
						num = ptr;
						ptr222 = num - 1;
						ptr = ref this.global1.data[1];
						ptr += 6;
						ptr = ref this.global1.data[2];
						ptr += 3;
						ptr = ref this.global1.data[3];
						ptr -= 2;
						ptr = ref this.global1.data[4];
						ptr += 2;
						ptr = ref this.global1.data[9];
						ref int ptr223 = ref ptr;
						num = ptr;
						ptr223 = num + 1;
						ptr = ref this.global1.data[5];
						ptr -= 2;
					}
					else if (this.global1.data[11] == 3)
					{
						ptr = ref this.global1.data[33];
						ref int ptr224 = ref ptr;
						num = ptr;
						ptr224 = num - 1;
						ptr = ref this.global1.data[22];
						ref int ptr225 = ref ptr;
						num = ptr;
						ptr225 = num - 1;
						ptr = ref this.global1.data[31];
						ref int ptr226 = ref ptr;
						num = ptr;
						ptr226 = num - 1;
						ptr = ref this.global1.data[1];
						ptr += 2;
						ptr = ref this.global1.data[2];
						ptr -= 5;
						ptr = ref this.global1.data[3];
						ptr += 2;
						if (!this.global1.allcountries[this.global1.data[0]].Vyshi)
						{
							ptr = ref this.global1.data[4];
							ptr += 8;
							ptr = ref this.global1.data[5];
							ref int ptr227 = ref ptr;
							num = ptr;
							ptr227 = num + 1;
							ptr = ref this.global1.data[6];
							ref int ptr228 = ref ptr;
							num = ptr;
							ptr228 = num - 1;
							ptr = ref this.global1.data[9];
							ref int ptr229 = ref ptr;
							num = ptr;
							ptr229 = num - 1;
							ptr = ref this.global1.data[10];
							ptr -= 2;
						}
						else
						{
							ptr = ref this.global1.data[4];
							ptr += 2;
							ptr = ref this.global1.data[9];
							ptr -= 2;
							ptr = ref this.global1.data[10];
							ref int ptr230 = ref ptr;
							num = ptr;
							ptr230 = num - 1;
						}
					}
					if (this.global1.data[12] == 4)
					{
						ptr = ref this.global1.data[1];
						ptr += 2;
						ptr = ref this.global1.data[3];
						ptr -= 3;
						ptr = ref this.global1.data[4];
						ptr += 3;
						ptr = ref this.global1.data[5];
						ptr -= 3;
						ptr = ref this.global1.data[8];
						ptr += 3;
					}
					else if (this.global1.data[12] == 5)
					{
						ptr = ref this.global1.data[1];
						ptr -= 2;
						ptr = ref this.global1.data[3];
						ptr += 4;
						ptr = ref this.global1.data[4];
						ptr += 4;
						ptr = ref this.global1.data[9];
						ref int ptr231 = ref ptr;
						num = ptr;
						ptr231 = num - 1;
						ptr = ref this.global1.data[8];
						ptr += 2;
						ptr = ref this.global1.data[2];
						ptr += 4;
						ptr = ref this.global1.data[10];
						ref int ptr232 = ref ptr;
						num = ptr;
						ptr232 = num - 1;
						ptr = ref this.global1.data[22];
						ref int ptr233 = ref ptr;
						num = ptr;
						ptr233 = num - 1;
					}
					else if (this.global1.data[12] == 6)
					{
						ptr = ref this.global1.data[1];
						ptr += 5;
						ptr = ref this.global1.data[2];
						ptr += 2;
						ptr = ref this.global1.data[3];
						ptr -= 3;
						ptr = ref this.global1.data[4];
						ptr += 3;
					}
					if (this.global1.data[13] == 7)
					{
						ptr = ref this.global1.data[1];
						ptr += 3;
						ptr = ref this.global1.data[4];
						ptr -= 2;
						ptr = ref this.global1.data[3];
						ptr += 2;
						ptr = ref this.global1.data[8];
						ptr -= 2;
						if (this.global1.data[22] < 700)
						{
							ptr = ref this.global1.data[22];
							ref int ptr234 = ref ptr;
							num = ptr;
							ptr234 = num + 1;
						}
						ptr = ref this.global1.data[5];
						ref int ptr235 = ref ptr;
						num = ptr;
						ptr235 = num - 1;
						ptr = ref this.global1.data[9];
						ref int ptr236 = ref ptr;
						num = ptr;
						ptr236 = num + 1;
					}
					else if (this.global1.data[13] == 8)
					{
						ptr = ref this.global1.data[33];
						ref int ptr237 = ref ptr;
						num = ptr;
						ptr237 = num + 1;
						ptr = ref this.global1.data[3];
						ptr -= 4;
						ptr = ref this.global1.data[4];
						ptr += 4;
						ptr = ref this.global1.data[1];
						ptr += 8;
						ptr = ref this.global1.data[2];
						ptr -= 2;
						if (this.global1.data[22] < 700)
						{
							ptr = ref this.global1.data[22];
							ptr += 3;
						}
						ptr = ref this.global1.data[5];
						ref int ptr238 = ref ptr;
						num = ptr;
						ptr238 = num - 1;
						ptr = ref this.global1.data[9];
						ptr += 2;
						if (this.global1.data[31] < 650)
						{
							ptr = ref this.global1.data[31];
							ref int ptr239 = ref ptr;
							num = ptr;
							ptr239 = num + 1;
						}
					}
					else if (this.global1.data[13] == 9)
					{
						ptr = ref this.global1.data[1];
						ptr += 5;
						ptr = ref this.global1.data[4];
						ref int ptr240 = ref ptr;
						num = ptr;
						ptr240 = num + 1;
						ptr = ref this.global1.data[8];
						ref int ptr241 = ref ptr;
						num = ptr;
						ptr241 = num - 1;
						if (this.global1.data[22] < 500)
						{
							ptr = ref this.global1.data[22];
							ref int ptr242 = ref ptr;
							num = ptr;
							ptr242 = num + 1;
						}
						if (this.global1.data[16] >= 12)
						{
							ptr = ref this.global1.data[9];
							ref int ptr243 = ref ptr;
							num = ptr;
							ptr243 = num + 1;
							ptr = ref this.global1.data[8];
							ptr += 2;
						}
					}
				}
				else if (this.global1.data[0] == 3)
				{
					if (this.global1.data[11] == 0)
					{
						ptr = ref this.global1.data[1];
						ptr += 8;
						ptr = ref this.global1.data[4];
						ptr += 2;
						ptr = ref this.global1.data[5];
						ptr += 4;
					}
					else if (this.global1.data[11] == 1)
					{
						ptr = ref this.global1.data[2];
						ref int ptr244 = ref ptr;
						num = ptr;
						ptr244 = num + 1;
						ptr = ref this.global1.data[1];
						ptr += 2;
						ptr = ref this.global1.data[3];
						ref int ptr245 = ref ptr;
						num = ptr;
						ptr245 = num + 1;
						ptr = ref this.global1.data[4];
						ptr += 2;
					}
					else if (this.global1.data[11] == 2)
					{
						ptr = ref this.global1.data[2];
						ptr += 3;
						ptr = ref this.global1.data[1];
						ptr -= 2;
						ptr = ref this.global1.data[3];
						ptr += 2;
						ptr = ref this.global1.data[4];
						ptr += 3;
					}
					else if (this.global1.data[11] == 3)
					{
						ptr = ref this.global1.data[10];
						ptr -= 2;
						ptr = ref this.global1.data[22];
						ptr -= 2;
						ptr = ref this.global1.data[9];
						ptr -= 2;
						if (this.global1.data[14] < 4)
						{
							if (this.global1.data[15] < 9)
							{
								ptr = ref this.global1.data[38];
								ref int ptr246 = ref ptr;
								num = ptr;
								ptr246 = num + 1;
							}
							else if (this.global1.data[17] < 17)
							{
								ptr = ref this.global1.data[40];
								ref int ptr247 = ref ptr;
								num = ptr;
								ptr247 = num + 1;
							}
							else if (this.global1.data[16] < 13)
							{
								ptr = ref this.global1.data[39];
								ref int ptr248 = ref ptr;
								num = ptr;
								ptr248 = num + 1;
							}
							ptr = ref this.global1.data[8];
							ptr -= 2;
						}
					}
					if (this.global1.data[12] == 4)
					{
						ptr = ref this.global1.data[2];
						ref int ptr249 = ref ptr;
						num = ptr;
						ptr249 = num + 1;
						ptr = ref this.global1.data[8];
						ptr += 2;
						ptr = ref this.global1.data[5];
						ptr -= 2;
						ptr = ref this.global1.data[1];
						ref int ptr250 = ref ptr;
						num = ptr;
						ptr250 = num - 1;
					}
					else if (this.global1.data[12] == 5)
					{
						ptr = ref this.global1.data[2];
						ptr += 2;
						ptr = ref this.global1.data[4];
						ptr += 3;
						ptr = ref this.global1.data[3];
						ptr += 2;
					}
					else if (this.global1.data[12] == 6)
					{
						ptr = ref this.global1.data[2];
						ptr += 3;
						ptr = ref this.global1.data[10];
						ptr -= 2;
						ptr = ref this.global1.data[3];
						ptr += 2;
						ptr = ref this.global1.data[4];
						ptr += 5;
					}
					if (this.global1.data[13] == 7)
					{
						ptr = ref this.global1.data[2];
						ptr += 2;
						ptr = ref this.global1.data[10];
						ptr -= 2;
						ptr = ref this.global1.data[4];
						ptr += 2;
						ptr = ref this.global1.data[1];
						ptr -= 2;
					}
					else if (this.global1.data[13] == 8)
					{
						ptr = ref this.global1.data[2];
						ptr -= 2;
						ptr = ref this.global1.data[10];
						ref int ptr251 = ref ptr;
						num = ptr;
						ptr251 = num + 1;
						ptr = ref this.global1.data[4];
						ptr -= 4;
						ptr = ref this.global1.data[3];
						ptr -= 2;
						ptr = ref this.global1.data[9];
						ptr += 2;
					}
					else if (this.global1.data[13] == 9)
					{
						ptr = ref this.global1.data[2];
						ref int ptr252 = ref ptr;
						num = ptr;
						ptr252 = num + 1;
						ptr = ref this.global1.data[10];
						ptr -= 2;
						ptr = ref this.global1.data[4];
						ptr += 4;
						ptr = ref this.global1.data[3];
						ptr += 2;
						if (this.global1.data[14] < 4)
						{
							ptr = ref this.global1.data[1];
							ptr -= 6;
						}
					}
				}
				else if (this.global1.data[0] == 4)
				{
					if (this.global1.data[11] == 0)
					{
						ptr = ref this.global1.data[1];
						ref int ptr253 = ref ptr;
						num = ptr;
						ptr253 = num + 1;
						ptr = ref this.global1.data[2];
						ref int ptr254 = ref ptr;
						num = ptr;
						ptr254 = num - 1;
						ptr = ref this.global1.data[3];
						ref int ptr255 = ref ptr;
						num = ptr;
						ptr255 = num + 1;
						ptr = ref this.global1.data[4];
						ref int ptr256 = ref ptr;
						num = ptr;
						ptr256 = num - 1;
						if (this.global1.data[31] > 500)
						{
							ptr = ref this.global1.data[31];
							ptr -= 2;
						}
						else if (this.global1.data[31] > 300)
						{
							ptr = ref this.global1.data[31];
							ref int ptr257 = ref ptr;
							num = ptr;
							ptr257 = num - 1;
						}
					}
					else if (this.global1.data[11] == 1)
					{
						ptr = ref this.global1.data[2];
						ptr -= 2;
						ptr = ref this.global1.data[9];
						ptr += 2;
						ptr = ref this.global1.data[3];
						ref int ptr258 = ref ptr;
						num = ptr;
						ptr258 = num + 1;
						ptr = ref this.global1.data[1];
						ref int ptr259 = ref ptr;
						num = ptr;
						ptr259 = num + 1;
						ptr = ref this.global1.data[10];
						ref int ptr260 = ref ptr;
						num = ptr;
						ptr260 = num + 1;
						if (this.global1.data[31] > 500)
						{
							ptr = ref this.global1.data[31];
							ref int ptr261 = ref ptr;
							num = ptr;
							ptr261 = num + 1;
						}
						else if (this.global1.data[31] > 300)
						{
							ptr = ref this.global1.data[31];
							ptr -= 2;
						}
					}
					else if (this.global1.data[11] == 2)
					{
						ptr = ref this.global1.data[2];
						ptr += 2;
						ptr = ref this.global1.data[3];
						ptr -= 2;
						ptr = ref this.global1.data[4];
						ptr += 2;
						ptr = ref this.global1.data[1];
						ref int ptr262 = ref ptr;
						num = ptr;
						ptr262 = num - 1;
						if (this.global1.data[1] >= 500)
						{
							ptr = ref this.global1.data[1];
							ptr -= (this.global1.data[1] - 400) / 100;
						}
						if (this.global1.data[1] >= 700)
						{
							ptr = ref this.global1.data[1];
							ptr -= (this.global1.data[1] - 400) / 50;
						}
						if (this.global1.data[1] >= 800)
						{
							ptr = ref this.global1.data[1];
							ptr -= (this.global1.data[1] - 400) / 25;
						}
					}
					else if (this.global1.data[11] == 3)
					{
						ptr = ref this.global1.data[2];
						ptr += 3;
						ptr = ref this.global1.data[22];
						ref int ptr263 = ref ptr;
						num = ptr;
						ptr263 = num - 1;
						ptr = ref this.global1.data[31];
						ref int ptr264 = ref ptr;
						num = ptr;
						ptr264 = num - 1;
						ptr = ref this.global1.data[4];
						ptr += 3;
					}
					if (this.global1.data[12] == 4)
					{
						ptr = ref this.global1.data[3];
						ptr += 2;
						ptr = ref this.global1.data[9];
						ref int ptr265 = ref ptr;
						num = ptr;
						ptr265 = num - 1;
					}
					else if (this.global1.data[12] == 5)
					{
						ptr = ref this.global1.data[2];
						ref int ptr266 = ref ptr;
						num = ptr;
						ptr266 = num - 1;
						ptr = ref this.global1.data[4];
						ptr += 2 * (this.global1.data[21] - 1988);
					}
					else if (this.global1.data[12] == 6)
					{
						ptr = ref this.global1.data[2];
						ptr += 2;
						ptr = ref this.global1.data[8];
						ptr += 2;
						ptr = ref this.global1.data[4];
						ptr += 3;
						ptr = ref this.global1.data[22];
						ref int ptr267 = ref ptr;
						num = ptr;
						ptr267 = num - 1;
					}
					if (this.global1.data[13] == 7)
					{
						ptr = ref this.global1.data[2];
						ptr += 3;
						ptr = ref this.global1.data[10];
						ref int ptr268 = ref ptr;
						num = ptr;
						ptr268 = num - 1;
						ptr = ref this.global1.data[4];
						ptr += 3;
					}
					else if (this.global1.data[13] == 8)
					{
						if (this.global1.data[31] < 800)
						{
							ptr = ref this.global1.data[31];
							ref int ptr269 = ref ptr;
							num = ptr;
							ptr269 = num + 1;
						}
						ptr = ref this.global1.data[2];
						ref int ptr270 = ref ptr;
						num = ptr;
						ptr270 = num - 1;
						ptr = ref this.global1.data[3];
						ptr += 2;
						ptr = ref this.global1.data[4];
						ptr += 2;
						if (this.global1.data[22] < 500)
						{
							ptr = ref this.global1.data[22];
							ref int ptr271 = ref ptr;
							num = ptr;
							ptr271 = num + 1;
						}
					}
					else if (this.global1.data[13] == 9)
					{
						ptr = ref this.global1.data[2];
						ptr -= 2;
						ptr = ref this.global1.data[8];
						ptr += 2;
						ptr = ref this.global1.data[5];
						ref int ptr272 = ref ptr;
						num = ptr;
						ptr272 = num + 1;
					}
				}
				else if (this.global1.data[0] == 20)
				{
					if (this.global1.data[11] == 0)
					{
						ptr = ref this.global1.data[4];
						ptr -= 11;
						ptr = ref this.global1.data[1];
						ptr += 4;
						ptr = ref this.global1.data[2];
						ptr -= 4;
						ptr = ref this.global1.data[22];
						ptr += 2;
						ptr = ref this.global1.data[31];
						ptr += 2;
						ptr = ref this.global1.data[10];
						ref int ptr273 = ref ptr;
						num = ptr;
						ptr273 = num + 1;
						ptr = ref this.global1.data[5];
						ref int ptr274 = ref ptr;
						num = ptr;
						ptr274 = num - 1;
						ptr = ref this.global1.data[6];
						ref int ptr275 = ref ptr;
						num = ptr;
						ptr275 = num + 1;
					}
					else if (this.global1.data[11] == 2)
					{
						ptr = ref this.global1.data[3];
						ptr += 5;
						ptr = ref this.global1.data[4];
						ptr -= 8;
						ptr = ref this.global1.data[2];
						ref int ptr276 = ref ptr;
						num = ptr;
						ptr276 = num + 1;
						ptr = ref this.global1.data[1];
						ref int ptr277 = ref ptr;
						num = ptr;
						ptr277 = num + 1;
						if (this.global1.data[22] > 500)
						{
							ptr = ref this.global1.data[22];
							ref int ptr278 = ref ptr;
							num = ptr;
							ptr278 = num - 1;
						}
						if (this.global1.data[31] > 500)
						{
							ptr = ref this.global1.data[31];
							ref int ptr279 = ref ptr;
							num = ptr;
							ptr279 = num - 1;
						}
					}
					else if (this.global1.data[11] == 3)
					{
						ptr = ref this.global1.data[4];
						ptr -= 9;
						ptr = ref this.global1.data[2];
						ref int ptr280 = ref ptr;
						num = ptr;
						ptr280 = num + 1;
						ptr = ref this.global1.data[1];
						ref int ptr281 = ref ptr;
						num = ptr;
						ptr281 = num - 1;
						ptr = ref this.global1.data[22];
						ref int ptr282 = ref ptr;
						num = ptr;
						ptr282 = num - 1;
						ptr = ref this.global1.data[31];
						ptr -= 2;
						ptr = ref this.global1.data[5];
						ref int ptr283 = ref ptr;
						num = ptr;
						ptr283 = num - 1;
					}
					if (this.global1.data[12] == 4)
					{
						ptr = ref this.global1.data[1];
						ptr += 4;
					}
					else if (this.global1.data[12] == 5)
					{
						ptr = ref this.global1.data[3];
						ptr -= 4;
						ptr = ref this.global1.data[4];
						ptr -= 2;
						ptr = ref this.global1.data[2];
						ptr -= 4;
						ptr = ref this.global1.data[9];
						ptr += 2;
					}
					else if (this.global1.data[12] == 6)
					{
						ptr = ref this.global1.data[3];
						ptr += 4;
						ptr = ref this.global1.data[4];
						ptr += 2;
						ptr = ref this.global1.data[10];
						ref int ptr284 = ref ptr;
						num = ptr;
						ptr284 = num - 1;
						ptr = ref this.global1.data[8];
						ptr += 2;
						ptr = ref this.global1.data[5];
						ptr -= 2;
						if (this.global1.data[14] < 4 || this.global1.data[11] == 0)
						{
							ptr = ref this.global1.data[1];
							ptr -= 4;
							ptr = ref this.global1.data[8];
							ptr -= 4;
						}
					}
					if (this.global1.data[13] == 7)
					{
						ptr = ref this.global1.data[3];
						ptr -= 2;
						ptr = ref this.global1.data[4];
						ptr -= 2;
						ptr = ref this.global1.data[1];
						ptr += 2;
						ptr = ref this.global1.data[2];
						ptr -= 4;
						if (this.global1.data[21] > 1989)
						{
							ptr = ref this.global1.data[6];
							ref int ptr285 = ref ptr;
							num = ptr;
							ptr285 = num + 1;
						}
					}
					else if (this.global1.data[13] == 8)
					{
						ptr = ref this.global1.data[1];
						ptr -= 4;
						ptr = ref this.global1.data[4];
						ptr += 2;
						ptr = ref this.global1.data[5];
						ptr += 2;
					}
					else if (this.global1.data[13] == 9)
					{
						ptr = ref this.global1.data[3];
						ptr += 2;
						ptr = ref this.global1.data[31];
						ref int ptr286 = ref ptr;
						num = ptr;
						ptr286 = num + 1;
						if (this.global1.data[14] < 4 || this.global1.data[11] == 0)
						{
							ptr = ref this.global1.data[1];
							ptr -= 4;
							ptr = ref this.global1.data[8];
							ptr -= 4;
						}
					}
				}
				else if (this.global1.data[0] >= 49 && this.global1.data[0] <= 51)
				{
					if (this.global1.data[114] != 100)
					{
						if (this.global1.data[112] == 0)
						{
							ptr = ref this.global1.data[26];
							ptr -= 3;
							ptr = ref this.global1.data[10];
							ptr -= 5;
						}
						else if (this.global1.data[112] == 1)
						{
							ptr = ref this.global1.data[4];
							ptr += 3;
							ptr = ref this.global1.data[10];
							ptr -= 5;
							ptr = ref this.global1.data[6];
							ptr -= 2;
						}
						else if (this.global1.data[112] == 2)
						{
							ptr = ref this.global1.data[6];
							ptr -= 2;
							ptr = ref this.global1.data[31];
							ref int ptr287 = ref ptr;
							num = ptr;
							ptr287 = num - 1;
							ptr = ref this.global1.data[4];
							ptr += 2;
							ptr = ref this.global1.data[8];
							ptr += 5;
							YugoCountry yugoCountry = this.yug1.gameState.yugcountries[0];
							yugoCountry.money += 5;
						}
						else if (this.global1.data[112] == 3)
						{
							ptr = ref this.global1.data[4];
							ptr -= 3;
							ptr = ref this.global1.data[3];
							ptr -= 3;
							YugoCountry yugoCountry = this.yug1.gameState.yugcountries[8];
							yugoCountry.money += 5;
							if (this.global1.data[0] == 49)
							{
								ptr = ref this.global1.data[8];
								ptr += 3;
							}
						}
						else if (this.global1.data[112] == 4)
						{
							ptr = ref this.global1.data[4];
							ptr -= 5;
							ptr = ref this.global1.data[3];
							ptr -= 4;
							ptr = ref this.global1.data[6];
							ptr += 3;
							ptr = ref this.global1.data[31];
							ptr++;
						}
						else if (this.global1.data[112] == 5)
						{
							ptr = ref this.global1.data[4];
							ptr += 5;
							ptr = ref this.global1.data[10];
							ptr -= 10;
							YugoCountry yugoCountry = this.yug1.gameState.yugcountries[1];
							yugoCountry.money += 5;
							if (this.global1.data[0] == 51)
							{
								ptr = ref this.global1.data[8];
								ptr += 3;
							}
							ptr = ref this.global1.data[6];
							ptr -= 6;
							ptr = ref this.global1.data[31];
							ptr -= 2;
						}
						else if (this.global1.data[112] == 7)
						{
							ptr = ref this.global1.data[4];
							ptr -= 5;
							ptr = ref this.global1.data[3];
							ptr += 3;
							ptr = ref this.global1.data[6];
							ptr += 2;
							ptr = ref this.global1.data[1];
							ptr++;
							ptr = ref this.global1.data[31];
							ptr += 2;
						}
						else if (this.global1.data[112] == 8)
						{
							ptr = ref this.global1.data[4];
							ptr -= 4;
							ptr = ref this.global1.data[3];
							ptr += 5;
							ptr = ref this.global1.data[6];
							ptr -= 2;
							ptr = ref this.global1.data[1];
							ptr -= 3;
							ptr = ref this.global1.data[31];
							ptr -= 2;
						}
						else if (this.global1.data[112] == 9)
						{
							ptr = ref this.global1.data[4];
							ptr -= 5;
							ptr = ref this.global1.data[3];
							ptr -= 4;
							ptr = ref this.global1.data[6];
							ptr += 3;
							ptr = ref this.global1.data[31];
							ptr++;
						}
						else if (this.global1.data[112] == 10)
						{
							ptr = ref this.global1.data[3];
							ptr += 3;
							ptr = ref this.global1.data[4];
							ptr += 2;
							ptr = ref this.global1.data[10];
							ptr -= 5;
							ptr = ref this.global1.data[5];
							ptr += 4;
							ptr = ref this.global1.data[8];
							ptr++;
							ptr = ref this.global1.data[23];
							ptr--;
						}
						else if (this.global1.data[112] == 11)
						{
							ptr = ref this.global1.data[3];
							ptr += 5;
							ptr = ref this.global1.data[4];
							ptr--;
							ptr = ref this.global1.data[5];
							ptr++;
							ptr = ref this.global1.data[31];
							ptr -= 3;
							if (this.global1.data[6] <= 30)
							{
								ptr = ref this.global1.data[6];
								ptr--;
							}
						}
						if (this.global1.data[12] == 4)
						{
							ptr = ref this.global1.data[1];
							ptr += 3;
							ptr = ref this.global1.data[4];
							ptr += 2;
							ptr = ref this.global1.data[9];
							ptr += 12;
							ptr = ref this.global1.data[31];
							ptr += 2;
							ptr = ref this.global1.data[33];
							ptr += 3;
						}
						else if (this.global1.data[12] == 5)
						{
							ptr = ref this.global1.data[4];
							ptr -= 5;
							ptr = ref this.global1.data[3];
							ptr--;
							ptr = ref this.global1.data[9];
							ptr += 5;
							ptr = ref this.global1.data[6];
							ptr += 5;
							YugoCountry yugoCountry = this.yug1.gameState.yugcountries[8];
							yugoCountry.money += 5;
							if (this.global1.data[0] == 49)
							{
								ptr = ref this.global1.data[8];
								ptr += 3;
							}
							ptr = ref this.global1.data[31];
							ptr--;
							ptr = ref this.global1.data[33];
							ref int ptr288 = ref ptr;
							num = ptr;
							ptr288 = num + 1;
						}
						else if (this.global1.data[12] == 6)
						{
							ptr = ref this.global1.data[1];
							ptr -= 3;
							ptr = ref this.global1.data[10];
							ptr -= 5;
							ptr = ref this.global1.data[4];
							ptr += 2;
							YugoCountry yugoCountry = this.yug1.gameState.yugcountries[1];
							yugoCountry.money += 5;
							if (this.global1.data[0] == 51)
							{
								ptr = ref this.global1.data[8];
								ptr += 3;
							}
							ptr = ref this.global1.data[31];
							ptr--;
							ptr = ref this.global1.data[6];
							ptr -= 2;
						}
						if (this.global1.data[13] == 7)
						{
							ptr = ref this.global1.data[1];
							ptr += 3;
							ptr = ref this.global1.data[10];
							ptr -= 5;
							ptr = ref this.global1.data[31];
							ptr++;
							ptr = ref this.global1.data[2];
							ref int ptr289 = ref ptr;
							num = ptr;
							ptr289 = num + 1;
						}
						else if (this.global1.data[13] == 8)
						{
							ptr = ref this.global1.data[1];
							ptr -= 2;
							ptr = ref this.global1.data[5];
							ptr -= 2;
							ptr = ref this.global1.data[8];
							ptr += 4;
							YugoCountry yugoCountry = this.yug1.gameState.yugcountries[3];
							YugoCountry yugoCountry3 = yugoCountry;
							num = yugoCountry.money;
							yugoCountry3.money = num + 1;
							if (this.global1.data[0] == 50)
							{
								ptr = ref this.global1.data[8];
								ref int ptr290 = ref ptr;
								num = ptr;
								ptr290 = num + 1;
							}
						}
						else if (this.global1.data[13] == 9)
						{
							ptr = ref this.global1.data[3];
							ptr += 2;
							ptr = ref this.global1.data[4];
							ptr += 5;
							ptr = ref this.global1.data[10];
							ptr -= 5;
							ptr = ref this.global1.data[5];
							ptr += 2;
							ptr = ref this.global1.data[8];
							ptr += 2;
							ptr = ref this.global1.data[23];
							ptr--;
							ptr = ref this.global1.data[6];
							ref int ptr291 = ref ptr;
							num = ptr;
							ptr291 = num - 1;
						}
					}
					else if (this.global1.data[0] == 49)
					{
						if (this.global1.data[11] == 0)
						{
							if (this.global1.data[7] <= 900)
							{
								ptr = ref this.global1.data[7];
								ptr++;
							}
							ptr = ref this.global1.data[1];
							ptr += 3;
							ptr = ref this.global1.data[9];
							ptr += 10;
							ptr = ref this.global1.data[31];
							ptr--;
						}
						else if (this.global1.data[11] == 1)
						{
							ptr = ref this.global1.data[4];
							ptr -= 4;
							ptr = ref this.global1.data[3];
							ptr += 3;
							ptr = ref this.global1.data[6];
							ptr += 5;
							ptr = ref this.global1.data[9];
							ptr += 5;
							ptr = ref this.global1.data[31];
							ptr += 3;
						}
						else if (this.global1.data[11] == 2)
						{
							ptr = ref this.global1.data[3];
							ptr += 2;
							ptr = ref this.global1.data[4];
							ptr -= 4;
							ptr = ref this.global1.data[6];
							ptr -= 5;
							ptr = ref this.global1.data[9];
							ptr += 5;
							ptr = ref this.global1.data[31];
							ptr += 3;
						}
						else if (this.global1.data[11] == 3)
						{
							ptr = ref this.global1.data[10];
							ptr -= 2;
							ptr = ref this.global1.data[1];
							ptr--;
							ptr = ref this.global1.data[4];
							ptr += 4;
							ptr = ref this.global1.data[6];
							ptr--;
							ptr = ref this.global1.data[31];
							ptr++;
							ptr = ref this.global1.data[5];
							ptr++;
						}
						if (this.global1.data[12] == 4)
						{
							ptr = ref this.global1.data[3];
							ptr += 4;
							ptr = ref this.global1.data[1];
							ptr += 4;
							ptr = ref this.global1.data[10];
							ptr++;
							ptr = ref this.global1.data[5];
							ptr--;
						}
						else if (this.global1.data[12] == 5)
						{
							ptr = ref this.global1.data[3];
							ptr -= 2;
							ptr = ref this.global1.data[1];
							ptr += 2;
							ptr = ref this.global1.data[9];
							ptr += 10;
						}
						else if (this.global1.data[12] == 6)
						{
							ptr = ref this.global1.data[10];
							ptr += 5;
							ptr = ref this.global1.data[8];
							ptr -= 5;
							ptr = ref this.global1.data[9];
							ptr += 15;
							ptr = ref this.global1.data[31];
							ptr++;
						}
						if (this.global1.data[13] == 7)
						{
							ptr = ref this.global1.data[10];
							ptr -= 2;
							ptr = ref this.global1.data[2];
							ref int ptr292 = ref ptr;
							num = ptr;
							ptr292 = num + 1;
							ptr = ref this.global1.data[3];
							ptr += 3;
							ptr = ref this.global1.data[9];
							ptr += 5;
							ptr = ref this.global1.data[31];
							ptr += 2;
						}
						else if (this.global1.data[13] == 8)
						{
							ptr = ref this.global1.data[3];
							ptr++;
							ptr = ref this.global1.data[1];
							ptr -= 5;
							ptr = ref this.global1.data[9];
							ptr += 8;
							ptr = ref this.global1.data[31];
							ptr += 3;
							ptr = ref this.global1.data[10];
							ptr += 5;
						}
						else if (this.global1.data[13] == 9)
						{
							ptr = ref this.global1.data[3];
							ptr += 10;
							ptr = ref this.global1.data[5];
							ref int ptr293 = ref ptr;
							num = ptr;
							ptr293 = num + 1;
							ptr = ref this.global1.data[1];
							ref int ptr294 = ref ptr;
							num = ptr;
							ptr294 = num - 1;
							ptr = ref this.global1.data[10];
							ref int ptr295 = ref ptr;
							num = ptr;
							ptr295 = num - 1;
						}
					}
					else if (this.global1.data[0] == 50)
					{
						if (this.global1.data[11] == 0)
						{
							ptr = ref this.global1.data[1];
							ptr += 5;
							ptr = ref this.global1.data[3];
							ptr += 8;
							ptr = ref this.global1.data[31];
							ptr += 2;
						}
						else if (this.global1.data[11] == 1)
						{
							ptr = ref this.global1.data[3];
							ptr++;
							ptr = ref this.global1.data[5];
							ptr++;
							ptr = ref this.global1.data[1];
							ptr++;
							ptr = ref this.global1.data[31];
							ptr--;
						}
						else if (this.global1.data[11] == 2)
						{
							ptr = ref this.global1.data[1];
							ptr += 2;
							ptr = ref this.global1.data[10];
							ptr -= 5;
							ptr = ref this.global1.data[5];
							ptr += 5;
							ptr = ref this.global1.data[6];
							ptr -= 4;
							ptr = ref this.global1.data[31];
							ptr++;
						}
						else if (this.global1.data[11] == 3)
						{
							ptr = ref this.global1.data[1];
							ptr += 3;
							ptr = ref this.global1.data[3];
							ptr++;
							ptr = ref this.global1.data[6];
							ptr += 2;
							ptr = ref this.global1.data[31];
							ptr--;
						}
						if (this.global1.data[12] == 4)
						{
							ptr = ref this.global1.data[3];
							ptr++;
							ptr = ref this.global1.data[8];
							ptr -= 10;
							ptr = ref this.global1.data[9];
							ptr += 30;
							ptr = ref this.global1.data[31];
							ptr++;
						}
						else if (this.global1.data[12] == 5)
						{
							ptr = ref this.global1.data[4];
							ptr += 5;
							ptr = ref this.global1.data[3];
							ptr += 3;
							ptr = ref this.global1.data[31];
							ptr += 2;
							ptr = ref this.global1.data[10];
							ptr -= 2;
						}
						else if (this.global1.data[12] == 6)
						{
							ptr = ref this.global1.data[5];
							ptr -= 3;
							ptr = ref this.global1.data[8];
							ptr += 12;
							ptr = ref this.global1.data[3];
							ptr += 3;
						}
						if (this.global1.data[13] == 7)
						{
							ptr = ref this.global1.data[1];
							ptr++;
							ptr = ref this.global1.data[6];
							ptr -= 3;
							ptr = ref this.global1.data[10];
							ptr -= 2;
							ptr = ref this.global1.data[4];
							ptr += 3;
							ptr = ref this.global1.data[3];
							ptr -= 2;
							ptr = ref this.global1.data[8];
							ptr += 4;
						}
						else if (this.global1.data[13] == 8)
						{
							ptr = ref this.global1.data[1];
							ptr += 2;
							ptr = ref this.global1.data[10];
							ptr -= 5;
							ptr = ref this.global1.data[5];
							ptr += 5;
							ptr = ref this.global1.data[6];
							ptr -= 4;
							ptr = ref this.global1.data[31];
							ptr += 3;
						}
						else if (this.global1.data[13] == 9)
						{
							ptr = ref this.global1.data[1];
							ptr += 3;
							ptr = ref this.global1.data[3];
							ptr++;
							ptr = ref this.global1.data[6];
							ptr += 2;
							ptr = ref this.global1.data[31];
							ptr--;
						}
					}
					else if (this.global1.data[0] == 51)
					{
						if (this.global1.data[11] == 0)
						{
							ptr = ref this.global1.data[1];
							ptr += 4;
							ptr = ref this.global1.data[10];
							ptr -= 5;
							ptr = ref this.global1.data[4];
							ptr += 5;
							ptr = ref this.global1.data[3];
							ptr += 5;
						}
						else if (this.global1.data[11] == 1)
						{
							ptr = ref this.global1.data[3];
							ptr += 2;
							ptr = ref this.global1.data[8];
							ptr += 10;
							ptr = ref this.global1.data[4];
							ptr += 2;
							ptr = ref this.global1.data[5];
							ptr += 2;
						}
						else if (this.global1.data[11] == 2)
						{
							ptr = ref this.global1.data[2];
							ptr++;
							ptr = ref this.global1.data[9];
							ptr += 25;
							ptr = ref this.global1.data[1];
							ptr++;
							ptr = ref this.global1.data[3];
							ptr--;
							ptr = ref this.global1.data[31];
							ptr--;
							ptr = ref this.global1.data[4];
							ptr++;
							if (this.global1.data[6] <= 500)
							{
								ptr = ref this.global1.data[6];
								ptr++;
							}
							if (this.global1.data[6] >= 600)
							{
								ptr = ref this.global1.data[6];
								ptr--;
							}
						}
						else if (this.global1.data[11] == 3)
						{
							ptr = ref this.global1.data[1];
							ptr += 2;
							ptr = ref this.global1.data[3];
							ptr++;
							ptr = ref this.global1.data[31];
							ptr--;
							ptr = ref this.global1.data[5];
							ptr++;
							ptr = ref this.global1.data[4];
							ptr--;
							ptr = ref this.global1.data[6];
							ptr++;
						}
						if (this.global1.data[12] == 4)
						{
							ptr = ref this.global1.data[8];
							ptr -= 10;
							ptr = ref this.global1.data[9];
							ptr += 18;
						}
						else if (this.global1.data[12] == 5)
						{
							ptr = ref this.global1.data[3];
							ptr += 3;
							ptr = ref this.global1.data[4];
							ptr -= 5;
							ptr = ref this.global1.data[31];
							ptr -= 2;
						}
						else if (this.global1.data[12] == 6)
						{
							ptr = ref this.global1.data[1];
							ptr += 3;
							ptr = ref this.global1.data[3];
							ptr += 3;
							ptr = ref this.global1.data[31];
							ptr--;
							ptr = ref this.global1.data[5];
							ptr += 3;
						}
						if (this.global1.data[13] == 7)
						{
							ptr = ref this.global1.data[3];
							ptr += 3;
							ptr = ref this.global1.data[8];
							ptr += 7;
							ptr = ref this.global1.data[4];
							ptr += 2;
							ptr = ref this.global1.data[5];
							ptr += 2;
						}
						else if (this.global1.data[13] == 8)
						{
							ptr = ref this.global1.data[3];
							ptr += 3;
							ptr = ref this.global1.data[10];
							ptr -= 5;
							ptr = ref this.global1.data[5];
							ptr++;
							ptr = ref this.global1.data[31];
							ptr--;
						}
						else if (this.global1.data[13] == 9)
						{
							ptr = ref this.global1.data[3];
							ptr++;
							ptr = ref this.global1.data[1];
							ptr += 2;
							ptr = ref this.global1.data[4];
							ptr += 5;
							ptr = ref this.global1.data[9];
							ptr++;
							ptr = ref this.global1.data[31];
							ptr++;
							ptr = ref this.global1.data[6];
							ptr -= 3;
						}
					}
					Debug.Log("MINISTERDONE");
				}
				if (this.global1.data[2] < 501)
				{
					if (this.global1.allcountries[this.global1.data[0]].Vyshi && !this.global1.allcountries[this.global1.data[0]].isOVD && !this.global1.allcountries[this.global1.data[0]].isSEV)
					{
						ptr = ref this.global1.data[1];
						ptr -= (1000 - this.global1.data[2]) / 200;
					}
					else if (this.global1.allcountries[this.global1.data[0]].Vyshi && !this.global1.allcountries[this.global1.data[0]].isOVD)
					{
						ptr = ref this.global1.data[1];
						ptr -= (1000 - this.global1.data[2]) / 150;
					}
					else if (this.global1.allcountries[this.global1.data[0]].Vyshi)
					{
						ptr = ref this.global1.data[1];
						ptr -= (1000 - this.global1.data[2]) / 100;
					}
					else
					{
						ptr = ref this.global1.data[1];
						ptr -= (1000 - this.global1.data[2]) / 80;
					}
					if (this.global1.data[30] > 0 && this.global1.data[0] != 12)
					{
						ptr = ref this.global1.data[8];
						ptr -= this.global1.data[30] / 50;
						ptr = ref this.global1.data[30];
						ptr -= this.global1.data[30] / 50;
					}
				}
				if (this.global1.data[4] > 600)
				{
					ptr = ref this.global1.data[1];
					ptr -= this.global1.data[4] / 180;
					ptr = ref this.global1.data[3];
					ptr -= this.global1.data[4] / 90;
				}
				ptr = ref this.global1.data[4];
				ptr += (500 - this.global1.data[22]) / 100;
				ptr = ref this.global1.data[4];
				ptr -= this.global1.allcountries[17].Westalgie / 80;
				ptr = ref this.global1.data[10];
				ptr -= this.global1.allcountries[17].Westalgie / 120;
				if (this.global1.data[21] < 1992)
				{
					if (this.global1.diff[0])
					{
						ptr = ref this.global1.data[1];
						ptr -= 3 + (this.global1.data[21] - 1988);
						if (this.global1.data[0] == 4 && this.global1.data[11] != 2)
						{
							ptr = ref this.global1.data[1];
							ptr -= 5;
						}
						else if (this.global1.data[0] == 20)
						{
							ptr = ref this.global1.data[8];
							ptr -= this.global1.data[21] - 1988;
						}
					}
					if (this.global1.diff[1])
					{
						if (!this.global1.is_gkchp || (this.global1.is_gkchp && !this.global1.allcountries[7].isOVD && !this.global1.allcountries[this.global1.data[0]].Vyshi))
						{
							ptr = ref this.global1.data[2];
							ptr -= 3 + (this.global1.data[21] - 1988);
						}
						else
						{
							ptr = ref this.global1.data[2];
							ptr += 3 + (this.global1.data[21] - 1988);
						}
					}
					if (this.global1.diff[2])
					{
						ptr = ref this.global1.data[3];
						ptr -= 3 + (this.global1.data[21] - 1988);
					}
				}
				else
				{
					if (this.global1.diff[0])
					{
						ptr = ref this.global1.data[1];
						ptr -= 6;
					}
					if (this.global1.diff[1])
					{
						if (!this.global1.is_gkchp || (this.global1.is_gkchp && !this.global1.allcountries[7].isOVD && !this.global1.allcountries[this.global1.data[0]].Vyshi))
						{
							ptr = ref this.global1.data[2];
							ptr -= 6;
						}
						else
						{
							ptr = ref this.global1.data[10];
							ptr += 6;
						}
					}
					if (this.global1.diff[2])
					{
						ptr = ref this.global1.data[3];
						ptr -= 6;
					}
				}
				if (this.global1.allcountries[7].isSEV && this.global1.allcountries[this.global1.data[0]].isSEV)
				{
					ptr = ref this.global1.data[1];
					ptr += this.global1.data[22] / 100;
				}
				else
				{
					ptr = ref this.global1.data[1];
					ptr += this.global1.data[22] / 50;
				}
				ptr = ref this.global1.data[3];
				ptr -= (700 - this.global1.data[5]) / 70;
				if ((this.global1.science_time[0] > 0 && this.global1.science_time[0] < 360) || (this.global1.science_time[1] > 0 && this.global1.science_time[1] < 360) || (this.global1.science_time[2] > 0 && this.global1.science_time[2] < 360))
				{
					if (this.global1.data[0] == 10 || this.global1.data[0] == 12 || this.global1.data[0] == 18)
					{
						ptr = ref this.global1.data[1];
						ref int ptr296 = ref ptr;
						num = ptr;
						ptr296 = num + 1;
						ptr = ref this.global1.data[3];
						ptr -= 2;
						ptr = ref this.global1.data[4];
						ref int ptr297 = ref ptr;
						num = ptr;
						ptr297 = num - 1;
						ptr = ref this.global1.data[10];
						ref int ptr298 = ref ptr;
						num = ptr;
						ptr298 = num + 1;
						ptr = ref this.global1.data[2];
						ref int ptr299 = ref ptr;
						num = ptr;
						ptr299 = num - 1;
					}
					else
					{
						ptr = ref this.global1.data[2];
						ptr -= 2;
						ptr = ref this.global1.data[10];
						ref int ptr300 = ref ptr;
						num = ptr;
						ptr300 = num + 1;
						ptr = ref this.global1.data[1];
						ptr += 2;
						ptr = ref this.global1.data[22];
						ref int ptr301 = ref ptr;
						num = ptr;
						ptr301 = num + 1;
					}
				}
				if ((this.global1.science_time[3] > 0 && this.global1.science_time[3] < 360) || (this.global1.science_time[4] > 0 && this.global1.science_time[4] < 360) || (this.global1.science_time[5] > 0 && this.global1.science_time[5] < 360))
				{
					if (this.global1.data[0] == 10 || this.global1.data[0] == 12 || this.global1.data[0] == 18)
					{
						ptr = ref this.global1.data[5];
						ptr += 2;
						ptr = ref this.global1.data[3];
						ref int ptr302 = ref ptr;
						num = ptr;
						ptr302 = num + 1;
						ptr = ref this.global1.data[4];
						ptr += 2;
					}
					else
					{
						ptr = ref this.global1.data[1];
						ptr -= 4;
						ptr = ref this.global1.data[5];
						ref int ptr303 = ref ptr;
						num = ptr;
						ptr303 = num + 1;
						ptr = ref this.global1.data[22];
						ref int ptr304 = ref ptr;
						num = ptr;
						ptr304 = num + 1;
					}
				}
				if ((this.global1.science_time[6] > 0 && this.global1.science_time[6] < 360) || (this.global1.science_time[7] > 0 && this.global1.science_time[7] < 360) || (this.global1.science_time[8] > 0 && this.global1.science_time[8] < 360))
				{
					if (this.global1.data[0] == 10 || this.global1.data[0] == 12 || this.global1.data[0] == 18)
					{
						ptr = ref this.global1.data[1];
						ptr += 2;
						ptr = ref this.global1.data[5];
						ptr += 2;
						ptr = ref this.global1.data[3];
						ptr -= 2;
					}
					else
					{
						ptr = ref this.global1.data[5];
						ref int ptr305 = ref ptr;
						num = ptr;
						ptr305 = num + 1;
						ptr = ref this.global1.data[1];
						ptr -= 2;
					}
				}
				if (this.global1.science_time[9] > 0 && this.global1.science_time[9] < 360)
				{
					ptr = ref this.global1.data[2];
					ptr -= 4;
					ptr = ref this.global1.data[10];
					ref int ptr306 = ref ptr;
					num = ptr;
					ptr306 = num + 1;
					ptr = ref this.global1.data[22];
					ptr += 2;
				}
				if (this.global1.data[0] == 10 || this.global1.data[0] == 12 || this.global1.data[0] == 18)
				{
					if (this.global1.science[0])
					{
						ptr = ref this.global1.data[4];
						ptr -= 2;
						ptr = ref this.global1.data[3];
						ptr += 2;
						ptr = ref this.global1.data[5];
						ref int ptr307 = ref ptr;
						num = ptr;
						ptr307 = num + 1;
					}
					if (this.global1.science[1])
					{
						ptr = ref this.global1.data[1];
						ptr += 2;
						ptr = ref this.global1.data[9];
						ptr += 2;
						ptr = ref this.global1.data[4];
						ptr -= 2;
					}
					if (this.global1.science[2])
					{
						ptr = ref this.global1.data[1];
						ptr += 4;
						ptr = ref this.global1.data[2];
						ptr += 4;
						ptr = ref this.global1.data[10];
						ptr -= 3;
					}
					if (this.global1.science[3])
					{
						ptr = ref this.global1.data[8];
						ptr += 2;
						ptr = ref this.global1.data[5];
						ptr += 2;
					}
					if (this.global1.science[4])
					{
						ptr = ref this.global1.data[1];
						ref int ptr308 = ref ptr;
						num = ptr;
						ptr308 = num + 1;
						ptr = ref this.global1.data[5];
						ref int ptr309 = ref ptr;
						num = ptr;
						ptr309 = num + 1;
					}
					if (this.global1.science[5])
					{
						ptr = ref this.global1.data[8];
						ptr += 2;
						ptr = ref this.global1.data[5];
						ptr += 3;
						ptr = ref this.global1.data[22];
						ptr += 3;
					}
					if (this.global1.science[6])
					{
						ptr = ref this.global1.data[5];
						ptr += 2;
						ptr = ref this.global1.data[1];
						ptr += 2;
						ptr = ref this.global1.data[22];
						ref int ptr310 = ref ptr;
						num = ptr;
						ptr310 = num + 1;
					}
					if (this.global1.science[7])
					{
						ptr = ref this.global1.data[4];
						ref int ptr311 = ref ptr;
						num = ptr;
						ptr311 = num + 1;
						ptr = ref this.global1.data[22];
						ptr += 2;
					}
					if (this.global1.science[8])
					{
						ptr = ref this.global1.data[4];
						ref int ptr312 = ref ptr;
						num = ptr;
						ptr312 = num - 1;
						ptr = ref this.global1.data[22];
						ref int ptr313 = ref ptr;
						num = ptr;
						ptr313 = num + 1;
						ptr = ref this.global1.data[5];
						ptr += 2;
					}
				}
				else if (this.global1.data[0] >= 49 && this.global1.data[0] <= 51)
				{
					if (this.global1.data[114] != 100)
					{
						if (this.global1.science[0])
						{
							ptr = ref this.global1.data[4];
							ref int ptr314 = ref ptr;
							num = ptr;
							ptr314 = num - 1;
							ptr = ref this.global1.data[3];
							ref int ptr315 = ref ptr;
							num = ptr;
							ptr315 = num + 1;
							ptr = ref this.global1.data[8];
							ref int ptr316 = ref ptr;
							num = ptr;
							ptr316 = num - 1;
						}
						if (this.global1.science[1])
						{
							ptr = ref this.global1.data[9];
							ptr += 3;
							ptr = ref this.global1.data[1];
							ptr += 4;
							ptr = ref this.global1.data[22];
							ref int ptr317 = ref ptr;
							num = ptr;
							ptr317 = num + 1;
						}
						if (this.global1.science[2])
						{
							ptr = ref this.global1.data[1];
							ptr += 2;
							ptr = ref this.global1.data[9];
							ptr += 3;
							ptr = ref this.global1.data[6];
							ref int ptr318 = ref ptr;
							num = ptr;
							ptr318 = num + 1;
						}
						if (this.global1.science[6])
						{
							ptr = ref this.global1.data[3];
							ptr += 2;
							ptr = ref this.global1.data[4];
							ref int ptr319 = ref ptr;
							num = ptr;
							ptr319 = num + 1;
							if (this.global1.data[6] >= 300)
							{
								ptr = ref this.global1.data[6];
								ref int ptr320 = ref ptr;
								num = ptr;
								ptr320 = num - 1;
							}
						}
						if (this.global1.science[7])
						{
							ptr = ref this.global1.data[1];
							ref int ptr321 = ref ptr;
							num = ptr;
							ptr321 = num + 1;
							ptr = ref this.global1.data[4];
							ptr -= 2;
							ptr = ref this.global1.data[6];
							ref int ptr322 = ref ptr;
							num = ptr;
							ptr322 = num + 1;
						}
						if (this.global1.science[8])
						{
							ptr = ref this.global1.data[3];
							ptr += 6;
							ptr = ref this.global1.data[4];
							ptr += 2;
							ptr = ref this.global1.data[22];
							ref int ptr323 = ref ptr;
							num = ptr;
							ptr323 = num + 1;
						}
					}
					else
					{
						if (this.global1.science[1])
						{
							ptr = ref this.global1.data[1];
							ptr += 4;
							ptr = ref this.global1.data[22];
							ref int ptr324 = ref ptr;
							num = ptr;
							ptr324 = num + 1;
						}
						if (this.global1.science[2])
						{
							ptr = ref this.global1.data[4];
							ptr -= 2;
							ptr = ref this.global1.data[8];
							ptr -= 2;
						}
						if (this.global1.science[6])
						{
							ptr = ref this.global1.data[4];
							ptr -= 2;
							ptr = ref this.global1.data[22];
							ref int ptr325 = ref ptr;
							num = ptr;
							ptr325 = num + 1;
						}
						if (this.global1.science[7])
						{
							ptr = ref this.global1.data[3];
							ptr += 2;
							ptr = ref this.global1.data[9];
							ref int ptr326 = ref ptr;
							num = ptr;
							ptr326 = num + 1;
						}
						if (this.global1.science[8])
						{
							ptr = ref this.global1.data[4];
							ptr -= 2;
							ptr = ref this.global1.data[3];
							ptr += 2;
							ptr = ref this.global1.data[8];
							ptr += 2;
						}
					}
					if (this.global1.science[3] && (!this.global1.allcountries[7].isSEV || !this.global1.allcountries[this.global1.data[0]].isSEV) && !this.global1.allcountries[this.global1.data[0]].isOVD)
					{
						ptr = ref this.global1.data[8];
						ptr += 2;
						if (this.global1.data[6] >= 500)
						{
							ptr = ref this.global1.data[6];
							ref int ptr327 = ref ptr;
							num = ptr;
							ptr327 = num - 1;
						}
						ptr = ref this.global1.data[10];
						ptr -= 2;
					}
					if (this.global1.science[4])
					{
						ptr = ref this.global1.data[10];
						ptr -= 2;
					}
					if (this.global1.science[5])
					{
						ptr = ref this.global1.data[9];
						ptr += 3;
						ptr = ref this.global1.data[22];
						ptr += 2;
						ptr = ref this.global1.data[1];
						ptr += 2;
						ptr = ref this.global1.data[8];
						ptr += 2;
						ptr = ref this.global1.data[10];
						ptr += 2;
					}
					if (this.global1.science[9])
					{
						ptr = ref this.global1.data[8];
						ptr += 2;
						ptr = ref this.global1.data[9];
						ptr += 3;
						ptr = ref this.global1.data[1];
						ptr += 2;
						ptr = ref this.global1.data[3];
						ptr += 2;
						ptr = ref this.global1.data[4];
						ptr += 2;
					}
				}
				else
				{
					if (this.global1.science[0])
					{
						ptr = ref this.global1.data[4];
						ptr -= 2;
						ptr = ref this.global1.data[9];
						ptr += 2;
						ptr = ref this.global1.data[1];
						ptr += 2;
					}
					if (this.global1.science[1])
					{
						ptr = ref this.global1.data[4];
						ptr -= 2;
						ptr = ref this.global1.data[1];
						ptr += 2;
						ptr = ref this.global1.data[3];
						ptr += 2;
					}
					if (this.global1.science[2])
					{
						ptr = ref this.global1.data[1];
						ptr += 6;
						ptr = ref this.global1.data[3];
						ptr += 2;
					}
					if (this.global1.science[3])
					{
						ptr = ref this.global1.data[8];
						ptr += 2;
						ptr = ref this.global1.data[5];
						ptr += 2;
					}
					if (this.global1.science[4])
					{
						ptr = ref this.global1.data[8];
						ptr += 4;
						ptr = ref this.global1.data[5];
						ptr += 2;
					}
					if (this.global1.science[5])
					{
						ptr = ref this.global1.data[8];
						ptr += 2;
						ptr = ref this.global1.data[5];
						ptr += 2;
						ptr = ref this.global1.data[22];
						ptr += 2;
					}
					if (this.global1.science[6])
					{
						ptr = ref this.global1.data[22];
						ptr += 2;
						ptr = ref this.global1.data[5];
						ptr += 2;
					}
					if (this.global1.science[7])
					{
						ptr = ref this.global1.data[22];
						ptr += 2;
						ptr = ref this.global1.data[5];
						ptr += 2;
						ptr = ref this.global1.data[8];
						ptr += 2;
					}
					if (this.global1.science[8])
					{
						ptr = ref this.global1.data[4];
						ptr -= 2;
						ptr = ref this.global1.data[5];
						ptr += 3;
						ptr = ref this.global1.data[3];
						ptr += 2;
					}
				}
				if (this.global1.science[9])
				{
					ptr = ref this.global1.data[2];
					ptr -= 2;
					ptr = ref this.global1.data[10];
					ref int ptr328 = ref ptr;
					num = ptr;
					ptr328 = num + 1;
					ptr = ref this.global1.data[22];
					ptr += 6;
					ptr = ref this.global1.data[1];
					ptr += 6;
				}
			}
			Debug.Log("SCIENCEDONE");
			for (int num52 = 1; num52 < 11; num52 = num + 1)
			{
				if (num52 != 8)
				{
					if (this.global1.data[num52] < 0 && num52 != 9)
					{
						this.global1.data[num52] = 0;
					}
					else if (this.global1.data[num52] > 1000 && num52 != 7 && num52 != 4)
					{
						this.global1.data[num52] = 1000;
					}
					else if (this.global1.data[num52] > 1500 && num52 == 4)
					{
						this.global1.data[num52] = 1500;
					}
				}
				num = num52;
			}
			int num53 = 0;
			for (int num54 = 0; num54 < this.global1.science_time.Length; num54 = num + 1)
			{
				if (this.global1.science_time[num54] > 0 && this.global1.science_time[num54] < 360)
				{
					num = num53;
					num53 = num + 1;
				}
				num = num54;
			}
			num = num53;
			num53 = num - 1;
			for (int num55 = 0; num55 < this.global1.science_time.Length; num55 = num + 1)
			{
				if (this.global1.science_time[num55] > 0 && this.global1.science_time[num55] < 360)
				{
					this.global1.neizucheno = false;
					int num56 = this.global1.science_time[num55];
					for (int num57 = 0; num57 < 15; num57 = num + 1)
					{
						if ((this.global1.regions[0].buildings[num57].type == 25 || this.global1.regions[0].buildings[num57].type == 9 || this.global1.regions[0].buildings[num57].type == 3 || this.global1.regions[0].buildings[num57].type == 16 || this.global1.regions[0].buildings[num57].type == 14) && this.global1.regions[0].buildings[num57].is_builded && this.global1.regions[0].buildings[num57].is_working)
						{
							ptr = ref this.global1.science_time[num55];
							ref int ptr329 = ref ptr;
							num = ptr;
							ptr329 = num + 1;
						}
						if ((this.global1.regions[1].buildings[num57].type == 25 || this.global1.regions[1].buildings[num57].type == 9 || this.global1.regions[1].buildings[num57].type == 3 || this.global1.regions[1].buildings[num57].type == 16 || this.global1.regions[1].buildings[num57].type == 14) && this.global1.regions[1].buildings[num57].is_builded && this.global1.regions[1].buildings[num57].is_working)
						{
							ptr = ref this.global1.science_time[num55];
							ref int ptr330 = ref ptr;
							num = ptr;
							ptr330 = num + 1;
						}
						if ((this.global1.regions[2].buildings[num57].type == 25 || this.global1.regions[2].buildings[num57].type == 9 || this.global1.regions[2].buildings[num57].type == 3 || this.global1.regions[2].buildings[num57].type == 16 || this.global1.regions[2].buildings[num57].type == 14) && this.global1.regions[2].buildings[num57].is_builded && this.global1.regions[2].buildings[num57].is_working)
						{
							ptr = ref this.global1.science_time[num55];
							ref int ptr331 = ref ptr;
							num = ptr;
							ptr331 = num + 1;
						}
						if ((this.global1.regions[3].buildings[num57].type == 25 || this.global1.regions[3].buildings[num57].type == 9 || this.global1.regions[3].buildings[num57].type == 3 || this.global1.regions[3].buildings[num57].type == 16 || this.global1.regions[3].buildings[num57].type == 14) && this.global1.regions[3].buildings[num57].is_builded && this.global1.regions[3].buildings[num57].is_working)
						{
							ptr = ref this.global1.science_time[num55];
							ref int ptr332 = ref ptr;
							num = ptr;
							ptr332 = num + 1;
						}
						if ((this.global1.regions[4].buildings[num57].type == 25 || this.global1.regions[4].buildings[num57].type == 9 || this.global1.regions[4].buildings[num57].type == 3 || this.global1.regions[4].buildings[num57].type == 16 || this.global1.regions[4].buildings[num57].type == 14) && this.global1.regions[4].buildings[num57].is_builded && this.global1.regions[4].buildings[num57].is_working)
						{
							ptr = ref this.global1.science_time[num55];
							ref int ptr333 = ref ptr;
							num = ptr;
							ptr333 = num + 1;
						}
						num = num57;
					}
					if ((this.global1.data[12] == 5 && this.global1.data[0] == 4) || (this.global1.data[12] == 5 && this.global1.data[0] == 12) || (this.global1.data[13] == 9 && this.global1.data[0] == 18) || (this.global1.data[13] == 8 && this.global1.data[0] == 20) || (this.global1.data[12] == 4 && this.global1.data[0] == 10))
					{
						ptr = ref this.global1.science_time[num55];
						ref int ptr334 = ref ptr;
						num = ptr;
						ptr334 = num + 1;
					}
					ptr = ref this.global1.science_time[num55];
					ptr -= num53;
					if (this.global1.science_time[num55] < num56)
					{
						this.global1.science_time[num55] = num56;
					}
					if (this.global1.science_time[num55] >= 360)
					{
						this.izuchenp = true;
						this.sci_num = num55;
					}
				}
				else if (this.global1.science_time[num55] >= 360 && !this.global1.science[num55])
				{
					this.global1.science[num55] = true;
					if (this.global1.data[0] == 10 || this.global1.data[0] == 12 || this.global1.data[0] == 18)
					{
						if (num55 == 3)
						{
							ptr = ref this.global1.data[24];
							ptr -= 3;
						}
						else if (num55 == 4)
						{
							ptr = ref this.global1.data[24];
							ref int ptr335 = ref ptr;
							num = ptr;
							ptr335 = num - 1;
							int num58 = 1;
							for (int num59 = 0; num59 < 15; num59 = num + 1)
							{
								if (!this.global1.regions[2].buildings[num59].is_builded)
								{
									this.global1.regions[2].buildings[num59].type = 2;
									this.global1.regions[2].buildings[num59].is_working = true;
									this.global1.regions[2].buildings[num59].is_private = false;
									this.global1.regions[2].buildings[num59].is_builded = true;
									num = num58;
									num58 = num + 1;
								}
								if (num58 > 1)
								{
									break;
								}
								num = num59;
							}
						}
						else if (num55 == 5 || num55 == 8)
						{
							ptr = ref this.global1.data[24];
							ptr -= 2;
						}
						else if (num55 == 6)
						{
							ptr = ref this.global1.data[24];
							ref int ptr336 = ref ptr;
							num = ptr;
							ptr336 = num - 1;
						}
						else if (num55 == 7)
						{
							ptr = ref this.global1.data[24];
							ref int ptr337 = ref ptr;
							num = ptr;
							ptr337 = num - 1;
							int num60 = 1;
							for (int num61 = 0; num61 < 15; num61 = num + 1)
							{
								if (!this.global1.regions[2].buildings[num61].is_builded)
								{
									this.global1.regions[2].buildings[num61].type = 1;
									this.global1.regions[2].buildings[num61].is_working = true;
									this.global1.regions[2].buildings[num61].is_private = false;
									this.global1.regions[2].buildings[num61].is_builded = true;
									num = num60;
									num60 = num + 1;
								}
								if (num60 > 1)
								{
									break;
								}
								num = num61;
							}
						}
					}
					else
					{
						if (num55 > 2 && num55 < 6)
						{
							ptr = ref this.global1.data[24];
							ptr -= 3;
						}
						else if (num55 > 5 && num55 < 7)
						{
							ptr = ref this.global1.data[24];
							ptr -= 2;
						}
						if (num55 > 7 && num55 < 9)
						{
							ptr = ref this.global1.data[24];
							ptr -= 5;
						}
					}
				}
				num = num55;
			}
			Debug.Log("RESEARCHDONE");
			if (this.global1.data[19] % 7 == 0)
			{
				for (int num62 = 1; num62 < array.Length; num62 = num + 1)
				{
					this.global1.data_old[num62] = this.global1.data[num62] - array[num62];
					num = num62;
				}
			}
			if (this.global1.data[3] + this.global1.data[22] / 100 <= 150)
			{
				if (this.global1.event_done[163])
				{
					this.crisis_event[1] = false;
					this.global1.data[46] = 1;
					GameObject.Find("Button (4)").GetComponent<EvetnnashScript>().new_scene = "Ending";
					GameObject.Find("Button (4)").GetComponent<EvetnnashScript>().OnMouseDown();
				}
				else
				{
					this.crisis_event[1] = true;
					this.DeathChoose(163);
				}
			}
			else if (this.global1.data[4] - this.global1.data[22] / 10 >= 990 || (this.global1.data[3] <= 300 && this.global1.data[4] - this.global1.data[22] / 10 >= 900) || (this.global1.data[3] <= 500 && this.global1.data[4] - this.global1.data[22] / 10 >= 950))
			{
				if (this.global1.event_done[162])
				{
					this.crisis_event[0] = false;
					this.global1.data[46] = 2;
					GameObject.Find("Button (4)").GetComponent<EvetnnashScript>().new_scene = "Ending";
					GameObject.Find("Button (4)").GetComponent<EvetnnashScript>().OnMouseDown();
				}
				else
				{
					this.crisis_event[0] = true;
					this.DeathChoose(162);
				}
			}
			else if ((this.global1.data[0] != 3 || this.global1.data[11] != 3) && (this.global1.data[1] < 250 || (!this.global1.allcountries[this.global1.data[0]].isOVD && this.global1.allcountries[this.global1.data[0]].Vyshi && this.global1.data[1] < 400 && this.global1.data[2] + this.global1.data[22] / 5 <= 100) || ((this.global1.allcountries[this.global1.data[0]].isOVD || !this.global1.allcountries[this.global1.data[0]].Vyshi) && this.global1.data[1] < 400 && this.global1.data[2] + this.global1.data[22] / 5 <= 400)))
			{
				if (this.global1.event_done[164])
				{
					this.crisis_event[2] = false;
					this.global1.data[46] = 3;
					GameObject.Find("Button (4)").GetComponent<EvetnnashScript>().new_scene = "Ending";
					GameObject.Find("Button (4)").GetComponent<EvetnnashScript>().OnMouseDown();
				}
				else
				{
					this.crisis_event[2] = true;
					this.DeathChoose(164);
				}
			}
			if (this.global1.data[19] == 1 && this.global1.data[20] == 1 && this.global1.data[21] == 1992)
			{
				this.Reborn();
			}
			if (this.global1.data[19] == 15 && this.global1.data[20] == 8 && this.global1.data[21] == 1991 && !this.global1.allcountries[22].Donat)
			{
				this.global1.allcountries[22].Gosstroy = 9;
				this.global1.allcountries[22].subideology = 0;
			}
			if (this.global1.data[20] == 5 && this.global1.data[21] == 1991 && !this.global1.allcountries[35].Donat)
			{
				this.global1.allcountries[35].Gosstroy = 9;
				this.global1.allcountries[35].subideology = 0;
			}
			Debug.Log("END");
			if (this.global1.data[21] >= 1992)
			{
				if (this.global1.data[21] >= 1995)
				{
					if (!this.global1.allcountries[28].Vyshi)
					{
						this.global1.allcountries[28].Vyshi = true;
					}
					if (!this.global1.allcountries[27].Vyshi && this.global1.allcountries[7].Vyshi)
					{
						this.global1.allcountries[27].Vyshi = true;
					}
					if (!this.global1.allcountries[26].Vyshi && !this.global1.allcountries[26].Torg)
					{
						this.global1.allcountries[26].Vyshi = true;
					}
				}
				if (this.global1.data[21] >= 2004)
				{
					if (!this.global1.allcountries[2].Vyshi && !this.global1.allcountries[2].isSEV && !this.global1.allcountries[2].isOVD && this.global1.allcountries[2].Gosstroy >= 2)
					{
						this.global1.allcountries[2].Vyshi = true;
					}
					if (!this.global1.allcountries[3].Vyshi && !this.global1.allcountries[3].isSEV && !this.global1.allcountries[3].isOVD && this.global1.allcountries[3].Gosstroy >= 2)
					{
						this.global1.allcountries[3].Vyshi = true;
					}
					if (!this.global1.allcountries[4].Vyshi && !this.global1.allcountries[4].isSEV && !this.global1.allcountries[4].isOVD && this.global1.allcountries[4].Gosstroy >= 2)
					{
						this.global1.allcountries[4].Vyshi = true;
					}
				}
				if (this.global1.data[21] >= 2007)
				{
					if (!this.global1.allcountries[5].Vyshi && !this.global1.allcountries[5].isSEV && !this.global1.allcountries[5].isOVD && this.global1.allcountries[5].Gosstroy >= 2)
					{
						this.global1.allcountries[5].Vyshi = true;
					}
					if (!this.global1.allcountries[6].Vyshi && !this.global1.allcountries[6].isSEV && !this.global1.allcountries[6].isOVD && this.global1.allcountries[6].Gosstroy >= 2)
					{
						this.global1.allcountries[6].Vyshi = true;
					}
				}
				if (this.global1.data[21] >= 2009 && !this.global1.allcountries[20].Vyshi && !this.global1.allcountries[20].isSEV && !this.global1.allcountries[20].isOVD && this.global1.allcountries[20].Gosstroy >= 2)
				{
					this.global1.allcountries[20].Vyshi = true;
				}
			}
			if (this.global1.allcountries[17].Westalgie < 0)
			{
				this.global1.allcountries[17].Westalgie = 0;
			}
			else if (this.global1.allcountries[17].Westalgie > 1000)
			{
				this.global1.allcountries[17].Westalgie = 1000;
			}
			if (this.global1.data[0] == 18 && this.global1.data[77] == 0)
			{
				this.global1.allcountries[this.global1.data[0]].Vyshi = true;
			}
			if (this.global1.data[57] > 100 && this.global1.data[57] < 1000)
			{
				this.global1.data[57] = 1000;
			}
			if (this.global1.data[0] == 12)
			{
				this.global1.data[80] = 20;
				if (this.global1.data[90] == 1)
				{
					ptr = ref this.global1.data[80];
					ptr += 20;
				}
				if (this.global1.data[92] == 1)
				{
					ptr = ref this.global1.data[80];
					ptr += 20;
				}
				if (this.global1.data[93] == 1)
				{
					ptr = ref this.global1.data[80];
					ptr += 20;
				}
				if (this.global1.data[94] == 1)
				{
					ptr = ref this.global1.data[80];
					ptr += 20;
				}
				if (this.global1.data[88] == 0)
				{
					this.global1.data[107] = 0;
				}
				if (this.global1.data[108] >= 100 && this.global1.data[88] > 0)
				{
					ptr = ref this.global1.data[3];
					ptr += 70;
					ptr = ref this.global1.data[1];
					ptr += 100;
					ptr = ref this.global1.data[2];
					ptr += 120;
					ptr = ref this.global1.data[4];
					ptr -= 90;
					if (this.global1.data[88] == 1)
					{
						int num63;
						if (this.global1.data[107] > 1)
						{
							this.global1.data[this.global1.data[107] + 90] = 1;
							num63 = this.global1.data[107] + 90;
						}
						else
						{
							this.global1.data[90] = 1;
							num63 = 90;
						}
						if (num63 == 93)
						{
							num63 = 0;
						}
						else if (num63 == 92)
						{
							num63 = 1;
						}
						else if (num63 == 90)
						{
							num63 = 3;
						}
						else if (num63 == 94)
						{
							num63 = 4;
						}
						this.global1.regions[num63].buildings[1].type = 1;
						this.global1.regions[num63].buildings[1].is_builded = true;
						this.global1.regions[num63].buildings[1].is_working = true;
						this.global1.regions[num63].buildings[1].is_private = true;
						this.global1.regions[num63].buildings[2].type = 4;
						this.global1.regions[num63].buildings[2].is_builded = true;
						this.global1.regions[num63].buildings[2].is_working = true;
						this.global1.regions[num63].buildings[2].is_private = false;
					}
					this.global1.data[111] = 0;
					this.global1.data[88] = 0;
					this.global1.data[107] = 0;
					this.global1.data[108] = 0;
				}
				else if (this.global1.data[108] <= 0 && this.global1.data[88] > 0)
				{
					ptr = ref this.global1.data[3];
					ptr -= 70;
					ptr = ref this.global1.data[1];
					ptr -= 100;
					ptr = ref this.global1.data[4];
					ptr += 90;
					if (this.global1.data[88] == 2)
					{
						if (this.global1.data[107] > 9)
						{
							this.global1.data[46] = 11;
							SceneManager.LoadScene("Ending");
						}
						else
						{
							int num64;
							if (this.global1.data[107] > 1)
							{
								this.global1.data[this.global1.data[107] + 90] = 0;
								num64 = this.global1.data[107] + 90;
							}
							else
							{
								this.global1.data[90] = 0;
								num64 = 90;
							}
							if (num64 == 93)
							{
								num64 = 0;
							}
							else if (num64 == 92)
							{
								num64 = 1;
							}
							else if (num64 == 90)
							{
								num64 = 3;
							}
							else if (num64 == 94)
							{
								num64 = 4;
							}
							for (int num65 = 0; num65 < 15; num65 = num + 1)
							{
								this.global1.regions[num64].buildings[num65].type = 0;
								this.global1.regions[num64].buildings[num65].is_working = false;
								this.global1.regions[num64].buildings[num65].is_private = false;
								this.global1.regions[num64].buildings[num65].is_builded = false;
								num = num65;
							}
						}
					}
					this.global1.data[111] = 0;
					this.global1.data[88] = 0;
					this.global1.data[107] = 0;
					this.global1.data[108] = 0;
				}
			}
			if (this.global1.iron_and_blood)
			{
				if (this.global1.data[19] == 1 && this.global1.data[20] == 1 && this.global1.data[21] == 1990)
				{
					this.achieves.GetComponent<achievements>().Set(1);
					int num66 = 0;
					for (int num67 = 0; num67 < 7; num67 = num + 1)
					{
						if (this.global1.allcountries[num67].Gosstroy == 0 && this.global1.data[0] != num67 && num67 != 4)
						{
							num = num66;
							num66 = num + 1;
						}
						num = num67;
					}
					if (this.global1.allcountries[4].Gosstroy == 1)
					{
						num = num66;
						num66 = num + 1;
					}
					if (num66 >= 5)
					{
						this.achieves.GetComponent<achievements>().Set(2);
					}
				}
				if (this.global1.data[0] == 49 && this.yug1.gameState.yugregions[0].owner == 8 && this.yug1.gameState.yugregions[1].owner == 8 && this.yug1.gameState.yugregions[2].owner == 8 && this.yug1.gameState.yugregions[3].owner == 8 && this.yug1.gameState.yugregions[4].owner == 8 && this.yug1.gameState.yugregions[5].owner == 8 && this.yug1.gameState.yugregions[6].owner == 8 && this.yug1.gameState.yugregions[7].owner == 8 && this.yug1.gameState.yugregions[8].owner == 8 && this.yug1.gameState.yugregions[9].owner == 8 && this.yug1.gameState.yugregions[10].owner == 8 && this.yug1.gameState.yugregions[11].owner == 8 && this.global1.data[162] != 3)
				{
					this.achieves.GetComponent<achievements>().Set(120);
				}
				if (this.global1.data[155] == 3)
				{
					if (this.global1.data[118] == 1 && this.global1.data[116] == 1 && this.global1.data[137] == 0 && this.global1.data[136] == 1 && this.global1.data[130] == 3 && this.global1.data[148] == 1 && this.global1.data[150] == 1 && this.global1.data[156] == 4 && this.global1.data[157] == 2 && (this.global1.data[176] == 2 || this.global1.data[176] == 7 || this.global1.data[176] == 8))
					{
						this.achieves.GetComponent<achievements>().Set(124);
					}
				}
				else if (this.global1.data[118] == 1 && this.global1.data[116] == 1 && this.global1.data[137] == 0 && this.global1.data[136] == 1 && this.global1.data[130] == 3 && this.global1.data[148] == 1 && this.global1.data[150] == 1 && this.global1.data[156] == 4 && this.global1.data[157] == 2)
				{
					this.achieves.GetComponent<achievements>().Set(124);
				}
				Debug.Log("ACHIEVDONE");
			}
			this.Recrisis();
			if (this.vybory)
			{
				this.Reelect();
			}
			else if (this.global1.data[0] >= 49 && this.global1.data[0] <= 51)
			{
				this.CheckYugoWars();
			}
			if (this.global1.autosave > 0)
			{
				if (this.global1.autosave == 1 && this.global1.data[19] == 1)
				{
					this.Autosasvemethod();
				}
				else if (this.global1.autosave == 2 && this.global1.data[19] == 1 && this.global1.data[20] == 6)
				{
					this.Autosasvemethod();
				}
			}
		}
		base.GetComponent<TextMesh>().text = string.Concat(new object[]
		{
			this.global1.data[19],
			".",
			this.global1.data[20],
			".",
			this.global1.data[21]
		});
	}

	// Token: 0x04000219 RID: 537
	public GameObject ending;

	// Token: 0x0400021A RID: 538
	public GameObject view;

	// Token: 0x0400021B RID: 539
	public bool is_showed;

	// Token: 0x0400021C RID: 540
	private int save_speed;

	// Token: 0x0400021D RID: 541
	private int this_num_event;

	// Token: 0x0400021E RID: 542
	private int this_num_place;

	// Token: 0x0400021F RID: 543
	private GlobalScript global1;

	// Token: 0x04000220 RID: 544
	private Yugoglobal yug1;

	// Token: 0x04000221 RID: 545
	public float now_time;

	// Token: 0x04000222 RID: 546
	private EvetnnashScript goto_economy;

	// Token: 0x04000223 RID: 547
	private SpeedScript goto_pause;

	// Token: 0x04000224 RID: 548
	public GameObject thishappened;

	// Token: 0x04000225 RID: 549
	public GameObject newcountries;

	// Token: 0x04000226 RID: 550
	public GameObject probel;

	// Token: 0x04000227 RID: 551
	public SpriteRenderer[] crisis = new SpriteRenderer[8];

	// Token: 0x04000228 RID: 552
	public TextMesh[] crisis_color = new TextMesh[8];

	// Token: 0x04000229 RID: 553
	public bool vybory;

	// Token: 0x0400022A RID: 554
	private GameObject achieves;

	// Token: 0x0400022B RID: 555
	public Sprite[] crisis_spr = new Sprite[2];

	// Token: 0x0400022C RID: 556
	public GameObject crisis_show;

	// Token: 0x0400022D RID: 557
	public GameObject[] special = new GameObject[2];

	// Token: 0x0400022E RID: 558
	private bool donedone;

	// Token: 0x0400022F RID: 559
	public at_war_script[] re_war = new at_war_script[9];

	// Token: 0x04000230 RID: 560
	public bool izuchenp;

	// Token: 0x04000231 RID: 561
	private int sci_num;

	// Token: 0x04000232 RID: 562
	public Savescript Autosavej;

	// Token: 0x04000233 RID: 563
	public bool[] crisis_event = new bool[3];

	// Token: 0x04000234 RID: 564
	public YugoMapManager yug_little;

	// Token: 0x04000235 RID: 565
	private MapChangesScript map1;

	// Token: 0x04000236 RID: 566
	public GameObject[] events = new GameObject[26];
}
