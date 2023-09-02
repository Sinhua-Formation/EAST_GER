using System;
using UnityEngine;

// Token: 0x0200005B RID: 91
public class TutorialScript : MonoBehaviour
{
	// Token: 0x060001C3 RID: 451 RVA: 0x0018C480 File Offset: 0x0018A680
	private void Repaint()
	{
		if (PlayerPrefs.GetInt("language") == 0)
		{
			this.shower.sprite = this.slides_en[this.now];
			if (this.now_text == 0)
			{
				this.text_this = "Hello, comrade! This is your first time in the game and do not know what to do? No problem, now I will teach you to govern the country!";
			}
			else if (this.now_text == 1)
			{
				this.text_this = "This is the screen of diplomacy, on which the main action of this game takes place. By clicking on the countries you can see what diplomatic actions you can perform with them and what you need for this";
			}
			else if (this.now_text == 2)
			{
				this.text_this = "In the upper left corner, the date and speed icons are displayed. \"Ostalgie\" is a real-time game, so for progress you will need to click on one of the lines below the date to set the speed. ";
			}
			else if (this.now_text == 3)
			{
				this.text_this = "Clicking on the corresponding button on the same panel, you can at any time put the game on pause, as you can do this by pressing the Space.";
			}
			else if (this.now_text == 4)
			{
				this.text_this = "Events will appear in the course of time in the game and will be displayed with such icon. By clicking on it you will go to the event itself and decide how to proceed.";
			}
			else if (this.now_text == 5)
			{
				this.text_this = "The game will be paused and will stay on it until you remove it. Thus, there is no need to press a pause when there are several events, you can simply click on one of them.";
			}
			else if (this.now_text == 6)
			{
				this.text_this = "At the top of the diplomacy screen are the numerical indicators of the situation in your country, which change every 7 days. By hovering over them, you will find out what they mean and how much they have changed in the last week.";
			}
			else if (this.now_text == 7)
			{
				this.text_this = "Under the indicators there are buttons for switching to other screens. Let's start with politics.";
			}
			else if (this.now_text == 8)
			{
				this.text_this = "Here you can see the leaders of your state and change them.";
			}
			else if (this.now_text == 9)
			{
				this.text_this = "Also here you can see and change the laws and doctrines of your state grouped into spheres - you can raise or lower the liberalization in a certain sphere once a month, it also rises and falls by events.";
			}
			else if (this.now_text == 10)
			{
				this.text_this = "Also here is the NATO threat indicator, which is responsible for how much NATO wants to \"bring democracy and peace\" to your country, let's say it's relations with the US. Until the end of the game, the invasion does not awaits you, so do not worry.";
			}
			else if (this.now_text == 11)
			{
				this.text_this = "The number of agent networks is a conditional indicator of the strength of your special services. They are expended for actions in diplomacy and events and are restored with time depending on your buildings.";
			}
			else if (this.now_text == 12)
			{
				this.text_this = "Now about the economy.";
			}
			else if (this.now_text == 13)
			{
				this.text_this = "Here you can see the buildings built, distributed by region and build new ones. By clicking on the + icon you can build one of the proposed buildings and see what effect it will give and how much it costs.";
			}
			else if (this.now_text == 14)
			{
				this.text_this = "All buildings can be demolished to make room, or temporarily suspend their work, which is usually more profitable. Many buildings can also be privatized in order to receive money, but only under market economy or a negative budget. ";
			}
			else if (this.now_text == 15)
			{
				this.text_this = "The number of vacant places for buildings is limited and determined by the level of the region. The level can be improved, but it costs money and the higher the level, the higher the cost, so sometimes it may be more useful to demolish any building.";
			}
			else if (this.now_text == 16)
			{
				this.text_this = "This is science. Here you can choose which technology from the three branches (+ nuclear weapons) to study and suspend this process.";
			}
			else if (this.now_text == 17)
			{
				this.text_this = "The beginning of the study of each technology costs 1 point of money. At the same time, you can study all 4 technologies, but the speed of learning in this case slows down.";
			}
			else if (this.now_text == 18)
			{
				this.text_this = "The very speed of learning depends on the number of buildings that develop science. After a full study of each branch of technology you will receive an associated event from which you can also profit.";
			}
			else if (this.now_text == 19)
			{
				this.text_this = "Next is the view screen";
			}
			else if (this.now_text == 20)
			{
				this.text_this = "Here are some details of your country's situation and its impact - the number of trade partners, imports and exports, sovereignty, Soviet aid, etc. (It is also possible to switch between the buttons of the view)";
			}
			else if (this.now_text == 21)
			{
				this.text_this = "However, if you want to win in Afghanistan or to see a single Yugoslavia - the control of their government over the country should be 100% and not less.";
			}
			else if (this.now_text == 22)
			{
				this.text_this = "Last screen - statistics.";
			}
			else if (this.now_text == 23)
			{
				this.text_this = "Here are the real indicators of the selected country for each month of 1989-1991 and your indicators. There is no influence of this screen on the gameplay, but here you can find out if you did better than it was in real history.";
			}
			else if (this.now_text == 24)
			{
				this.text_this = "Well, that's about it. Of course, there are a few more minor nuances, but them you can now learn in the game.";
			}
			else if (this.now_text == 25)
			{
				this.text_this = "Forward to a brighter future, comrade!";
			}
		}
		else
		{
			this.shower.sprite = this.slides_ru[this.now];
			if (this.now_text == 0)
			{
				this.text_this = "Привет, товарищ! Только зашли в игру и не знаете, что делать? Не беда, сейчас я научу вас управлять страной!";
			}
			else if (this.now_text == 1)
			{
				this.text_this = "Это - экран дипломатии, на котором происходит основное действо этой игры. Нажимая на страны вы можете видеть какие дипломатические действия с ними можно выполнять и что для этого нужно";
			}
			else if (this.now_text == 2)
			{
				this.text_this = "В левом верхнем углу показана дата и значки скорости хода игры. \"Остальгия\" - игра в реальном времени, так что для продвижения вам нужно будет нажать на одну из чёрточек под датой, которые и устанавливают скорость. ";
			}
			else if (this.now_text == 3)
			{
				this.text_this = "Нажав на соответствующую кнопку на всё той же панели, вы можете в любой момент поставить игру на паузу, так же это можно сделать, нажав на клавишу Пробел.";
			}
			else if (this.now_text == 4)
			{
				this.text_this = "События будут появляться по ходу времени в игре и будут отображаться вот таким значком. Нажав на него вы перейдте к самому событию и будете решать, как поступить.";
			}
			else if (this.now_text == 5)
			{
				this.text_this = "Игра при этом поставится на паузу и будет на ней стоять, пока вы сами её не снимете. Таким образом необходимости нажимать паузу при наличии нескольких событий нет, можно просто нажать на одно из них.";
			}
			else if (this.now_text == 6)
			{
				this.text_this = "Наверху экрана дипломатии есть численные показатели ситуации в вашей стране, которые меняются каждые 7 дней. Наведя на них курсор, вы узнаете, что они значат и насколько они изменились за последнюю неделю.";
			}
			else if (this.now_text == 7)
			{
				this.text_this = "Под показателями расположены кнопки перехода на другие экраны. Начнём с политики.";
			}
			else if (this.now_text == 8)
			{
				this.text_this = "Здесь вы можете видеть первых лиц вашего государства и менять их.";
			}
			else if (this.now_text == 9)
			{
				this.text_this = "Также здесь можно видеть и менять законы и доктрины вашего государства, сгруппированные в области - можно раз в месяц повышать или понижать либерализацию в определённой области, также она повышается и понижается по событиям.";
			}
			else if (this.now_text == 10)
			{
				this.text_this = "Ещё здесь расположен показатель угрозы НАТО, который отвечает за то, насколько НАТО хочет \"принести демократию и мир\" в вашу страну, можно сказать, это отношения с США. До конца игры вторжение вас не ждёт, так что не беспокойтесь.";
			}
			else if (this.now_text == 11)
			{
				this.text_this = "Количество агентурных сетей - это условный показатель силы ваших спецслужб. Они расходуются для действий в дипломатии и событиях и восстанавливаются со временем в зависимости от ваших построек.";
			}
			else if (this.now_text == 12)
			{
				this.text_this = "Теперь об экономике.";
			}
			else if (this.now_text == 13)
			{
				this.text_this = "Здесь вы можете видеть построенные здания, распределённые по регионам и строить новые. Нажав на значок + вы можете построить одно из предложенных зданий и увидеть, какой эффект оно даст и сколько стоит.";
			}
			else if (this.now_text == 14)
			{
				this.text_this = "Все здания можно снести, чтобы освободить место, или временно приостановить их работу, что обычно выгоднее. Многие здания также можно приватизировать, чтобы получить деньги, но только при рыночной экномике или отрицательном бюджете. ";
			}
			else if (this.now_text == 15)
			{
				this.text_this = "Количество свободных мест для постройки ограничено и определяется уровнем региона. Уровень можно улучшить, но это стоит денег и чем больше уровень, тем выше стоимость, так что иногда может быть полезнее снести уже ненужное здание.";
			}
			else if (this.now_text == 16)
			{
				this.text_this = "Это наука. Здесь вы можете выбирать, какую технологию из трёх ветвей (+ ядерное оружие) изучать и приостанавливать этот процесс.";
			}
			else if (this.now_text == 17)
			{
				this.text_this = "Начало изучения каждой технологии стоит 1 очко денег. Одновременно можно изучать хоть 4 технологии, но скорость изучения в данном случае замедляется.";
			}
			else if (this.now_text == 18)
			{
				this.text_this = "Сама скорость изучения зависит от количества у вас развивающих науку зданий. После полного изучения каждой ветки технологий вы получите связанное с ними событие из которого также может извлечь пользу.";
			}
			else if (this.now_text == 19)
			{
				this.text_this = "Дальше идёт экран обзора";
			}
			else if (this.now_text == 20)
			{
				this.text_this = "Здесь показаны некоторые детали положения вашей страны и их влияние - количество торговых партнёров, импорт и экспорт, суверенитет, советская помощь и т.д. (Также присутствует возможность переключаться между кнопками обзора)";
			}
			else if (this.now_text == 21)
			{
				this.text_this = "Однако, если вы хотите победить в Афганистане или очень сильно желаете видеть единую Югославию - контроль их правительства над страной должен быть 100% и никак не менее.";
			}
			else if (this.now_text == 22)
			{
				this.text_this = "Последний экран - статистика.";
			}
			else if (this.now_text == 23)
			{
				this.text_this = "Здесь показаны реальные показатели выбранной страны за каждый месяц 1989-1991 годов и ваши показатели. Какого-либо влияния этот экран на игровой процесс не оказывает, но тут вы можете узнать, сделали ли вы лучше, чем было в реальной истории.";
			}
			else if (this.now_text == 24)
			{
				this.text_this = "Ну и на этом всё. Разумеется, есть ещё несколько мелких нюансов, но с ними вы сможете теперь сами освоиться в процессе игры.";
			}
			else if (this.now_text == 25)
			{
				this.text_this = "Вперёд к светлому будущему, товарищ!";
			}
		}
		this.text.text = this.Text(this.text_this, 30);
		if (this.now_text == 0)
		{
			this.right.GetComponent<TutorialButtonScript>().Show(true);
			this.left.GetComponent<TutorialButtonScript>().Show(false);
			return;
		}
		if (this.now_text == 25)
		{
			this.right.GetComponent<TutorialButtonScript>().Show(false);
			this.left.GetComponent<TutorialButtonScript>().Show(true);
			return;
		}
		this.right.GetComponent<TutorialButtonScript>().Show(true);
		this.left.GetComponent<TutorialButtonScript>().Show(true);
	}

	// Token: 0x060001C4 RID: 452 RVA: 0x0018CA84 File Offset: 0x0018AC84
	public void OnDown(bool isleft)
	{
		if (isleft)
		{
			this.now--;
			this.now_text--;
		}
		else
		{
			if (this.now_text == 0 || this.now_text == 3 || this.now_text == 4 || this.now_text == 5 || this.now_text == 7 || this.now_text == 12 || this.now_text == 15 || this.now_text == 19 || this.now_text == 22)
			{
				this.now++;
			}
			this.now_text++;
		}
		this.Repaint();
	}

	// Token: 0x060001C5 RID: 453 RVA: 0x0018CB28 File Offset: 0x0018AD28
	private void Awake()
	{
		this.Repaint();
	}

	// Token: 0x060001C6 RID: 454 RVA: 0x0018CB30 File Offset: 0x0018AD30
	private string Text(string text, int col)
	{
		int num = 0;
		string text2 = "";
		for (int i = 0; i < text.Length; i++)
		{
			if (text[i] == char.Parse("|"))
			{
				num = 0;
				text2 += "\n";
			}
			else if (num >= col)
			{
				if (text[i] == char.Parse(" "))
				{
					num = 0;
					text2 += "\n";
				}
				else
				{
					text2 += text[i].ToString();
					for (int j = i; j >= 0; j--)
					{
						if (text2[j] == char.Parse(" "))
						{
							text2 = text2.Substring(0, j) + "\n" + text2.Substring(j + 1, text2.Length - 1 - (j + 1) + 1);
							num = text2.Length - 1 - (j + 1) + 1;
							break;
						}
					}
				}
			}
			else
			{
				text2 += text[i].ToString();
				num++;
			}
		}
		return text2;
	}

	// Token: 0x0400028D RID: 653
	public GameObject left;

	// Token: 0x0400028E RID: 654
	public GameObject right;

	// Token: 0x0400028F RID: 655
	public int now;

	// Token: 0x04000290 RID: 656
	public int now_text;

	// Token: 0x04000291 RID: 657
	public TextMesh text;

	// Token: 0x04000292 RID: 658
	private string text_this;

	// Token: 0x04000293 RID: 659
	public Sprite[] slides_en;

	// Token: 0x04000294 RID: 660
	public Sprite[] slides_ru;

	// Token: 0x04000295 RID: 661
	public SpriteRenderer shower;
}
