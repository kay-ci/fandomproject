namespace userInfo{
    public class Message{
        private int id {get{return id;}}
        private User sender {get{return sender;} set{sender = value;}}
        private List<User> recipients = new List<User>();
        private DateTime timesent {get{return timesent;} set{timesent = value;}}
        private string text {get{return text;} set{text = value;}}
        private bool seen {get{return seen;}set{seen = value;}}

        public Message(User sender, List<User> recipients, string text){
            this.sender = sender;
            this.timesent = DateTime.Now;
            this.text = text;
            this.seen = false;
            foreach(User user in recipients){
                this.recipients.Add(user);
            }
        }

        public void MessageIsRead(){ this.seen = true; }
    }
}