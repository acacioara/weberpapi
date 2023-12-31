﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Modelos.Modules
{
    public class Module
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string BackgroundColor { get; set; }
        public string FontColor { get; set; }
        public bool Able { get; set; }

        public Module()
        {
            Id = Guid.NewGuid();
        }
    }
}
