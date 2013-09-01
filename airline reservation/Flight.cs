using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace airline_reservation
{
    class Flight
    {
        public string id { get; set; }
        public string start { get; set; }
        public string destination { get; set; }

        public List<Seat> seats { get; set; }

        public Flight(string id = "n/a", string start = "Hamburg", string destination = "Frankfurt", List<Seat> seats = null)
        {
            this.id = id;
            this.start = start;
            this.destination = destination;
            if (seats != null)
            {
                this.seats = seats;
            }
            else
            {
                this.seats = new List<Seat>();
            }
        }

        public ListViewItem toListViewItem()
        {
            return new ListViewItem(new string[] { id, start, destination });
        }
    }

    class Seat
    {
        public int id { get; set; }
        public Helper.SeatClass quality { get; set; }
        public decimal price { get; set; }
        public bool taken { get; set; }

        public Seat(int id = 0, Helper.SeatClass quality = Helper.SeatClass.ThirdClass, decimal price = 5M, bool taken = false)
        {
            this.id = id;
            this.quality = quality;
            this.price = price;
            this.taken = taken;
        }
    }
}
