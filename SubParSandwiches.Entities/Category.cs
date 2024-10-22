﻿using System.Collections.Generic;

namespace SubParSandwiches.Entities
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<Item> Items { get; set; }
    }
}
