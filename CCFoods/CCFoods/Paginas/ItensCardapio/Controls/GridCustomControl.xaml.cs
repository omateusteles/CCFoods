using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Modulo1.Paginas.ItensCardapio.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GridCustomControl : Grid
    {
        public GridCustomControl()
        {
            InitializeComponent();
        }
    }
}