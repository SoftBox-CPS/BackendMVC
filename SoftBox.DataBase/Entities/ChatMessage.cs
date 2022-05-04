﻿using System.ComponentModel.DataAnnotations;

namespace SoftBox.DataBase.Entities
{
    public class ChatMessage
    {  
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public Guid ChatUserID { get; set; }
        public ChatUser ChatUser { get; set; }
        [Required]
        public DateTimeOffset DateTimeUTCMessage { get; set; }
    }
}