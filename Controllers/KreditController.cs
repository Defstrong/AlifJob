using arst;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace WebApplication4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KreditController : ControllerBase
    {

        [HttpGet(Name = "Kredit")]

            public string Get(string TipProduct, int Sum, string PhoneNumbers, int Installment)
            {
                int InstallmentPercentage = 0;
                string Product = "Eror";
                if (TipProduct == "Phone")
                {
                    Product = "Phone";
                    InstallmentPercentage = ForInstallment(9, Installment) * 3;
                    InstallmentPercentage = (Sum * InstallmentPercentage) / 100;
                }
                else if (TipProduct == "Komputer")
                {
                    Product = "Komputer";
                    InstallmentPercentage = ForInstallment(12, Installment) * 4;
                    InstallmentPercentage = (Sum * InstallmentPercentage) / 100;
                }
                else if (TipProduct == "TV")
                {
                    Product = "TV";
                    InstallmentPercentage = ForInstallment(18, Installment) * 5;
                    InstallmentPercentage = (Sum * InstallmentPercentage) / 100;
                }
                else return "Eror 404. Produkt it's not found";
                
                return SendMassage(Product, InstallmentPercentage+Sum, Installment);


                int ForInstallment(int RangeStart, int RangeEnd)
                {
                    int Procent = 0;
                    List<int> Ranges = new List<int>(6) { 3, 6, 9, 12, 18, 24 };
                    for (int i = 0; i < Ranges.Count; i++)
                    {
                        if (Ranges[i] > RangeStart)
                            Procent++;
                        if (Ranges[i] == RangeEnd) break;
                    }
                    return Procent;
                }
                string SendMassage(string TipProduct, int Sum, int Installment)
                {
                    return $"Your product: {Product}\nInstallment duration: {Installment}\nTotal amount: {Sum} smn\n";
                }
            }
    }
}
