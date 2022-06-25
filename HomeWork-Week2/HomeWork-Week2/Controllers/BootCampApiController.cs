using HomeWork_Week2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork_Week2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BootCampApiController : ControllerBase
    {


        
        public List<Bootcamp> _bootcamps = FakeData.FakeData.GetBootcamp(100); // 100 adet bootcamp fake datası oluşturma kodu.

        public List<Bootcamp> _BootCamps
        {
            get
            {
                return _bootcamps;
            }
            set
            {
                _bootcamps.Add(value.FirstOrDefault());
            }
        }

        public static List<BootcampMembers> members = new List<BootcampMembers>(); // Static olarak bootcamp katılımcıları nesnesi.
         



        /// <summary>
        /// Bootcamp Listele Aktif için True, Pasif için False.
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpGet] //Get metodu ile true ve false olarak bootcamp durumunun aktifliğini ve pasifliğini sorgulayacak kod bloğu.
        [Route("GetByStatus/{status}")] // Route yapılandırması. True veya false alacak şekilde.
        public List<Bootcamp> GetByStatus(bool status)
        {
            if (status == true)
            {
                List<Bootcamp> bootcamp = _bootcamps.Where(x => x.BootcampStatus == true).ToList(); // Aktif olanları listeleme kodu.
                return bootcamp;
            }
            else
            {
                List<Bootcamp> bootcamp = _bootcamps.Where(x => x.BootcampStatus == false).ToList(); // Pasif olanları listeleme kodu.
                return bootcamp;
            }

        }

        /// <summary>
        /// Girilen id bilgisine ait Bootcamp var iste Bootcamp'in bilgisini getirir.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetByID/{id}")] // Bootcamp listesinden id ile istenilen bootcamp'i getirecek olan kod bloğu.
        public Bootcamp GetByID(int id)
        {
            Bootcamp selectedBootcamp = _bootcamps.Where(x => x.BootcampID == id).FirstOrDefault(); // Katılımcı request edilen id ile getirilir.
            return selectedBootcamp;
        }



        /// <summary>
        /// Bootcamp'e bootcampMembers türünde veriler post edilerek katılım işlemi gerçekleştirir.
        /// </summary>
        /// <param name="bootcampMembers"></param>
        /// <returns></returns>
        [HttpPost] // Bootcamp'e katılacak kişilerin bilgilerini post edeceği kod bloğu.
        public BootcampMembers Join([FromBody] BootcampMembers bootcampMembers) // Katılımcı türünde veri beklemektedir.
        {
            
            if (bootcampMembers != null && members.Where(x => x.BootcampMembersID == bootcampMembers.BootcampMembersID).Count() == 0)
            {
                bootcampMembers.Status = false; //Katılımcı ilk kayıt bilgilerini gönderdiğinde sisteme pasif olarak kaydedilir.
                members.Add(bootcampMembers); // Katılımcı sisteme eklenir.
              
            }
            return bootcampMembers;
        }



    }
}
