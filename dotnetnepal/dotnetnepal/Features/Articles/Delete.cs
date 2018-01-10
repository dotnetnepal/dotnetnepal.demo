﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnetnepal.Features.Articles
{
    public class Delete
    {
        public class Command : IRequest
        {
            public Command(string slug)
            {
                Slug = slug;
            }

            public string Slug { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Slug).NotNull().NotEmpty();
            }
        }

        public class QueryHandler : IAsyncRequestHandler<Command>
        {
            private readonly ConduitContext _context;

            public QueryHandler(ConduitContext context)
            {
                _context = context;
            }

            public async Task Handle(Command message)
            {
                var article = await _context.Articles
                    .FirstOrDefaultAsync(x => x.Slug == message.Slug);

                if (article == null)
                {
                    throw new RestException(HttpStatusCode.NotFound);
                }

                _context.Articles.Remove(article);
                await _context.SaveChangesAsync();
            }
        }
    }
}
