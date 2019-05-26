using Chameleon.Data;
using System.Windows.Forms;

namespace Chameleon
{
    public partial class FormVendas : Form
    {
        public FormVendas()
        {
            InitializeComponent();

            CarregarDados();
        }

        private void CarregarDados()
        {
            var source = new BindingSource();
            var pedidos = PedidoVendaRepository.GetPedidosVenda();
            source.DataSource = pedidos;
            dtVendas.DataSource = source;
        }
    }
}
