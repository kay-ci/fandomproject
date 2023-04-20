namespace UserInfo{
    public class Message{
        public int Id {get; set;}
        public UserMessage Sender {get; set;} = null!;
        public List<UserMessage> Recipients = new();
        public DateTime Timesent {get; set;}
        public string Text {get; set;}
        public string Title {get; set;}
        //This field determines if the message has been read or not. Will get updated by UserMessage
        public bool Seen {get; set;}

        private Message(){}
        //Basic constructor, validation done in UserMessage for text
        public Message(UserMessage sender, List<UserMessage> recipients, string text, string title){
            this.Sender = sender;
            this.Timesent = DateTime.Now;
            this.Text = text;
            this.Title = title;
            this.Seen = false;
            this.Recipients = new List<UserMessage>();
            foreach(UserMessage user in recipients){
                this.Recipients.Add(user);
            }
        }
        //This method is accessed by UserMessage inside of ReadMessage. Will make the field true.
        public void MessageIsRead(){ this.Seen = true; }
    }
}