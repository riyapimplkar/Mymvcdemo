using Mymvcdemo.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mymvcdemo.Models
{
    public class mvcdemoModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mobile_No { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int srno { get; set; }

        public string Savereg(mvcdemoModel model)
        {
            string msg = "Save";

            MvcdemoEntities Db = new MvcdemoEntities();
            var reg = Db.tblRegistrations.Where(p => p.Id == model.Id).FirstOrDefault();

            if (model.Id == 0)
            {

                var regData = new tblRegistration()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Mobile_No = model.Mobile_No,
                    Email = model.Email,
                    Address = model.Address,
                };
                Db.tblRegistrations.Add(regData);
                Db.SaveChanges();

            }
            else
            {
                reg.Id = model.Id;
                reg.Name = model.Name;
                reg.Mobile_No = model.Mobile_No;
                reg.Email = model.Email;
                reg.Address = model.Address;
                Db.SaveChanges();
                msg = "update successfully";
            }

            return msg;

        }

        public List<mvcdemoModel> GetRegistrationList()
        {
            MvcdemoEntities Db = new MvcdemoEntities();
            List<mvcdemoModel> lstRegistration = new List<mvcdemoModel>();
            var AddRegistrationList = Db.tblRegistrations.ToList();
            int srno = 1;
            if (AddRegistrationList != null)
            {
                foreach (var registration in AddRegistrationList)
                {
                    lstRegistration.Add(new mvcdemoModel()
                    {
                        srno = srno,
                        Id = registration.Id,
                        Name = registration.Name,
                        Mobile_No = registration.Mobile_No,
                        Email = registration.Email,
                        Address = registration.Address,


                    });
                    srno++;
                }
            }
            return lstRegistration;
        }

        public string deleteRegistration(int Id)
        {
            var msg = "delete successfull";
            MvcdemoEntities Db = new MvcdemoEntities();
            var data = Db.tblRegistrations.Where(p => p.Id == Id).FirstOrDefault();
            if (data != null)
            {
                Db.tblRegistrations.Remove(data);
                Db.SaveChanges();

            }
            return msg;
        }

        public mvcdemoModel getRegisterbyID(int Id)
        {
            mvcdemoModel model = new mvcdemoModel();
            MvcdemoEntities Db = new MvcdemoEntities();
            var data = Db.tblRegistrations.Where(p => p.Id == Id).FirstOrDefault();
            if (data != null)
            {
                model.Id = data.Id;
                model.Name = data.Name;
                model.Mobile_No = data.Mobile_No;
                model.Email = data.Email;
                model.Address = data.Address;

            }
            return model;
        }
    }
}