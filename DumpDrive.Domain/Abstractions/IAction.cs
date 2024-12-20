﻿namespace DumpDrive.Domain.Abstractions
{
    public interface IAction
    {
        int MenuIndex { get; set; }
        string Name { get; set; }
        void Open();
    }
}
