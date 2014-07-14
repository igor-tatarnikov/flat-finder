using System;

namespace FlatFinder.Init
{
    internal class DatabaseAction
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Action Action { get; set; }
    }
}