namespace UserInfo {
    public class Category {

        public int CategoryId {get; set;}
        public string cat_name {get; set;}

        public Category(){}

        public Category(int cat_id, string name){
            this.CategoryId = cat_id;
            this.cat_name = name;
        }
    }
}