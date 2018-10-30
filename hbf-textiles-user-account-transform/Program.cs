
using LINQtoCSV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace hbf_textiles_user_account_transform
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessProducts();

        
        }

        static void ProcessUserAccounts()
        {
            /*
             INSTRUCTIONS

             Remove name spaces from main tag
             Replace string dt: by empty string in the XML file

             */

            var users = new List<UserAccount>();

            //var path = @"C:\Users\CampanelliA\Desktop\CustomersHBF\CustomersHBF";
            var path = @"C:\Users\CampanelliA\Desktop\CustomersHBF2\CustomersHBF.small.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            foreach (XmlNode node in doc.GetElementsByTagName("customer"))
            {
                var userNode = node.SelectSingleNode("users/user");
                var profileNode = node.SelectSingleNode("users/user/profile");
                var addressNode = node.SelectSingleNode("users/user/profile/addresses/address");
                var credentialsNode = node.SelectSingleNode("users/user/profile/credentials");

                var user = new UserAccount()
                {
                    Id = node.Attributes["id"].Value,
                    FirstName = profileNode.SelectSingleNode("first-name").InnerText,
                    LastName = profileNode.SelectSingleNode("last-name").InnerText,
                    Address = addressNode.SelectSingleNode("street").InnerText,
                    City = addressNode.SelectSingleNode("city").InnerText,
                    Company = (addressNode.SelectSingleNode("company-name") != null) ? addressNode.SelectSingleNode("company-name").InnerText : "",
                    State = (addressNode.SelectSingleNode("state") != null) ? addressNode.SelectSingleNode("state").InnerText : "",
                    Country = (addressNode.SelectSingleNode("company-name") != null) ? addressNode.SelectSingleNode("country-code").InnerText : "",
                    Telephone = (addressNode.SelectSingleNode("phone-business") != null) ? addressNode.SelectSingleNode("phone-business").InnerText : "",
                    Email = (profileNode.SelectSingleNode("email") != null) ? profileNode.SelectSingleNode("email").InnerText : "",
                    SecurityQuestion = (credentialsNode.SelectSingleNode("security-question") != null) ? credentialsNode.SelectSingleNode("security-question").InnerText : "",
                    ZipCode = (addressNode.SelectSingleNode("postal-code") != null) ? addressNode.SelectSingleNode("postal-code").InnerText : "",

                };

                users.Add(user);
            }

            CsvFileDescription outputFileDescription = new CsvFileDescription
            {
                SeparatorChar = ';', 
                FirstLineHasColumnNames = true, 
                FileCultureName = "en-US", // text format
                QuoteAllFields = true
            };

            CsvContext cc = new CsvContext();

            cc.Write(
                users,
                "users.csv",
                outputFileDescription);
        }

        static void ProcessProducts()
        {
            ProcessPatterns();
            ProcessColors();
        }

        static void ProcessPatterns()
        {

            /*
             INSTRUCTIONS

             Remove name spaces from main tag
             Replace string dt: by empty string in the XML file

             */

            var innerFieldSeparator = "|";
            var patterns = new List<Pattern>();

            var path = @"C:\Work\onedrive\OneDrive - HNI Corporation\hbf-textiles\product-data\products-export-small.xml";
            XmlDocument doc = new XmlDocument();
            
            doc.Load(path);
            foreach (XmlNode node in doc.GetElementsByTagName("offer"))
            {
                try
                {
                    var sku = node.Attributes["sku"].Value;
                    var categories = new List<string>();
                    var colorFamilies = new List<string>();
                    var patternTypes = new List<string>();
                    var priceFacets = new List<string>();
                    var sustainabilityFacets = new List<string>();
                    var collectionSynonyms = new List<string>();
                    var contentSynonyms = new List<string>();
                    var newSynonyms = new List<string>();
                    var sustainabilitySynonyms = new List<string>();
                    var abrasionFacets = new List<string>();
                    var finishFacets = new List<string>();

                    if (sku.ToLower().Contains("master"))
                    {
                        var imageNodes = node.SelectSingleNode("images/image-ref");
                        var listPriceNode = node.SelectSingleNode("product-list-prices/product-list-price");
                        var collectionName = node.SelectSingleNode("custom-attributes/custom-attribute[@name='CollectionName']");
                        var content = node.SelectSingleNode("custom-attributes/custom-attribute[@name='Content']");
                        var colorWayNode = node.SelectSingleNode("custom-attributes/custom-attribute[@name='ColorWay']");
                        var categoryNodes = node.SelectSingleNode("custom-attributes/custom-attribute[@name='Application']");
                        var designer = node.SelectSingleNode("custom-attributes/custom-attribute[@name='DesignerName']");
                        var flameResistance = node.SelectSingleNode("custom-attributes/custom-attribute[@name='FlameResistance']");
                        var grade = node.SelectSingleNode("custom-attributes/custom-attribute[@name='Grade']");
                        var notes = node.SelectSingleNode("custom-attributes/custom-attribute[@name='Notes']");
                        var origin = node.SelectSingleNode("custom-attributes/custom-attribute[@name='Origin']");
                        var packingUnit = node.SelectSingleNode("custom-attributes/custom-attribute[@name='PackingUnit']");
                        var patternNodes = node.SelectSingleNode("custom-attributes/custom-attribute[@name='Pattern']");
                        var performanceFacet = node.SelectSingleNode("custom-attributes/custom-attribute[@name='PerformanceFacet']");
                        var price = node.SelectSingleNode("custom-attributes/custom-attribute[@name='Price']");
                        var priceFacet = node.SelectSingleNode("custom-attributes/custom-attribute[@name='PriceFacet']");
                        var repeat = node.SelectSingleNode("custom-attributes/custom-attribute[@name='Repeat']");
                        var sampleSize = node.SelectSingleNode("custom-attributes/custom-attribute[@name='SampleSize']");
                        var sustainability = node.SelectSingleNode("custom-attributes/custom-attribute[@name='Sustainability']");
                        var sustainabilityFacet = node.SelectSingleNode("custom-attributes/custom-attribute[@name='SustainabilityFacet']");
                        var sustainabilityPdf = node.SelectSingleNode("custom-attributes/custom-attribute[@name='SustainabilityPdf']");
                        var synonymForCollectionName = node.SelectSingleNode("custom-attributes/custom-attribute[@name='SynonymForCollectionName']");
                        var synonymForContent = node.SelectSingleNode("custom-attributes/custom-attribute[@name='SynonymForContent']");
                        var synonymForNew = node.SelectSingleNode("custom-attributes/custom-attribute[@name='SynonymForNew']");
                        var synonymForSustainability = node.SelectSingleNode("custom-attributes/custom-attribute[@name='SynonymForSustainability']");
                        var weight = node.SelectSingleNode("custom-attributes/custom-attribute[@name='WEIGHT']");
                        var width = node.SelectSingleNode("custom-attributes/custom-attribute[@name='Width']");
                        var abrasion = node.SelectSingleNode("custom-attributes/custom-attribute[@name='Abrasion']");
                        var abrasionFacet = node.SelectSingleNode("custom-attributes/custom-attribute[@name='AbrasionFacet']");
                        var actRegisteredCertification = node.SelectSingleNode("custom-attributes/custom-attribute[@name='ActRegisteredCertification']");
                        var applicationDetail = node.SelectSingleNode("custom-attributes/custom-attribute[@name='ApplicationDetail']");
                        var averageHide = node.SelectSingleNode("custom-attributes/custom-attribute[@name='AverageHide']");
                        var averageThickness = node.SelectSingleNode("custom-attributes/custom-attribute[@name='AVERAGETHICKNESS']");
                        var backing = node.SelectSingleNode("custom-attributes/custom-attribute[@name='Backing']");
                        var colorfastnesstoLightCertificationMark = node.SelectSingleNode("custom-attributes/custom-attribute[@name='ColorfastnesstoLightCertificationMark']");
                        var finish = node.SelectSingleNode("custom-attributes/custom-attribute[@name='Finish']");
                        var finishFacet = node.SelectSingleNode("custom-attributes/custom-attribute[@name='FinishFacet']");
                        var flammabilityCertificationMark = node.SelectSingleNode("custom-attributes/custom-attribute[@name='FlammabilityCertificationMark']");
                        var heavyDutyAbrasionCertificationMark = node.SelectSingleNode("custom-attributes/custom-attribute[@name='HeavyDutyAbrasionCertificationMark']");
                        var maintenance = node.SelectSingleNode("custom-attributes/custom-attribute[@name='Maintenance']");
                        var maintenancePdf = node.SelectSingleNode("custom-attributes/custom-attribute[@name='MaintenancePdf']");
                        var physicalPropertiesCertificationMark = node.SelectSingleNode("custom-attributes/custom-attribute[@name='PhysicalPropertiesCertificationMark']");
                        var wetDryCrockingCertificationMark = node.SelectSingleNode("custom-attributes/custom-attribute[@name='WetDryCrockingCertificationMark']");

                        if (categoryNodes != null)
                        {
                            foreach (XmlNode category in categoryNodes.ChildNodes)
                            {
                                categories.Add(category.InnerText);
                            }
                        }

                        if (colorWayNode != null)
                        {
                            foreach (XmlNode color in colorWayNode.ChildNodes)
                            {
                                colorFamilies.Add(color.InnerText);
                            }
                        }

                        if (patternNodes != null)
                        {
                            foreach (XmlNode patternType in patternNodes.ChildNodes)
                            {
                                patternTypes.Add(patternType.InnerText);
                            }
                        }

                        if (priceFacet != null)
                        {
                            foreach (XmlNode priceValue in priceFacet.ChildNodes)
                            {
                                priceFacets.Add(priceValue.InnerText);
                            }
                        }

                        if (sustainabilityFacet != null)
                        {
                            foreach (XmlNode sustainabilityValue in sustainabilityFacet.ChildNodes)
                            {
                                sustainabilityFacets.Add(sustainabilityValue.InnerText);
                            }
                        }

                        if (synonymForCollectionName != null)
                        {
                            foreach (XmlNode synonym in synonymForCollectionName.ChildNodes)
                            {
                                collectionSynonyms.Add(synonym.InnerText);
                            }
                        }

                        if (synonymForNew != null)
                        {
                            foreach (XmlNode synonym in synonymForNew.ChildNodes)
                            {
                                newSynonyms.Add(synonym.InnerText);
                            }
                        }

                        if (synonymForSustainability != null)
                        {
                            foreach (XmlNode synonym in synonymForSustainability.ChildNodes)
                            {
                                sustainabilitySynonyms.Add(synonym.InnerText);
                            }
                        }

                        if (abrasionFacet != null)
                        {
                            foreach (XmlNode value in abrasionFacet.ChildNodes)
                            {
                                abrasionFacets.Add(value.InnerText);
                            }
                        }

                        if (finishFacet != null)
                        {
                            foreach (XmlNode value in finishFacet.ChildNodes)
                            {
                                finishFacets.Add(value.InnerText);
                            }
                        }

                        var pattern = new Pattern()
                        {
                            PatternNumber = sku,
                            PatternName = (node.SelectSingleNode("name") != null) ? node.SelectSingleNode("name").InnerText : "",
                            Application = (categories.Count > 0) ? String.Join(innerFieldSeparator, categories.ToArray()) : "",
                            CollectionName = (collectionName != null) ? collectionName.InnerText: "", 
                            ColorWay = (colorFamilies.Count > 0) ? String.Join(innerFieldSeparator, colorFamilies.ToArray()) : "",
                            Content = (content != null) ? content.InnerText : "",
                            Designer = (designer != null) ? designer.InnerText : "",
                            Facts = "", 
                            FlameResistance = (flameResistance != null) ? flameResistance.InnerText : "",
                            Grade = (grade != null) ? grade.InnerText : "",
                            Notes = (notes != null) ? notes.InnerText : "",
                            Origin = (origin != null) ? origin.InnerText : "",
                            PackingUnit = (packingUnit != null) ? packingUnit.InnerText : "",
                            PatternType = (patternTypes.Count > 0) ? String.Join(innerFieldSeparator, patternTypes.ToArray()) : "",
                            Performance = (performanceFacet != null) ? performanceFacet.InnerText : "",
                            PerformanceFacet = (performanceFacet != null) ? performanceFacet.InnerText : "",
                            Price = (price != null) ? price.InnerText : "",
                            PriceFacet = (priceFacets.Count > 0) ? String.Join(innerFieldSeparator, priceFacets.ToArray()) : "",
                            Repeat = (repeat != null) ? repeat.InnerText : "",
                            SampleSize = (sampleSize != null) ? sampleSize.InnerText : "",
                            Sustainability = (sustainability != null) ? sustainability.InnerText : "",
                            SustainabilityFacet = (sustainabilityFacets.Count > 0) ? String.Join(innerFieldSeparator, sustainabilityFacets.ToArray()) : "",
                            SustainabilityPdf = (sustainabilityPdf != null) ? sustainabilityPdf.InnerText : "",
                            SynonymForCollectionName = (collectionSynonyms.Count > 0) ? String.Join(innerFieldSeparator, collectionSynonyms.ToArray()) : "",
                            SynonymForContent = (contentSynonyms.Count > 0) ? String.Join(innerFieldSeparator, contentSynonyms.ToArray()) : "",
                            SynonymforNew = (newSynonyms.Count > 0) ? String.Join(innerFieldSeparator, newSynonyms.ToArray()) : "",
                            SynonymForSustainability = (sustainabilitySynonyms.Count > 0) ? String.Join(innerFieldSeparator, sustainabilitySynonyms.ToArray()) : "",
                            Weight = (weight != null) ? weight.InnerText : "",
                            Width = (width != null) ? width.InnerText : "",
                            Abrasion = (abrasion != null) ? abrasion.InnerText : "",
                            AbrasionFacet = (abrasionFacets.Count > 0) ? String.Join(innerFieldSeparator, abrasionFacets.ToArray()) : "",
                            ActRegisteredCertification = (actRegisteredCertification != null) ? actRegisteredCertification.InnerText : "",
                            ApplicationDetail = (applicationDetail != null) ? applicationDetail.InnerText : "",
                            AverageHide = (averageHide != null) ? averageHide.InnerText : "",
                            AverageThickness = (averageThickness != null) ? averageThickness.InnerText : "",
                            Backing = (backing != null) ? backing.InnerText : "",
                            ColorfastnesstoLightCertificationMark = (colorfastnesstoLightCertificationMark != null) ? colorfastnesstoLightCertificationMark.InnerText : "",
                            Finish = (finish != null) ? finish.InnerText : "",
                            FinishFacet = (finishFacets.Count > 0) ? String.Join(innerFieldSeparator, finishFacets.ToArray()) : "",
                            FlammabilityCertificationMark = (flammabilityCertificationMark != null) ? flammabilityCertificationMark.InnerText : "",
                            HeavyDutyAbrasionCertificationMark = (heavyDutyAbrasionCertificationMark != null) ? heavyDutyAbrasionCertificationMark.InnerText : "",
                            Maintenance = (maintenance != null) ? maintenance.InnerText : "",
                            MaintenancePdf = (maintenancePdf != null) ? maintenancePdf.InnerText : "",
                            MasterPatternImage = "true", 
                            PhysicalPropertiesCertificationMark = (physicalPropertiesCertificationMark != null) ? physicalPropertiesCertificationMark.InnerText : "",
                            WetDryCrockingCertificationMark = (wetDryCrockingCertificationMark != null) ? wetDryCrockingCertificationMark.InnerText : "",
 

                        };

                        patterns.Add(pattern);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("Error processing product: {0}", node.InnerXml));
                    Console.WriteLine(ex.ToString());
                }
            }

           CsvFileDescription outputFileDescription = new CsvFileDescription
            {
                SeparatorChar = ',', 
                FirstLineHasColumnNames = true, 
                FileCultureName = "en-US", // text format
                QuoteAllFields = true
            };

            CsvContext cc = new CsvContext();

            cc.Write(
                patterns,
                "patterns.csv",
                outputFileDescription);
        }

        static void ProcessColors()
        {
            /*
             INSTRUCTIONS

             Remove name spaces from main tag
             Replace string dt: by empty string in the XML file

             */

            var innerFieldSeparator = "|";
            var colors = new List<Color>();

            var path = @"C:\Work\onedrive\OneDrive - HNI Corporation\hbf-textiles\product-data\products-export-small.xml";
            XmlDocument doc = new XmlDocument();

            doc.Load(path);
            foreach (XmlNode node in doc.GetElementsByTagName("offer"))
            {
                try
                {
                    var sku = node.Attributes["sku"].Value;
                    var patternName = "";
                    var categories = new List<string>();
                    var colorFamilies = new List<string>();
                    var patternTypes = new List<string>();
                    var priceFacets = new List<string>();
                    var colorSynonyms = new List<string>();
                    var colorNameSynonyms = new List<string>();

                    var sustainabilityFacets = new List<string>();
                    var collectionSynonyms = new List<string>();
                    var contentSynonyms = new List<string>();
                    var newSynonyms = new List<string>();
                    var sustainabilitySynonyms = new List<string>();

                    if (!sku.ToLower().Contains("master"))
                    {
                        var patternArray = sku.Split("-".ToCharArray());
                        patternName = patternArray[0] + "-Master";

                        var colorWayNode = node.SelectSingleNode("custom-attributes/custom-attribute[@name='ColorWay']");
                        var designer = node.SelectSingleNode("custom-attributes/custom-attribute[@name='Designer']");
                        var synonymForColorName = node.SelectSingleNode("custom-attributes/custom-attribute[@name='SynonymForColorName']");
                        var colorName = node.SelectSingleNode("custom-attributes/custom-attribute[@name='ColorName']");
                        var synonymForColor = node.SelectSingleNode("custom-attributes/custom-attribute[@name='SynonymForColor']");
                        var swatchImage = node.SelectSingleNode("custom-attributes/custom-attribute[@name='SwatchImage']");

                        if (colorWayNode != null)
                        {
                            foreach (XmlNode colorWay in colorWayNode.ChildNodes)
                            {
                                colorFamilies.Add(colorWay.InnerText);
                            }
                        }

                        if (synonymForColorName != null)
                        {
                            foreach (XmlNode value in synonymForColorName)
                            {
                                colorNameSynonyms.Add(colorName.InnerText);
                            }
                        }

                        if (synonymForColor != null)
                        {
                            foreach (XmlNode value in synonymForColor)
                            {
                                colorSynonyms.Add(colorName.InnerText);
                            }
                        }
                        
                        var color = new Color()
                        {
                            ColorFamily = (colorFamilies.Count > 0) ? String.Join(innerFieldSeparator, colorFamilies.ToArray()) : "",
                            ColorName = (colorName != null) ? colorName.InnerText : "",
                            ColorNumber = sku, 
                            //DesignerName = (designer != null) ? designer.InnerText : "",
                            SwatchImage = (swatchImage != null) ? swatchImage.InnerText : "",
                            SynonymForColor = (colorSynonyms.Count > 0) ? String.Join(innerFieldSeparator, colorSynonyms.ToArray()) : "",
                            SynonymForColorName = (colorNameSynonyms.Count > 0) ? String.Join(innerFieldSeparator, colorNameSynonyms.ToArray()) : "",
                            PatternName = patternName,
                        };

                        colors.Add(color);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("Error processing product: {0}", node.InnerXml));
                    Console.WriteLine(ex.ToString());
                }
            }

            CsvFileDescription outputFileDescription = new CsvFileDescription
            {
                SeparatorChar = ',',
                FirstLineHasColumnNames = true,
                FileCultureName = "en-US", // text format
                QuoteAllFields = true
            };

            CsvContext cc = new CsvContext();

            cc.Write(
                colors,
                "colors.csv",
                outputFileDescription);
        }
    }

    
}
