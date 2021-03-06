﻿using LagDaemon.InformationManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.InformationManager.DAL.Model
{
    public class MetaData
    {
        public int MetaDataId { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public MetaValue Value { get; set; }
    }
}
