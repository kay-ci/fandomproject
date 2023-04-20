namespace UserInfo{
    public class Message{
        public int id {get; set;}
        public UserMessage sender {get; set;}
        public List<UserMessage> recipients = new List<UserMessage>();
        public DateTime timesent {get; set;}
        public string text {get; set;}
        //This field determines if the message has been read or not. Will get updated by UserMessage
        public bool seen {get; set;}
        //Basic constructor, validation done in UserMessage for text
        public Message(UserMessage sender, List<UserMessage> recipients, string text){
            this.sender = sender;
            this.timesent = DateTime.Now;
            this.text = text;
            this.seen = false;
            foreach(User user in recipients){
                this.recipients.Add(user);
            }
        }
        //This method is accessed by UserMessage inside of ReadMessage. Will make the field true.
        public void MessageIsRead(){ this.seen = true; }
    }
}