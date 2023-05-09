namespace UserInfo {
    public class Badge {

        public int BadgeId {get; set;}
        public string BadgeName {get; set;}

        public Badge(){}

        public Badge(string name){
            this.BadgeName = name;
        }
        public override bool Equals(object? obj){
            var item = obj as Badge;
            if(ReferenceEquals(item, this)){
                return true;
            }
            if(item == null){
                return false;
            }
            return (
                this.BadgeName == item.BadgeName
            );
        }
    }
}