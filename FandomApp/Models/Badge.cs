namespace UserInfo {
    public class Badge {

        public int BadgeId {get; set;}
        public string badgeName {get; set;}

        public Badge(){}

        public Badge(int bad_id, string name){
            this.BadgeId = bad_id;
            this.badgeName = name;
        }
        public override bool Equals(object obj){
            var item = obj as Badge;
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
                this.badgeName == item.badgeName
            );
        }
    }
}