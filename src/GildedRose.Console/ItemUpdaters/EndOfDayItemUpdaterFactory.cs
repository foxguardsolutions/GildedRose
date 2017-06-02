using System;
using System.Linq;

namespace GildedRose.Console.ItemUpdaters
{
    public static class EndOfDayItemUpdaterFactory
    {
        private static readonly EndOfDayItemUpdater[] _updater = 
            AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => typeof(EndOfDayItemUpdater).IsAssignableFrom(type) && !type.IsAbstract)
                .Select(type => (EndOfDayItemUpdater)Activator.CreateInstance(type))
                .ToArray();

        public static EndOfDayItemUpdater GetItemUpdater(Item item)
        {
            var category = StoreItemIdentifier.GetCategory(item);
            return _updater.Single(updater => updater.Category == category);
        }
    }
}
