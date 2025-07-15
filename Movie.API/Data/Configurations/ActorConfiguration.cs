﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movie.API.Entities;

namespace Movie.API.Data.Configurations
{

    public class ActorConfigurations : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.HasKey(a => a.Id);
            builder.HasMany(a => a.Movies)
                   .WithMany(m => m.Actors);
        }
    }
}
