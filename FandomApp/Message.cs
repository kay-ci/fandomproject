namespace UserInfo{
    public class Message{
        public int Id {get; set;}
        public User Sender {get; set;} = null!;
        public List<User> Recipients = new();
        public DateTime Timesent {get; set;}
        public string Text {get; set;}
        //This field determines if the message has been read or not. Will get updated by UserMessage
        public bool Seen {get; set;}

        private Message(){}
        //Basic constructor, validation done in UserMessage for text
        public Message(User sender, List<User> recipients, string text){
            this.Sender = sender;
            this.Timesent = DateTime.Now;
            this.Text = text;
            this.Seen = false;
            this.Recipients = new List<User>();
            foreach(User user in recipients){
                this.Recipients.Add(user);
            }
        }
        //This method is accessed by UserMessage inside of ReadMessage. Will make the field true.
        public void MessageIsRead(){ this.Seen = true; }
    }
}