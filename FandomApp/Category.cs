namespace UserInfo {
    public class Category {

        public int CategoryId {get; set;}
        public string cat_name {get; set;}

        public Category(){}

        public Category(int cat_id, string name){
            this.CategoryId = cat_id;
            this.cat_name = name;
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
                this.cat_name == item.cat_name
            );
        }


    }
}