﻿namespace Managers.Meta
{
    public interface IManager
    {
        SaveInfo Save(SaveInfo saveInfo);
        void Load(SaveInfo saveInfo);
        void InitialSetup();
        void PostLoad();
        void Advance(float speed);
    }
}