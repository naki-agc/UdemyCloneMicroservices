using FreeCourse.Services.Order.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCourse.Services.Order.Domain.OrderAggregate
{
    public class Address:ValueObject //Value object çünkü idsi yok
    {
        //private set ettim stateleri değiştirmesin dışarıdan kimse
        public string Province { get; private set; }
        public string District { get; private set; }
        public string Street { get; private set; }
        public string ZipCode { get; private set; }
        public string Line { get; private set; }


        //yukarıda private dedik edemezsiniz bunun için aşağıdaki constructer kullandık
        // aşağıda set edicez işte bu sayede
        public Address(string province, string district, string street, string zipCode, string line)
        {
            Province = province;
            District = district;
            Street = street;
            ZipCode = zipCode;
            Line = line;
        }

        public void SetZipCode(string zipCode)
        {
            //bussines code
            ZipCode = zipCode;
        }


        //yield yazarız çünkü hem return yapar hem de dizi döndürür koleksiyon döndürür
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Province;  
            yield return District; 
            yield return Street; 
            yield return ZipCode;
            yield return Line; 
        }
    }
}
