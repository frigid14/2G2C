﻿using Content.Shared.Singularity.Components;
using Robust.Client.GameObjects;
using Robust.Shared.GameObjects;

namespace Content.Client.ParticleAccelerator.UI
{
    public sealed class ParticleAcceleratorBoundUserInterface : BoundUserInterface
    {
        private ParticleAcceleratorControlMenu? _menu;

        public ParticleAcceleratorBoundUserInterface(ClientUserInterfaceComponent owner, object uiKey) : base(owner, uiKey)
        {
        }

        protected override void Open()
        {
            base.Open();

            _menu = new ParticleAcceleratorControlMenu(this);
            _menu.OnClose += Close;
            _menu.OpenCentered();
        }

        public void SendEnableMessage(bool enable)
        {
            SendMessage(new ParticleAcceleratorSetEnableMessage(enable));
        }

        public void SendPowerStateMessage(ParticleAcceleratorPowerState state)
        {
            SendMessage(new ParticleAcceleratorSetPowerStateMessage(state));
        }

        public void SendScanPartsMessage()
        {
            SendMessage(new ParticleAcceleratorRescanPartsMessage());
        }

        protected override void UpdateState(BoundUserInterfaceState state)
        {
            _menu?.DataUpdate((ParticleAcceleratorUIState) state);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            _menu?.Dispose();
            _menu = null;
        }
    }
}
