﻿using Sylver.Network.Common;

namespace Rhisis.LoginServer.Client
{
    public interface ILoginClient : INetUser
    {
        /// <summary>
        /// Gets the ID assigned to this session.
        /// </summary>
        uint SessionId { get; }

        /// <summary>
        /// Gets the client's logged user id.
        /// </summary>
        int UserId { get; }

        /// <summary>
        /// Gets the client's logged username.
        /// </summary>
        string Username { get; }

        /// <summary>
        /// Check if the client is connected.
        /// </summary>
        bool IsConnected { get; }

        /// <summary>
        /// Disconnects the current client.
        /// </summary>
        void Disconnect();

        /// <summary>
        /// Sets the client's username and id.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="userId"></param>
        void SetClientUsername(string username, int userId);
    }
}