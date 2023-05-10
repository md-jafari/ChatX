﻿using ChatX.Data;
using ChatX.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace ChatX.Hubs
{
    public class Chathub : Hub
    {
        private static int _messageId = 0;
        private readonly AppDbContext database;

        public Chathub (AppDbContext context)
        {
            _db = context;
        }

        public async Task SendMessage(string loggedInUserName, int loggedInUser, string messageContent)
        {
            Message message = new()
            {
                Content = messageContent,
                Sender = loggedInUser,
                SenderName = loggedInUserName,
                TimeStamp = DateTime.UtcNow
            };

            // Save message to db
            await _db.Messages.AddAsync(message);
            await _db.SaveChangesAsync();

            await Clients.All.SendAsync("ReceiveMessage", message);
        }

        public async Task DeleteMessage(int id)
        {
            // Delete from db here
            // Counsult with Customer if to keep/delete the message history
            
            await Clients.All.SendAsync("deleteMessageRemote", id);
        }
    }
}
