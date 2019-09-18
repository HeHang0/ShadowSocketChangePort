using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ShadowSocketChangePort.Models
{
    public class ShadowSocketConfig
    {
        [JsonProperty(PropertyName = "server")]
        public string Server { get; set; } = "0.0.0.0";
        [JsonProperty(PropertyName = "server_port")]
        public int ServerPort { get; set; } = 448;
        [JsonProperty(PropertyName = "local_address")]
        public string LocalAddress { get; set; } = "127.0.0.1";
        [JsonProperty(PropertyName = "local_port")]
        public int LocalPort { get; set; } = 1080;
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; } = "speaknow";
        [JsonProperty(PropertyName = "timeout")]
        public int TimeOut { get; set; } = 300;
        [JsonProperty(PropertyName = "menthod")]
        public string Menthod { get; set; } = "aes-256-cfb";
        [JsonProperty(PropertyName = "fast_open")]
        public bool FastOpen { get; set; } = true;

        [JsonIgnore]
        public static List<SelectListItem> MenthodList { get; set; } = 
            new List<SelectListItem>() {
                new SelectListItem { Text = "aes-256-cfb", Value = "aes-256-cfb"},
                new SelectListItem { Text = "aes-128-ctr", Value = "aes-128-ctr"},
                new SelectListItem { Text = "aes-192-ctr", Value = "aes-192-ctr"},
                new SelectListItem { Text = "aes-256-ctr", Value = "aes-256-ctr"},
                new SelectListItem { Text = "camellia-128-cfb", Value = "camellia-128-cfb"},
                new SelectListItem { Text = "camellia-192-cfb", Value = "camellia-192-cfb"},
                new SelectListItem { Text = "camellia-256-cfb", Value = "camellia-256-cfb"},
                new SelectListItem { Text = "bf-cfb", Value = "bf-cfb"},
                new SelectListItem { Text = "chacha20-ietf-poly1305", Value = "chacha20-ietf-poly1305"},
                new SelectListItem { Text = "xchacha20-ietf-poly1305", Value = "xchacha20-ietf-poly1305"},
                new SelectListItem { Text = "salsa20", Value = "salsa20"},
                new SelectListItem { Text = "chacha20", Value = "chacha20"},
                new SelectListItem { Text = "chacha20-ietf", Value = "chacha20-ietf"},
                new SelectListItem { Text = "rc4-md5", Value = "rc4-md5"}
        };
    }
}
