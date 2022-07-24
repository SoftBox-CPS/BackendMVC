using Microsoft.AspNetCore.Mvc;
using SoftBox.DataBase.Entities;
using SoftBox.DataBase.InterfacesRepository;

namespace MVCWebApplication.Controllers
{
    public class RoomList : Base.EntityController<Room, Guid>
    {
        private readonly IRoomRepository roomRepository;

        public RoomList(IRoomRepository roomRepository) :base (roomRepository)
        {
            this.roomRepository = roomRepository;
        }

        [HttpGet]
        public async Task<IActionResult> AllRooms()
        {
            var rooms = await roomRepository.GetAll();
            return View(rooms);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetUsersInRoom(Guid usersId)
        {
            var users = await roomRepository.GetRoomUser(usersId);
            // if (человек нажал кнопку) --> заносит в отдельную базу 
            // вытаскивает из базы и засовывает в холд. 
            return View(users);
        }
    }
}
