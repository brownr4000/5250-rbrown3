﻿using System;
using SQLite;

namespace Mine.Models
{
    /// <summary>
    /// The ItemModel class creates Items for the Characters and Monsters to use
    /// </summary>
    public class ItemModel
    {
        // The Id for the Item using Guid
        [PrimaryKey]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        
        // The Display Text for the Item
        public string Text { get; set; }

        // The Description for the Item
        public string Description { get; set; }

        // The Value if the Item is +9 Damage
        public int Value { get; set; } = 0;
    }
}