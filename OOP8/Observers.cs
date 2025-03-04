﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP8
{
    public interface IObserver 
    {
        void onSubjectChanged(ISubject subject);
    }

    public interface ISubject
    {
        void addObserver(IObserver observer);
        void removeObserver(IObserver observer);
        void notifyEveryone();
    }
}
