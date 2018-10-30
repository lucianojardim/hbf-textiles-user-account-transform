using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQtoCSV;

namespace hbf_textiles_user_account_transform
{
    public class Pattern
    {
        [CsvColumn(FieldIndex = 1)]
        public string PatternNumber { get; set; }
        [CsvColumn(FieldIndex = 2)]
        public string PatternName { get; set; }
        [CsvColumn(FieldIndex = 3)]
        public string MasterPatternImage { get; set; }
        [CsvColumn(FieldIndex = 4)]
        public string Price { get; set; }
        [CsvColumn(FieldIndex = 5)]
        public string PriceFacet { get; set; }
        [CsvColumn(FieldIndex = 6)]
        public string Grade { get; set; }
        [CsvColumn(FieldIndex = 7)]
        public string CollectionName { get; set; }
        [CsvColumn(FieldIndex = 8)]
        public string Designer { get; set; }
        [CsvColumn(FieldIndex = 9)]
        public string ColorWay { get; set; }
        [CsvColumn(FieldIndex = 10, Name = "Pattern")]
        public string PatternType { get; set; }
        [CsvColumn(FieldIndex = 11)]
        public string ActRegisteredCertification { get; set; }
        [CsvColumn(FieldIndex = 12)]
        public string ColorfastnesstoLightCertificationMark { get; set; }
        [CsvColumn(FieldIndex = 13)]
        public string FlammabilityCertificationMark { get; set; }
        [CsvColumn(FieldIndex = 14)]
        public string HeavyDutyAbrasionCertificationMark { get; set; }
        [CsvColumn(FieldIndex = 15)]
        public string PhysicalPropertiesCertificationMark { get; set; }
        [CsvColumn(FieldIndex = 16)]
        public string WetDryCrockingCertificationMark { get; set; }
        [CsvColumn(FieldIndex = 17)]
        public string Abrasion { get; set; }
        [CsvColumn(FieldIndex = 18)]
        public string AbrasionFacet { get; set; }
        [CsvColumn(FieldIndex = 19)]
        public string Application { get; set; }
        [CsvColumn(FieldIndex = 20)]
        public string ApplicationDetail { get; set; }
        [CsvColumn(FieldIndex = 21)]
        public string Finish { get; set; }
        [CsvColumn(FieldIndex = 22)]
        public string FinishFacet { get; set; }
        [CsvColumn(FieldIndex = 23)]
        public string Maintenance { get; set; }
        [CsvColumn(FieldIndex = 24)]
        public string MaintenancePdf { get; set; }
        [CsvColumn(FieldIndex = 25)]
        public string AverageHide { get; set; }
        [CsvColumn(FieldIndex = 26)]
        public string AverageThickness { get; set; }
        [CsvColumn(FieldIndex = 27)]
        public string Backing { get; set; }
        [CsvColumn(FieldIndex = 28)]
        public string Content { get; set; }
        [CsvColumn(FieldIndex = 29)]
        public string Performance { get; set; }
        [CsvColumn(FieldIndex = 30)]
        public string PerformanceFacet { get; set; }
        [CsvColumn(FieldIndex = 31)]
        public string Sustainability { get; set; }
        [CsvColumn(FieldIndex = 32)]
        public string SustainabilityFacet { get; set; }
        [CsvColumn(FieldIndex = 33)]
        public string SustainabilityPdf { get; set; }
        [CsvColumn(FieldIndex = 34)]
        public string Facts { get; set; }
        [CsvColumn(FieldIndex = 35)]
        public string Origin { get; set; }
        [CsvColumn(FieldIndex = 36)]
        public string PackingUnit { get; set; }
        [CsvColumn(FieldIndex = 37)]
        public string SynonymForCollectionName { get; set; }
        [CsvColumn(FieldIndex = 38)]
        public string SynonymForContent { get; set; }
        [CsvColumn(FieldIndex = 39)]
        public string SynonymforNew { get; set; }
        [CsvColumn(FieldIndex = 40)]
        public string SynonymForSustainability { get; set; }
        [CsvColumn(FieldIndex = 41)]
        public string FlameResistance { get; set; }
        [CsvColumn(FieldIndex = 42)]
        public string Repeat { get; set; }
        [CsvColumn(FieldIndex = 43)]
        public string Weight { get; set; }
        [CsvColumn(FieldIndex = 44)]
        public string Width { get; set; }
        [CsvColumn(FieldIndex = 45)]
        public string Notes { get; set; }
        [CsvColumn(FieldIndex = 46)]
        public string SampleSize { get; set; }


    }
}
