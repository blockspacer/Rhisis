﻿using System;
using Rhisis.Game.Abstractions.Protocol;
using Sylver.Network.Data;

namespace Rhisis.Network.Packets.World.Bank
{
    public class CloseGuildBankWindow : IPacketDeserializer
    {
        /// <inheritdoc />
        public void Deserialize(INetPacketStream packet)
        {
            throw new NotImplementedException();
        }
    }
}