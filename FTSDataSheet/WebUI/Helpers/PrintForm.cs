using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Utilities.Extensions;
using System.IO;

namespace WebUI.Helpers
{
    public class PrintForm
    {
        public string DataSheetPrint(string value,DataSheet model,string customerName)
        {
            value = value.Replace("#Firma#", customerName);
            value = value.Replace("#FirmaIlgili#", model.Contact);
            value = value.Replace("#AnaMusteri#", model.MainCustomer);
            value = value.Replace("#Telefon#", model.TelephoneNumber);
            value = value.Replace("#Faks#", model.FaxNumber);
            value = value.Replace("#Email#", model.EmailAddress);
            value = value.Replace("#NumuneTarihi#", model.SampleSentDate.DateStringWithoutTime());
            value = value.Replace("#AnaMusteriModel#", model.MainCustomerSampleNumber);
            value = value.Replace("#Model#", model.SampleNumber);
            value = value.Replace("#KumasTipi#", model.FabricType);
            value = value.Replace("#YKK1#", model.YKKProductCode1);
            value = value.Replace("#YKK2#", model.YKKProductCode2);
            value = value.Replace("#1_#", model.ProductPosition1);
            value = value.Replace("#2_#", model.ProductPosition2);
            value = value.Replace("#3_#", model.ProductPosition2);
            value = value.Replace("#4_#", model.ProductPosition2);
            value = value.Replace("#AnaMusteriIlgili#", model.MainCustomerContact);

            if (model.Department == 1)
            {
                value = value.Replace("#Departman#", "bay");
            }
            else if (model.Department == 2)
            {
                value = value.Replace("#Departman#", "bayan");
            }
            else if (model.Department == 3)
            {
                value = value.Replace("#Departman#", "cocuk");
            }

            return value;
        }
    }
}
