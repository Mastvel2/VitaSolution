using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Vita.App.XML_Entities;

namespace Vita.App
{
    public class XmlExporter
    {
        public static void SavePatientToXml(PatientXML patient, string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(PatientXML));

            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(fs, patient);
            }
        }

        public static void SavePatientsToXml(List<PatientXML> patients, string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<PatientXML>));

            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(fs, patients);
            }
        }
    }
}
