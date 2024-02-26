using bll.interfaces;
using BLL.interfaces;
using DAL.Models;
using DTO.classes;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {
        IUserBLL bll;
        public userController(IUserBLL bll)
        {
            this.bll = bll;
        }

        [HttpGet]
        public List<DTO.classes.User> GetUsers()
        {
            return this.bll.getAll();
        }

        [HttpPost]
        [Route("AddUser")]
        public int AddUser(DTO.classes.User user)
        {

            return this.bll.add(user);
        }

        [HttpDelete]
        [Route("deletUser/{id}")]
        public bool DeleteUser(int id)
        {
            return this.bll.remove(id);
        }

        [HttpGet]
        [Route("getByEmailAndPassword/{email}/{password}")]
        public DTO.classes.User getByEmailAndPassword(string email,string password) 
        { 
            return this.bll.getByEmailAndPassword(email, password);
        }

        [HttpPut]
        [Route("upDate/{id}")]
        public bool upDate(DTO.classes.User user,int id)
        {
            return this.bll.upDate(user,id);
        }

        [HttpGet]
        [Route("GetAllTrips/{id}")]
        public List<DTO.classes.Booking> GetAllTrips(int id)
        {
            return this.bll.GetAllTrips(id);
        }

    }
}
