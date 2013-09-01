using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace airline_reservation
{
    public partial class airlineForm : Form
    {
        List<Flight> flights;
        List<Seat> seats;
        List<Seat> seats2;

        public airlineForm()
        {
            InitializeComponent();
            flights = new List<Flight>();
            seats = new List<Seat>();
            seats2 = new List<Seat>();
            for (int i = 0; i < 10; i++)
            {
                seats.Add(new Seat(i));
            }
            seats[2].quality = Helper.SeatClass.FirstClass;
            seats[3].quality = Helper.SeatClass.FirstClass;
            seats[7].quality = Helper.SeatClass.SecondClass;
            seats[8].quality = Helper.SeatClass.SecondClass;
            seats[9].quality = Helper.SeatClass.SecondClass;
            for (int i = 0; i < 15; i++)
            {
                seats2.Add(new Seat(i));
            }
            flights.Add(new Flight(id: "#1", seats: seats));
            flights.Add(new Flight(id: "#2", start: "Frankfurt", destination: "Hamburg", seats: seats2));
            foreach (Flight li in flights)
            {
                flightList.Items.Add(li.toListViewItem());
            }
        }

        private void flightSelected(object sender, EventArgs e)
        {
            dbgLabel.Text = "Index changed!";
            if (flightList.SelectedItems.Count > 0)
            {
                ListViewItem li = flightList.SelectedItems[0];
                string fId = li.SubItems[0].Text;
                string fStart = li.SubItems[1].Text;
                string fDest = li.SubItems[2].Text;

                flightDetailIdInput.Text = fId;
                flightDetailStartInput.Text = fStart;
                flightDetailDestinationInput.Text = fDest;

                Flight f = flights.Find(x => x.id.Equals(fId));
                int fClassSeats = f.seats.Where(x => x.quality.Equals(Helper.SeatClass.FirstClass) && !x.taken).Count();
                int sClassSeats = f.seats.Where(x => x.quality.Equals(Helper.SeatClass.SecondClass) && !x.taken).Count();
                int tClassSeats = f.seats.Where(x => x.quality.Equals(Helper.SeatClass.ThirdClass) && !x.taken).Count();

                FlightDetail1stClassInput.Text = fClassSeats.ToString();
                FlightDetail2ndClassInput.Text = sClassSeats.ToString();
                FlightDetail3rdClassInput.Text = tClassSeats.ToString();

                checkBtnEnabled(f);
            }
        }

        private void checkBtnEnabled(Flight f)
        {
            int fClassSeats = f.seats.Where(x => x.quality.Equals(Helper.SeatClass.FirstClass) && !x.taken).Count();
            int sClassSeats = f.seats.Where(x => x.quality.Equals(Helper.SeatClass.SecondClass) && !x.taken).Count();
            int tClassSeats = f.seats.Where(x => x.quality.Equals(Helper.SeatClass.ThirdClass) && !x.taken).Count();

            book1stBtn.Enabled = (fClassSeats > 0);
            book2ndBtn.Enabled = (sClassSeats > 0);
            book3rdBtn.Enabled = (tClassSeats > 0);
        }

        private void book3rdSeat(object sender, EventArgs e)
        {
            bookSeat(Helper.SeatClass.ThirdClass, flightList.SelectedIndices[0]);
        }

        private void book2ndSeat(object sender, EventArgs e)
        {
            bookSeat(Helper.SeatClass.SecondClass, flightList.SelectedIndices[0]);
        }

        private void book1stSeat(object sender, EventArgs e)
        {
            bookSeat(Helper.SeatClass.FirstClass, flightList.SelectedIndices[0]);
        }

        private void bookSeat(Helper.SeatClass seatClass, int listIndex)
        {
            ListViewItem li = flightList.Items[listIndex];
            Flight f = flights.Find(x => x.id.Equals(li.Text));
            Seat s = null;
            switch (seatClass)
            {
                case Helper.SeatClass.FirstClass: 
                    s = f.seats.Find(x => x.quality.Equals(Helper.SeatClass.FirstClass) && !x.taken);
                    s.taken = true;
                    FlightDetail1stClassInput.Text = (f.seats.Where(x => x.quality.Equals(Helper.SeatClass.FirstClass) && !x.taken).Count()).ToString();
                    break;
                case Helper.SeatClass.SecondClass:
                    s = f.seats.Find(x => x.quality.Equals(Helper.SeatClass.SecondClass) && !x.taken);
                    s.taken = true;
                    FlightDetail2ndClassInput.Text = (f.seats.Where(x => x.quality.Equals(Helper.SeatClass.SecondClass) && !x.taken).Count()).ToString();
                    break;
                case Helper.SeatClass.ThirdClass:
                    s = f.seats.Find(x => x.quality.Equals(Helper.SeatClass.ThirdClass) && !x.taken);
                    s.taken = true;
                    FlightDetail3rdClassInput.Text = (f.seats.Where(x => x.quality.Equals(Helper.SeatClass.ThirdClass) && !x.taken).Count()).ToString();
                    break;
            }
            checkBtnEnabled(f);
        }

        private void exit(object sender, EventArgs e)
        {
            Close();
        }
    }
}
