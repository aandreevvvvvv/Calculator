﻿using Calculator.Model.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Model.Loggers
{
    interface ILogger
    {
        public void Write(LogEntry entry);
        public LogEntry Read(int idx);
    }
}
