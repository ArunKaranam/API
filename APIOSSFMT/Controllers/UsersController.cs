using APIOSSFMT.DTO;
using AutoMapper;
using MVCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIOSSFMT.Controllers
{
    public class UsersController : ApiController
    {
        private MyDbContext db;
        public UsersController()
        {
            db = new MyDbContext();
        }
        //Get/api/users
        public IEnumerable<UserDTO> GetUsers()
        {
            return db.users.ToList().Select(Mapper.Map<User,UserDTO>);

        }
        //Get/api/users/1
        public IHttpActionResult GetUser(int id)
        {
            var user = db.users.SingleOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();


            }
            return Ok(Mapper.Map<User,UserDTO>(user));
        }
        //POST /api/users
        [HttpPost]
        public IHttpActionResult CreateUser(UserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();

            }
            var user = Mapper.Map<UserDTO, User>(userDTO);

            db.users.Add(user);
            db.SaveChanges();
           
            userDTO.Id = user.Id;
            return Created(new Uri(Request.RequestUri +"/"+user.Id),userDTO);

        }
        //PUT/api/users/1
        [HttpPut]
        public void UpdateUser(int id,UserDTO userDTO)
        {

            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            }
            var userInDb = db.users.SingleOrDefault(x => x.Id == id);
            if (userInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);

            }
            Mapper.Map<UserDTO, User>(userDTO, userInDb);
            //userInDb.Id = user.Id;
            //userInDb.UserName = user.UserName;
            //userInDb.PassWord = user.PassWord;
            //userInDb.RoleName = user.RoleName;
            db.SaveChanges();     
        }
        //Delete /api/users/1
        [HttpDelete]
        public void DeleteUser(int id)
        {
            var userInDb = db.users.SingleOrDefault(x => x.Id == id);
            if (userInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);

            }
            db.users.Remove(userInDb);
            db.SaveChanges();

        }
    }
}
