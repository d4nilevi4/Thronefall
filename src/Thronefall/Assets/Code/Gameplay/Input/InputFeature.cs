﻿using Thronefall.Infrastructure;

namespace Thronefall.Gameplay.Input
{
    public sealed class InputFeature : Feature
    {
        public InputFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<InitializeInputSystem>());
            
            Add(systemFactory.Create<EmitInputSystem>());
            
            Add(systemFactory.Create<TearDownInputSystem>());
        }
    }
}