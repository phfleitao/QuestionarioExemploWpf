﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionario.Core
{
    internal class Answer
    {
        public Answer() { }
        public Answer(int id, string? description)
        {
            Id = id;
            Description = description;
        }

        public int Id { get; set; }
        public string? Description { get; set; }
    }
}
