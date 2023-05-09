namespace UserInfo {
    public class Category {

        public int CategoryId {get; set;}
        public string Category_name {get; set;}
        public List<Event> events {get;} = new();

        public Category(){}

        public Category(string name){
            this.Category_name = name;
        }
        
        public override bool Equals(object? obj){
            var item = obj as Category;
            if(ReferenceEquals(item, this)){
                return true;
            }
            if(item == null){
                return false;
            }
            return (
                this.Category_name == item.Category_name
            );
        }


    }
}