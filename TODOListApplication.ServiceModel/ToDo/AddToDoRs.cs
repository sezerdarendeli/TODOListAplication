﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOListApplication.ServiceModel.ToDo
{
    public class AddToDoRq : BaseRq
    {
        public string Name { get; set; }
        public int UserId { get; set; }
    }
}
