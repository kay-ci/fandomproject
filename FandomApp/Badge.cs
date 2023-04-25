namespace UserInfo {
    public class Badge {

        public int BadgeId {get; set;}
        public string bad_name {get; set;}

        public Badge(){}

        public Badge(int bad_id, string name){
            this.BadgeId = bad_id;
            this.bad_name = name;
        }
    }
}