﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HearthStoneSimCore.Model
{
    public interface IDataService
    {
        void GetData(Action<DataItem, Exception> callback);
        void GetCardDefs(Action<Dictionary<string, Card>, Exception> callback);
    }
}