using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Infrastracture.DataModels
{
    public enum RatingScore
    {
        One=0,Two=1,Three=2,Four=3,Five=4
    }
    public class RatingData
    {
        //Rabete beyn ketabha va ratingdata yek be chand ast va bayad rabete ra dar BookData va OrderData niz tarif shavad

        public int BookId { get; set; }

        //Har RatingData ba yek Ketab rabete dare.
        public BookData Book { get; set; }
        public int OrderId { get; set; }
        public OrderData Order { get; set; }
        public RatingScore Score { get; set; }
        public DateTime TimeCreated { get; set; }



        //Dar in class, key tarkibi az 2 key BookId va OrderId hast va nemikhaym key digari tarif konim.
        //Baraye inkar bayad dar ApplicationDbContext Key ra moarefi konim.
    }
}
