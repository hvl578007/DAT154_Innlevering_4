﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ClassLibraryHotel;

namespace DesktopWPFHotel
{
    /// <summary>
    /// Interaction logic for SearchRooms.xaml
    /// </summary>
    public partial class SearchRooms : Window
    {
        public SearchRooms()
        {
            InitializeComponent();
        }

        public SearchRooms(HotelContext hcx)
        {
            InitializeComponent();
        }
    }
}