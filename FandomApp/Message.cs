namespace UserInfo{
    public class Message{
<<<<<<< HEAD
        public int id {get; set;}
        public UserMessage sender {get; set;}
        public List<UserMessage> recipients = new List<UserMessage>();
        public DateTime timesent {get; set;}
        public string text {get; set;}
=======
        public int Id {get; set;}
        public User Sender {get; set;} = null!;
        public List<User> Recipients = new();
        public DateTime Timesent {get; set;}
        public string Text {get; set;}
>>>>>>> de2e9a883ab19bb15c3d05d34bec3f377f2f861b
        //This field determines if the message has been read or not. Will get updated by UserMessage
        public bool Seen {get; set;}

        private Message(){}
        //Basic constructor, validation done in UserMessage for text
<<<<<<< HEAD
        public Message(UserMessage sender, List<UserMessage> recipients, string text){
            this.sender = sender;
            this.timesent = DateTime.Now;
            this.text = text;
            this.seen = false;
=======
        public Message(User sender, List<User> recipients, string text){
            this.Sender = sender;
            this.Timesent = DateTime.Now;
            this.Text = text;
            this.Seen = false;
            this.Recipients = new List<User>();
>>>>>>> de2e9a883ab19bb15c3d05d34bec3f377f2f861b
            foreach(User user in recipients){
                this.Recipients.Add(user);
            }
        }
        //This method is accessed by UserMessage inside of ReadMessage. Will make the field true.
        public void MessageIsRead(){ this.Seen = true; }
    }
}