﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.AspNetCore.ServerSentEvents.Model
{
    public class SseResponseModel
    {
        public string RequestId { get; set; }
        public string Message { get; set; }
    }
}
