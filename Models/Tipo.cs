﻿using System.Collections.Generic;
using System;
using System.Linq;

namespace AdminPanel.Models
{
    public class Tipo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Message> Messages { get; set; } = new List<Message>();

        public Tipo()
        {
        }

        public Tipo(int id, string name)
        {
            Id = id;
            Name = name;
        }

       
    }
}