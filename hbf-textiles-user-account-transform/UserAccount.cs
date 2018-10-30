using LINQtoCSV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hbf_textiles_user_account_transform
{
    public class UserAccount
    {
        [CsvColumn(FieldIndex = 1)]
        public string Id { get; set; }
        [CsvColumn(FieldIndex = 2)]
        public string Email { get; set; }
        [CsvColumn(FieldIndex = 3)]
        public string FirstName { get; set; }
        [CsvColumn(FieldIndex = 4)]
        public string LastName { get; set; }
        [CsvColumn(FieldIndex = 5)]
        public string SecurityQuestion { get; set; }
        [CsvColumn(FieldIndex = 6)]
        public string Company { get; set; }
        [CsvColumn(FieldIndex = 7)]
        public string Country { get; set; }
        [CsvColumn(FieldIndex = 8)]
        public string Address { get; set; }
        [CsvColumn(FieldIndex = 9)]
        public string Address2 { get; set; }
        [CsvColumn(FieldIndex = 10)]
        public string City { get; set; }
        [CsvColumn(FieldIndex = 11)]
        public string State { get; set; }
        [CsvColumn(FieldIndex = 12)]
        public string ZipCode { get; set; }
        [CsvColumn(FieldIndex = 13, OutputFormat ="S")]
        public string Telephone { get; set; }
        [CsvColumn(FieldIndex = 14)]
        public string Role { get; set; }
        [CsvColumn(FieldIndex = 15)]
        public bool Residence { get; set; }
        [CsvColumn(FieldIndex = 16)]
        public bool ReceiveCommunication { get; set; }
        [CsvColumn(FieldIndex = 17)]
        public bool ContactMe { get; set; }
    }
}
