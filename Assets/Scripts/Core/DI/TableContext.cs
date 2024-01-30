using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace CradsTable.Core.DI
{
    public class TableContext : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            // builder.Register<Main>(Lifetime.Singleton);
        }
    }
}
