﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DFBot.Enum;
using DFBot.Network;
using DFBot.States;

namespace DFBot
{
    public class Bot
    {
        #region constants
        private const char charNewLine= (char)10;
        private const char charNull = (char)0;
        #endregion

        #region datatoremove
        private const int IDSERVER = 602;
        private int test = 0;
        private IDictionary<String, String> Cache = new Dictionary<String, String>();

        #endregion
        #region attributes
        /// <summary>
        /// Account link to this bot
        /// </summary>
        private Account _account;

        public Account Account
        {
            get { return _account; }
        }

        /// <summary>
        /// PErso use for this bot
        /// </summary>
        private Perso _perso;

        public Perso Perso
        {
            get { return _perso; }
        }

        /// <summary>
        /// Current state of the bot
        /// </summary>
        private State _state;

        public State State
        {
            get { return _state; }
            set { _state = value; }
        }

        private SocketDof _socket;

        public  SocketDof Socket
        {
            set { _socket = value; }
        }

        #endregion

        public Bot(Account account, Perso perso)
        {
            _account = account;
            _perso = perso;
            this.State = new NotConnectedState();
        }

        #region public methods
        public int Connection(string message)
        {
            //Receiving the crypting key
            if (message.StartsWith(PrefixMessage.Connection.ReceivedKey))
            {
                //Attach the key to the account
                _account.Key = message.Remove(0,PrefixMessage.Connection.ReceivedKey.Length);

                ConnectPerso();
            }
            else if (message.StartsWith(PrefixMessage.Connection.DisconnectSomeone))
            {
                ConnectPerso();
            }
            else if (message.StartsWith(PrefixMessage.Connection.ConnectionOk))
            {
                _state = new ServerSelectionState();
            }
            return 0;
        }

        public int ServerSelection(string message)
        {
            if (message.StartsWith(PrefixMessage.ServerSelection.ServersInfo))
            {
                SelectServer();
            }
            else if (message.StartsWith(PrefixMessage.ServerSelection.SelectServer))
            {
                //Switch socket
                _socket.ReconnectTo("80.239.173.168");

                //Store in the cache the value for the next step
                Cache.Add(PrefixMessage.ServerSelection.SelectServer, message.Substring(14, 7));
            }
            else if (message.StartsWith(PrefixMessage.ServerSelection.SwitchSocketOK))
            {
                _socket.Send(PrefixMessage.ServerSelection.ServerIdentification + Cache[PrefixMessage.ServerSelection.SelectServer] + charNewLine + charNull);
            }
            else if (message.StartsWith(PrefixMessage.ServerSelection.ServerIdentification))
            {
                _socket.Send("Ai07ZMr3g5oEkTN0" + charNewLine + charNull + "AL" + charNewLine + charNull + "Af" + charNewLine + charNull);
            /*    _socket.Send("Ak0"+charNewLine+charNull);
            }
            else if (message.StartsWith("BN") && test==0)
            {
                test++;
                _socket.Send("AV" + charNewLine + charNull);
            }
            else if (message.StartsWith("AV0"))
            {
                _socket.Send("Agfr" + charNewLine + charNull);
            }
            else if (message.StartsWith("BN") && test==1)
            {
                test++;
                _socket.Send("Ai07ZMr3g5oEkTN0" + charNewLine + charNull + "AL" + charNewLine + charNull);*/
            }
            else if (message.StartsWith(PrefixMessage.ServerSelection.PlaceQueue))
            {

                string place = message.Remove(0, PrefixMessage.ServerSelection.PlaceQueue.Length);
                Program.log.Info("Place in the queue: "+place);


               _socket.Send("Af" + charNewLine + charNull);


                //TODO change this
                if (place == "1")
                {
                    //In the queue for connection, we switch state
                    _state = new PersoSelectionState();
                }
            }
            return 0;
        }

        public int PersoSelection(string message)
        {
            if (message.StartsWith(PrefixMessage.PersoSelection.PersoInfo))
            {
                _perso.ParseMessageFromServer(message);
                _socket.Send("AS"+_perso.Id);
            }
            return 0;
        }

        #endregion

        #region private method
        private void ConnectPerso()
        {
            Program.log.Info("Account connection attemp ....");
            try
            {
                //Connection attempt
                string encryptedPassword = _account.EncryptionPassword();
                _socket.Send("1.29.1" + charNewLine + charNull);
                _socket.Send(_account.Pseudo + charNewLine + encryptedPassword + charNewLine + charNull + "Af" + charNewLine + charNull);
            }
            catch (NullReferenceException e)
            {
                Program.log.Info("Secret key not received from the server");
                Program.log.Error(e.ToString());
            }
        }

        private void SelectServer()
        {
            Program.log.Info("Server selection ...");
            _socket.Send(PrefixMessage.ServerSelection.SelectServer + IDSERVER.ToString() + charNewLine + charNull);
        }
        #endregion
    }
}