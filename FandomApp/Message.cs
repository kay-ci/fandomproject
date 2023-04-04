namespace userInfo{
    public class Message{
        public int id {get{return this.id;}}
        public User sender {get{return this.sender;} set{this.sender = value;}}
        public List<User> recipients = new List<User>();
        public DateTime timesent {get{return this.timesent;} set{this.timesent = value;}}
        public string text {get{return this.text;} set{this.text = value;}}
        //This field determines if the message has been read or not. Will get updated by UserMessage
        public bool seen {get{return this.seen;}set{this.seen = value;}}
        //Basic constructor, validation done in UserMessage for text
        public Message(User sender, List<User> recipients, string text){
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