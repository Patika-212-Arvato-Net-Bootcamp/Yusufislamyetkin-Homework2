using HomeWork_Week2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork_Week2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminApiController : ControllerBase
    {
        BootCampApiController bootCampApiController = new BootCampApiController();



        /// <summary>
        /// Bootcamp kaydetme işlemi; Bootcamp türünde veri gönderilir.
        /// </summary>
        /// <param name="bootcamp"></param>
        /// <returns></returns>
        [HttpPost]
        public Bootcamp Add([FromBody] Bootcamp bootcamp) // Bootcamp türünde veri bekleyen bootcamp ekleme kod bloğu.
        {

            if (bootcamp != null && bootCampApiController._bootcamps.Where(x => x.BootcampID == bootcamp.BootcampID).Count() == 0) // Eğer gönderilen bootcamp boş değilse
            {
                bootCampApiController._bootcamps.Add(bootcamp); // Ekleme işlemi yapılır.
            }
            return bootcamp;
        }

        /// <summary>
        /// Bootcamp silme işlemi; Girilen id verisine ait bootcamp var ise silinir.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("DeleteBootcamp/{id}")]
        public int DeleteBootcamp(int id)
        {

            Bootcamp valueDelete = bootCampApiController.GetByID(id); // istenilen id'ye sahip bootcampi getirir.
            if (valueDelete != null)  // istenilen id ile ilgili veri, veri listesinde varsa eğer.
            {
                bootCampApiController._bootcamps.Remove(valueDelete); // request edilen id'ye sahip veri silinir.
                return 1;
            }
            return 0;
           
        }

        /// <summary>
        /// Gönderilen id bilgisine ait kullanıcı var ise durumu onaylanır.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("ConfirmMember/{id}")]
        public int ConfirmMember(int id) 
        {


            BootcampMembers member = BootCampApiController.members.Where(x => x.BootcampMembersID == id).FirstOrDefault(); // Gönderilen id ye sahip katılımcıyı varsa eğer getirir.

            if (member != null)
            {
                
                member.Status = true; // Katılımcının durumunu pasiften aktife geçirir.
                return 1;

            }
            return 0;
        }


        /// <summary>
        /// Gönderilen id bilgisine ait katılımcı var ise katılımcı silinir.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteMember/{id}")]
        public int DeleteMember(int id)
        {


            BootcampMembers member = BootCampApiController.members.Where(x => x.BootcampMembersID == id).FirstOrDefault(); // request edilen id ye sahip kullanıcı varsa eğer getirir.

            if (member != null)
            {

                BootCampApiController.members.Remove(member); // Eğer id ile eşleşen  Kullanıcı varsa sistemden silinir.
                return 1;

            }
            return 0;
        }

        /// <summary>
        /// Tüm katılımcıları listeler.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<BootcampMembers> GetBootcampMembers()  // Kullanıcı listesini döndürür.
        {
        
            return BootCampApiController.members;

        }

    }
}
