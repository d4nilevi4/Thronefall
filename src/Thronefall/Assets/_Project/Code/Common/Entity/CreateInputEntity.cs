﻿namespace Thronefall.Common.Entity
{
    public static class CreateInputEntity
    {
        public static InputEntity Empty() =>
            Contexts.sharedInstance.input.CreateEntity();
    }
}