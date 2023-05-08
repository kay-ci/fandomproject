namespace UserInfo {
    public class Category {

        public int CategoryId {get; set;}
        public string Category_name {get; set;}
        public List<Event> events {get;} = new();

        public Category(){}

        public Category(string name){
            this.Category_name = name;
        }
    }
}