﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using MusicHub.Migrations;
using MusicHub.Dto;
using MusicHub.Models;
//using Following = MusicHub.Models.Following;

namespace MusicHub.Controllers
{
    [Authorize]
    public class FollowingController : ApiController
    {
        private ApplicationDbContext _context;

        public FollowingController()
        {
            _context=new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Follow(FollowingDto dto)
        {
            var userId = User.Identity.GetUserId();

            if(_context.Followings.Any(f=>f.FolloweeId==userId && f.FolloweeId == dto.FolloweeId))
                return BadRequest("Following already exists.");
            var following = new Models.Following
            {
                FollowerId = userId,
                FolloweeId = dto.FolloweeId
            };
            _context.Followings.Add(following);
            _context.SaveChanges();

            return Ok();
        }
    }
}
