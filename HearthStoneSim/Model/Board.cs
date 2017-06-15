﻿using System.CodeDom;
using System.Collections.Generic;
using HearthStoneSim.Model.Enums;
using HearthStoneSim.Model.GameCore;

namespace HearthStoneSim.Model
{
   public class Board
   {
      public List<Core> Cards = new List<Core>();
      public int MaxSize { get; set; } = 7;

      public void Add(Core card)
      {
         if (Cards.Count == MaxSize) return;
         card.Zone = Zone.PLAY;
         Cards.Add(card);
      }

      public void Insert(Core card, int index)
      {
         if (Cards.Count == MaxSize) return;
         card.Zone = Zone.PLAY;
         Cards.Insert(index, card);
      }
   }
}
