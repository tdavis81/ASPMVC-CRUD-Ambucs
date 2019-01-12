using AmbucsProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmbucsProject.Services
{
    public class RecordsService : DatabaseService
    {


        public List<Recipient> GetAllRecords()
        {
            return this.DB.Recipients.OrderBy(x => x.gifted_date).ToList();
        }
        public void saveRecord(string first_name, string last_name, string birthdate, string gifted_date, string phone_number, string address, string city, string state, string zip)
        {
            Recipient record = new Recipient
            {
                first_name = first_name,
                last_name = last_name,
                birthdate = Convert.ToDateTime(birthdate),
                gifted_date = Convert.ToDateTime(gifted_date),
                phone_number = phone_number,
                address = address,
                city = city,
                state = state,
                zip = zip
            };


            this.DB.Recipients.Add(record);
            this.DB.SaveChanges();
        }
        public void updateRecord(int recipient_id, string first_name, string last_name, string birthdate, string gifted_date, string phone_number, string address, string city, string state, string zip)
        {
            var record = this.DB.Recipients.First(t => t.recipient_id == recipient_id);

            record.first_name = first_name;
            record.last_name = last_name;
            record.birthdate = Convert.ToDateTime(birthdate);
            record.gifted_date = Convert.ToDateTime(gifted_date);
            record.phone_number = phone_number;
            record.address = address;
            record.city = city;
            record.state = state;
            record.zip = zip;

            this.DB.SaveChanges();

        }

        public void deleteRecord(int id)
        {
            var record = this.DB.Recipients.First(t => t.recipient_id == id);

            this.DB.Recipients.Remove(record);
            this.DB.SaveChanges();
        }
    }
}