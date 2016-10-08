using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using SwypeInBackService.DataObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwypeInBackService.Hubs
{
    [HubName("chat")]
    public class ChatHub : Hub
    {

        static int _counter = 0;
        static List<ChatMessage> CurrentMessage = new List<ChatMessage>();
        //static List<ChatMessage> CurrentUser = new List<ChatMessage>();

        //public void Send(ChatMessage message, ChatMessage username)
        //{
        //    AddMessageinCache(message, username);            
        //    Clients.All.broadcastMessage(message, username);                                                                        
        //}

        public void Send(ChatMessage message)
        {
            AddMessageinCache(message);
            Clients.All.broadcastMessage(message);
        }

        private void AddMessageinCache(ChatMessage _MessageDetail)
        {
            CurrentMessage.Add(_MessageDetail);
            if (CurrentMessage.Count > 100)
                CurrentMessage.RemoveAt(0);            
        }

        private void record()
        {
            _counter += 1;
            Clients.All.receiveHit(_counter);
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            _counter -= 1;
            Clients.All(_counter);
            return base.OnDisconnected(stopCalled);
        }

        //private void AddMessageinCache(ChatMessage _MessageDetail, ChatMessage _UserDetail)
        //{
        //    CurrentMessage.Add(_MessageDetail);
        //    if (CurrentMessage.Count > 100)
        //        CurrentMessage.RemoveAt(0);

        //    CurrentUser.Add(_UserDetail);
        //    if (CurrentUser.Count > 100)
        //        CurrentUser.RemoveAt(0);
        //}        
    }
}   