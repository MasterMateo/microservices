﻿using CQRS.Core.Commands;
using System.Diagnostics;

namespace Post.Cmd.Api.Commands
{
    public class AddCommentCommand : BaseCommand
    {
        public string Comment { get; set; }
        public string Username { get; set; }
    }
}
