﻿using Rhisis.Core.Data;
using Rhisis.World.Game.Entities;
using Rhisis.World.Game.Structures;

namespace Rhisis.World.Packets
{
    public interface ISkillPacketFactory
    {
        /// <summary>
        /// Sends the skill tree update to the given player.
        /// </summary>
        /// <param name="player">Current player.</param>
        void SendSkillTreeUpdate(IPlayerEntity player);

        /// <summary>
        /// Sends the skill to use.
        /// </summary>
        /// <param name="player">Current player.</param>
        /// <param name="target">Current target entity.</param>
        /// <param name="skill">Skill to use.</param>
        /// <param name="castingTime">Skill casting time.</param>
        /// <param name="skillUseType">Skill use type.</param>
        void SendUseSkill(ILivingEntity player, IWorldEntity target, SkillInfo skill, int castingTime, SkillUseType skillUseType);
    }
}
