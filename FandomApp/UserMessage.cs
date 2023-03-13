namespace userInfo{
    public class UserMessage{

        private List<Message> Inbox = new List<Message>();
        private List<Message> Outbox = new List<Message>();

        public UserMessage(List<Message> Inbox, List<Message> Outbox){
            foreach(Message msg in Inbox){ this.Inbox.Add(msg); }
            foreach(Message msg in Outbox){ this.Outbox.Add(msg); }
        }

        public void CreateMessage(){}

        public string ReadMessage(){return "";}

        public void SortMessages(){}
    }
}