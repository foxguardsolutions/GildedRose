﻿using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    public class TicketItemTests
    {
        [TestCase(11, Result = 21)]
        [TestCase(10, Result = 22)]
        [TestCase(6, Result = 22)]
        [TestCase(5, Result = 23)]
        [TestCase(0, Result = 23)]
        [TestCase(-1, Result = 0)]
        public int TicketItemUpdateQualityUpdatesQualityCorrectly(int sellIn)
        {
            TicketItem item = new TicketItem("Speeding Ticket", sellIn, 20);
            item.UpdateQuality();
            return item.Quality;
        }
    }
}
