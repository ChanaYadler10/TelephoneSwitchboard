﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs
{
    public class StatusTaskDto
    {
        public int StatusTaskId { get; set; }
        public string Status { get; set; } = null!;
    }
}
