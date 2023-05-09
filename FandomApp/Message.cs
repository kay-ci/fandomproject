using System.ComponentModel.DataAnnotations.Schema;

namespace UserInfo{
    public class Message{
        private string _text;
        private string _title;
        public int Id {get; set;}
        [NotMapped]
        public UserMessage Sender {get; set;} = null!;
        public List<UserMessage>? Recipients = new();
        public UserMessage? Recipient = null;
        public DateTime Timesent {get; set;}
        public string Text {
            get{return _text;} 
            set{ 
                if (!IsValid(value)){
                    throw new ArgumentException("Text property cannot be null or whitespace");
                }
                _text = value;
            }
        }
        public string Title {
            get{return _title;} 
            set{
                if (!IsValid(value)){
                    throw new ArgumentException("Title cannot be null or whitespace");
                }
                _title = value;
            }
        }
        //This field determines if the message has been read or not. Will get updated by UserMessage
        public bool Seen {get; set;}

        private Message(){}
        //Basic constructor, validation done in UserMessage for text
        public Message(UserMessage sender, List<UserMessage> recipients, string text, string title){
            if(!IsValid(text) || !IsValid(title)){
                throw new ArgumentException("text can not be null");
            }
            if(!IsValid(title)){
                throw new ArgumentException("title can not be null");
            }
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
        //This one is for only one recipient
        public Message(UserMessage sender, UserMessage recipient, string text, string title){
            if(!IsValid(text) || !IsValid(title)){
                throw new ArgumentException("text can not be null");
            }
            if(!IsValid(title)){
                throw new ArgumentException("title can not be null");
            }
            this.Sender = sender;
            this.Timesent = DateTime.Now;
            this.Text = text;
            this.Title = title;
            this.Seen = false;
            this.Recipient = recipient;
        }
        //This method is accessed by UserMessage inside of ReadMessage. Will make the field true.
        public void MessageIsRead(){ this.Seen = true; }
        public bool IsValid(string field){
            if (string.IsNullOrWhiteSpace(field)){
                return false;
            }
            return true;
        }

        public override bool Equals(object obj){
            var item = obj as Message;
            if(ReferenceEquals(item, this)){
                return true;
            }
            if(item == null && this == null){
                return true;
            }
            if(item == null){
                return false;
            }
            return (
                this.Sender == item.Sender &&
                this.Recipient == item.Recipient &&
                this.Recipients.Count == item.Recipients.Count &&
                this.Title.Equals(item.Title) &&
                this.Text.Equals(item.Text));
        }
    }
}