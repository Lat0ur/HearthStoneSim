﻿using System.Collections.Generic;
using HearthStoneSimCore.Enums;

namespace HearthStoneSimCore.Model
{
    public interface ICard
   {
      string Id { get; }
      string Name { get; }
      string CardTextInHand { get; }
      string ArtImageSource { get; }
      string FrameImageSource { get; }
      int Cost { get; }
      int Health { get; }
      int Attack { get; }
   }

   public class Card : ICard
   {
      public int this[GameTag t] => Tags.ContainsKey(t) ? Tags[t] : 0;
      public string Id { get; set; }
      public string Name { get; set; }
      public string CardTextInHand { get; set; }
      public string ArtImageSource => @"d:/CardArt/Full/" + Id + ".png";
      public string FrameImageSource => @"../Images/inhand_minion_druid.png";

      public int Cost => this[GameTag.COST];
      public int Health => this[GameTag.HEALTH];
      public int Attack => this[GameTag.ATK];

      public Dictionary<GameTag, int> Tags { get; set; }
      public Dictionary<PlayRequirements, int> Requirements { get; set; }

      public override string ToString() { return Name; }

      //default constructor
      public Card()
      {

      }

      // Cloning copy constructor
      public Card(Card cloneFrom)
      {
         Id = cloneFrom.Id;
         Name = cloneFrom.Name;
         CardTextInHand = cloneFrom.CardTextInHand;

         Tags = new Dictionary<GameTag, int>(cloneFrom.Tags);
      }
   }
}