﻿using Content.Shared.Construction;
using JetBrains.Annotations;

namespace Content.Server.Construction.Completions
{
    [UsedImplicitly]
    [DataDefinition]
    public sealed class AddContainer : IGraphAction
    {
        [DataField("container")] public string? Container { get; private set; } = null;

        public void PerformAction(EntityUid uid, EntityUid? userUid, IEntityManager entityManager)
        {
            if (string.IsNullOrEmpty(Container))
                return;

            entityManager.EntitySysManager.GetEntitySystem<ConstructionSystem>().AddContainer(uid, Container);
        }
    }
}
