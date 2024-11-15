﻿using LessonMonitor.Core;
using LessonMonitor.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonMonitor.DataAccess.MSSQL.Repositories
{
    public class MembersRepository : IMembersRepository
    {
        private readonly LessonMonitorDbContext _context;
        public MembersRepository(LessonMonitorDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(Member newMember)
        {
            if (newMember is null)
            {
                throw new ArgumentNullException(nameof(newMember));
            }

            var newMemberEntity = new Entities.Member
            {
                Name = newMember.Name,
                YoutubeAccountId = newMember.YoutubeUserId
            };

            await _context.Members.AddAsync(newMemberEntity);
            await _context.SaveChangesAsync();

            return newMemberEntity.Id;
        }

        public async Task<Member[]> Get()
        {
            var members = await _context.Members
                .AsNoTracking()
                .Select(x=> new Member 
                {
                    Id = x.Id,
                    Name = x.Name,
                    YoutubeUserId = x.YoutubeAccountId
                })
                .ToArrayAsync();

            return members;
        }
    }
}
