using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Entities
{
    public class BookEntity
    {
        // По факту, це теж саме, що і просто Book,
        // але просто без всяких помилок і логіки,
        // вона нам тут не потрібна

        //Типу тут не буде користуватися цим юзер, тому нам можна
        // поставити тут типу set, можна за це не переживати

        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
