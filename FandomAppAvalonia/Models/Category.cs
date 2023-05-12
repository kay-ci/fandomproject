namespace UserInfo {
    public class Category {

        public int CategoryID {get; set;}
        public string Name {get; set;}
        public List<Event> events {get;} = new();

        public Category(){}

        public Category(string name){
            this.Name = name;
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
                this.Name == item.Name
            );
        }


    }
}