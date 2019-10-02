using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLib
{
    public class Bog
    {
        private string _titel;
        private string _forfatter;
        private int _sideTal;
        private string _isbn;

        public Bog(string titel, string forfatter, int sideTal, string isbn)
        {
            _titel = titel;
            _forfatter = forfatter;
            _sideTal = sideTal;
            _isbn = isbn;
        }

        public Bog()
        {

        }

        public void TitleLenght(string value)
        {
            if (value.Length < 2)
            {
                throw new ArgumentException("Din titel skal være længere end 2 tegn.");
            }
        }

        public void PageNumber(int value)
        {
            if (value < 10 || value > 1000)
            {
                throw new ArgumentException("Sidetallet skal være mellem 10 og 1000.");
            }
        }

        public void IsbnLenght(string value)
        {
            if (value.Length != 13)
            {
                throw new ArgumentException("Dit ISBN nummer skal være 13 tegn langt");
            }
        }


        public string Titel
        {
            get { return _titel; }
            set
            {
                _titel = value;
                TitleLenght(value);
            }
        }

        public string Forfatter
        {
            get { return _forfatter; }
            set { _forfatter = value; }
        }

        public int SideTal
        {
            get { return _sideTal; }
            set
            {
                _sideTal = value;
                PageNumber(value);
            }
        }

        public string Isbn
        {
            get { return _isbn; }
            set
            {
                _isbn = value;
                IsbnLenght(value);
            }
        }
    }
}