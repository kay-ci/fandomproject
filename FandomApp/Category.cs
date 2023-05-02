namespace UserInfo {
    public class Category {

        public int CategoryId {get; set;}
        public string Category_name {get; set;}
        public List<Event> events {get;} = new();

        public Category(){}

        public Category(int cat_id, string name){
            this.CategoryId = cat_id;
            this.Category_name = name;
        }
    }
}