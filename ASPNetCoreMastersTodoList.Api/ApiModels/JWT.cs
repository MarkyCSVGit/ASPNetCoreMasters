﻿namespace ASPNetCoreMastersTodoList.Api.ApiModels
{
    public class JWT
    {
        public string SecurityKey { get; set; } 
        public string Issuer { get; set; } 
        public string Audience { get; set; } 
    }
}
