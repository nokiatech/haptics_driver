/*

* Copyright (c) 2025 Nokia Corporation and/or its subsidiary(-ies). All rights reserved.

*

*

* This software, including documentation, is protected by copyright controlled by Nokia Corporation and/ or its

* subsidiaries. All rights are reserved. Copying, including reproducing, storing, adapting or translating, any or all

* of this material requires the prior written consent of Nokia.

*/

using System;
using WeArt.Core;
using WeArt.Utils;
using ClientError = WeArt.Core.WeArtClient.ErrorType;

namespace WeArt.Components
{
    /// <summary>
    /// This component wraps and exposes the network client that communicates with the hardware middleware.
    /// Use the <see cref="Instance"/> singleton property to retrieve the instance.
    /// </summary>
    public class WeArtController
    {
        
        internal int _clientPort = 13031;

        internal bool _debugMessages = false;

        private WeArtClient _weArtClient;

        public WeArtController()
        {

        }

        /// <summary>
        /// The network client that communicates with the hardware middleware.
        /// </summary>
        public WeArtClient Client
        {
            get
            {
                if (_weArtClient == null)
                {
                    _weArtClient = new WeArtClient
                    {
                        IpAddress = WeArtConstants.ipLocalHost,
                        Port = _clientPort,
                    };
                    _weArtClient.OnConnectionStatusChanged += OnConnectionChanged;
                    _weArtClient.OnTextMessage += OnMessage;
                    _weArtClient.OnError += OnError;
                }
                return _weArtClient;
            }
        }

        private void OnConnectionChanged(bool connected)
        {
            if (connected)
                WeArtLog.Log($"Connected to {Client.IpAddress}.");
            else
                WeArtLog.Log($"Disconnected from {Client.IpAddress}.");
        }

        private void OnMessage(WeArtClient.MessageType type, string message)
        {
            if (!_debugMessages)
                return;

            if (type == WeArtClient.MessageType.MessageSent)
                WeArtLog.Log($"To Middleware: \"{message}\"");

            else if (type == WeArtClient.MessageType.MessageReceived)
                WeArtLog.Log($"From Middleware: \"{message}\"");
        }

        private void OnError(ClientError error, Exception exception)
        {
            string errorMessage;
            switch (error)
            {
                case ClientError.ConnectionError:
                    errorMessage = $"Cannot connect to {Client.IpAddress}";
                    break;
                case ClientError.SendMessageError:
                    errorMessage = $"Error on send message";
                    break;
                case ClientError.ReceiveMessageError:
                    errorMessage = $"Error on message received";
                    break;
                default:
                    throw new NotImplementedException();
            }
            WeArtLog.Log($"{errorMessage}\n{exception.StackTrace}");
        }
    }
}