using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQtoCSV;

namespace hbf_textiles_user_account_transform
{
    public class Color
    {
        [CsvColumn(FieldIndex = 1)]
        public string ColorNumber { get; set; }
        [CsvColumn(FieldIndex = 2)]
        public string ColorName { get; set; }
        [CsvColumn(FieldIndex = 3)]
        public string SwatchImage { get; set; }
        [CsvColumn(FieldIndex = 4)]
        public string DesignerName { get; set; }
        [CsvColumn(FieldIndex = 5)]
        public string SynonymForColor { get; set; }
        [CsvColumn(FieldIndex = 6)]
        public string SynonymForColorName { get; set; }
        [CsvColumn(FieldIndex = 7)]
        public string ColorFamily { get; set; }
        [CsvColumn(FieldIndex = 8)]
        public string PatternName { get; set; }
    }
}
