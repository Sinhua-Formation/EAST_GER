using System;
using UnityEngine;

// Token: 0x02000005 RID: 5
public class authores : MonoBehaviour
{
	// Token: 0x0600000F RID: 15 RVA: 0x00002818 File Offset: 0x00000A18
	private void Awake()
	{
		if (PlayerPrefs.GetInt("language") == 0)
		{
			this.text1.text = "Ostalgie:\nThe Berlin Wall\n\nLeading developers:\nVasiliy Vladimirovich Kostilev\nMaxim Olegovich Chornobuk";
			this.text4.text = "\nThe game uses the songs of socialist times.\nwww.kremlingames.com";
			this.text2.text = "In the development took part:\nIllarion Soldaev - vk.com/id17834106\nEldar Manyashev - vk.com/id109719499\n\nSpecial thanks:\nGeorgy Emelyanov - vk.com/gogaa24\nIlya Kuznetsov - vk.com/id276119505\nVladimir Gridasov - vk.com/id145067238\nVasiliy Anreyev - vk.com/brutalpin\nМаксим Косицын - vk.com/socialmaxim";
			this.text3.text = "Special thanks:\nДаниил Чумаков\nГеоргий Коршиков - vk.com/id455054985\nАлександр Кучкин - vk.com/sachasaha\nВолкович - vk.com/volkovichstanislav\nАнтон Максимов - vk.com/mash2525\nВиктор Гордеев\nЕгор Клюев - vk.com/trallshaman\nDavid52522\nKeTsarl\nДмитрий Иванов - vk.com/kratos999god";
			return;
		}
		this.text1.text = "Ostalgie:\nБерлинская стена\n\nВедущие разработчики:\nВасилий Владимирович Костылев\nМаксим Олегович Чорнобук";
		this.text4.text = "\nВ игре используются песни\nсоциалистических времён.\nwww.kremlingames.com";
		this.text2.text = "В разработке проекта участвовали:\nИлларион Солдаев - vk.com/id17834106\nЭльдар Маняшев - vk.com/id109719499\n\nОсобая благодарность:\nГеоргий Емельянов - vk.com/gogaa24\nИлья Кузнецов - vk.com/id276119505\nВладимир Гридасов - vk.com/id145067238\nВасилий Андреев - vk.com/brutalpin\nМаксим Косицын - vk.com/socialmaxim";
		this.text3.text = "Особая благодарность:\nДаниил Чумаков\nГеоргий Коршиков - vk.com/id455054985\nАлександр Кучкин - vk.com/sachasaha\nВолкович - vk.com/volkovichstanislav\nАнтон Максимов - vk.com/mash2525\nВиктор Гордеев\nЕгор Клюев - vk.com/trallshaman\nDavid52522\nKeTsarl\nДмитрий Иванов - vk.com/kratos999god";
	}

	// Token: 0x0400000C RID: 12
	public TextMesh text1;

	// Token: 0x0400000D RID: 13
	public TextMesh text2;

	// Token: 0x0400000E RID: 14
	public TextMesh text3;

	// Token: 0x0400000F RID: 15
	public TextMesh text4;
}
