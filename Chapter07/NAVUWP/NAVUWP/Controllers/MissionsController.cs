using NAVUWP.Models;
using NAVUWP.NAVWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NAVUWP.Controllers
{
    public class MissionsController : ApiController
    {
        [HttpPost]
        public void AddMission(Mission mission)
        {
            //Here we have to call NAV Web Service and pass the Mission data
            //TODO!!
            //string check = mission.Code;
            try
            {
                RegisterMissionTicket WS = new RegisterMissionTicket();
                WS.CallRegisterMissionTicket(mission.Code, mission.Date, mission.Status, mission.Latitude, mission.Longitude, mission.Note);
            }
            catch(Exception)
            {
                //Handle exception here
            }
        }

        [HttpGet]
        public List<Mission> GetMissions()
        {
            //Here we have to call NAV Web Service and pass the Mission data
            List<Mission> list = new List<Mission>();
            Mission m1 = new Mission();
            m1.Code = "M1";
            list.Add(m1);
            return list;
        }

        [HttpGet]
        [ActionName("GetMissionsForUserID")]
        public List<Mission> GetMissions(string UserID)
        {
            //Here we have to call NAV Web Service and pass the Mission data
            List<Mission> list = new List<Mission>();
            Mission m1 = new Mission();
            m1.Code = "NAVLAB Milan";
            m1.Date = DateTime.Now;
            list.Add(m1);

            m1 = new Mission();
            m1.Code = "EID Borgomanero";
            m1.Date = DateTime.Now;
            list.Add(m1);

            m1 = new Mission();
            m1.Code = "Microsoft Italy";
            m1.Date = DateTime.Now;
            list.Add(m1);

            return list;
        }
    }
}
