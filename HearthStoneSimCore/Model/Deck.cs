﻿using System.Collections.Generic;

namespace HearthStoneSimCore.Model
{
    public class Deck
    {
        public List<Card> Cards = new List<Card>();
        public int StartingCards { get; set; } = 30;

        public void Add(Card card)
        {
            Cards.Add(card);
        }
    }
}