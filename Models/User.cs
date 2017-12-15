using System;

namespace userService.Models {
    public class User {
        public string _id { get; set; }
        public string _rev { get; set; }
        public string password { get; set; }
    }

    public class Token {
        public string _id { get; set; }
        public int ttl { get; set; }
        public DateTime create { get; set; }

        public Token() {}
    }
}