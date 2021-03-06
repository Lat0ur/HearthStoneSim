﻿using HearthStoneSimCore.Auras;
using HearthStoneSimCore.Tasks;

namespace HearthStoneSimCore.Enchants
{
	public class Power
	{
		public string InfoCardId { get; set; } = null;

		public Aura Aura { get; set; }

		public Enchant Enchant { get; set; }

		public Trigger Trigger { get; set; }

		public ISimpleTask PowerTask { get; set; }

		public ISimpleTask DeathrattleTask { get; set; }

		public ISimpleTask ComboTask { get; set; }

		public ISimpleTask TopdeckTask { get; set; }

		//internal static Power OneTurnStealthEnchantmentPower =>
		//	new Power
		//	{
		//		Enchant = new Enchant(Effects.StealthEff),
		//		Trigger = new Trigger(TriggerType.TURN_START)
		//		{
		//			SingleTask = new RemoveEnchantmentTask(),
		//			RemoveAfterTriggered = true,
		//		}
		//	};
	}
}
