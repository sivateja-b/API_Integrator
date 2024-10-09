﻿using System.Collections.Generic;

namespace MyRestAPILibrary.ReqResModels
{
    public class GetUsersResponse
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public List<User> data { get; set; }
    }
}
